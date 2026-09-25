using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Producto
    {
        // ---------------------------------------------------------
        // 1. LISTAR PRODUCTOS (Trae también el nombre de la categoría)
        // ---------------------------------------------------------
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    // 🌟 LEFT JOIN: un producto con categoría inválida o nula ya no
                    // desaparece de la lista entera (antes se perdía en silencio con INNER JOIN)
                    string query = @"SELECT p.IdProducto, p.Codigo, p.Nombre, p.Descripcion, 
                                            c.IdCategoria, c.Descripcion as DescripcionCategoria, 
                                            p.Stock, p.StockMinimo, p.PrecioCompra, p.PrecioVenta, p.Estado 
                                     FROM PRODUCTO p
                                     LEFT JOIN CATEGORIA c ON p.IdCategoria = c.IdCategoria";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                // Llenamos el objeto Categoría solo si el LEFT JOIN encontró una real;
                                // si no, queda null (mdProductoVentas.cs ya sabe manejar ese caso con
                                // "Sin Categoría", ese chequeo antes nunca se disparaba)
                                oCategoria = dr["IdCategoria"] != DBNull.Value ? new Categoria()
                                {
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    Descripcion = dr["DescripcionCategoria"].ToString()
                                } : null,
                                Stock = Convert.ToDecimal(dr["Stock"]),
                                StockMinimo = Convert.ToDecimal(dr["StockMinimo"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                lista = new List<Producto>();
            }
            return lista;
        }

        // ---------------------------------------------------------
        // 2. REGISTRAR NUEVO PRODUCTO
        // ---------------------------------------------------------
        public int Registrar(Producto obj, out string Mensaje)
        {
            int idAutogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oconexion);

                    // 🌟 Enviamos todos los datos que pusimos en SQL Server
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("StockMinimo", obj.StockMinimo);
                    cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idAutogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idAutogenerado = 0;
                Mensaje = ex.Message;
            }
            return idAutogenerado;
        }

        // ---------------------------------------------------------
        // 3. EDITAR PRODUCTO
        // ---------------------------------------------------------
        public bool Editar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oconexion);

                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("StockMinimo", obj.StockMinimo);
                    cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        // ---------------------------------------------------------
        // 4. ELIMINAR PRODUCTO (Baja lógica o física, usaremos procedimiento)
        // ---------------------------------------------------------
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarProducto", oconexion);

                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        // ---------------------------------------------------------
        // 5. VALIDAR CÓDIGO DUPLICADO
        // ---------------------------------------------------------
        public bool ExisteCodigo(string codigo, int idProducto)
        {
            bool respuesta = false;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Cuenta los productos con ese código, excluyendo el ID actual
                    string query = "SELECT COUNT(*) FROM PRODUCTO WHERE Codigo = @Codigo AND IdProducto != @IdProducto";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                    if (cantidad > 0)
                    {
                        respuesta = true; // Sí existe otro producto usando ese código
                    }
                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}