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

namespace Sistema.Forms.modulo_Caja
{
    public partial class VerCajas : BaseContext
    {
        private CajasRepository _cajasRepository = null;
        public int sucursalvalor =0;
        public int estadoCaja = 0;

        public VerCajas()
        {
            _cajasRepository = new CajasRepository(_context);
            InitializeComponent();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

            if (dgvcajas.CurrentRow == null)
            {
                return;
            }

            var caja = (ListarCaja)dgvcajas.CurrentRow.DataBoundItem;
            var GetCaja = _cajasRepository.Get(caja.Id_Transaccion);

            

            detalleCaja detalleCaja = new detalleCaja(GetCaja);
            detalleCaja.Show();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            sucursalvalor = 0;
            estadoCaja = 0;
            RefrescardgCajas(true);
            lbMostrarSucursal.Text = "Todas";
            lbestado.Text = "Sin Filtro";
        }

        private void btnBuscarSucursal_Click(object sender, EventArgs e)
        {
            FiltroSucursal filtroSucursal = new FiltroSucursal(this);
            filtroSucursal.Show();
        }

        private void btnfiltroestado_Click(object sender, EventArgs e)
        {
            FiltroEstado filtro = new FiltroEstado(this);
            filtro.Show();
        }

        private void VerCajas_Load(object sender, EventArgs e)
        {
            RefrescardgCajas();
        }


        public void RefrescardgCajas(bool loadNewContext = true)
        {

            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cajasRepository = null;
                _cajasRepository = new CajasRepository(_context);
            }


            var obtenercodcajaActiva = _cajasRepository.GetCajas(sucursalvalor, estadoCaja);
            BindingSource source = new BindingSource();
            source.DataSource = obtenercodcajaActiva;
            dgvcajas.DataSource = typeof(List<>);
            dgvcajas.DataSource = source;
            dgvcajas.AutoResizeColumns();
            //operaciones con las columnas y Labels
           



        }



    }
}
