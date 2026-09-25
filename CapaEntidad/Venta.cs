using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Usuario oUsuario { get; set; }

        // Esta propiedad es importante porque la usas al Registrar
        public int IdCliente { get; set; }
        public Cliente oCliente { get; set; }

        public string Ticket { get; set; }
        public string MetodoPago { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }
        public string FechaRegistro { get; set; }

        // Lista para guardar el detalle de los productos
        public List<DetalleVenta> oDetalleVenta { get; set; }
    }
}