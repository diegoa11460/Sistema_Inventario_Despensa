using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Venta
    {
        // =========================================================
        // PENDIENTE DE CONFIRMAR: este método no se está usando en
        // Form_Ventas.cs (el Ticket se genera como "TK-" + fecha/hora,
        // no con este correlativo). Se deja intacto por ahora; si se
        // confirma que ningún otro formulario lo usa, se puede eliminar
        // junto con su equivalente CN_Venta().ObtenerCorrelativo(),
        // igual que se hizo con CD_Compras.ObtenerCorrelativo().
        // =========================================================
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select count(*) + 1 from VENTA";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 5;

                    oconexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                }
            }

            return idcorrelativo;
        }

        public bool RegistrarVenta(Venta obj, DataTable dtDetalleVenta, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 5;

                    // Parámetros adaptados a tu base de datos real
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("@MetodoPago", obj.MetodoPago);
                    cmd.Parameters.AddWithValue("@MontoRecibido", obj.MontoRecibido);
                    cmd.Parameters.AddWithValue("@MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("@Ticket", obj.Ticket);

                    // Parámetro estructurado (TVP) apuntando al TYPE exacto de SQL
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@DetalleVenta", dtDetalleVenta);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.EDetalle_Venta";

                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return respuesta;
        }

        // =========================================================
        // OBTENER VENTA POR TICKET (Cabecera y Cliente)
        // =========================================================
        public Venta ObtenerVenta(string numero, out string Mensaje)
        {
            Venta obj = new Venta();
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select v.IdVenta, u.NombreCompleto, r.Descripcion [Rol], v.Ticket, v.Estado, ");
                    query.AppendLine("v.MetodoPago, v.MontoRecibido, v.MontoCambio, v.MontoTotal, convert(char(10), v.FechaRegistro, 103)[FechaRegistro], ");
                    query.AppendLine("ISNULL(c.Documento, '0') [DocumentoCliente], ISNULL(c.NombreCompleto, 'Consumidor Final') [NombreCliente]");
                    query.AppendLine("from VENTA v");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = v.IdUsuario");
                    query.AppendLine("inner join ROL r on r.IdRol = u.IdRol");
                    query.AppendLine("left join CLIENTE c on c.IdCliente = v.IdCliente");
                    query.AppendLine("WHERE v.Ticket = @busqueda");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@busqueda", numero);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 5;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Venta()
                            {
                                IdVenta = dr["IdVenta"] != DBNull.Value ? Convert.ToInt32(dr["IdVenta"]) : 0,
                                oUsuario = new Usuario()
                                {
                                    NombreCompleto = dr["NombreCompleto"] != DBNull.Value ? dr["NombreCompleto"].ToString() : "",
                                    oRol = new Rol() { Descripcion = dr["Rol"] != DBNull.Value ? dr["Rol"].ToString() : "" }
                                },
                                oCliente = new Cliente()
                                {
                                    Documento = dr["DocumentoCliente"] != DBNull.Value ? dr["DocumentoCliente"].ToString() : "0",
                                    NombreCompleto = dr["NombreCliente"] != DBNull.Value ? dr["NombreCliente"].ToString() : "Consumidor Final"
                                },
                                Ticket = dr["Ticket"] != DBNull.Value ? dr["Ticket"].ToString() : "",
                                Estado = dr["Estado"] != DBNull.Value ? dr["Estado"].ToString() : "",
                                MetodoPago = dr["MetodoPago"] != DBNull.Value ? dr["MetodoPago"].ToString() : "",
                                MontoRecibido = dr["MontoRecibido"] != DBNull.Value ? Convert.ToDecimal(dr["MontoRecibido"]) : 0,
                                MontoCambio = dr["MontoCambio"] != DBNull.Value ? Convert.ToDecimal(dr["MontoCambio"]) : 0,
                                MontoTotal = dr["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(dr["MontoTotal"]) : 0,
                                FechaRegistro = dr["FechaRegistro"] != DBNull.Value ? dr["FechaRegistro"].ToString() : ""
                            };
                        }
                    }

                    // Si encontramos la venta, traemos también el detalle de productos
                    if (obj.IdVenta != 0)
                    {
                        obj.oDetalleVenta = ObtenerDetalleVenta(obj.IdVenta, oconexion);
                    }
                }
                catch (Exception ex)
                {
                    obj = new Venta();
                    Mensaje = ex.Message;
                }
            }
            return obj;
        }

        // =========================================================
        // LISTA COMPLETA DE VENTAS (para md_BusquedaVentas)
        // =========================================================
        public List<Venta> ObtenerListaVentas()
        {
            List<Venta> lista = new List<Venta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("select v.IdVenta, v.Ticket, convert(char(10), v.FechaRegistro, 103) [FechaRegistro], ");
                query.AppendLine("v.MontoTotal, u.NombreCompleto [NombreUsuario], ");
                query.AppendLine("ISNULL(c.Documento, '0') [DocumentoCliente], ISNULL(c.NombreCompleto, 'Consumidor Final') [NombreCliente]");
                query.AppendLine("from VENTA v");
                query.AppendLine("inner join USUARIO u on u.IdUsuario = v.IdUsuario");
                query.AppendLine("left join CLIENTE c on c.IdCliente = v.IdCliente");
                query.AppendLine("order by v.IdVenta desc");

                SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 5;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Venta()
                        {
                            IdVenta = dr["IdVenta"] != DBNull.Value ? Convert.ToInt32(dr["IdVenta"]) : 0,
                            Ticket = dr["Ticket"] != DBNull.Value ? dr["Ticket"].ToString() : "",
                            FechaRegistro = dr["FechaRegistro"] != DBNull.Value ? dr["FechaRegistro"].ToString() : "",
                            MontoTotal = dr["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(dr["MontoTotal"]) : 0,
                            oUsuario = new Usuario()
                            {
                                NombreCompleto = dr["NombreUsuario"] != DBNull.Value ? dr["NombreUsuario"].ToString() : ""
                            },
                            oCliente = new Cliente()
                            {
                                Documento = dr["DocumentoCliente"] != DBNull.Value ? dr["DocumentoCliente"].ToString() : "0",
                                NombreCompleto = dr["NombreCliente"] != DBNull.Value ? dr["NombreCliente"].ToString() : "Consumidor Final"
                            }
                        });
                    }
                }
            }

            return lista;
        }

        // =========================================================
        // DETALLE DE PRODUCTOS DE UNA VENTA (para el módulo Ver Detalles)
        // CORREGIDO: la tabla real es "DetalleVenta" (sin guion bajo);
        // "DETALLE_VENTA" no existe en el esquema. Se agrega además
        // dv.IdProducto y dv.IdDetalleVenta para poder alimentar la
        // columna oculta CIDproducto de la grilla en Form_DetalleVentas.
        // =========================================================
        private List<DetalleVenta> ObtenerDetalleVenta(int idVenta, SqlConnection oconexion)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();

            string query = "select dv.IdDetalleVenta, dv.IdProducto, p.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal " +
                            "from DetalleVenta dv " +
                            "inner join PRODUCTO p on p.IdProducto = dv.IdProducto " +
                            "where dv.IdVenta = @idVenta";

            SqlCommand cmd = new SqlCommand(query, oconexion);
            cmd.Parameters.AddWithValue("@idVenta", idVenta);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 5;

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    lista.Add(new DetalleVenta()
                    {
                        IdDetalleVenta = dr["IdDetalleVenta"] != DBNull.Value ? Convert.ToInt32(dr["IdDetalleVenta"]) : 0,
                        oProducto = new Producto()
                        {
                            IdProducto = dr["IdProducto"] != DBNull.Value ? Convert.ToInt32(dr["IdProducto"]) : 0,
                            Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : ""
                        },
                        PrecioVenta = dr["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioVenta"]) : 0,
                        Cantidad = dr["Cantidad"] != DBNull.Value ? Convert.ToInt32(dr["Cantidad"]) : 0,
                        SubTotal = dr["SubTotal"] != DBNull.Value ? Convert.ToDecimal(dr["SubTotal"]) : 0
                    });
                }
            }

            return lista;
        }
    }
}