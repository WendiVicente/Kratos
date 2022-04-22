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

namespace Sistema.Reports.Reports_Caja
{
    public partial class FiltroSucursal : BaseContext
    {
        private ReporteCajaAbierta _reporteCaja = null;
        private SucursalesRepository _sucursalesRepository = null;
        private CajasRepository _cajasRepository = null;
        public FiltroSucursal(ReporteCajaAbierta reporte)
        {
            _sucursalesRepository = new SucursalesRepository(_context);
            _reporteCaja = reporte;
            _cajasRepository = new CajasRepository(_context);
            InitializeComponent();
            CargarCombox();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (listsucursales.Items.Count <= 0) { KryptonMessageBox.Show("No hay ninguna sucursal"); return; }
           
            obtenercaja();

        }

        private void FiltroSucursal_Load(object sender, EventArgs e)
        {

        }
        private void CargarCombox()
        {
            var sucursal = _sucursalesRepository.GetList();

            // agregar nuevo item a la lista
            sucursal.Add(new ListarSucursales { Id = 0, NombreSucursal = "Todas" });
            var s = sucursal.OrderBy(a => a.Id).ToList();

            // mostrar datos en dgv
            listsucursales.DataSource = s;
            listsucursales.DisplayMember = "NombreSucursal";
            listsucursales.ValueMember = "Id";
            listsucursales.Text = "Seleccione una Sucursal"; // esto no jalo? no me jalo
            listsucursales.SelectedIndex = 0;
            listsucursales.Invalidate();
        }
      


        private void obtenercaja()
        {
         var  Caja  = _cajasRepository.GetCajaAperturada(Convert.ToInt32(listsucursales.SelectedValue.ToString()));

            _reporteCaja.idcajaAbierta = Caja.Id;
            _reporteCaja.nombreSucursal = listsucursales.Text;
            _reporteCaja.CargarTabla();
            _reporteCaja.cargarTextbox();
            _reporteCaja.reportViewer1.RefreshReport();

        }




    }
}
