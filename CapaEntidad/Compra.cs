using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int IdCompra { get; set; }

        // 🌟 Instanciamos las clases relacionadas
        public Usuario oUsuario { get; set; }
        public Proveedor oProveedor { get; set; }

        // Agregamos las propiedades que faltaban para el documento
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

        public decimal MontoTotal { get; set; }

        public string FechaRegistro { get; set; }

        // 💡 EXTRA IMPORTANTE: Una compra siempre está compuesta por varios productos.
        public List<Detalle_Compra> oDetalleCompra { get; set; }
    }
}