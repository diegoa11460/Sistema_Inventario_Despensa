using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Movimiento
    {
        public List<Movimiento> Listar(out string Mensaje)
        {
            Mensaje = string.Empty;
            List<Movimiento> lista = new List<Movimiento>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"SELECT 
                        m.FechaRegistro, 
                        p.Nombre AS Producto, 
                        m.TipoMovimiento, 
                        m.Motivo, 
                        m.Cantidad, 
                        m.StockAnterior, 
                        m.StockActual, 
                        u.NombreCompleto AS Usuario, 
                        r.Descripcion AS RolDescripcion,
                        m.Observacion 
                    FROM MOVIMIENTO m
                    INNER JOIN PRODUCTO p ON p.IdProducto = m.IdProducto
                    INNER JOIN USUARIO u ON u.IdUsuario = m.IdUsuario
                    INNER JOIN ROL r ON r.IdRol = u.IdRol
                    ORDER BY m.FechaRegistro DESC";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Movimiento()
                            {
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                                oProducto = new Producto() { Nombre = dr["Producto"].ToString() },
                                TipoMovimiento = dr["TipoMovimiento"].ToString(),
                                Motivo = dr["Motivo"].ToString(),
                                Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                                StockAnterior = Convert.ToDecimal(dr["StockAnterior"]),
                                StockActual = Convert.ToDecimal(dr["StockActual"]),
                                oUsuario = new Usuario()
                                {
                                    NombreCompleto = dr["Usuario"].ToString(),
                                    oRol = new Rol() { Descripcion = dr["RolDescripcion"].ToString() }
                                },
                                Observacion = dr["Observacion"] == DBNull.Value ? "" : dr["Observacion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Movimiento>();
                    Mensaje = ex.Message;
                }
            }
            return lista;
        }
    }
}