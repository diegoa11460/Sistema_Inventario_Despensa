using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_inventario
{
    public partial class Form_Ver_detalle : Form
    {
        public Form_Ver_detalle()
        {
            InitializeComponent();
        }

        private void Form_Historial_Load(object sender, EventArgs e)
        {

        }

        private void btnVerVenta_Click(object sender, EventArgs e)
        {
            Form_DetalleVentas frmDetalle = new Form_DetalleVentas();

            // 2. Le decimos que aparezca centrado en la pantalla (Opcional, pero se ve mejor)
            frmDetalle.StartPosition = FormStartPosition.CenterParent;

            // 3. Lo mostramos en pantalla como ventana emergente
            frmDetalle.ShowDialog();
        }

        private void btnVerCompra_Click(object sender, EventArgs e)
        {
            // 1. Creamos una variable del formulario que queremos abrir
            Form_DetalleCompras frmDetalle = new Form_DetalleCompras();

            // 2. Le decimos que aparezca centrado en la pantalla (Opcional, pero se ve mejor)
            frmDetalle.StartPosition = FormStartPosition.CenterParent;

            // 3. Lo mostramos en pantalla como ventana emergente
            frmDetalle.ShowDialog();
        }
    }
}
