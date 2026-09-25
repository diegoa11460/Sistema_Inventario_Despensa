using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Sistema_inventario
{
    public partial class Form_Inicio : Form
    {
        private readonly CN_Inicio objCNInicio = new CN_Inicio();
        private readonly CN_Reportes objCNReportes = new CN_Reportes();

        private const int DIAS_ALERTA_VENCIMIENTO = 30;
        private const int TOP_STOCK_BAJO = 5;
        private const int TOP_MAS_VENDIDOS = 3;

        // Fonts reutilizados en vez de crear una instancia nueva por cada label/refresco
        // (evita ir acumulando handles de GDI en refrescos frecuentes).
        private static readonly Font FontItem = new Font("Segoe UI", 8.5F);
        private static readonly Font FontItemNegrita = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        private static readonly Font FontVacio = new Font("Segoe UI", 8.5F, FontStyle.Italic);

        // Errores acumulados durante una pasada de CargarDatos, para mostrar un solo aviso
        // en vez de un MessageBox por cada sección que falle.
        private readonly List<string> erroresCarga = new List<string>();

        public Form_Inicio()
        {
            InitializeComponent();

            // La barra de totales se re-centra cada vez que cambia de ancho (por el Anchor
            // que la estira con la ventana) y también después de cargar datos, porque el
            // texto de categorías/clientes cambia de longitud según los valores reales.
            pnlTotalProductos.Resize += (s, e) => CentrarBarraTotales();
        }

        // =========================================================
        // CENTRA el contenido de la barra "Total de Productos" dentro
        // del panel, sin importar su ancho actual ni el largo del texto.
        // =========================================================
        private void CentrarBarraTotales()
        {
            if (pnlTotalProductos.Controls.Count == 0) return;

            int izquierda = int.MaxValue;
            int derecha = int.MinValue;

            foreach (Control c in pnlTotalProductos.Controls)
            {
                if (c.Left < izquierda) izquierda = c.Left;
                if (c.Right > derecha) derecha = c.Right;
            }

            int anchoContenido = derecha - izquierda;
            int desplazamiento = (pnlTotalProductos.Width - anchoContenido) / 2 - izquierda;

            // Evita que el contenido se salga del panel si la ventana queda muy angosta
            if (desplazamiento < 0) desplazamiento = 0;

            foreach (Control c in pnlTotalProductos.Controls)
            {
                c.Left += desplazamiento;
            }
        }

        // Único handler de Load. Si en el Designer siguen enganchados Form_Inicio_Load
        // y Form_Inicio_Load_1 al mismo evento, dejar solo uno apuntando a este método
        // y quitar el otro handler del Designer (y su suscripción en InitializeComponent).
        private async void Form_Inicio_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            await CargarDatosAsync();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            try
            {
                await CargarDatosAsync();
            }
            finally
            {
                btnActualizar.Enabled = true;
            }
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            var cultura = new System.Globalization.CultureInfo("es-ES");
            if (lblFechaHora != null)
            {
                lblFechaHora.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy  HH:mm:ss", cultura);
            }
        }

        // =========================================================
        // CARGA GENERAL DEL PANEL (asíncrona, no bloquea la UI)
        // =========================================================
        private async Task CargarDatosAsync()
        {
            erroresCarga.Clear();

            await CargarResumenAsync();
            await CargarInventarioPorCategoriaAsync();
            await CargarProductosRecientesAsync();
            await CargarVentasSemanaAsync();
            await CargarStockCriticoAsync();
            await CargarMasVendidosAsync();
            await CargarVencimientosAsync();

            // El texto de "N categorías" / "N clientes" puede cambiar de largo
            // según los datos reales, así que se re-centra después de cargarlos.
            CentrarBarraTotales();

            if (erroresCarga.Count > 0)
            {
                MessageBox.Show(
                    "No se pudieron cargar algunas secciones del panel:" + Environment.NewLine + Environment.NewLine
                    + string.Join(Environment.NewLine, erroresCarga),
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // =========================================================
        // GRÁFICO DE BARRAS: VENTAS DE LA SEMANA (Lun - Dom)
        // =========================================================
        private async Task CargarVentasSemanaAsync()
        {
            string mensaje = null;
            List<EVentaSemanal> lista = null;

            await Task.Run(() => lista = objCNReportes.ObtenerVentasSemana(out mensaje));

            if (!string.IsNullOrEmpty(mensaje))
            {
                erroresCarga.Add("Ventas de la semana: " + mensaje);
                return;
            }

            chartVentasSemana.Series["VentasSemana"].Points.Clear();

            for (int i = 0; i < lista.Count; i++)
            {
                int idx = chartVentasSemana.Series["VentasSemana"].Points.AddXY(i, lista[i].Total);
                chartVentasSemana.Series["VentasSemana"].Points[idx].AxisLabel = lista[i].DiaSemana.Substring(0, 3);
            }
        }

        // =========================================================
        // LISTA: STOCK CRÍTICO (Top 5 Bajo)
        // =========================================================
        private async Task CargarStockCriticoAsync()
        {
            string mensaje = null;
            List<EStockCritico> lista = null;

            await Task.Run(() => lista = objCNReportes.ObtenerStockCritico(out mensaje));

            if (!string.IsNullOrEmpty(mensaje))
            {
                erroresCarga.Add("Stock crítico: " + mensaje);
                return;
            }

            flpListaStockBajo.Controls.Clear();

            if (lista.Count == 0)
            {
                flpListaStockBajo.Controls.Add(CrearLabelVacio("Sin alertas de stock bajo"));
                return;
            }

            foreach (EStockCritico item in lista.Take(TOP_STOCK_BAJO))
            {
                flpListaStockBajo.Controls.Add(CrearLabelItem(string.Format(
                    "{0}  -  Stock: {1}  (mín: {2})", item.Producto, FormatCantidad(item.Stock), FormatCantidad(item.StockMinimo))));
            }
        }

        // =========================================================
        // LISTA: MÁS VENDIDOS (Top 3, mes actual)
        // =========================================================
        private async Task CargarMasVendidosAsync()
        {
            string mensaje = null;
            List<EProductoVendido> lista = null;
            int mes = DateTime.Now.Month;
            int anio = DateTime.Now.Year;

            await Task.Run(() => lista = objCNReportes.ObtenerMasVendidos(mes, anio, out mensaje, TOP_MAS_VENDIDOS));

            if (!string.IsNullOrEmpty(mensaje))
            {
                erroresCarga.Add("Más vendidos: " + mensaje);
                return;
            }

            flpListaMasVendidos.Controls.Clear();

            if (lista.Count == 0)
            {
                flpListaMasVendidos.Controls.Add(CrearLabelVacio("Sin ventas registradas este mes"));
                return;
            }

            foreach (EProductoVendido item in lista)
            {
                flpListaMasVendidos.Controls.Add(CrearLabelItem(string.Format(
                    "{0}  -  {1} vendidos", item.Producto, FormatCantidad(item.CantidadVendida))));
            }
        }

        // =========================================================
        // LISTA: CONTROL DE VENCIMIENTOS
        // =========================================================
        private async Task CargarVencimientosAsync()
        {
            string mensaje = null;
            List<EVencimiento> lista = null;

            await Task.Run(() => lista = objCNReportes.ObtenerVencimientos(DIAS_ALERTA_VENCIMIENTO, out mensaje));

            if (!string.IsNullOrEmpty(mensaje))
            {
                erroresCarga.Add("Vencimientos: " + mensaje);
                return;
            }

            flpListaVencimientos.Controls.Clear();

            if (lista.Count == 0)
            {
                flpListaVencimientos.Controls.Add(CrearLabelVacio("Sin productos por vencer"));
                return;
            }

            foreach (EVencimiento item in lista)
            {
                int dias = (item.FechaVencimiento.Date - DateTime.Now.Date).Days;
                string textoUrgencia;
                Color color;
                bool negrita;

                if (dias < 0)
                {
                    textoUrgencia = string.Format("VENCIDO hace {0} día(s)", Math.Abs(dias));
                    color = Color.FromArgb(178, 34, 34);
                    negrita = true;
                }
                else if (dias == 0)
                {
                    textoUrgencia = "Vence HOY";
                    color = Color.FromArgb(178, 34, 34);
                    negrita = true;
                }
                else if (dias <= 3)
                {
                    textoUrgencia = string.Format("Vence en {0} día(s)", dias);
                    color = Color.FromArgb(200, 45, 45);
                    negrita = true;
                }
                else if (dias <= 7)
                {
                    textoUrgencia = string.Format("Vence en {0} día(s)", dias);
                    color = Color.FromArgb(200, 140, 0);
                    negrita = false;
                }
                else
                {
                    textoUrgencia = string.Format("Vence: {0:dd/MM/yyyy}", item.FechaVencimiento);
                    color = Color.FromArgb(55, 50, 90);
                    negrita = false;
                }

                string texto = string.Format("{0}  -  {1}  -  Lote {2}  -  Cant: {3}",
                    item.Producto, textoUrgencia, item.NroLote, FormatCantidad(item.Cantidad));

                flpListaVencimientos.Controls.Add(CrearLabelItem(texto, color, negrita));
            }
        }

        // =========================================================
        // TARJETAS KPI + TOTALES
        // =========================================================
        private async Task CargarResumenAsync()
        {
            string mensaje = null;
            ResumenInicio resumen = null;

            await Task.Run(() => resumen = objCNInicio.ObtenerResumen(out mensaje));

            if (!string.IsNullOrEmpty(mensaje))
            {
                erroresCarga.Add("Resumen: " + mensaje);
                return;
            }

            lblGananciaMesValor.Text = "Gs. " + resumen.GananciaMes.ToString("N0");
            lblVendidoHoyValor.Text = "Gs. " + resumen.VendidoHoy.ToString("N0");
            lblValorInventarioValor.Text = "Gs. " + resumen.ValorInventario.ToString("N0");
            lblTotalProductosValor.Text = resumen.TotalProductos.ToString();
            lblTotalCategoriasValor.Text = resumen.TotalCategorias.ToString() + " categorías";
            lblTotalClientesValor.Text = resumen.TotalClientes.ToString() + " clientes";
        }

        // =========================================================
        // GRÁFICO DE DONA: INVENTARIO POR CATEGORÍA
        // =========================================================
        private async Task CargarInventarioPorCategoriaAsync()
        {
            string mensaje = null;
            List<CategoriaInventario> lista = null;

            await Task.Run(() => lista = objCNInicio.ObtenerInventarioPorCategoria(out mensaje));

            if (!string.IsNullOrEmpty(mensaje))
            {
                erroresCarga.Add("Inventario por categoría: " + mensaje);
                return;
            }

            chartInventario.Series["Categorias"].Points.Clear();
            chartInventario.Series["Categorias"]["PieLabelStyle"] = "Disabled";

            if (lista.Count == 0)
            {
                chartInventario.Series["Categorias"].Points.AddXY("Sin datos", 1);
            }
            else
            {
                foreach (CategoriaInventario item in lista)
                {
                    chartInventario.Series["Categorias"].Points.AddXY(item.Descripcion, item.StockTotal);
                }
            }
        }

        // =========================================================
        // LISTA: PRODUCTOS RECIÉN AÑADIDOS
        // =========================================================
        private async Task CargarProductosRecientesAsync()
        {
            string mensaje = null;
            List<Producto> lista = null;

            await Task.Run(() => lista = objCNInicio.ObtenerProductosRecientes(5, out mensaje));

            if (!string.IsNullOrEmpty(mensaje))
            {
                erroresCarga.Add("Productos recientes: " + mensaje);
                return;
            }

            flpListaRecientes.Controls.Clear();

            if (lista.Count == 0)
            {
                flpListaRecientes.Controls.Add(CrearLabelVacio("Sin productos recientes"));
                return;
            }

            foreach (Producto producto in lista)
            {
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Font = FontItem;
                lbl.ForeColor = Color.FromArgb(55, 50, 90);
                lbl.Text = string.Format("{0}  ({1})  -  Stock: {2}  -  Gs. {3:N0}",
                    producto.Nombre, producto.oCategoria.Descripcion, FormatCantidad(producto.Stock), producto.PrecioVenta);
                flpListaRecientes.Controls.Add(lbl);
            }
        }

        private Label CrearLabelVacio(string texto)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = FontVacio;
            lbl.ForeColor = Color.FromArgb(150, 150, 160);
            lbl.Text = texto;
            return lbl;
        }

        private Label CrearLabelItem(string texto)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = FontItem;
            lbl.ForeColor = Color.FromArgb(55, 50, 90);
            lbl.Text = texto;
            return lbl;
        }

        private Label CrearLabelItem(string texto, Color color, bool negrita = false)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = negrita ? FontItemNegrita : FontItem;
            lbl.ForeColor = color;
            lbl.Text = texto;
            return lbl;
        }

        // Quita los decimales cuando son ",00" (ej: 4.00 -> "4", 4.50 -> "4,50")
        private string FormatCantidad(decimal valor)
        {
            return valor == Math.Truncate(valor) ? valor.ToString("N0") : valor.ToString("0.##");
        }
    }
}