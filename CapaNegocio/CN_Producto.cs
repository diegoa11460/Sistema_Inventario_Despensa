using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 🌟 Enlazamos con las otras capas
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        // Instanciamos la Capa de Datos para poder enviarle las órdenes
        private CD_Producto objcd_producto = new CD_Producto();

        // ---------------------------------------------------------
        // 1. LISTAR PRODUCTOS
        // ---------------------------------------------------------
        public List<Producto> Listar()
        {
            return objcd_producto.Listar();
        }

        // ---------------------------------------------------------
        // 2. REGISTRAR PRODUCTO (Con Validaciones)
        // ---------------------------------------------------------
        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // 🛡️ REGLAS DE NEGOCIO (Validaciones)
            if (string.IsNullOrWhiteSpace(obj.Codigo))
            {
                Mensaje += "Es necesario ingresar el código del producto.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje += "Es necesario ingresar el nombre del producto.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje += "Es necesario ingresar la descripción del producto.\n";
            }
            if (obj.PrecioCompra < 0)
            {
                Mensaje += "El precio de compra no puede ser negativo.\n";
            }
            if (obj.PrecioVenta < 0)
            {
                Mensaje += "El precio de venta no puede ser negativo.\n";
            }

            // Si el mensaje ya no está vacío, significa que rompimos alguna regla
            if (Mensaje != string.Empty)
            {
                return 0; // Retornamos 0 para indicar que falló el registro
            }
            else
            {
                // Si todo está perfecto, le damos luz verde a la Capa de Datos
                return objcd_producto.Registrar(obj, out Mensaje);
            }
        }

        // ---------------------------------------------------------
        // 3. EDITAR PRODUCTO (Con Validaciones)
        // ---------------------------------------------------------
        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // 🛡️ REGLAS DE NEGOCIO (Las mismas validaciones que al registrar)
            if (string.IsNullOrWhiteSpace(obj.Codigo))
            {
                Mensaje += "Es necesario ingresar el código del producto.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje += "Es necesario ingresar el nombre del producto.\n";
            }
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje += "Es necesario ingresar la descripción del producto.\n";
            }
            if (obj.PrecioCompra < 0)
            {
                Mensaje += "El precio de compra no puede ser negativo.\n";
            }
            if (obj.PrecioVenta < 0)
            {
                Mensaje += "El precio de venta no puede ser negativo.\n";
            }

            // Si falló alguna validación
            if (Mensaje != string.Empty)
            {
                return false; // Retornamos false para cancelar la edición
            }
            else
            {
                // Luz verde a la Capa de Datos
                return objcd_producto.Editar(obj, out Mensaje);
            }
        }

        // ---------------------------------------------------------
        // 4. ELIMINAR PRODUCTO
        // ---------------------------------------------------------
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            // Para eliminar solo pasamos directo a la Capa de Datos
            return objcd_producto.Eliminar(obj, out Mensaje);
        }

        // ---------------------------------------------------------
        // 5. VALIDAR CÓDIGO DUPLICADO (El puente)
        // ---------------------------------------------------------
        public bool ExisteCodigo(string codigo, int idProducto)
        {
            // Le pedimos a la Capa de Datos que haga la consulta en SQL
            return objcd_producto.ExisteCodigo(codigo, idProducto);
        }
    }
}