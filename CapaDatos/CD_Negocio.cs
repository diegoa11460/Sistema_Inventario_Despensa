using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Negocio
    {
        // ---------------------------------------------------------
        // 1. OBTENER DATOS DEL NEGOCIO
        // ---------------------------------------------------------
        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select IdNegocio, Nombre, RUC, Direccion from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                RUC = dr["RUC"].ToString(),
                                Direccion = dr["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolvemos el objeto vacío
                obj = new Negocio();
            }

            return obj;
        }

        // ---------------------------------------------------------
        // 2. GUARDAR / ACTUALIZAR DATOS DEL NEGOCIO
        // ---------------------------------------------------------
        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    // Actualizamos siempre el registro con IdNegocio = 1
                    string query = "update NEGOCIO set Nombre = @nombre, RUC = @ruc, Direccion = @direccion where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@ruc", obj.RUC);
                    cmd.Parameters.AddWithValue("@direccion", obj.Direccion);
                    cmd.CommandType = CommandType.Text;

                    // ExecuteNonQuery devuelve el número de filas afectadas. Si es menor a 1, falló.
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        Mensaje = "No se pudo actualizar los datos del negocio.";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        // ---------------------------------------------------------
        // 3. OBTENER LOGO
        // ---------------------------------------------------------
        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "select Logo from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Verificamos que la base de datos no devuelva un valor nulo
                            if (dr["Logo"] != DBNull.Value)
                            {
                                LogoBytes = (byte[])dr["Logo"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obtenido = false;
                LogoBytes = new byte[0];
            }

            return LogoBytes;
        }

        // ---------------------------------------------------------
        // 4. ACTUALIZAR LOGO
        // ---------------------------------------------------------
        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    // Solo actualizamos el campo Logo del registro 1
                    string query = "update NEGOCIO set Logo = @imagen where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    // Pasamos nuestro arreglo de bytes (byte[]) como parámetro
                    cmd.Parameters.AddWithValue("@imagen", image);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo del negocio.";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }
    }
}