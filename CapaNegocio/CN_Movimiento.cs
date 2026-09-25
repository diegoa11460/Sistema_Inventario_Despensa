using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Movimiento
    {
        private CD_Movimiento objcd_movimiento = new CD_Movimiento();

        public List<Movimiento> Listar(out string Mensaje)
        {
            return objcd_movimiento.Listar(out Mensaje);
        }
    }
}