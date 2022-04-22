using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
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
    public partial class VerCompras : BaseContext
    {
        private ComprasRepository _comprasRepository = null;
        private RecepcionesRepository _recepcionesRepository = null;
        public VerCompras()
        {
            _comprasRepository = new ComprasRepository(_context);
            _recepcionesRepository = new RecepcionesRepository(_context);
            InitializeComponent();
        }

        public void RefrescarDataGridCompras(bool loadNewContext = true,int numeroSucursal =0)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _comprasRepository = null;
                _comprasRepository = new ComprasRepository(_context);
            }

            BindingSource source = new BindingSource();
            var compras = _comprasRepository.GetListGenerales(numeroSucursal);
            source.DataSource = compras;
            listadodeSolicitudes.DataSource = typeof(List<>);
            listadodeSolicitudes.DataSource = source;
            listadodeSolicitudes.AutoResizeColumns();
            listadodeSolicitudes.Columns[3].Visible = false;
            var suma = compras.Sum(a => a.Total);
            tlbtotal.Text = suma.ToString();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            RefrescarDataGridCompras(true);
            base.OnLoad(e);
        }

        private void VerCompras_Load(object sender, EventArgs e)
        {

        }

     
       

       
        /*
        private void txtbuscarSolicitud_TextChanged(object sender, EventArgs e)
        {
            var comprabuscada = _comprasRepository.GetListGenerales(UsuarioLogeadoSistemas.User.SucursalId);

            var filter = comprabuscada.Where
            (a => a.NoComprobante.Contains(txtbuscarSolicitud.Text) ||
            (a.NombreVendedor != null && a.NombreVendedor.Contains(txtbuscarSolicitud.Text)) ||
            (a.Proveedor != null && a.Proveedor.Contains(txtbuscarSolicitud.Text)));
            listadodeSolicitudes.DataSource = filter.ToList();
        }
        */
        

      

     

      

        private void btnnueva_Click(object sender, EventArgs e)
        {
            SolicitudCompra solicitudCompra = new SolicitudCompra();
            //  solicitudCompra.MdiParent = this;
            solicitudCompra.Show();
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (listadodeSolicitudes.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar la Solicitud de la lista?", "Eliminar Solicitud",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);


            if (dialog == DialogResult.Yes)
            {
                var cancelado = "Cancelado";
                var compralista = (ListarCompras)listadodeSolicitudes.CurrentRow.DataBoundItem;
                var compraObtenida = _comprasRepository.Get(compralista.Id);
                //cambiar estado de Recepcion de Compra
                var recepcionObtenida = _recepcionesRepository.Get(compraObtenida.Id);
                var EstadoRecepcionObtenida = _recepcionesRepository.ObtenerEstadoId(cancelado);
                //cambiar estados
                compraObtenida.IsActive = true;
                
                if (recepcionObtenida != null && EstadoRecepcionObtenida !=null)
                {

                    recepcionObtenida.EstadoRecepcionId = EstadoRecepcionObtenida.Id;
                    _recepcionesRepository.Update(recepcionObtenida);
                }


                //guardamos cambios en compras y Recepciones
                _comprasRepository.Update(compraObtenida);


                RefrescarDataGridCompras(true);

            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (listadodeSolicitudes.CurrentRow == null)
            {
                return;
            }

            var compra = (ListarCompras)listadodeSolicitudes.CurrentRow.DataBoundItem;
            var Getcompra = _comprasRepository.Get(compra.Id);

            if (Getcompra != null)
            {
                //var ValidarEstadoRecepcion = _recepcionesRepository.Get(Getcompra.Id);

                //if (ValidarEstadoRecepcion.EstadoRecepcionId == ObtenerIdEstado("Hecho"))
                //{
                //    KryptonMessageBox.Show("La Recepcion de Esta Solicitud ya afecto el inventario!\n" +
                //                            "Deberá crear una nueva solicitud!");
                //    return;
                //}

                EditarSolicitud childForm = new EditarSolicitud(Getcompra, this); // me sirve para refrescar el dg cie el thiscunado regrese
                childForm.Show();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            lbMostrarSucursal.Text = "Todas";
            RefrescarDataGridCompras(true);
        }

        private void btnBuscarSucursal_Click(object sender, EventArgs e)
        {
            filtroSucursal childForm = new filtroSucursal(this); 
            childForm.Show();
        }

        private int ObtenerIdEstado(string EstadoBuscado)
        {
            var estadoRecepcion = _recepcionesRepository.ObtenerEstadoId(EstadoBuscado);
            var id = estadoRecepcion.Id;
            return id;
        }
    }
}
