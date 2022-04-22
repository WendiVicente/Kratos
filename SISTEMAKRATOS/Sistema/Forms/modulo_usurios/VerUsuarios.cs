using CapaDatos.Models.Usuarios;
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

namespace Sistema.Forms.modulo_usurios
{
    public partial class VerUsuarios : BaseContext
    {
        private readonly RepositoryUsuarios _RepositoryUsuarios = null;
        public VerUsuarios()
        {
            InitializeComponent();
            _RepositoryUsuarios = new RepositoryUsuarios(_context);
        }

        private void VerUsuarios_Load(object sender, EventArgs e)
        {
           
            cargarDatagrid();
        }


        private void cargarDatagrid()
        {

            var listausuarios = _RepositoryUsuarios.GetlistaUsuarios();
            BindingSource recurso = new BindingSource();

                recurso.DataSource = listausuarios;
                dgvusuarios.DataSource = typeof(List<>);
                dgvusuarios.DataSource = recurso;
                dgvusuarios.AutoResizeColumns();
                // _listaCombos = lista;
            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvusuarios.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el usuario de la lista?", "Eliminar usuario",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog == DialogResult.Yes)
            {
                var usuarioselected = (User)dgvusuarios.CurrentRow.DataBoundItem;
                var userobtenido = _RepositoryUsuarios.Get(usuarioselected.Id);
                userobtenido.IsDeleted = true;
                _RepositoryUsuarios.Update(userobtenido);
                cargarDatagrid();

            }
        }
    }
}
