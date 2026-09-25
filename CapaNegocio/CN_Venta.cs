using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private CD_Venta objcd_venta = new CD_Venta();

        public int ObtenerCorrelativo()
        {
            return objcd_venta.ObtenerCorrelativo();
        }

        public bool Registrar(Venta obj, DataTable dtDetalleVenta, out string Mensaje)
        {
            Mensaje = string.Empty;

            // 1. Validaciones de Negocio
            if (obj.oUsuario == null || obj.oUsuario.IdUsuario == 0)
            {
                Mensaje += "Error de sesión: Usuario no válido.\n";
            }

            if (dtDetalleVenta == null || dtDetalleVenta.Rows.Count == 0)
            {
                Mensaje += "Debe agregar al menos un producto a la venta.\n";
            }

            // 2. Si hay errores, retornamos false
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false;
            }
            else
            {
                // 3. Si todo está bien, llamamos a la capa de datos
                return objcd_venta.RegistrarVenta(obj, dtDetalleVenta, out Mensaje);
            }
        }

        // CORREGIDO: CD_Venta.ObtenerVenta ahora expone el error real vía out
        // string Mensaje en vez de tragarlo. Se propaga ese mismo out acá para
        // que el formulario que llame a CN_Venta().ObtenerVenta(...) pueda
        // distinguir "no encontrado" de "error de conexión/consulta".
        public Venta ObtenerVenta(string numero, out string Mensaje)
        {
            return objcd_venta.ObtenerVenta(numero, out Mensaje);
        }

        // NUEVO: lista completa de ventas para el modal md_BusquedaVentas
        public List<Venta> ObtenerListaVentas()
        {
            return objcd_venta.ObtenerListaVentas();
        }
    }
}