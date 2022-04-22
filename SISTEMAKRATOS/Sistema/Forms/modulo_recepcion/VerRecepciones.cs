using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_recepcion
{
    public partial class VerRecepciones : BaseContext
    {
        private RecepcionesRepository _recepcionesRepository = null;
        private ComprasRepository _comprasRepository = null;
        public int sucursalvalor = 0;
        public int estado = 0;

        public VerRecepciones()
        {
            _comprasRepository = new ComprasRepository(_context);
            _recepcionesRepository = new RecepcionesRepository(_context);
            InitializeComponent();
        }

        private void VerRecepciones_Load(object sender, EventArgs e)
        {

            RefrescarDataGridCompras();
            SetWidthDatagrid();
        }


        public void RefrescarDataGridCompras(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _recepcionesRepository = null;
                _recepcionesRepository = new RecepcionesRepository(_context);
            }

            BindingSource source = new BindingSource();
            var compras = _recepcionesRepository.GetListRecepciones(sucursalvalor, estado);
            source.DataSource = compras;
            dgvListaRecepciones.DataSource = typeof(List<>);
            dgvListaRecepciones.DataSource = source;
            dgvListaRecepciones.AutoResizeColumns();
            dgvListaRecepciones.Columns[1].Visible = false;
            dgvListaRecepciones.Columns[2].Visible = false;
            dgvListaRecepciones.Columns[5].Visible = false;
            // var suma = compras.Sum(a => a.total);
            // lbtotal.Text = suma.ToString();
            SetWidthDatagrid();
        }

        private void btnDetalleP_Click(object sender, EventArgs e)
        {
            if (dgvListaRecepciones.CurrentRow == null)
            {
                return;
            }

            var Recepcion = (ListarRecepciones)dgvListaRecepciones.CurrentRow.DataBoundItem;
            if (_comprasRepository.Get(Recepcion.SolicitudCompra) == null) return;
            var GetCompra = _comprasRepository.Get(Recepcion.SolicitudCompra);

            DetalleRecepcion childForm = new DetalleRecepcion(GetCompra,Recepcion, this); // me sirve para refrescar el dg cie el thiscunado regrese
            childForm.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            estado = 0;
            sucursalvalor = 0;
            lbfiltro.Text = "Todas";
            RefrescarDataGridCompras(true);
        }

        private void btnestado_Click(object sender, EventArgs e)
        {
            FiltroEstado buscarEstados = new FiltroEstado(this);
            //buscarEstados.MdiParent = this;
            buscarEstados.Show();
        }

        private void btnsucursal_Click(object sender, EventArgs e)
        {
            BuscarPorSucursales buscarEstados = new BuscarPorSucursales(this);
            //buscarEstados.MdiParent = this;
            buscarEstados.Show();
        }


        private void SetWidthDatagrid()
        {
            DataGridViewColumn colDescripcion = dgvListaRecepciones.Columns[3];
            DataGridViewColumn colprove = dgvListaRecepciones.Columns[4];
            DataGridViewColumn colestado = dgvListaRecepciones.Columns[6];
            DataGridViewColumn colReferencia = dgvListaRecepciones.Columns[0];
            colprove.Width = 200;
            colestado.Width = 200;
            colDescripcion.Width = 200;
            colReferencia.Width = 150;
        }

    }
}
