using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int IdUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT p.IdRol, p.NombreMenu FROM Permiso p");
                query.AppendLine("INNER JOIN Rol r ON r.IdRol = p.IdRol");
                query.AppendLine("INNER JOIN Usuario u ON u.IdRol = r.IdRol");
                query.AppendLine("WHERE u.IdUsuario = @IdUsuario");

                using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                NombreMenu = dr["NombreMenu"] != DBNull.Value
                                    ? dr["NombreMenu"].ToString()
                                    : string.Empty,
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<Permiso> ListarPorRol(int IdRol)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT IdRol, NombreMenu FROM Permiso");
                query.AppendLine("WHERE IdRol = @IdRol");

                using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                {
                    cmd.Parameters.AddWithValue("@IdRol", IdRol);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                NombreMenu = dr["NombreMenu"] != DBNull.Value
                                    ? dr["NombreMenu"].ToString()
                                    : string.Empty,
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public bool Guardar(int IdRol, List<string> listaPermisos)
        {
            bool respuesta = false;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                oconexion.Open();
                SqlTransaction transaccion = oconexion.BeginTransaction();

                try
                {
                    using (SqlCommand cmdBorrar = new SqlCommand(
                        "DELETE FROM Permiso WHERE IdRol = @IdRol", oconexion, transaccion))
                    {
                        cmdBorrar.Parameters.AddWithValue("@IdRol", IdRol);
                        cmdBorrar.ExecuteNonQuery();
                    }

                    foreach (string nombreMenu in listaPermisos)
                    {
                        using (SqlCommand cmdInsertar = new SqlCommand(
                            "INSERT INTO Permiso (IdRol, NombreMenu) VALUES (@IdRol, @NombreMenu)",
                            oconexion, transaccion))
                        {
                            cmdInsertar.Parameters.AddWithValue("@IdRol", IdRol);
                            cmdInsertar.Parameters.AddWithValue("@NombreMenu", nombreMenu);
                            cmdInsertar.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();
                    respuesta = true;
                }
                catch (Exception )
                {
                    transaccion.Rollback();
                    respuesta = false;
                }
            }

            return respuesta;
        }
    }
}