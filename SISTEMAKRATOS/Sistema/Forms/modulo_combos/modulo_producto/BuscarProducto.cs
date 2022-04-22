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

namespace Sistema.Forms.modulo_producto
{
    public partial class BuscarProducto : BaseContext
    {
        private readonly ProductosRepository _productosRepository = null;
        private readonly KryptonDataGridView _listarproductos = null;
        public BuscarProducto(KryptonDataGridView datagrid)
        {

            _listarproductos = datagrid;
            _productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }
       
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var producto = _productosRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId);

            var filter = producto.Where(a => a.Categoria != null &&
            a.Categoria.Contains(txtbuscar.Text) ||
            (a.Descripcion != null && a.Descripcion.Contains(txtbuscar.Text)) ||
            (a.CodigoReferencia != null && a.CodigoReferencia.Contains(txtbuscar.Text)) ||
            (a.Ubicacion != null && a.Ubicacion.Contains(txtbuscar.Text)) ||
            (a.Notas != null && a.Notas.Contains(txtbuscar.Text))
           
            );
            _listarproductos.DataSource = filter.ToList();


        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {

        }


        // que se pueda buscar con
        // categoria, descripcion, codigo ref, ubicacion, notas nada mas okok
        // dale dale
        // como le 


    }
}
