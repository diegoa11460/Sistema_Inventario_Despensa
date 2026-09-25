using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Inicio
    {
        private readonly CD_Inicio objCD;

        public CN_Inicio()
        {
            objCD = new CD_Inicio();
        }

        public ResumenInicio ObtenerResumen(out string Mensaje)
        {
            return objCD.ObtenerResumen(out Mensaje);
        }

        public List<CategoriaInventario> ObtenerInventarioPorCategoria(out string Mensaje)
        {
            return objCD.ObtenerInventarioPorCategoria(out Mensaje);
        }

        public List<Producto> ObtenerProductosRecientes(int top, out string Mensaje)
        {
            return objCD.ObtenerProductosRecientes(top, out Mensaje);
        }
    }
}