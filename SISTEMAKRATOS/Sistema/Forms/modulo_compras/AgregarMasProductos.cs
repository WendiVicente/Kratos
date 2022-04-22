using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using POS.Validations;
using sharedDatabase.Models.Compras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_compras
{
    public partial class AgregarMasProductos : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private  EditarSolicitud _editarSolicitud = null;
       /* private int codcol = 0;
        private int descripcol = 1;
        private int preciocol = 2;
        private int cantidadcol = 4;
        private int impuestocol = 4;
        private int baseimponilblecol = 5;
        private int subtotalcol = 6;
        private int idcol = 7;*/
        public AgregarMasProductos(EditarSolicitud editarSolicitud)
        {
            _editarSolicitud = editarSolicitud;
            _productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }

        public void CargarDgv()
        {

            var recargarLista = _editarSolicitud.AccesoProductoRepository();

            ListadoProductosC.ListaDeProductos = recargarLista.GetList(_editarSolicitud.sucursalId);

            BindingSource source = new BindingSource();
            source.DataSource = ListadoProductosC.ListaDeProductos;
            dgListaProductos.DataSource = typeof(List<>);
            dgListaProductos.DataSource = source;
            dgListaProductos.AutoResizeColumns();

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AddRowListaProductos();
            //_editarSolicitud.();
        }

        private void txtbuscarP_TextChanged(object sender, EventArgs e)
        {
            var ProductoBuscado = ListadoProductosC.ListaDeProductos;

            var filter = ProductoBuscado.Where(a => a.Descripcion.Contains(txtbuscarP.Text) ||
            (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscarP.Text)) ||
            (a.Categoria != null && a.Categoria.Contains(txtbuscarP.Text)) ||
            (a.Notas != null && a.Notas.Contains(txtbuscarP.Text)));
            dgListaProductos.DataSource = filter.ToList();
        }
        public void AddRowListaProductos()
        {
            if (dgListaProductos.Rows.Count == 0) return;
            if (dgListaProductos.CurrentRow == null) return;

            var produc = (ListarProductos)dgListaProductos.CurrentRow.DataBoundItem;
            var producto = ListadoProductosC.GetProducto(produc.CodigoReferencia);
            if (producto == null) return;

          // crea un nuevo objeto de tipo Detalle Compra
           
            CompraDetalleList nuevodetalle = new CompraDetalleList();
            var impuesto = 1.12M;
            nuevodetalle.Id = 0;
            nuevodetalle.Cantidad = 1;
            nuevodetalle.Precio = produc.Coste;
            nuevodetalle.Total = (produc.Coste * nuevodetalle.Cantidad);
            nuevodetalle.BaseImponible = decimal.Parse((nuevodetalle.Total / impuesto).ToString("0.00"));
            nuevodetalle.Impuesto = decimal.Parse((nuevodetalle.Total - nuevodetalle.BaseImponible).ToString("0.00"));
            nuevodetalle.Descripcion = produc.Descripcion;
            nuevodetalle.Referencia = produc.CodigoReferencia;
            nuevodetalle.productoId = produc.Id;
            
           // valido si el nuevo producto ya esta en la lista
            var resultado = _editarSolicitud.detalleListsObtenida.FirstOrDefault(s=> s.Referencia == nuevodetalle.Referencia);

            //cambio los datos y actualizo la lista del Form anterior
            if (resultado != null)
            {
                resultado.Cantidad += 1;
                resultado.Total = (produc.Coste * resultado.Cantidad);
                resultado.BaseImponible = decimal.Parse((resultado.Total / impuesto).ToString("0.00"));
                resultado.Impuesto = decimal.Parse((resultado.Total - resultado.BaseImponible).ToString("0.00"));
                _editarSolicitud.CargarPueba();
            }
            else
            {
                _editarSolicitud.detalleListsObtenida.Add(nuevodetalle);
                _editarSolicitud.CargarPueba();

            }

            _editarSolicitud.ActualizarLabelTotal();
            //_editarSolicitud.ListaProductSelect.CurrentRow.Cells[0].Selected = true;
            _editarSolicitud.ListaProductSelect.ClearSelection();
            txtbuscarP.Text = null;
        }

        private void AgregarMasProductos_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }

        private void kryptonHeaderGroup1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
