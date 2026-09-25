using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Esta librería es la que lee tu App.config
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        // Esta variable "cadena" guarda la ruta exacta para abrir tu SQL Server
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
    }
}