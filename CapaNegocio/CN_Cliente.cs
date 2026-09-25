using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_cliente = new CD_Cliente();

        // ==========================================
        // 1. LISTAR CLIENTES
        // ==========================================
        public List<Cliente> Listar()
        {
            return objcd_cliente.Listar();
        }

        // ==========================================
        // 2. REGISTRAR CLIENTE
        // ==========================================
        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones (Reglas de negocio)
            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                Mensaje += "Es necesario el documento del cliente.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                Mensaje += "Es necesario el nombre completo del cliente.\n";
            }

            // Si el mensaje ya no está vacío, hubo un error y detenemos el proceso
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_cliente.Registrar(obj, out Mensaje);
            }
        }

        // ==========================================
        // 3. EDITAR CLIENTE
        // ==========================================
        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones (Reglas de negocio)
            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                Mensaje += "Es necesario el documento del cliente.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                Mensaje += "Es necesario el nombre completo del cliente.\n";
            }

            // Si el mensaje ya no está vacío, hubo un error y detenemos el proceso
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_cliente.Editar(obj, out Mensaje);
            }
        }

        // ==========================================
        // 4. ELIMINAR CLIENTE
        // ==========================================
        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            // Para eliminar usualmente no hacemos validaciones de campos de texto,
            // solo enviamos el Id directamente a la base de datos.
            return objcd_cliente.Eliminar(obj, out Mensaje);
        }
    }
}