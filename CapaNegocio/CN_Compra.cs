using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private CD_Compras objcd_compras = new CD_Compras();

        public int ObtenerCorrelativo()
        {
            return objcd_compras.ObtenerCorrelativo();
        }

        public bool Registrar(Compra obj, DataTable dtDetalleCompra, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oProveedor == null || obj.oProveedor.IdProveedor == 0)
            {
                Mensaje += "Debe seleccionar un proveedor válido.\n";
            }

            if (string.IsNullOrWhiteSpace(obj.NumeroDocumento))
            {
                Mensaje += "Debe ingresar el número de factura.\n";
            }

            if (dtDetalleCompra == null || dtDetalleCompra.Rows.Count == 0)
            {
                Mensaje += "Debe agregar al menos un producto al detalle de la compra.\n";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false;
            }
            else
            {
                return objcd_compras.RegistrarCompra(obj, dtDetalleCompra, out Mensaje);
            }
        }

        public Compra ObtenerCompra(string numero)
        {
            return objcd_compras.ObtenerCompra(numero);
        }

        public List<Detalle_Compra> ObtenerDetalleCompra(int idcompra)
        {
            return objcd_compras.ObtenerDetalleCompra(idcompra);
        }

        public List<LoteDisponible> ObtenerLotesDisponibles(out string Mensaje)
        {
            return new CD_Compras().ObtenerLotesDisponibles(out Mensaje);
        }

        // NUEVO: da de baja un lote vencido (resta stock y registra en Movimiento)
        public bool RegistrarBajaPorVencimiento(int idDetalleCompra, int idUsuario, out string Mensaje)
        {
            return objcd_compras.RegistrarBajaPorVencimiento(idDetalleCompra, idUsuario, out Mensaje);
        }

        // 🌟 NUEVO: para el modal de búsqueda
        public List<Compra> ObtenerListaCompras()
        {
            return objcd_compras.ObtenerListaCompras();
        }
    }
}