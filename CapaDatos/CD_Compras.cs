using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Compras
    {
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select count(*) + 1 from COMPRA";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    idcorrelativo = 0;
                }
            }

            return idcorrelativo;
        }

        public bool RegistrarCompra(Compra obj, DataTable dtDetalleCompra, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRAR_COMPRA", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("@IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@MontoTotal", obj.MontoTotal);

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@DetalleCompra", dtDetalleCompra);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.DETALLE_COMPRA_TYPE";

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

        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdCompra, u.NombreCompleto, r.Descripcion [Rol], pr.Documento, pr.RazonSocial, ");
                    query.AppendLine("c.TipoDocumento, c.NumeroDocumento, c.MontoTotal, convert(char(10), c.FechaRegistro, 103)[FechaRegistro]");
                    query.AppendLine("from COMPRA c");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = c.IdUsuario");
                    query.AppendLine("inner join ROL r on r.IdRol = u.IdRol");
                    query.AppendLine("inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("WHERE c.NumeroDocumento = @busqueda OR pr.Documento = @busqueda OR pr.RazonSocial LIKE '%' + @busqueda + '%'");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    // CORRECCIÓN AQUÍ: el parámetro ahora coincide con @busqueda
                    cmd.Parameters.AddWithValue("@busqueda", numero);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = dr["IdCompra"] != DBNull.Value ? Convert.ToInt32(dr["IdCompra"]) : 0,
                                oUsuario = new Usuario()
                                {
                                    NombreCompleto = dr["NombreCompleto"] != DBNull.Value ? dr["NombreCompleto"].ToString() : "",
                                    oRol = new Rol() { Descripcion = dr["Rol"] != DBNull.Value ? dr["Rol"].ToString() : "" }
                                },
                                oProveedor = new Proveedor()
                                {
                                    Documento = dr["Documento"] != DBNull.Value ? dr["Documento"].ToString() : "",
                                    RazonSocial = dr["RazonSocial"] != DBNull.Value ? dr["RazonSocial"].ToString() : ""
                                },
                                TipoDocumento = dr["TipoDocumento"] != DBNull.Value ? dr["TipoDocumento"].ToString() : "",
                                NumeroDocumento = dr["NumeroDocumento"] != DBNull.Value ? dr["NumeroDocumento"].ToString() : "",
                                MontoTotal = dr["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(dr["MontoTotal"]) : 0,
                                FechaRegistro = dr["FechaRegistro"] != DBNull.Value ? dr["FechaRegistro"].ToString() : ""
                            };
                        }
                    }
                }
                catch { obj = new Compra(); }
            }
            return obj;
        }

        public List<Detalle_Compra> ObtenerDetalleCompra(int idcompra)
        {
            List<Detalle_Compra> oLista = new List<Detalle_Compra>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    // CORREGIDO: "DetalleCompra" sin guion bajo, tal como está en tu base de datos
                    query.AppendLine("select p.IdProducto, p.Nombre, dc.PrecioCompra, dc.PrecioVenta, dc.Cantidad, dc.NroLote, convert(char(10), dc.FechaVencimiento, 103)[FechaVencimiento], dc.SubTotal from DetalleCompra dc");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dc.IdProducto");
                    query.AppendLine("where dc.IdCompra = @idcompra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idcompra", idcompra);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Compra()
                            {
                                oProducto = new Producto()
                                {
                                    IdProducto = dr["IdProducto"] != DBNull.Value ? Convert.ToInt32(dr["IdProducto"]) : 0,
                                    Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : ""
                                },
                                PrecioCompra = dr["PrecioCompra"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioCompra"]) : 0,
                                PrecioVenta = dr["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioVenta"]) : 0,
                                Cantidad = dr["Cantidad"] != DBNull.Value ? Convert.ToInt32(dr["Cantidad"]) : 0,
                                NroLote = dr["NroLote"] != DBNull.Value ? dr["NroLote"].ToString() : "",
                                FechaVencimiento = dr["FechaVencimiento"] != DBNull.Value ? dr["FechaVencimiento"].ToString() : "",
                                SubTotal = dr["SubTotal"] != DBNull.Value ? Convert.ToDecimal(dr["SubTotal"]) : 0,
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                oLista = new List<Detalle_Compra>();
            }

            return oLista;
        }

        public List<Compra> ObtenerListaCompras()
        {
            List<Compra> oLista = new List<Compra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdCompra, u.NombreCompleto, r.Descripcion [Rol], pr.Documento, pr.RazonSocial, ");
                    query.AppendLine("c.TipoDocumento, c.NumeroDocumento, c.MontoTotal, convert(char(10), c.FechaRegistro, 103)[FechaRegistro]");
                    query.AppendLine("from COMPRA c");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = c.IdUsuario");
                    query.AppendLine("inner join ROL r on r.IdRol = u.IdRol");
                    query.AppendLine("inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("order by c.IdCompra desc");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Compra()
                            {
                                IdCompra = dr["IdCompra"] != DBNull.Value ? Convert.ToInt32(dr["IdCompra"]) : 0,
                                oUsuario = new Usuario()
                                {
                                    NombreCompleto = dr["NombreCompleto"] != DBNull.Value ? dr["NombreCompleto"].ToString() : "",
                                    oRol = new Rol() { Descripcion = dr["Rol"] != DBNull.Value ? dr["Rol"].ToString() : "" }
                                },
                                oProveedor = new Proveedor()
                                {
                                    Documento = dr["Documento"] != DBNull.Value ? dr["Documento"].ToString() : "",
                                    RazonSocial = dr["RazonSocial"] != DBNull.Value ? dr["RazonSocial"].ToString() : ""
                                },
                                TipoDocumento = dr["TipoDocumento"] != DBNull.Value ? dr["TipoDocumento"].ToString() : "",
                                NumeroDocumento = dr["NumeroDocumento"] != DBNull.Value ? dr["NumeroDocumento"].ToString() : "",
                                MontoTotal = dr["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(dr["MontoTotal"]) : 0,
                                FechaRegistro = dr["FechaRegistro"] != DBNull.Value ? dr["FechaRegistro"].ToString() : ""
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    oLista = new List<Compra>();
                }
            }

            return oLista;
        }

        // ============================================================================
        // NUEVO — para mdProductoVentas: lista TODOS los lotes (de cualquier compra)
        // con stock restante > 0, ordenados por vencimiento (FEFO). El restante se
        // calcula como Cantidad del lote menos lo ya vendido de ese mismo lote
        // (DetalleVenta.IdDetalleCompra).
        // ============================================================================
        public List<LoteDisponible> ObtenerLotesDisponibles(out string Mensaje)
        {
            List<LoteDisponible> oLista = new List<LoteDisponible>();
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select dc.IdDetalleCompra, dc.IdProducto, dc.NroLote, dc.FechaVencimiento, dc.PrecioVenta, ");
                    query.AppendLine("dc.Cantidad");
                    query.AppendLine("  - isnull((select sum(dv.Cantidad) from DetalleVenta dv where dv.IdDetalleCompra = dc.IdDetalleCompra), 0)");
                    query.AppendLine("  - isnull((select sum(m.Cantidad) from Movimiento m where m.IdDetalleCompra = dc.IdDetalleCompra and m.Motivo = 'MERMA'), 0)");
                    query.AppendLine("  [Disponible]");
                    query.AppendLine("from DetalleCompra dc");
                    query.AppendLine("order by dc.FechaVencimiento asc");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new LoteDisponible()
                            {
                                IdDetalleCompra = dr["IdDetalleCompra"] != DBNull.Value ? Convert.ToInt32(dr["IdDetalleCompra"]) : 0,
                                IdProducto = dr["IdProducto"] != DBNull.Value ? Convert.ToInt32(dr["IdProducto"]) : 0,
                                NroLote = dr["NroLote"] != DBNull.Value ? dr["NroLote"].ToString() : "",
                                FechaVencimiento = dr["FechaVencimiento"] != DBNull.Value ? Convert.ToDateTime(dr["FechaVencimiento"]) : DateTime.MinValue,
                                PrecioVenta = dr["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioVenta"]) : 0,
                                Disponible = dr["Disponible"] != DBNull.Value ? Convert.ToInt32(dr["Disponible"]) : 0
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message;
                    oLista = new List<LoteDisponible>();
                }
            }

            return oLista;
        }

        // ============================================================================
        // NUEVO — da de baja un lote vencido: resta el stock restante de Producto y
        // deja registro trazable en Movimiento (llama a sp_DarDeBajaLotePorVencimiento).
        // ============================================================================
        public bool RegistrarBajaPorVencimiento(int idDetalleCompra, int idUsuario, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DarDeBajaLotePorVencimiento", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdDetalleCompra", idDetalleCompra);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
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
    }
}