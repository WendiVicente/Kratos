using CapaDatos.Data;
using CapaDatos.Models.DocumentoSAT;
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

namespace Sistema.Forms.modulo_facturacion
{
    public partial class ListarAnulaciones : BaseContext
    {
        private CertificadoSatRepository _certificadoSatRepository = null;
        private List<AnulacionCertificado> _listaAnular = null;
        public ListarAnulaciones()
        {
            _certificadoSatRepository = new CertificadoSatRepository(_context);
            
            InitializeComponent();
        }

        private void ListarAnulaciones_Load(object sender, EventArgs e)
        {
            _listaAnular = _certificadoSatRepository.GetListaAnulaciones();
            RefrescarDataGridAnulaciones(_listaAnular);
        }

        public void RefrescarDataGridAnulaciones(List<AnulacionCertificado> lista,bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _certificadoSatRepository = null;
                _certificadoSatRepository = new CertificadoSatRepository(_context);
            }

            BindingSource source = new BindingSource();
            // var clientes = _clientesRepository.GetList(filtroid);
            source.DataSource = lista;
           //dgvanulaciones.DataSource = typeof(List<>);
            dgvanulaciones.DataSource = source;
            dgvanulaciones.Columns[0].Visible = false;
            dgvanulaciones.Columns[1].Visible = false;
            dgvanulaciones.Columns[3].Visible = false;
            dgvanulaciones.Columns[4].Visible = false;
            dgvanulaciones.Columns[5].Visible = false;
            dgvanulaciones.Columns[6].Visible = false;
            dgvanulaciones.Columns[7].Visible = false;
            dgvanulaciones.AutoResizeColumns();
         //   dgvanulaciones.Columns[0].Visible = false;


        }

    }
}
