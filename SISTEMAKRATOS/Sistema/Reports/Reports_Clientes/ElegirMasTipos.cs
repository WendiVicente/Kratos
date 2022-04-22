using CapaDatos.Models.Clientes;
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

namespace Sistema.Reports.Reports_Clientes
{
    public partial class ElegirMasTipos : BaseContext
    {
        private ClientesRepository _clientesRepository = null;
        private ReporteGeneralClientes _reporteGeneral = null;
        public ElegirMasTipos(ReporteGeneralClientes reporte)
        {
            _reporteGeneral = reporte;
               _clientesRepository = new ClientesRepository(_context);
            InitializeComponent();
        }

        private void btnaddTipos_Click(object sender, EventArgs e)
        {
            TiposSelected();
            Close();
        }

        private void ElegirMasTipos_Load(object sender, EventArgs e)
        {
            CargarTiposClientes();
        }


        private void CargarTiposClientes()
        {
           
            var tipos = _clientesRepository.GetTipos();
            var s = tipos.OrderBy(a => a.Id).ToList();
            cklistbox.DataSource = s;
            cklistbox.DisplayMember = "TipoCliente";
            cklistbox.ValueMember = "Id";
            cklistbox.Invalidate();
          
        }

        private void TiposSelected()
        {
            List<Tipos> Listacheckbox = new List<Tipos>();
              foreach (Tipos item in cklistbox.CheckedItems)
              {
                Listacheckbox.Add(item);
              }

            _reporteGeneral.TiposSeleccionadosLista = Listacheckbox;
            
        }
    }
}
