using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_permiso = new CD_Permiso();

        // Método para listar permisos cuando entra el usuario al Login
        public List<Permiso> Listar(int IdUsuario)
        {
            return objcd_permiso.Listar(IdUsuario);
        }

        // Método para listar permisos específicos de un rol
        public List<Permiso> ListarPorRol(int IdRol)
        {
            return objcd_permiso.ListarPorRol(IdRol);
        }

        // 💾 NUEVO MÉTODO: El puente para guardar los tildes desde el formulario
        public bool Guardar(int IdRol, List<string> listaPermisos)
        {
            return objcd_permiso.Guardar(IdRol, listaPermisos);
        }
    }
}