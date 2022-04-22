using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Personal;
using CapaDatos.Repository;
using CapaDatos.Repository.PersonalRepository;
using CapaDatos.Validation;
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

namespace Sistema.Forms.modulo_personal
{
    public partial class TrasladarPersonal : BaseContext
    {
        private PersonalRepository _personalRepository = null;
        private SucursalesRepository _sucursalesRepository = null;
        private List<Personal> ListaToChange = null;
        private readonly ModuloPersonal VerPersonal = null;
        public TrasladarPersonal(List<Personal> _listaPersonal,ModuloPersonal forms)
        {
            //ListaToChange = new List<ListarPersonal>();
            ListaToChange = _listaPersonal;
            VerPersonal = forms;
            _personalRepository = new PersonalRepository(_context);
            _sucursalesRepository = new SucursalesRepository(_context);
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
           // WindowState= FormWindowState.max
        }

        private void TrasladarPersonal_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
            CargarSucursales();
        }

        public void RefrescarDataGrid(bool LoadNewContext = true)
        {
            
            BindingSource source = new BindingSource();
            source.DataSource = ListaToChange;
            dgvPersonalLista.DataSource = typeof(List<>);
            dgvPersonalLista.DataSource = source;
            for (int i = 0; i < 28; i++)
            {
                dgvPersonalLista.Columns[i].Visible = false;
            }

            dgvPersonalLista.Columns[1].Visible = true;
            dgvPersonalLista.Columns[2].Visible = true;
            dgvPersonalLista.Columns[11].Visible = true;
          

        }
        private void CargarSucursales()
        {
            var sucursal = _sucursalesRepository.GetList();
            comboSucursal.DataSource = sucursal;
            comboSucursal.DisplayMember = "NombreSucursal";
            comboSucursal.ValueMember = "Id";
            comboSucursal.SelectedIndex = 0;
            comboSucursal.Invalidate();
        }

       
        private Personal GetViewModel(Personal persona)
        {

            return persona;
        }


            private void GuardarTraslado()
        {

            foreach (var item in ListaToChange)
            {
                var personaObtener = _personalRepository.Get(item.Id);
                var Getpersonal = GetViewModel(personaObtener);
                if (!ModelState.IsValid(Getpersonal)) { return; }
                
                Getpersonal.SucursalId= int.Parse(comboSucursal.SelectedValue.ToString());
                _personalRepository.Update(Getpersonal);
            }
        }



        private void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarTraslado();
            Close();
            VerPersonal._personalTochange.Clear();
        }
    }
}
