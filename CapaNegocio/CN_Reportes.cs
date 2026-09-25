using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Reportes
    {
        private readonly CD_Reportes datos = new CD_Reportes();

        public EBalance ObtenerBalance(int mes, int anio, out string mensaje)
        {
            return datos.ObtenerBalance(mes, anio, out mensaje);
        }

        public List<EVencimiento> ObtenerVencimientos(int diasAlerta, out string mensaje)
        {
            return datos.ObtenerVencimientos(diasAlerta, out mensaje);
        }

        public List<EStockCritico> ObtenerStockCritico(out string mensaje)
        {
            return datos.ObtenerStockCritico(out mensaje);
        }

        public List<EProductoVendido> ObtenerMasVendidos(int mes, int anio, out string mensaje, int top = 5)
        {
            return datos.ObtenerMasVendidos(mes, anio, top, out mensaje);
        }

        public List<EProductoVendido> ObtenerMenosVendidos(int mes, int anio, out string mensaje, int top = 5)
        {
            return datos.ObtenerMenosVendidos(mes, anio, top, out mensaje);
        }

        public List<EVentaSemanal> ObtenerVentasSemana(out string mensaje)
        {
            return datos.ObtenerVentasSemana(out mensaje);
        }

        // Overload usado por la navegación de semanas en Form_Reportes: recibe el lunes/domingo
        // de la semana elegida (calculados ahí con ObtenerLunesDeSemana) y delega en CD_Reportes.
        public List<EVentaSemanal> ObtenerVentasSemana(DateTime lunes, DateTime domingo, out string mensaje)
        {
            return datos.ObtenerVentasSemana(lunes, domingo, out mensaje);
        }
    }
}