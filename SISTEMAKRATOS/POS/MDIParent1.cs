using CapaDatos;
using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Usuarios;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using POS.Forms;
using POS.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS
{
    public partial class MDIParent1 : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        

        static int idCol = 0;
        static int descripcionCol = 1;
        static int descuentoCol = 2;
        static int precioVentaCol = 3;
        static int cantidadCol = 4;
        static int subtotalcol = 5;
        static int totalcol = 6;
        public MDIParent1(User user)
        {
            UsuarioLogeadoPOS.User = user;
            _productosRepository = new ProductosRepository(_context);
            ListadoProductos.ListaDeProductos = _productosRepository.GetList(UsuarioLogeadoPOS.User.SucursalId);
            
            InitializeComponent();
        }

        public ProductosRepository AccesoProductoRepository()
        {
            _context = null;
            _context = new Context();
            _productosRepository = null;
            _productosRepository = new ProductosRepository(_context);

            return _productosRepository;
        }



        private void ShowNewForm(object sender, EventArgs e)
        {
            if (ListaProductSelect.CurrentRow is null) return;

                List<string> ProductoSelected = new List<string>();

            foreach (DataGridViewCell item in ListaProductSelect.CurrentRow.Cells)
            {

                ProductoSelected.Add(item.Value.ToString());

            }


            Descuento childForm = new Descuento(ProductoSelected, ListaProductSelect.CurrentRow.Cells, this);
            //childForm.MdiParent = this;
            childForm.Show();
            
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
     
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            KryptonManager kryptonManager = new KryptonManager
            {
                GlobalPaletteMode = PaletteModeManager.SparklePurple
            };
            if (UsuarioLogeadoPOS.User == null)
            {
                KryptonMessageBox.Show("Login incorrecto, No puede acceder.");
                Close();
                return;
            }

            txtsucursal.Text = UsuarioLogeadoPOS.User.Sucursal.NombreSucursal;
            txtusuario.Text = UsuarioLogeadoPOS.User.Name;

            FontSizeDatagridView();
        }

        private void FontSizeDatagridView()
        {
            foreach (DataGridViewColumn c in ListaProductSelect.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 30F, GraphicsUnit.Pixel);
            }
        }

        private void kryptonTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var codigoReferencia = codReferencia.Text.Trim();
            var producto = ListadoProductos.GetProducto(codigoReferencia);
            var comprobarEnTabla = new ComprobarExistenciaEnTabla(ListaProductSelect);

            if (e.KeyCode == Keys.Enter)
            {
                if (producto == null) return;

                CargarDataGridView(producto, comprobarEnTabla.ComprobarProductoRepetidoFila(producto), true);
                ActualizarLabels();
                codReferencia.Text = null;
            }

        }

        // creo que aqui en este metodo seria mas conveniente
        // agregarlo
        // analicemos ok
        public void CargarDataGridView(ListarProductos productoCapturado, bool comprobacion, bool resetDescuento)
        {
            int ahorroCol = 2;
            int descuentoscol = 8;
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(ListaProductSelect);




            if (comprobacion)
            {
                foreach (DataGridViewRow r in ListaProductSelect.Rows)
                {
                    int cantidad = Convert.ToInt32(r.Cells[4].Value);

                    if (r.Cells[0].Value.ToString() == productoCapturado.CodigoReferencia)
                    {


                        if (cantidad < productoCapturado.Stock)
                        {
                            cantidad++;
                            r.Cells[4].Value = cantidad;
                            r.Cells[5].Value = Convert.ToDecimal(r.Cells[3].Value) * Convert.ToDecimal(r.Cells[4].Value);
                            r.Cells[6].Value = r.Cells[5].Value;
                        }
                        
                        if (resetDescuento) 
                        {
                            r.Cells[ahorroCol].Value = 0.00M;
                            r.Cells[descuentoscol].Value = 0;
                        }

                        return;

                    }
                }
            }

            row.Cells[0].Value = productoCapturado.CodigoReferencia;
            row.Cells[1].Value = productoCapturado.Descripcion;
            row.Cells[2].Value = 0.00M;
            row.Cells[3].Value = productoCapturado.PrecioVenta;
            row.Cells[4].Value = 1;
            row.Cells[5].Value = Convert.ToDecimal(row.Cells[3].Value) * Convert.ToDecimal(row.Cells[4].Value);
            row.Cells[6].Value = row.Cells[5].Value;
            row.Cells[7].Value = productoCapturado.Id;
            row.Cells[8].Value = 0;
            ListaProductSelect.Rows.Add(row);
        }
        public void ActualizarLabels()
        {
            decimal actualizarsubtotal = 0.00M;
            decimal actualizarPrecioTotal = 0.00M;
            decimal actualizarDescuentoTotal = 0.00M;

            //operacion actualizar total
            foreach (DataGridViewRow row in ListaProductSelect.Rows)
            {
                if (row.Cells[totalcol].Value != null)
                    actualizarPrecioTotal += (decimal)row.Cells[totalcol].Value;


            }
            LabelTotal.Text = actualizarPrecioTotal.ToString();

            //operacion actualizar subtotal
            foreach (DataGridViewRow row in ListaProductSelect.Rows)
            {
                if (row.Cells[subtotalcol].Value != null)
                    actualizarsubtotal += (decimal)row.Cells[subtotalcol].Value;


            }
            lsubtotal.Text = actualizarsubtotal.ToString();

            // operacion suma descuento
            foreach (DataGridViewRow row in ListaProductSelect.Rows)
            {
                if (row.Cells[descuentoCol].Value != null)
                    actualizarDescuentoTotal += (decimal)row.Cells[descuentoCol].Value;


            }


            ldescuento.Text = actualizarDescuentoTotal.ToString();


        }
        private void btnBuscarP_Click(object sender, EventArgs e)
        {

            AddProducto childForm = new AddProducto(this);
            childForm.Show();

        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {/*
            if (ListaProductSelect.CurrentRow == null) return;

            if (Application.OpenForms["Pago"] != null) return;
            //if (Controls.OfType<Pago>().Any()) return;

            Pago childForm = new Pago(this);
            childForm.Show();*/
        }

        public List<Detalle> GetDatosDetalle() //GetDatosDetalle
        {
            var List = new List<Detalle>();

            foreach (DataGridViewRow item in ListaProductSelect.Rows)
            {
                if (item == null)
                {
                    continue;
                }

                Detalle detalle = new Detalle
                {
                    Id = int.Parse(item.Cells[7].Value.ToString()),
                    ReferenciaProducto = item.Cells[idCol].Value.ToString(),
                    Descripcion = item.Cells[descripcionCol].Value.ToString(),
                    Descuento = decimal.Parse(item.Cells[descuentoCol].Value.ToString()),
                    Precio = decimal.Parse(item.Cells[precioVentaCol].Value.ToString()),
                    Cantidad = int.Parse(item.Cells[cantidadCol].Value.ToString()),
                    SubTotal = decimal.Parse(item.Cells[subtotalcol].Value.ToString()),
                    Total = decimal.Parse(item.Cells[totalcol].Value.ToString())
                };

                List.Add(detalle);
            }
            return List;
          
        }

        private void ListaProductSelect_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ActualizarLabels();
        }

        private void ListaProductSelect_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizarLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UsuarioLogeadoPOS.User.Name);
        }
    }
}
