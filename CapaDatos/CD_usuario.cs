using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                string query = @"
                    SELECT u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, 
                           r.IdRol, r.Descripcion 
                    FROM USUARIO u
                    INNER JOIN ROL r ON r.IdRol = u.IdRol";

                SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.CommandType = CommandType.Text;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Documento = dr["Documento"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            oRol = new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                            }
                        });
                    }
                }
            }

            return lista;
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = @"
                        INSERT INTO USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado) 
                        VALUES (@documento, @nombrecompleto, @correo, @clave, @idrol, @estado); 
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@nombrecompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@clave", obj.Clave);
                    cmd.Parameters.AddWithValue("@idrol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("@estado", obj.Estado);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    idUsuarioGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                idUsuarioGenerado = 0;
                Mensaje = ex.Message;
            }

            return idUsuarioGenerado;
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    string query = @"
                        UPDATE USUARIO SET 
                        Documento = @documento, 
                        NombreCompleto = @nombrecompleto, 
                        Correo = @correo, 
                        Clave = @clave, 
                        IdRol = @idrol, 
                        Estado = @estado 
                        WHERE IdUsuario = @idusuario";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("@documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@nombrecompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@clave", obj.Clave);
                    cmd.Parameters.AddWithValue("@idrol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("@estado", obj.Estado);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                        respuesta = true;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        // 👇 AQUÍ ESTÁ EL MÉTODO ELIMINAR INTEGRADO 👇
        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    // Llama al Procedimiento Almacenado que apaga al usuario
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion);

                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
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
        // 👆 FIN DEL MÉTODO ELIMINAR 👆
    }
}