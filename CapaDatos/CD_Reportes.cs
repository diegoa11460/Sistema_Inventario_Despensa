using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Reportes
    {
        public EBalance ObtenerBalance(int mes, int anio, out string mensaje)
        {
            mensaje = string.Empty;
            EBalance balance = new EBalance();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    oconexion.Open();

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT ISNULL(SUM(MontoTotal), 0)
                        FROM Venta
                        WHERE MONTH(FechaRegistro) = @Mes
                          AND YEAR(FechaRegistro) = @Anio
                          AND Estado = 1", oconexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);
                        balance.Ingresos = Convert.ToDecimal(cmd.ExecuteScalar());
                    }

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT ISNULL(SUM(MontoTotal), 0)
                        FROM Compra
                        WHERE MONTH(FechaRegistro) = @Mes
                          AND YEAR(FechaRegistro) = @Anio", oconexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);
                        balance.Compras = Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return balance;
        }

        // Vencimientos por lote, descontando lo ya vendido de ese lote (DetalleVenta.IdDetalleCompra).
        // NOTA: no descuenta retiros manuales (Movimiento) porque esa tabla no guarda a qué lote
        // afectó el retiro — solo el total por producto. Si se agrega IdDetalleCompra a Movimiento
        // en el futuro, este mismo query se puede extender para restarlo también.
        public List<EVencimiento> ObtenerVencimientos(int diasAlerta, out string mensaje)
        {
            mensaje = string.Empty;
            List<EVencimiento> lista = new List<EVencimiento>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = @"SELECT p.Nombre AS Producto, dc.FechaVencimiento, dc.NroLote,
                                             dc.Cantidad - ISNULL(SUM(dv.Cantidad), 0) AS CantidadRestante
                                      FROM DetalleCompra dc
                                      INNER JOIN Producto p ON p.IdProducto = dc.IdProducto
                                      LEFT JOIN DetalleVenta dv ON dv.IdDetalleCompra = dc.IdDetalleCompra
                                      WHERE dc.FechaVencimiento IS NOT NULL
                                        AND dc.FechaVencimiento <= DATEADD(DAY, @Dias, GETDATE())
                                      GROUP BY p.Nombre, dc.FechaVencimiento, dc.NroLote, dc.Cantidad
                                      HAVING dc.Cantidad - ISNULL(SUM(dv.Cantidad), 0) > 0
                                      ORDER BY dc.FechaVencimiento ASC";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Dias", diasAlerta);

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EVencimiento
                            {
                                Producto = dr["Producto"].ToString(),
                                FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
                                Cantidad = Convert.ToDecimal(dr["CantidadRestante"]),
                                NroLote = dr["NroLote"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return lista;
        }

        public List<EStockCritico> ObtenerStockCritico(out string mensaje)
        {
            mensaje = string.Empty;
            List<EStockCritico> lista = new List<EStockCritico>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = @"SELECT IdProducto, Nombre, Stock, StockMinimo
                                      FROM Producto
                                      WHERE Stock <= StockMinimo
                                        AND Estado = 1
                                      ORDER BY Stock ASC";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EStockCritico
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Producto = dr["Nombre"].ToString(),
                                Stock = Convert.ToDecimal(dr["Stock"]),
                                StockMinimo = Convert.ToDecimal(dr["StockMinimo"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return lista;
        }

        public List<EProductoVendido> ObtenerMasVendidos(int mes, int anio, int top, out string mensaje)
        {
            return ObtenerRankingVendidos(mes, anio, top, descendente: true, mensaje: out mensaje);
        }

        public List<EProductoVendido> ObtenerMenosVendidos(int mes, int anio, int top, out string mensaje)
        {
            return ObtenerRankingVendidos(mes, anio, top, descendente: false, mensaje: out mensaje);
        }

        private List<EProductoVendido> ObtenerRankingVendidos(int mes, int anio, int top, bool descendente, out string mensaje)
        {
            mensaje = string.Empty;
            List<EProductoVendido> lista = new List<EProductoVendido>();
            string orden = descendente ? "DESC" : "ASC";

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = $@"SELECT TOP (@Top) p.Nombre AS Producto, SUM(dv.Cantidad) AS CantidadVendida
                                       FROM DetalleVenta dv
                                       INNER JOIN Venta v ON v.IdVenta = dv.IdVenta
                                       INNER JOIN Producto p ON p.IdProducto = dv.IdProducto
                                       WHERE MONTH(v.FechaRegistro) = @Mes
                                         AND YEAR(v.FechaRegistro) = @Anio
                                         AND v.Estado = 1
                                       GROUP BY p.Nombre
                                       ORDER BY CantidadVendida {orden}";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Top", top);
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Anio", anio);

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EProductoVendido
                            {
                                Producto = dr["Producto"].ToString(),
                                CantidadVendida = Convert.ToDecimal(dr["CantidadVendida"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return lista;
        }

        // Balance de la semana actual (lunes a domingo). Se mantiene por compatibilidad con
        // código existente que no necesita elegir semana: simplemente calcula el lunes/domingo
        // de hoy y delega en el overload que sí recibe el rango de fechas.
        public List<EVentaSemanal> ObtenerVentasSemana(out string mensaje)
        {
            DateTime hoy = DateTime.Now.Date;
            // DayOfWeek: Domingo=0 ... Sábado=6. Se ajusta para que la semana arranque en Lunes.
            int diasDesdeLunes = ((int)hoy.DayOfWeek + 6) % 7;
            DateTime lunes = hoy.AddDays(-diasDesdeLunes);
            DateTime domingo = lunes.AddDays(6);

            return ObtenerVentasSemana(lunes, domingo, out mensaje);
        }

        // Balance de una semana arbitraria (lunes a domingo), un total por día,
        // pensado para alimentar el gráfico de barras y detectar el día pico de ventas.
        // 'lunes' y 'domingo' deben ser el primer y último día de esa semana (ver Form_Reportes.ObtenerLunesDeSemana).
        public List<EVentaSemanal> ObtenerVentasSemana(DateTime lunes, DateTime domingo, out string mensaje)
        {
            mensaje = string.Empty;
            List<EVentaSemanal> lista = new List<EVentaSemanal>();

            lunes = lunes.Date;
            domingo = domingo.Date;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = @"SELECT CAST(FechaRegistro AS DATE) AS Fecha, SUM(MontoTotal) AS Total
                                      FROM Venta
                                      WHERE CAST(FechaRegistro AS DATE) BETWEEN @Lunes AND @Domingo
                                        AND Estado = 1
                                      GROUP BY CAST(FechaRegistro AS DATE)";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Lunes", lunes);
                    cmd.Parameters.AddWithValue("@Domingo", domingo);

                    oconexion.Open();

                    Dictionary<DateTime, decimal> totalesPorFecha = new Dictionary<DateTime, decimal>();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DateTime fecha = Convert.ToDateTime(dr["Fecha"]);
                            decimal total = Convert.ToDecimal(dr["Total"]);
                            totalesPorFecha[fecha] = total;
                        }
                    }

                    string[] nombresDias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

                    for (int i = 0; i < 7; i++)
                    {
                        DateTime fechaDia = lunes.AddDays(i);
                        decimal total = totalesPorFecha.ContainsKey(fechaDia) ? totalesPorFecha[fechaDia] : 0m;

                        lista.Add(new EVentaSemanal
                        {
                            DiaSemana = nombresDias[i],
                            Fecha = fechaDia,
                            Total = total
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return lista;
        }
    }
}