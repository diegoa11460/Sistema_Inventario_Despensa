using System;

namespace CapaEntidad
{
    public class DetalleSalida
    {
        public int IdDetalleSalida { get; set; }
        public int IdSalida { get; set; }
        public Producto oProducto { get; set; } // Qué se tiró o consumió
        public decimal Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}