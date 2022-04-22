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

namespace Sistema.Forms.modulo_promos
{
    public partial class VerDetallePromo : BaseContext
    {
        private PromocionRepository _promocionRepository = null;
       // private VerPromos _verpromos = null;
        private ListarPromocion _promocionrecibida = null;
        private CombosRepository _combosRepository = null;
        public VerDetallePromo(ListarPromocion listarPromocion)
        {
            _promocionRepository = new PromocionRepository(_context);
            _combosRepository = new CombosRepository(_context);
            _promocionrecibida = listarPromocion;
            InitializeComponent();
        }

        private void VerDetallePromo_Load(object sender, EventArgs e)
        {
            cargarTxt();
            CargarDataGrid();
        }

        private void cargarTxt()
        {
            txtdescripcion.Text = _promocionrecibida.Descripcion;
            txtfechainicio.Text = _promocionrecibida.FechaInicio.ToString();
            txtfechafin.Text = _promocionrecibida.FechaFin.ToString();
            txthorainicio.Text = _promocionrecibida.FechaInicio.ToString();
            txthorafin.Text = _promocionrecibida.HoraFin.ToString();


        }
        
        private void CargarDataGrid()
        {

            BindingSource source = new BindingSource();
            var promocion = _promocionRepository.GetlistDetallePromocion(_promocionrecibida.Id);
            var combos = _combosRepository.ListaReporte();
            foreach (var item in promocion)
            {
                var detallebuscado = combos.Where(x => x.Id == item.ComboId).FirstOrDefault();
                if (detallebuscado != null)
                {
                    item.NombreCombo = detallebuscado.Descripcion;

                }

            }
            source.DataSource = promocion;
            dgvDetallePromos.DataSource = typeof(List<>);
            dgvDetallePromos.DataSource = source;

            dgvDetallePromos.Columns[0].Visible = false;
            dgvDetallePromos.Columns[6].Visible = false;
            dgvDetallePromos.Columns[7].Visible = false;
            dgvDetallePromos.Columns[5].Visible = false;
            dgvDetallePromos.Columns[8].Visible = false;
            dgvDetallePromos.AutoResizeColumns();
           
        }


    }
}
