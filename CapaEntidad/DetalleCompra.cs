using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Compra
    {
        public int IdDetalleCompra { get; set; }

        // 🌟 Instanciamos el Producto para poder traer su Nombre y Código a la tabla visual
        public Producto oProducto { get; set; }

        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }

        // Datos extra para el control de inventario
        public string NroLote { get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaRegistro { get; set; }
    }
}