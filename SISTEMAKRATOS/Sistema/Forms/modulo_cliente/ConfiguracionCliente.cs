using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Clientes;
using CapaDatos.Repository;
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

namespace Sistema.Forms.modulo_cliente
{
    public partial class ConfiguracionCliente : BaseContext
    {
        public TiposClienteRepository _tiposRepository = null;
        private int estadoCambio = 0;
        private int estadoCategoria = 0;
        public ConfiguracionCliente()
        {
            InitializeComponent();
        }



        public void RefrescarDataGrid(bool LoadNewContext = true)
        {

            if (LoadNewContext)
            {
                _context = null;
                _context = new Context();
                _tiposRepository = null;
                _tiposRepository = new TiposClienteRepository(_context);
            }

            var listaTipos = _tiposRepository.GettiposCliente();

            BindingSource source = new BindingSource();
            source.DataSource = listaTipos;
            dgvTiposCliente.DataSource = typeof(List<>);
            dgvTiposCliente.DataSource = source;

        }

        public void RefrescarDataGridCategoria(bool LoadNewContext = true)
        {

            if (LoadNewContext)
            {
                _context = null;
                _context = new Context();
                _tiposRepository = null;
                _tiposRepository = new TiposClienteRepository(_context);
            }

            var listaCategoria = _tiposRepository.GetCategoria();

            BindingSource source = new BindingSource();
            source.DataSource = listaCategoria;
            dgvCategorias.DataSource = typeof(List<>);
            dgvCategorias.DataSource = source;

        }
        private Tipos GetViewModelEdit(Tipos tipo)
        {
            tipo.TipoCliente = txttipocliente.Text;
            tipo.IsActive = checkEstado.Checked;
            return tipo;
        }

        private Tipos getmodeltipos()
        {

            return new Tipos()
            {
                TipoCliente = txttipocliente.Text,
                IsActive= checkEstado.Checked
                
            };


        }

        //************** Modelos de Catengoria

        private CategoriaCliente GetmodeloCategoria(CategoriaCliente categoria)
        {
            categoria.Categoria = txtcategoria.Text;
            categoria.IsActive = checkestadocate.Checked;
            return categoria;
        }

        private CategoriaCliente GetmodeloNewCategoria()
        {

            return new CategoriaCliente()
            {
                Categoria = txtcategoria.Text,
                IsActive = checkestadocate.Checked

            };


        }
        //************* fin 

        private void guardartipo()
        {
            if (estadoCambio == 0)
            {
                var modeloTipo = getmodeltipos();
                if (String.IsNullOrEmpty(txttipocliente.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar un nuevo Tipo"); return; }
                if (!ModelState.IsValid(modeloTipo)) { return; }

                _tiposRepository.AddTipos(modeloTipo);

                RefrescarDataGrid(true);
            } 
        }
        //funcion guardar Categoria

        private void GuardarCategoria()
        {
            if (estadoCategoria == 0)
            {
                var modeloCategoria = GetmodeloNewCategoria();
                if (String.IsNullOrEmpty(txtcategoria.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar una nueva categoria"); return; }
                if (!ModelState.IsValid(modeloCategoria)) { return; }

                _tiposRepository.AddCategoriaCliente(modeloCategoria);

                RefrescarDataGridCategoria(true);
            }
        }


        private void ConfiguracionCliente_Load(object sender, EventArgs e)
        {
            RefrescarDataGrid();
            RefrescarDataGridCategoria();
            lblimpiar.Visible = false;
            lbcatelimpiar.Visible = false;
        }

        private void btnguardartipo_Click(object sender, EventArgs e)
        {
        //estadoCambio = 0;
            guardartipo();
            LimpiarTxt();
        }

        private void btnGuardarCate_Click(object sender, EventArgs e)
        {
           // estadoCategoria = 0;
            GuardarCategoria();
            LimpiarTxtcategorias();
        }

        private void btneditartipo_Click(object sender, EventArgs e)
        {
            if (dgvTiposCliente.CurrentRow == null)
            {
                return;
            }

            if (estadoCambio == 1)
            {
                var tipoRow = (ListaDeTiposCliente)dgvTiposCliente.CurrentRow.DataBoundItem;
                var GetTipo = _tiposRepository.GetTipo(tipoRow.Id);

                var modeloEditar = GetViewModelEdit(GetTipo);
                if (String.IsNullOrEmpty(txttipocliente.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar un nuevo Tipo"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }
                _tiposRepository.UpdateTipos(modeloEditar);
                RefrescarDataGrid(true);
                LimpiarTxt();
            }

        }
        private void btnActualizarCate_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                return;
            }
            if (estadoCategoria == 1)
            {
                var tipoRow = (ListaDeCategoriaCliente)dgvCategorias.CurrentRow.DataBoundItem;
                var GetTipo = _tiposRepository.GetCategoria(tipoRow.Id);

                var modeloEditar = GetmodeloCategoria(GetTipo);
                if (String.IsNullOrEmpty(txtcategoria.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar una categoria"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }

                _tiposRepository.UpdateCategoria(modeloEditar);

                RefrescarDataGridCategoria(true);
                LimpiarTxtcategorias();

            }
        }


            public  void LlenarTextBox(int IndiceDGV)
        {
            lbcodigo.Text = dgvTiposCliente.Rows[IndiceDGV].Cells[0].Value.ToString();
            txttipocliente.Text = dgvTiposCliente.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (dgvTiposCliente.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkEstado.Checked = false;

            }
            else
            {
                checkEstado.Checked = true;
            }
            
           

        }
        public void LlenarTextBoxCategoria(int IndiceDGV)
        {
            kryptonLabel3.Text = dgvCategorias.Rows[IndiceDGV].Cells[0].Value.ToString();
            txtcategoria.Text = dgvCategorias.Rows[IndiceDGV].Cells[1].Value.ToString(); //tipo de cliente

            if (dgvCategorias.Rows[IndiceDGV].Cells[2].Value.ToString() == "Activa")
            {
                checkestadocate.Checked = false;

            }
            else
            {
                checkestadocate.Checked = true;
            }



        }

        private void dgvTiposCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBox(dgvTiposCliente.CurrentRow.Index);
            lblimpiar.Visible = true;
            estadoCambio = 1;
        }
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxCategoria(dgvCategorias.CurrentRow.Index);
            lbcatelimpiar.Visible = true;
            estadoCategoria = 1;
        }

        private void LimpiarTxt()
        {
            lbcodigo.Text = "";
            txttipocliente.Text = "";
            checkEstado.Checked = false;
        }

        private void LimpiarTxtcategorias()
        {
            kryptonLabel3.Text = "";
            txtcategoria.Text = "";
            checkestadocate.Checked = false;
        }
        private void lblimpiar_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void lblimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
            estadoCambio = 0;
        }

        private void lbcatelimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTxtcategorias();
            estadoCategoria = 0;
        }

        private void kryptonPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
