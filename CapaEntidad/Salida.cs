using System;

namespace CapaEntidad
{
    public class Salida
    {
        public int IdSalida { get; set; }
        public Usuario oUsuario { get; set; } // Quién dio la baja
        public string Motivo { get; set; }    // VENCIDO, ROTO, CONSUMO PROPIO
        public string Observacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}