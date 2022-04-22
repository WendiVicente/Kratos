using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Repository;
using CapaDatos.WebServiceSAT;

using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using Microsoft.Reporting.WinForms;
using POS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS.Recibo
{

    public partial class ReciboCliente : BaseContext
    {

        private readonly FacturasRepository _facturasRepository = null;
        private readonly DetalleProductoRepository _detalleProductoRepository = null;
        private IList<ListarDetalleFacturas> listadetalles = null;
        private readonly DocumentoCertificadoSAT DocCertificado = null;
        private Guid idfactura;
        string numeroFactura = "";
        string _direccion = "";
       // decimal totaldesc = 0.00m;
        private String fechaemision;
        string direccioncliente="";
        private string direccion = "";
        private object cliente;
        
        public ReciboCliente(Guid idfac, DocumentoCertificadoSAT DocCertif, string direccion)
        {
            idfactura = idfac;
            DocCertificado = DocCertif;
            _facturasRepository = new FacturasRepository(_context);
            _detalleProductoRepository = new DetalleProductoRepository(_context);
          
           _direccion = direccion;
            fechaemision = DateTime.Now.ToString();
            InitializeComponent();
        }
        private void ReciboCliente_Load(object sender, EventArgs e)
        {
            CargarTabla();
            traerparametros();
            this.RvFelCarta.RefreshReport();
            
            
          
        }

        private void CargarTabla()
        {
            var encabezadoFactura = _facturasRepository.Get(idfactura);
            numeroFactura = encabezadoFactura.NoFactura;
            direccioncliente = encabezadoFactura.Direccion;
            var detallesproducto = _detalleProductoRepository.GetListNoDocumento(encabezadoFactura.NoFactura);
            listadetalles = _facturasRepository.GetDetallebyFactura(idfactura);

            IList<ListarDetalleFacturas> listado = new List<ListarDetalleFacturas>();
            if (detallesproducto.Count > 0)
            {
                foreach (var item in listadetalles)
                {
                    string detalles = "";
                    var details = detallesproducto.Where(x => x.ProductoId == item.ProductoId);
                    if (details.Count() > 0)
                    {
                        foreach (var detalle in details)
                        {
                            detalles = detalles + "\n" + " " + detalle.Cantidad + " " + detalle.Detalle;
                        }
                        detalles = item.Descripcion + "\n" + detalles;
                        item.Descripcion = detalles;
                        listado.Add(item);
                    }
                    else
                    {
                        listado.Add(item);
                    }
                }
            }
            else
            {
                listado = listadetalles;
            }

            
            //rvfacturafel.LocalReport.ReportEmbeddedResource = "POS.Recibo.FacturaFEL.rdlc";
            RvFelCarta.LocalReport.ReportEmbeddedResource = "POS.Recibo.ReciboClientes.rdlc";
            var rds1 = new ReportDataSource("DetalleFactura", listado);
            RvFelCarta.LocalReport.DataSources.Clear();
            RvFelCarta.LocalReport.DataSources.Add(rds1);

        }

       
        private void traerparametros()
        {
            
            decimal iva = 0.10714284m;
            var totaldesc = listadetalles.Sum(x => x.Descuento);
            
            var sumatotal = listadetalles.Sum(x => x.PrecioTotal);
            var direccionCl = _facturasRepository.Get(idfactura);
            var ivatotal = sumatotal * iva;
            string totalletras = Conversores.NumeroALetras((decimal)sumatotal);
          
            ReportParameterCollection reportParameters = new ReportParameterCollection
           
            {
                new ReportParameter("noautorizacion",DocCertificado.Autorizacion ),
                new ReportParameter("nombrecomprador",DocCertificado.NOMBRE_COMPRADOR),
                new ReportParameter("nitcomprador",DocCertificado.NIT_COMPRADOR),
                new ReportParameter("fechaemision",fechaemision),
                new ReportParameter("nombreeface", DocCertificado.NOMBRE_EFACE),
                new ReportParameter("niteface", DocCertificado.NIT_EFACE),
                new ReportParameter("ivatotal",ivatotal.ToString("0.0000")),
                new ReportParameter("totalfactura",sumatotal.ToString("0.00")),
                new ReportParameter("totaldescuento",totaldesc.ToString("0.00")),
                new ReportParameter("direccion", "Lote 18, manzana G, Residenciales Las Hojaracas, Zona 1, Mixco."),
                new ReportParameter("serie" ,DocCertificado.Serie),
                new ReportParameter("numero",DocCertificado.NUMERO),
                new ReportParameter("numeroFactura",numeroFactura),
                new ReportParameter("TotalLetras",totalletras),
                new ReportParameter("Direccioncliente",direccioncliente),
               
              new ReportParameter("imagenQr",Convert.ToBase64String(DocCertificado.QRImagen)),

            };
            RvFelCarta.LocalReport.EnableExternalImages = true;
            RvFelCarta.LocalReport.SetParameters(new ReportParameterCollection());
            RvFelCarta.LocalReport.SetParameters(reportParameters);
          
        }

        private void RvFelCarta_Load(object sender, EventArgs e)
        {

        }
    }
}
