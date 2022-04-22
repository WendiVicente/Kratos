using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Repository;
using CapaDatos.Repository.DevolucionesRepository;
using CapaDatos.WebServiceSAT;
using ComponentFactory.Krypton.Toolkit;
using Newtonsoft.Json;
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
using WebApi;

namespace Sistema.Forms.modulo_devoluciones
{
    public partial class NotaCreditoFEL : BaseContext
    {
        private NotaCreditoVista _notaCreditoVista = null;
        private CertificadoSatRepository _certificadoSatRepository = null;
        private DocumentoCertificadoSAT _certificadoSAT = null;
        private ListarVentas _venta = null;
        private FacturasRepository _facturasRepository = null;
        private Factura _facturaActual = null;
        private NotaCreditoRepository _notaCreditoRepository = null;
        
        public NotaCreditoFEL(DocumentoCertificadoSAT certificadoSAT, ListarVentas venta, NotaCreditoVista _vista)
        {
            _venta = venta;
            _certificadoSAT = certificadoSAT;
            _facturasRepository = new FacturasRepository(_context);
            _notaCreditoRepository = new NotaCreditoRepository(_context);
            _certificadoSatRepository = new CertificadoSatRepository(_context);
            _notaCreditoVista = _vista;
            InitializeComponent();
        }

        private void NotaCreditoFEL_Load(object sender, EventArgs e)
        {
            cargarTXT();
            RefrescarDataGridDetalle(_venta);
        }

        private void cargarTXT()
        {
            if (_certificadoSAT != null)
            {
                txtnofactura.Text = _venta.NoFactura;
                txtnoAutorizacion.Text = _certificadoSAT.Autorizacion;
                txtnit.Text = _certificadoSAT.NIT_COMPRADOR;
                txtnombres.Text = _certificadoSAT.NOMBRE_COMPRADOR;
                txtfechaemision.Text = _certificadoSAT.Fecha_DTE.ToString();

            }
        }


        private void dgvdetalleFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFila(dgvdetalleFactura, 17);
            CreaListaDetallebyFactura(dgvdetalleFactura, 17);
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            validar();
        }


        private void RefrescarDataGridDetalle(ListarVentas venta)
        {
            var detalle = _facturasRepository.GetDetallebyFactura(venta.Id);
            BindingSource source = new BindingSource();
            source.DataSource = detalle;
            dgvdetalleFactura.DataSource = typeof(List<>);
            dgvdetalleFactura.DataSource = source;
            dgvdetalleFactura.Columns[0].Visible = false;
            dgvdetalleFactura.Columns[1].Visible = false;
            dgvdetalleFactura.Columns[2].Visible = false;
            dgvdetalleFactura.Columns[9].Visible = false;
            dgvdetalleFactura.Columns[10].Visible = false;
            dgvdetalleFactura.Columns[11].Visible = false;
            dgvdetalleFactura.Columns[12].Visible = false;
            dgvdetalleFactura.Columns[13].Visible = false;
            dgvdetalleFactura.Columns[14].Visible = false;
            dgvdetalleFactura.Columns[15].Visible = false;
            dgvdetalleFactura.Columns[16].Visible = false;



        }
        private void SeleccionarFila(DataGridView datagrid, int acciones)
        {
            bool estadoActual = Convert.ToBoolean(datagrid.CurrentRow.Cells[acciones].Value);
            if (estadoActual)
            {
                datagrid.CurrentRow.Cells[acciones].Value = false;
            }
            else
            {
                datagrid.CurrentRow.Cells[acciones].Value = true;

            }

        }

        private List<ListarDetalleFacturas> _listaDetallefact = null;
        private void CreaListaDetallebyFactura(DataGridView data, int colacciones)
        {
            if (data.RowCount <= 0) { return; }
            int filasSeleccion = 0;
            int contadorfila = 0;
            decimal total = 0;
            _listaDetallefact = new List<ListarDetalleFacturas>();
            foreach (DataGridViewRow Rows in data.Rows)
            {
                var filasTotales = int.Parse(data.RowCount.ToString());


                bool acciones = Convert.ToBoolean(Rows.Cells[colacciones].Value);
                if (!acciones)
                {
                    filasSeleccion += 1;
                }
                else

                {
                    total += decimal.Parse(Rows.Cells[8].Value.ToString());
                   // lbtotal.Text = "Q." + total.ToString();
                    var filaactual = (ListarDetalleFacturas)dgvdetalleFactura.Rows[contadorfila].DataBoundItem;
                    _listaDetallefact.Add(filaactual);
                }

                
                contadorfila++;
            }
        }


        private RESPONSE clientesx = null;
        private void validar()
        {
            var tokenObtenido=TokenPOST.GetToken();
            var clienteobtenidoSAT = ValidaClienteSat.GetClientbyNit(tokenObtenido, "321052");
            if (clienteobtenidoSAT == null) { return; }
            Root clienteSAT = JsonConvert.DeserializeObject<Root>(clienteobtenidoSAT);
            foreach (var item in clienteSAT.RESPONSE)
            {
               
                if (clienteSAT.RESPONSE == null)
                {
                    clientesx = null;
                    continue;
                   
                }
                else
                {
                    clientesx = new RESPONSE
                    {
                        NOMBRE = item.NOMBRE,
                        NIT = item.NIT,
                        DEPARTAMENTO = item.DEPARTAMENTO,
                        Direccion = item.Direccion,
                        MUNICIPIO = item.MUNICIPIO,
                        PAIS = item.PAIS,
                    };

                }
               

            }

            var xmlValidado = ValidarXML.EnviarXMLNCredito( clientesx, tokenObtenido, _certificadoSAT,_listaDetallefact,txtmotivo.Text);

           var DocCertificado = JsonConvert.DeserializeObject<DocumentoCertificadoSAT>(xmlValidado);
            if (DocCertificado == null) { return; }
            try
            {
                //  DocCertificado.FacturaId = guidFacturaid;
                //_certificadoSatRepository.add(DocCertificado);
                KryptonMessageBox.Show("listo listo");
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }





        }
        

    }
}
