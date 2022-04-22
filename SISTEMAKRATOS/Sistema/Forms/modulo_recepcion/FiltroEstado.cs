using CapaDatos.Models.Recepciones;
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
    public partial class FiltroEstado : BaseContext
    {
        private RecepcionesRepository _recepcionesRepository = null;
        private readonly VerRecepciones _verRecepciones = null;
        public FiltroEstado(VerRecepciones verRecepciones)
        {
            _verRecepciones = verRecepciones;
            _recepcionesRepository = new RecepcionesRepository(_context);
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbestados.Items.Count <= 0) { return; }
            _verRecepciones.lbfiltro.Text = cbestados.Text;
            var valorCombobox = cbestados.SelectedValue.ToString();
            _verRecepciones.estado = Convert.ToInt32(valorCombobox);
            _verRecepciones.RefrescarDataGridCompras(true );
        }

        private void FiltroEstado_Load(object sender, EventArgs e)
        {
            var estadosRecepcion = _recepcionesRepository.SearchByState();

            //agragar item a la listada
            EstadoRecepcion estadonuevo = new EstadoRecepcion();
            estadonuevo.Id = 0;
            estadonuevo.Estado = "Todas";
            estadosRecepcion.Add(estadonuevo);

            var s = estadosRecepcion.OrderBy(a => a.Id).ToList();

            // mostrar datos en dgv
            cbestados.DataSource = s;
            cbestados.DisplayMember = "Estado";
            cbestados.ValueMember = "Id";
            cbestados.Text = "Seleccione un Estado"; // esto no jalo? no me jalo
            cbestados.SelectedIndex = 0;
            cbestados.Invalidate();
        }
    }
}
