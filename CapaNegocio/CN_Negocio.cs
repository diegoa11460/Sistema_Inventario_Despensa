using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        // Instanciamos la Capa de Datos
        private CD_Negocio objcd_negocio = new CD_Negocio();

        // ---------------------------------------------------------
        // 1. OBTENER DATOS
        // ---------------------------------------------------------
        public Negocio ObtenerDatos()
        {
            return objcd_negocio.ObtenerDatos();
        }

        // ---------------------------------------------------------
        // 2. GUARDAR DATOS (Con validaciones de negocio)
        // ---------------------------------------------------------
        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validamos que los campos obligatorios no estén vacíos
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del negocio.\n";
            }

            if (obj.RUC == "")
            {
                Mensaje += "Es necesario el número de RUC.\n";
            }

            if (obj.Direccion == "")
            {
                Mensaje += "Es necesaria la dirección.\n";
            }

            // Si hay algún mensaje de error, detenemos el proceso y devolvemos false
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Si todo está correcto, enviamos los datos a la Capa de Datos
                return objcd_negocio.GuardarDatos(obj, out Mensaje);
            }
        }

        // ---------------------------------------------------------
        // 3. OBTENER LOGO
        // ---------------------------------------------------------
        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objcd_negocio.ObtenerLogo(out obtenido);
        }

        // ---------------------------------------------------------
        // 4. ACTUALIZAR LOGO
        // ---------------------------------------------------------
        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            return objcd_negocio.ActualizarLogo(image, out mensaje);
        }
    }
}