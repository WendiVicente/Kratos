using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class CategoriaProducto : BaseContext
    {
        private CategoriaProdRepository _categoriaRepository = null;
        private int estadoCategoria = 0;
        public CategoriaProducto()
        {
            InitializeComponent();
            RefrescarDataGrid();
        }

        private void lbcatelimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTxtcategorias();
            estadoCategoria = 0;
        }

        private void checkestadocate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarCate_Click(object sender, EventArgs e)
        {
            GuardarCategoria();
            LimpiarTxtcategorias();
        }

        private void btnActualizarCate_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                return;
            }
            if (estadoCategoria == 1)
            {
                var tipoRow = (ListarCategoriaProd)dgvCategorias.CurrentRow.DataBoundItem;
                var GetCateg = _categoriaRepository.GetCategoria(tipoRow.Id);

                var modeloEditar = GetmodeloCategoria(GetCateg);
                if (String.IsNullOrEmpty(txtcategoria.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar una categoria"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }

                _categoriaRepository.Update(modeloEditar);

                RefrescarDataGrid(true);
                LimpiarTxtcategorias();

            }
        }
        public void RefrescarDataGrid(bool LoadNewContext = true)
        {

            if (LoadNewContext)
            {
                _context = null;
                _context = new Context();
                _categoriaRepository = null;
                _categoriaRepository = new CategoriaProdRepository(_context);
            }

            var listaTipos = _categoriaRepository.GetListcategoria();

            BindingSource source = new BindingSource();
            source.DataSource = listaTipos;
            dgvCategorias.DataSource = typeof(List<>);
            dgvCategorias.DataSource = source;

        }
        private Categoria GetmodeloCategoria(Categoria categoria)
        {
            categoria.Nombre = txtcategoria.Text;
            categoria.Inactivo = checkestadocate.Checked;
            return categoria;
        }

        private Categoria GetmodeloNewCategoria()
        {

            return new Categoria()
            {
                Nombre = txtcategoria.Text,
                Inactivo = checkestadocate.Checked

            };


        }
        //************* fin 

        private void GuardarCategoria()
        {
            if (estadoCategoria == 0)
            {
                var modeloCategoria = GetmodeloNewCategoria();
                if (String.IsNullOrEmpty(txtcategoria.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar una nueva categoria"); return; }
                if (!ModelState.IsValid(modeloCategoria)) { return; }

                _categoriaRepository.Add(modeloCategoria);

                RefrescarDataGrid(true);
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

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarTextBoxCategoria(dgvCategorias.CurrentRow.Index);
            lbcatelimpiar.Visible = true;
            estadoCategoria = 1;

        }

        private void LimpiarTxtcategorias()
        {
            kryptonLabel3.Text = "";
            txtcategoria.Text = "";
            checkestadocate.Checked = false;
        }

        private void CategoriaProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
