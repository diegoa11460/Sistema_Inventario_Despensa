using System;

namespace CapaEntidad
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public Producto oProducto { get; set; }
        public Usuario oUsuario { get; set; }

        // Usamos "int?" porque pueden ser nulos (ej: si es una venta, el IdEntrada es null)
        public int? IdEntrada { get; set; }
        public int? IdVenta { get; set; }
        public int? IdSalida { get; set; }

        public string TipoMovimiento { get; set; } // ENTRADA, SALIDA, AJUSTE
        public string Motivo { get; set; }         // COMPRA, VENTA, MERMA, etc.
        public decimal Cantidad { get; set; }
        public decimal StockAnterior { get; set; }
        public decimal StockActual { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}