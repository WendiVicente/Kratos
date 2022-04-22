using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas.PropiedadesLista;
using CapaDatos.Models.Proveedores;
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

namespace Sistema.Forms.modulo_proveedor
{
    public partial class ConfiguracionProveedor : BaseContext
    {
        PropiedadesRepository _propiedadesRepository = null;
        int estadoCambio = 0;
        int estadoRubro = 0;
        int estadoTipos = 0;
        public ConfiguracionProveedor()
        {
            _propiedadesRepository = new PropiedadesRepository(_context);
            InitializeComponent();
        }

        private void ConfiguracionProveedor_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
            limpiarFrecuencia.Visible = false;
            limpiarTipoProve.Visible = false;
            LimpiarRubro.Visible = false;
            RefrescarDataRubros();
            RefrescarDataTipos();

        }

        public void RefrescarDataGrid(bool LoadNewContext = true)
        {
          
            var listarFrecuencias = _propiedadesRepository.GetListFrecuencias();

            BindingSource source = new BindingSource();
            source.DataSource = listarFrecuencias;
            listaFrecuencia.DataSource = typeof(List<>);
            listaFrecuencia.DataSource = source;

        }
        // datagrid 
       
        public void RefrescarDataRubros(bool LoadNewContext = true)
        {
          
            var listarRubros = _propiedadesRepository.GetListRubros();

            BindingSource source = new BindingSource();
            source.DataSource = listarRubros;
            listaRubro.DataSource = typeof(List<>);
            listaRubro.DataSource = source;

        }

        // datagrid tipos de proveedores
        public void RefrescarDataTipos(bool LoadNewContext = true)
        {

            var listarTiposProve = _propiedadesRepository.GetListTipoProveedores();
            BindingSource source = new BindingSource();
            source.DataSource = listarTiposProve;
            listaTipoProveedor.DataSource = typeof(List<>);
            listaTipoProveedor.DataSource = source;

        }

        // nuevo y actualizacion de Frecuencia
        private Frecuencia GetFrecuenciaEdit(Frecuencia frecuencia)
        {
            frecuencia.Periodo = txtDescripFrecuencia.Text;
            frecuencia.IsActive = checkestadoFrecuenc.Checked;
            return frecuencia;
        }
        private Frecuencia GetFrecuenciaNuevo()
        {
            return new Frecuencia()
            {
                Periodo = txtDescripFrecuencia.Text,
                IsActive = checkestadoFrecuenc.Checked
            };
        }
        //fin 

        // nuevo y actualizacion de Rubro
        private Rubro GetRubroEdit(Rubro rubro)
        {
            rubro.Descripcion = txtdescripcionRubro.Text;
            rubro.IsActive = checkEstadoRubro.Checked;
            return rubro;
        }

        private Rubro GetRubroNuevo()
        {

            return new Rubro()
            {
                Descripcion = txtdescripcionRubro.Text,
                IsActive = checkEstadoRubro.Checked

            };


        }
        //fin 

        // nuevo y actualizacion de Tipos de proveedor
        private TipoProveedor GetTiposEdit(TipoProveedor tipoprove)
        {
            tipoprove.Descripcion = txtdescripTipoProv.Text;
            tipoprove.IsActive = checkEstadoTipo.Checked;
            return tipoprove;
        }

        private TipoProveedor GetTiposNuevo()
        {

            return new TipoProveedor()
            {
                Descripcion = txtdescripTipoProv.Text,
                IsActive = checkEstadoTipo.Checked

            };


        }
        //fin 

        //guardar Frecuencia 
        private void guardartipo()
        {
            if (estadoCambio == 0)
            {
                var modeloFre= GetFrecuenciaNuevo();
                if (String.IsNullOrEmpty(txtDescripFrecuencia.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar un nuevo Periodo"); return; }
                if (!ModelState.IsValid(modeloFre)) { return; }

                _propiedadesRepository.AddFrecuencia(modeloFre);

                RefrescarDataGrid(true);
            }
        }

        //guardar Rubro
        private void guardarRubro()
        {
            if (estadoRubro == 0)
            {
                var modeloRubro = GetRubroNuevo();
                if (String.IsNullOrEmpty(txtdescripcionRubro.Text)) 
                { KryptonMessageBox.Show("Campo Vacio, ingresar un nuevo rubro"); return; }
                if (!ModelState.IsValid(modeloRubro)) { return; }

                _propiedadesRepository.AddRubro(modeloRubro);

                RefrescarDataRubros(true);
            }
        }

        private void guardarTipoProveedor()
        {
            if (estadoTipos == 0)
            {
                var modeloTipos = GetTiposNuevo();
                if (String.IsNullOrEmpty(txtdescripTipoProv.Text)) 
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Tipo de proveedor"); return; }
                if (!ModelState.IsValid(modeloTipos)) { return; }

                _propiedadesRepository.AddTipoProveedor(modeloTipos);

                RefrescarDataTipos(true);
            }
        }



        private void btnGuardarFrecuenc_Click(object sender, EventArgs e)
        {
            guardartipo();
            LimpiarTxt();
        }
        private void btnguardarTipos_Click(object sender, EventArgs e)
        {
           guardarTipoProveedor();
            LimpiarTxtTipos();

        }
        private void btnguardarRubro_Click(object sender, EventArgs e)
        {
            guardarRubro();
            LimpiarTxtRubro();
        }

        private void btnActualizarFrecuen_Click(object sender, EventArgs e)
        {
            if (listaFrecuencia.CurrentRow == null)
            {
                return;
            }

            if (estadoCambio == 1)
            {
                var tipoRow = (ListarFrecuenciaP)listaFrecuencia.CurrentRow.DataBoundItem;
                var GetTipo = _propiedadesRepository.GetFrecuencia(tipoRow.Id);

                var modeloEditar = GetFrecuenciaEdit(GetTipo);
                if (String.IsNullOrEmpty(txtDescripFrecuencia.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar un Periodo"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }
                _propiedadesRepository.UpdateFrecuencia(modeloEditar);
                RefrescarDataGrid(true);
                LimpiarTxt();
            }

        }

        private void btnUpdateTipo_Click(object sender, EventArgs e)
        {
            if (listaTipoProveedor.CurrentRow == null)
            {
                return;
            }

            if (estadoTipos == 1)
            {
                var Row = (TipoProveedorListar)listaTipoProveedor.CurrentRow.DataBoundItem;
                var GetTipo = _propiedadesRepository.GetTipoProveedor(Row.Id);

                var modeloEditar = GetTiposEdit(GetTipo);
                if (String.IsNullOrEmpty(txtdescripTipoProv.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un tipo de proveedor"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }
                _propiedadesRepository.UpdateTipoProveedor(modeloEditar);
                RefrescarDataTipos(true);
                LimpiarTxtTipos();
            }

        }
        private void btnUpdateRubro_Click(object sender, EventArgs e)
        {
            if (listaRubro.CurrentRow == null)
            {
                return;
            }

            if (estadoRubro == 1)
            {
                var Row = (ListarRubros)listaRubro.CurrentRow.DataBoundItem;
                var GetRubro = _propiedadesRepository.GetRubro(Row.Id);

                var modeloEditar = GetRubroEdit(GetRubro);
                if (String.IsNullOrEmpty(txtdescripcionRubro.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Rubro"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }
                _propiedadesRepository.UpdateRubro(modeloEditar);
                RefrescarDataRubros(true);
                LimpiarTxtRubro();
            }

        }

        //limpiar datos de frecuencia
        private void LimpiarTxt()
        {
            txtcodFrecuencia.Text = "";
            txtDescripFrecuencia.Text = "";
            checkestadoFrecuenc.Checked = false;
        }
        //limpiar datos de Rubro
        private void LimpiarTxtRubro()
        {
            txtcodigoRubro.Text = "";
            txtdescripcionRubro.Text = "";
            checkEstadoRubro.Checked = false;
        }
        //limpiar datos de Rubro
        private void LimpiarTxtTipos()
        {
            txtcodigoTipoProv.Text = "";
            txtdescripTipoProv.Text = "";
            checkEstadoTipo.Checked = false;
        }

        private void listaFrecuencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxFrecuencia(listaFrecuencia.CurrentRow.Index);
            limpiarFrecuencia.Visible = true;
            estadoCambio = 1;
        }
        //seleccion de fila datagrid rubros
        private void listaRubro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxRubros(listaRubro.CurrentRow.Index);
            LimpiarRubro.Visible = true;
            estadoRubro = 1;
        }
        //seleecion fila tipos de proveedor
        private void listaTipoProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxTipos(listaTipoProveedor.CurrentRow.Index);
            limpiarTipoProve.Visible = true;
            estadoTipos = 1;
        }

        public void LlenarTextBoxFrecuencia(int IndiceDGV)
        {
            txtcodFrecuencia.Text = listaFrecuencia.Rows[IndiceDGV].Cells[0].Value.ToString();
            txtDescripFrecuencia.Text = listaFrecuencia.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (listaFrecuencia.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkestadoFrecuenc.Checked = false;

            }
            else
            {
                checkestadoFrecuenc.Checked = true;
            }
        }
        //llenado de rubros
        public void LlenarTextBoxRubros(int IndiceDGV)
        {
            txtcodigoRubro.Text = listaRubro.Rows[IndiceDGV].Cells[0].Value.ToString();
            txtdescripcionRubro.Text = listaRubro.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (listaRubro.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkEstadoRubro.Checked = false;

            }
            else
            {
                checkEstadoRubro.Checked = true;
            }
        }



        //llenado de textbox tipos de proveedor 
        public void LlenarTextBoxTipos(int IndiceDGV)
        {
            txtcodigoTipoProv.Text = listaTipoProveedor.Rows[IndiceDGV].Cells[0].Value.ToString();
            txtdescripTipoProv.Text = listaTipoProveedor.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (listaTipoProveedor.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkEstadoTipo.Checked = false;

            }
            else
            {
                checkEstadoTipo.Checked = true;
            }
        }



        private void limpiarFrecuencia_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
            estadoCambio = 0;

        }

        private void LimpiarRubro_Click(object sender, EventArgs e)
        {
            LimpiarTxtRubro();
            estadoRubro = 0;
        }
        private void limpiarTipoProve_Click(object sender, EventArgs e)
        {
            LimpiarTxtTipos();
            estadoTipos = 0;
        }



      
       

      

        private void page2_Click(object sender, EventArgs e)
        {
            RefrescarDataRubros();
        }

        private void ConfiguracionProveedor_Click(object sender, EventArgs e)
        {
          
            RefrescarDataTipos();
        }
    }
}
