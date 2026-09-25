using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                string query = "SELECT IdRol, Descripcion, FechaCreacion FROM Rol";

                SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Rol()
                        {
                            IdRol = Convert.ToInt32(dr["IdRol"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}