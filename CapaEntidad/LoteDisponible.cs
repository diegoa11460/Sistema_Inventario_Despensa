using System;

namespace CapaEntidad
{
    /// <summary>
    /// Representa una fila de DetalleCompra (un lote de compra) con su stock restante ya calculado
    /// (Cantidad comprada menos lo ya vendido de ese mismo lote). Se usa para la selección FEFO
    /// de producto en Ventas (mdProductoVentas), donde cada lote del mismo producto aparece por separado.
    /// </summary>
    public class LoteDisponible
    {
        public int IdDetalleCompra { get; set; }
        public int IdProducto { get; set; }
        public string NroLote { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Disponible { get; set; }
    }
}