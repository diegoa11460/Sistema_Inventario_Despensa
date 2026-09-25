using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 🌟 Enlazamos con las otras capas
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        // Instanciamos la Capa de Datos para poder enviarle las órdenes
        private CD_Proveedor objcd_proveedor = new CD_Proveedor();

        // ---------------------------------------------------------
        // 1. LISTAR PROVEEDORES
        // ---------------------------------------------------------
        public List<Proveedor> Listar()
        {
            return objcd_proveedor.Listar();
        }

        // ---------------------------------------------------------
        // 2. REGISTRAR PROVEEDOR (Con Validaciones)
        // ---------------------------------------------------------
        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // 🛡️ REGLAS DE NEGOCIO (Validaciones para que no envíen datos vacíos)
            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                Mensaje += "Es necesario ingresar el número de documento.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.RazonSocial))
            {
                Mensaje += "Es necesario ingresar la Razón Social del proveedor.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje += "Es necesario ingresar el correo del proveedor.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje += "Es necesario ingresar el teléfono del proveedor.\n";
            }

            // Si el mensaje ya no está vacío, significa que rompimos alguna regla
            if (Mensaje != string.Empty)
            {
                return 0; // Retornamos 0 para indicar que falló el registro en la interfaz
            }
            else
            {
                // Si todo está perfecto, le damos luz verde a la Capa de Datos
                return objcd_proveedor.Registrar(obj, out Mensaje);
            }
        }

        // ---------------------------------------------------------
        // 3. EDITAR PROVEEDOR (Con Validaciones)
        // ---------------------------------------------------------
        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // 🛡️ REGLAS DE NEGOCIO (Las mismas validaciones que al registrar)
            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                Mensaje += "Es necesario ingresar el número de documento.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.RazonSocial))
            {
                Mensaje += "Es necesario ingresar la Razón Social del proveedor.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje += "Es necesario ingresar el correo del proveedor.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje += "Es necesario ingresar el teléfono del proveedor.\n";
            }

            // Si falló alguna validación
            if (Mensaje != string.Empty)
            {
                return false; // Retornamos false para cancelar la edición
            }
            else
            {
                // Luz verde a la Capa de Datos
                return objcd_proveedor.Editar(obj, out Mensaje);
            }
        }

        // ---------------------------------------------------------
        // 4. ELIMINAR PROVEEDOR
        // ---------------------------------------------------------
        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            // Para eliminar solo pasamos directo a la orden hacia la Capa de Datos
            return objcd_proveedor.Eliminar(obj, out Mensaje);
        }
    }
}