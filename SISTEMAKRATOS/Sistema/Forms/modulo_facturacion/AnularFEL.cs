using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.DocumentoSAT;
using CapaDatos.Repository;
using CapaDatos.WebServiceSAT;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Reporting.WinForms;
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

namespace Sistema.Forms.modulo_facturacion
{
    public partial class AnularFEL : BaseContext
    {
        private readonly Form _formpadre = null;
        private readonly FacturasRepository _facturasRepository = null;
        private readonly ProductosRepository _productosRepository = null;
        private readonly CertificadoSatRepository _certificadoSatRepository = null;
        private readonly TallasyColoresRepository _tallasyColoresRepository = null;
        private readonly ProductosReservaRepository _productosReservaRepository = null;
        private readonly CombosRepository _combosRepository = null;
        private readonly ColoresRepository _coloresRepository = null;
        private readonly TallasRepository _tallasRepository = null;
        private IList<ListarDetalleFacturas> listadetalles = null;
        private string numeroFel;
        private DocumentoCertificadoSAT documentoToAnular = null;
        private TokenSAT TokenObtenidoSat;
        public AnularFEL(Form form)
        {
            _formpadre = form;
            _combosRepository = new CombosRepository(_context);
            _tallasRepository = new TallasRepository(_context);
            _coloresRepository = new ColoresRepository(_context);
            _facturasRepository = new FacturasRepository(_context);
            _productosRepository = new ProductosRepository(_context);
            _tallasyColoresRepository = new TallasyColoresRepository(_context);
            _certificadoSatRepository = new CertificadoSatRepository(_context);
            _productosReservaRepository = new ProductosReservaRepository(_context);
            
            InitializeComponent();
        }

        private void AnularFEL_Load(object sender, EventArgs e)
        {
            txtanular.Visible = false;
            btnAnular.Visible = false;
            System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
            TokenObtenidoSat = JsonConvert.DeserializeObject<TokenSAT>(TokenPOST.GetToken());

            this.rvFacturaFEL.RefreshReport();

        }


        private void CargarTabla(Guid idfactura)
        {
            listadetalles = _facturasRepository.GetDetallebyFactura(idfactura);

            rvFacturaFEL.LocalReport.ReportEmbeddedResource = "Sistema.Forms.modulo_facturacion.AnularFEL.rdlc";
            var rds1 = new ReportDataSource("detallefactura", listadetalles);
            rvFacturaFEL.LocalReport.DataSources.Clear();
            rvFacturaFEL.LocalReport.DataSources.Add(rds1);

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnumerofel.Text)) { return; }
            var certificadotoAnular = _certificadoSatRepository.Get(txtnumerofel.Text.Trim());
            if (certificadotoAnular == null) { KryptonMessageBox.Show("Numero de Factura no encontrado en la base de datos!!"); return; }
            documentoToAnular = certificadotoAnular;
            CargarTabla(certificadotoAnular.FacturaId);
            traerparametros(certificadotoAnular);
            this.rvFacturaFEL.RefreshReport();

        }


        private void traerparametros(DocumentoCertificadoSAT CertiToAnular)
        {
            decimal iva = 0.10714284m;
            var sumatotal = listadetalles.Sum(x => x.PrecioTotal);
            var direccionCl = _facturasRepository.Get(CertiToAnular.FacturaId);
            var ivatotal = sumatotal * iva;

            ReportParameterCollection reportParameters = new ReportParameterCollection
            {
                new ReportParameter("noautorizacion",CertiToAnular.Autorizacion ),
                new ReportParameter("nombrecomprador",CertiToAnular.NOMBRE_COMPRADOR),
                  new ReportParameter("nitcomprador",CertiToAnular.NIT_COMPRADOR),
                   new ReportParameter("direcomprador",direccionCl.Direccion),
                new ReportParameter("serie" ,CertiToAnular.Serie),
                new ReportParameter("numero",CertiToAnular.NUMERO),
                 new ReportParameter("nombreeface", CertiToAnular.NOMBRE_EFACE),
                  new ReportParameter("niteface", CertiToAnular.NIT_EFACE),
                new ReportParameter("ivatotal",ivatotal.ToString("0.0000")),
                new ReportParameter("totalfactura",sumatotal.ToString("0.00"))

            };
            rvFacturaFEL.LocalReport.SetParameters(reportParameters);

        }

        private void checkAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAnular.Checked == true)
            {
                txtanular.Visible = true;
                btnAnular.Visible = true;
            }
            else
            {
                txtanular.Visible = false;
                btnAnular.Visible = false;


            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {   
            string motivo = "";
            if (string.IsNullOrEmpty(txtanular.Text)) { KryptonMessageBox.Show("Motivo Obligatorio, por favor llene el campo:"); return; }

            motivo = txtanular.Text;
           var xmlRespuesa= ValidarXML.EnviarXmlAnularFel(TokenObtenidoSat.Token, documentoToAnular, motivo);
            var AnulacionCerti = JsonConvert.DeserializeObject<AnulacionCertificado>(xmlRespuesa);
            if (AnulacionCerti == null) { return; }
           
                _certificadoSatRepository.addAnulacion(AnulacionCerti);
            foreach (var item in listadetalles)
            {
                
                RollbackProductos(item, true);
            }

            AbrirAnulacionCerti(AnulacionCerti);
              //  KryptonMessageBox.Show("Certificado anulado! Autorización:" + AnulacionCerti.Autorizacion);
         
        }


        private void AbrirAnulacionCerti(AnulacionCertificado CertiAnulado)
        {
            if (Application.OpenForms["RespuestaAnularFel"] == null)
            {
                RespuestaAnularFel vale = new RespuestaAnularFel(CertiAnulado);
                //vale.MdiParent = this;
                vale.Show();
            }
            else
            {
                Application.OpenForms["RespuestaAnularFel"].Activate();
            }
        }

        
            public bool RollbackProductos(ListarDetalleFacturas detallefactura, bool save = false)
            {
                Producto producto = new Producto();
                if (detallefactura.ProductoId != 0)
                {
                    producto = _productosRepository.Get(detallefactura.ProductoId);
                    if (producto.StockControl == true)
                    {
                        if (producto.TieneColor == false && producto.TieneTalla == false)
                        {
                                    if (save)
                                    {
                                        producto.Stock += detallefactura.Cantidad;
                                        _productosRepository.Update(producto);
                                        return true;
                                    }

                                   
                               
                        }//descuento en tabla DetalleColors
                        else if (producto.TieneColor == true && producto.TieneTalla == false)
                        {
                            var listaobtenidaDetalleColor = _coloresRepository.GetProductoListaColor(producto.Id);
                            var detalleColorToLess = listaobtenidaDetalleColor.Where(x => x.Id == detallefactura.DetalleColorId).FirstOrDefault();

                                    if (save)
                                    {
                                        detalleColorToLess.Stock += detallefactura.Cantidad;
                                        _coloresRepository.Update(detalleColorToLess);
                                        producto.Stock += detallefactura.Cantidad;
                                        _productosRepository.Update(producto);
                                        return true;
                                    }

                        }//Resta en tabla DetalleTalla stock 
                        else if (producto.TieneColor == false && producto.TieneTalla == true)
                        {
                            var listTallabyProducto = _tallasRepository.GetTallaListaProducto(producto.Id);
                            var detalleTallaToLess = listTallabyProducto.Where(x => x.Id == detallefactura.DetalleTallaId).FirstOrDefault();

                                    if (save)
                                    {
                                        detalleTallaToLess.Stock += detallefactura.Cantidad;
                                        _tallasRepository.Update(detalleTallaToLess);
                                        producto.Stock += detallefactura.Cantidad;
                                        _productosRepository.Update(producto);
                                        return true;
                                    }
                        }
                        else if (producto.TieneColor == true && producto.TieneTalla == true)
                        {
                            var tallasyColores = _tallasyColoresRepository.GetTallaColorListaProducto(producto.Id);
                            var colorytallatoLess = tallasyColores.Where(x => x.Id == detallefactura.TallayColorId).FirstOrDefault();

                                    if (save)
                                    {
                                        colorytallatoLess.Stock += detallefactura.Cantidad;
                                        _tallasyColoresRepository.Update(colorytallatoLess);
                                        producto.Stock += detallefactura.Cantidad;
                                        _productosRepository.Update(producto);
                                        return true;
                                    }
                                   
                        }

                    }



                }
                else
                {
                    var comboToLess = _combosRepository.Get(detallefactura.ComboId);
                   
                        if (save)
                        {
                            comboToLess.Stock += detallefactura.Cantidad;
                            _combosRepository.Update(comboToLess);
                            return true;
                        }
                      
                }

                return false;

            }
        

    }
}
