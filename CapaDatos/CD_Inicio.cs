using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Inicio
    {

        public ResumenInicio ObtenerResumen(out string Mensaje)
        {
            ResumenInicio obj = new ResumenInicio();
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT");

                    // 1. GANANCIA DEL MES: (PrecioVenta - PrecioCompra del LOTE vendido) * Cantidad.
                    // Se usa el precio de compra del lote real (DetalleCompra) cuando existe,
                    // y se cae al PrecioCompra actual del producto solo si la venta no tiene
                    // lote asignado (IdDetalleCompra NULL, ventas sin selección FEFO todavía).
                    // Rango de fechas (>= / <) en vez de MONTH()/YEAR() para poder usar índice.
                    // Se excluyen ventas anuladas (Estado NULL o 0 no cuentan).
                    query.AppendLine("(SELECT ISNULL(SUM((dv.PrecioVenta - ISNULL(dc.PrecioCompra, p.PrecioCompra)) * dv.Cantidad), 0)");
                    query.AppendLine(" FROM DetalleVenta dv");
                    query.AppendLine(" INNER JOIN VENTA v ON v.IdVenta = dv.IdVenta");
                    query.AppendLine(" INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto");
                    query.AppendLine(" LEFT JOIN DetalleCompra dc ON dc.IdDetalleCompra = dv.IdDetalleCompra");
                    query.AppendLine(" WHERE ISNULL(v.Estado, 0) = 1");
                    query.AppendLine(" AND v.FechaRegistro >= DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0)");
                    query.AppendLine(" AND v.FechaRegistro < DATEADD(month, DATEDIFF(month, 0, GETDATE()) + 1, 0)) AS GananciaMes,");

                    // 2. VENDIDO HOY: mismo criterio de rango de fechas y exclusión de anuladas.
                    query.AppendLine("(SELECT ISNULL(SUM(MontoTotal), 0) ");
                    query.AppendLine(" FROM VENTA ");
                    query.AppendLine(" WHERE ISNULL(Estado, 0) = 1");
                    query.AppendLine(" AND FechaRegistro >= CAST(GETDATE() AS DATE) ");
                    query.AppendLine(" AND FechaRegistro < DATEADD(day, 1, CAST(GETDATE() AS DATE))) AS VendidoHoy,");

                    // 3. VALOR INVENTARIO: a precio de venta (decisión confirmada con Diego:
                    // "cuánto vale si vendo todo el stock", consistente con el resto del panel).
                    query.AppendLine("(SELECT ISNULL(SUM(Stock * PrecioVenta), 0) FROM PRODUCTO WHERE Estado = 1) AS ValorInventario,");

                    // 4. TOTALES
                    query.AppendLine("(SELECT COUNT(*) FROM PRODUCTO WHERE Estado = 1) AS TotalProductos,");
                    query.AppendLine("(SELECT COUNT(*) FROM CATEGORIA WHERE Estado = 1) AS TotalCategorias,");
                    query.AppendLine("(SELECT COUNT(*) FROM CLIENTE WHERE Estado = 1) AS TotalClientes");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 5;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new ResumenInicio()
                            {
                                GananciaMes = dr["GananciaMes"] != DBNull.Value ? Convert.ToDecimal(dr["GananciaMes"]) : 0,
                                VendidoHoy = dr["VendidoHoy"] != DBNull.Value ? Convert.ToDecimal(dr["VendidoHoy"]) : 0,
                                ValorInventario = dr["ValorInventario"] != DBNull.Value ? Convert.ToDecimal(dr["ValorInventario"]) : 0,
                                TotalProductos = dr["TotalProductos"] != DBNull.Value ? Convert.ToInt32(dr["TotalProductos"]) : 0,
                                TotalCategorias = dr["TotalCategorias"] != DBNull.Value ? Convert.ToInt32(dr["TotalCategorias"]) : 0,
                                TotalClientes = dr["TotalClientes"] != DBNull.Value ? Convert.ToInt32(dr["TotalClientes"]) : 0
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new ResumenInicio();
                    Mensaje = ex.Message;
                }
            }

            return obj;
        }

        // =========================================================
        // INVENTARIO POR CATEGORÍA (stock total agrupado, para
        // el gráfico de dona chartInventario)
        // =========================================================
        public List<CategoriaInventario> ObtenerInventarioPorCategoria(out string Mensaje)
        {
            List<CategoriaInventario> lista = new List<CategoriaInventario>();
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT c.Descripcion, SUM(p.Stock) AS StockTotal " +
                                    "FROM PRODUCTO p " +
                                    "INNER JOIN CATEGORIA c ON c.IdCategoria = p.IdCategoria " +
                                    "WHERE p.Estado = 1 " +
                                    "GROUP BY c.Descripcion " +
                                    "ORDER BY StockTotal DESC";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 5;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CategoriaInventario()
                            {
                                Descripcion = dr["Descripcion"] != DBNull.Value ? dr["Descripcion"].ToString() : "",
                                StockTotal = dr["StockTotal"] != DBNull.Value ? Convert.ToDecimal(dr["StockTotal"]) : 0
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<CategoriaInventario>();
                    Mensaje = ex.Message;
                }
            }

            return lista;
        }

        // =========================================================
        // PRODUCTOS RECIÉN AÑADIDOS
        // =========================================================
        public List<Producto> ObtenerProductosRecientes(int top, out string Mensaje)
        {
            List<Producto> lista = new List<Producto>();
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT TOP (@top) p.IdProducto, p.Codigo, p.Nombre, p.Stock, p.PrecioVenta, " +
                                    "c.IdCategoria, c.Descripcion AS DescripcionCategoria " +
                                    "FROM PRODUCTO p " +
                                    "INNER JOIN CATEGORIA c ON c.IdCategoria = p.IdCategoria " +
                                    "WHERE p.Estado = 1 " +
                                    "ORDER BY p.IdProducto DESC";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@top", top);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 5;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = dr["IdProducto"] != DBNull.Value ? Convert.ToInt32(dr["IdProducto"]) : 0,
                                Codigo = dr["Codigo"] != DBNull.Value ? dr["Codigo"].ToString() : "",
                                Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : "",
                                Stock = dr["Stock"] != DBNull.Value ? Convert.ToDecimal(dr["Stock"]) : 0,
                                PrecioVenta = dr["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioVenta"]) : 0,
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = dr["IdCategoria"] != DBNull.Value ? Convert.ToInt32(dr["IdCategoria"]) : 0,
                                    Descripcion = dr["DescripcionCategoria"] != DBNull.Value ? dr["DescripcionCategoria"].ToString() : ""
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();
                    Mensaje = ex.Message;
                }
            }

            return lista;
        }
    }
}