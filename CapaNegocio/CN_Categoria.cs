using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        // Conectamos con la Capa de Datos de Categoría que acabamos de terminar
        private CD_Categoria objcd_categoria = new CD_Categoria();

        // ---------------------------------------------------------
        // 1. LISTAR
        // ---------------------------------------------------------
        public List<Categoria> Listar()
        {
            return objcd_categoria.Listar();
        }

        // ---------------------------------------------------------
        // 2. REGISTRAR
        // ---------------------------------------------------------
        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validamos que el cajero o administrador no deje la caja de texto vacía
            if (string.IsNullOrEmpty(obj.Descripcion))
            {
                Mensaje += "Es necesario ingresar el nombre de la categoría.\n";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0; // Si hay error, devolvemos 0 y no enviamos nada a la base de datos
            }
            else
            {
                return objcd_categoria.Registrar(obj, out Mensaje);
            }
        }

        // ---------------------------------------------------------
        // 3. EDITAR
        // ---------------------------------------------------------
        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Misma validación: no podemos actualizar a un nombre vacío
            if (string.IsNullOrEmpty(obj.Descripcion))
            {
                Mensaje += "Es necesario ingresar el nombre de la categoría.\n";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false;
            }
            else
            {
                return objcd_categoria.Editar(obj, out Mensaje);
            }
        }

        // ---------------------------------------------------------
        // 4. ELIMINAR
        // ---------------------------------------------------------
        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            // La eliminación directa, la validación de seguridad ya la hicimos en SQL
            return objcd_categoria.Eliminar(obj, out Mensaje);
        }
    }
}