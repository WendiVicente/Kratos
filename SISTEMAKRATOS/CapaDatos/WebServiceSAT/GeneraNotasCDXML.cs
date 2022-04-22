using CapaDatos.ListasPersonalizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApi;
using CapaDatos.Models;
using CapaDatos.Models.DocumentoSAT;

namespace CapaDatos.WebServiceSAT
{
    public class GeneraNotasCDXML
    {
        //public static IList<ListarDetalleFacturas> _listadetalle = null;
        //public static DocumentoCertificadoSAT CertificadoOrigen = null;
        public static Emisor emi = new EmisorFEL().emi;

        public static string XMLNotaCreditoFormat(RESPONSE cliente, IList<ListarDetalleFacturas> _listadetalle, DocumentoCertificadoSAT certificadoOrigen, string MotivoAjuste)
        {

            //datos del emisor
            string direccionEmisor = "CIUDAD";
            string codpostalEmisor = "0100";
            string muniEmisor = emi.DeptoEmisor;
            string DeptoEmisor = emi.muniEmisor;
            string paisEmisor = emi.paisEmisor;
            string nitemisor = emi.nitemisor;
            string nombreemisor = emi.nombreemisor;
            string codestable = "1";
            string namecomercial = emi.namecomercial;
            string tipoafiliacion = "GEN";

            //datos Receptor persona que compra
            string nombreReceptor = cliente.NOMBRE;
            string IdReceptor = cliente.NIT;
            string direccionReceptor = cliente.Direccion + "," + cliente.DEPARTAMENTO + "," + cliente.MUNICIPIO + "," + cliente.PAIS;
            string codpostalReceptor = "0100";
            string muniReceptor = cliente.MUNICIPIO;
            string DeptoReceptor = cliente.DEPARTAMENTO;
            string paisReceptor = cliente.PAIS;

            //namespaces for head xml

            //string uri = @"C:\Users\alexa\Desktop\Backup-proyectos\notaCreditoapp1.xml";
            var date = DateTime.Now;
            var url = "http://www.sat.gob.gt/dte/fel/0.2.0";
            var xsiurl = "http://www.w3.org/2001/XMLSchema-instance";
            var urlnocredito = "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0";
            var schemalocation = "http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0 GT_Complemento_Referencia_Nota-0.1.0.xsd";
            var ns = XNamespace.Get(url);
            var nscomplemento = XNamespace.Get(schemalocation);
            var nsNotaCredito = XNamespace.Get(urlnocredito);
            string version = "0.1";

            // datos del tipo de documento 
            var tipodoc = "NCRE";
            var tipomoneda = "GTQ";
            var numberAcces = "100000000";

            // ITEM AUN PENDIENTE
           
            string unitmedida = "CA";
            decimal descuentoitem = 0.0m;
           // decimal totalmontoimpuesto = (totaltosend * 12) / 100;


            var xDoc=
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "false"),
                    new XElement(ns + "GTDocumento",
                    new XAttribute("Version", version),
                    new XAttribute(XNamespace.Xmlns + "xsi", xsiurl),
                    new XAttribute(XNamespace.Xmlns + "dte", url),

                     new XElement(ns + "SAT", new XAttribute("ClaseDocumento", "dte"),
                           new XElement(ns + "DTE", new XAttribute("ID", "DatosCertificados"),
                               new XElement(ns + "DatosEmision", new XAttribute("ID", "DatosEmision"),

                                new XElement(ns + "DatosGenerales", new XAttribute("Tipo", tipodoc),
                                                                             new XAttribute("FechaHoraEmision", date.ToString("yyyy-MM-ddThh:mm:ss")),
                                                                             new XAttribute("CodigoMoneda", tipomoneda),
                                                                             new XAttribute("NumeroAcceso", numberAcces)
                                                                             ),
                                                 new XElement(ns + "Emisor", new XAttribute("NITEmisor", nitemisor),
                                                                             new XAttribute("NombreEmisor", nombreemisor),
                                                                             new XAttribute("CodigoEstablecimiento", codestable),
                                                                             new XAttribute("NombreComercial", namecomercial),
                                                                             new XAttribute("AfiliacionIVA", tipoafiliacion),

                                                              new XElement(ns + "DireccionEmisor",

                                                                                    new XElement(ns + "Direccion", direccionEmisor),
                                                                                     new XElement(ns + "CodigoPostal", codpostalEmisor),
                                                                                     new XElement(ns + "Municipio", muniEmisor),
                                                                                      new XElement(ns + "Departamento", DeptoEmisor),
                                                                                     new XElement(ns + "Pais", paisEmisor)
                                                                            )),

                                                  new XElement(ns + "Receptor", new XAttribute("NombreReceptor", nombreReceptor),
                                                                                  new XAttribute("IDReceptor", IdReceptor),
                                                               new XElement(ns + "DireccionReceptor",
                                                                                     new XElement(ns + "Direccion", direccionReceptor),
                                                                                     new XElement(ns + "CodigoPostal", codpostalReceptor),
                                                                                     new XElement(ns + "Municipio", muniReceptor),
                                                                                      new XElement(ns + "Departamento", DeptoReceptor),
                                                                                     new XElement(ns + "Pais", paisReceptor))
                                                               ),
                                                     new XElement(ns + "Items"),
                                                     new XElement(ns + "Totales" ),

                                                     new XElement(ns+ "Complementos",
                                                                        new XElement(ns + "Complemento",  new XAttribute("URIComplemento","cno"),
                                                                                                        new XAttribute("NombreComplemento", tipodoc),
                                                                                                            new XAttribute(XNamespace.Xmlns + "xsi", xsiurl),
                                                                                                            new XAttribute(XNamespace.Xmlns + "cno", urlnocredito),
                                                                                                            new XAttribute(nscomplemento + "schemaLocation", schemalocation),
                                                                                            new XElement(nsNotaCredito+"ReferenciasNota", new XAttribute("Version","0.1"),
                                                                                                                        new XAttribute("NumeroAutorizacionDocumentoOrigen", certificadoOrigen.Autorizacion ),
                                                                                                                            new XAttribute("FechaEmisionDocumentoOrigen",certificadoOrigen.Fecha_DTE.ToString("yyyy-MM-dd") ),
                                                                                                                            new XAttribute("MotivoAjuste", MotivoAjuste ),
                                                                                                                            new XAttribute("NumeroDocumentoOrigen", certificadoOrigen.NUMERO),
                                                                                                                            new XAttribute("SerieDocumentoOrigen", certificadoOrigen.Serie)
                                                                                                                    )       




                                                                                                    )
                                                                                     
                                                                                     
                                                                                     
                                                                                     
                                                                                     )




                                                     )))
                               )




                );




            int filanumero = 1;
            decimal totaliva = 0.00m;
            decimal totalfinal = 0.00m;


            foreach (var item in _listadetalle)
            {
                decimal ivaBase = 0.10714284m;
                decimal montoimpues = (ivaBase * item.PrecioTotal);
                decimal montoGrav = item.PrecioTotal - montoimpues;
                decimal montoTotal = item.Cantidad * item.Precio;
                totalfinal += montoTotal;
                totaliva += montoimpues;

                var xnodo = new XElement(ns + "Item", new XAttribute("NumeroLinea", filanumero.ToString()),
                                                                                    new XAttribute("BienOServicio", "B"),
                                                                                     new XElement(ns + "Cantidad", item.Cantidad.ToString()),
                                                                                     new XElement(ns + "UnidadMedida", unitmedida),
                                                                                     new XElement(ns + "Descripcion", item.Descripcion),
                                                                                     new XElement(ns + "PrecioUnitario", item.Precio.ToString()),
                                                                                     new XElement(ns + "Precio", montoTotal.ToString()),
                                                                                     new XElement(ns + "Descuento", descuentoitem.ToString()),
                                                                                     new XElement(ns + "Impuestos",
                                                                                         new XElement(ns + "Impuesto",
                                                                                                 new XElement(ns + "NombreCorto", "IVA"),
                                                                                                 new XElement(ns + "CodigoUnidadGravable", "1"),
                                                                                                 new XElement(ns + "MontoGravable", montoGrav.ToString()),
                                                                                                 new XElement(ns + "MontoImpuesto", montoimpues.ToString()))
                                                                                                     ),
                                                                                      new XElement(ns + "Total", montoTotal.ToString())
                                                                                     );


                XElement detallesFactura = xDoc.Descendants(ns + "Items").FirstOrDefault();
                if (detallesFactura != null)
                {
                    detallesFactura.Add(xnodo);
                }

                filanumero += 1;
            }

            XElement calculoIvatotal = xDoc.Descendants(ns + "Totales").FirstOrDefault();
            var nodoIVA = IvatotalGrantotal(ns, totaliva, totalfinal);
            if (calculoIvatotal != null)
            {
                calculoIvatotal.Add(nodoIVA);
            }

            XElement gettotalfinal = xDoc.Descendants(ns + "Totales").FirstOrDefault();
            var nodoTotalfinal = grantotalfinal(ns, totalfinal);
            if (gettotalfinal != null)
            {
                gettotalfinal.Add(nodoTotalfinal);
            }





            //xDoc.Save(uri);
            var stringxml = xDoc.ToString();

            return stringxml;







        }
        private static XElement IvatotalGrantotal(XNamespace ns, decimal montoimpuestoTotal, decimal granTotal)
        {
            var calculosiva = new XElement(ns + "TotalImpuestos",
                                                                  new XElement(ns + "TotalImpuesto", new XAttribute("NombreCorto", "IVA"),
                                                                                  new XAttribute("TotalMontoImpuesto", montoimpuestoTotal.ToString())));


            return calculosiva;
        }
        private static XElement grantotalfinal(XNamespace ns, decimal granTotal)
        {
            var totalfinal = new XElement(ns + "GranTotal", granTotal.ToString());

            return totalfinal;
        }


    }
}
