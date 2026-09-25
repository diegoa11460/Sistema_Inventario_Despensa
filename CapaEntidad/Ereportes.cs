using System;

namespace CapaEntidad
{
    public class EBalance
    {
        public decimal Ingresos { get; set; }
        public decimal Compras { get; set; }
        public decimal Ganancia => Ingresos - Compras;
    }

    public class EVencimiento
    {
        public string Producto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Cantidad { get; set; }
        public string NroLote { get; set; }
    }

    public class EStockCritico
    {
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
    }

    public class EProductoVendido
    {
        public string Producto { get; set; }
        public decimal CantidadVendida { get; set; }
    }
}