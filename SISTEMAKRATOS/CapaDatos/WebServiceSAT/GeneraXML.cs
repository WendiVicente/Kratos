using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.DocumentoSAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApi;

namespace CapaDatos.WebServiceSAT
{
   public  class GeneraXML
    {
        public static IList<ListarDetalleFacturas> _listadetalle = null;
        public static Emisor emi = new EmisorFEL(1).emi;
        public static string XMLformato(RESPONSE cliente, IList<ListarDetalleFacturas> detalleFacturas)
        {


            _listadetalle = detalleFacturas;

            //datos del emisor
            //string direccionEmisor = "CIUDAD";
            //string codpostalEmisor = "0100";
            //string muniEmisor = "GUATEMALA";
            //string DeptoEmisor = "GUATEMALA";
            //string paisEmisor = "GT";

            //datos Receptor persona que compra
            string nombreReceptor = cliente.NOMBRE;
            string IdReceptor = cliente.NIT;
            string direccionReceptor = cliente.Direccion+","+cliente.DEPARTAMENTO+","+cliente.MUNICIPIO+","+cliente.PAIS;
            string codpostalReceptor = "0100";
            string muniReceptor = cliente.MUNICIPIO;
            string DeptoReceptor = cliente.DEPARTAMENTO;
            string paisReceptor = cliente.PAIS;

            // ITEM AUN PENDIENTE
            int cantidaditem = 10;
            string unitmedida = "CA";
            string descripcionitem = "papas ala francesa";
            decimal preciounitario = 3.13m;
            decimal preciototal = cantidaditem * preciounitario;
            decimal descuentoitem = 0.0m;
            decimal totaltosend = cantidaditem * preciounitario;
            decimal totalmontoimpuesto = (totaltosend * 12) / 100;



            //namespaces for head xml

            
            var date = DateTime.Today;
            var url = "http://www.sat.gob.gt/dte/fel/0.2.0";
            var xsiurl = "http://www.w3.org/2001/XMLSchema-instance";
            var ns = XNamespace.Get(url);
            string version = "0.1";



            var xDoc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "false"),
                    new XElement(ns + "GTDocumento",
                    new XAttribute("Version", "0.1"),
                    new XAttribute(XNamespace.Xmlns + "xsi", xsiurl),
                    new XAttribute(XNamespace.Xmlns + "dte", url),


                      new XElement(ns + "SAT", new XAttribute("ClaseDocumento", "dte"),
                           new XElement(ns + "DTE", new XAttribute("ID", "DatosCertificados"),
                               new XElement(ns + "DatosEmision", new XAttribute("ID", "DatosEmision"),

                                                  new XElement(ns + "DatosGenerales", new XAttribute("Tipo", "FACT"),
                                                                             new XAttribute("FechaHoraEmision", date.ToString("yyyy-MM-ddThh:mm:ss")),
                                                                             new XAttribute("CodigoMoneda", "GTQ")
                                                                             ),
                                                 new XElement(ns + "Emisor", new XAttribute("NITEmisor", emi.nitemisor),
                                                                             new XAttribute("NombreEmisor", emi.namecomercial),
                                                                             new XAttribute("CodigoEstablecimiento", emi.codestable),
                                                                             new XAttribute("NombreComercial", emi.namecomercial),
                                                                             new XAttribute("AfiliacionIVA", emi.tipoafiliacion),

                                                             new XElement(ns + "DireccionEmisor",

                                                                                    new XElement(ns + "Direccion", emi.direccionEmisor),
                                                                                     new XElement(ns + "CodigoPostal", emi.codpostalEmisor),
                                                                                     new XElement(ns + "Municipio", emi.muniEmisor),
                                                                                      new XElement(ns + "Departamento", emi.DeptoEmisor),
                                                                                     new XElement(ns + "Pais", emi.paisEmisor)
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

                                                     new XElement(ns + "Frases",
                                                     new XElement(ns + "Frase", new XAttribute("TipoFrase", "1"),
                                                                                    new XAttribute("CodigoEscenario", "1"))
                                                                    ),

                                                     new XElement(ns + "Items"
                                                                              ),
                                                     new XElement(ns + "Totales"
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
                if (item.Descuento > 0)
                {
                    montoTotal -= item.Descuento;
                    item.Precio = montoTotal / item.Cantidad;
                }
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


            //string uri = @"C:\SoftwareRedDowl\xml\prueba4.xml";
            //xDoc.Save(uri);
            var stringxml = xDoc.ToString() ;

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

        public static string FormatoAnularFel(DocumentoCertificadoSAT docToAnular,string motivo)
        {

           
            var date = DateTime.Today;
            var url = "http://www.sat.gob.gt/dte/fel/0.1.0";
            var xsiurl = "http://www.w3.org/2001/XMLSchema-instance";
            var ns = XNamespace.Get(url);
            //var niteface = "86689126";
            string version = "0.1";



            var xDocAnular =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "false"),
                    new XElement(ns + "GTAnulacionDocumento",
                    new XAttribute("Version", version),
                    new XAttribute(XNamespace.Xmlns + "xsi", xsiurl),
                    new XAttribute(XNamespace.Xmlns + "dte", url),


                      new XElement(ns + "SAT",
                           new XElement(ns + "AnulacionDTE", new XAttribute("ID", "DatosCertificados"),


                                                  new XElement(ns + "DatosGenerales",
                                                                             new XAttribute("ID", "DatosAnulacion"),
                                                                             new XAttribute("NumeroDocumentoAAnular", docToAnular.Autorizacion),  //date.ToString("yyyy-MM-ddThh:mm:ss")
                                                                             new XAttribute("NITEmisor", emi.nitemisor),
                                                                             new XAttribute("IDReceptor", docToAnular.NIT_COMPRADOR),
                                                                             new XAttribute("FechaEmisionDocumentoAnular", docToAnular.Fecha_DTE),
                                                                             new XAttribute("FechaHoraAnulacion", date.ToString("yyyy-MM-ddThh:mm:ss")),
                                                                             new XAttribute("MotivoAnulacion", motivo)
                                                                            )
                                                  )
                           )
                      )
                    );

            //string uri = @"C:\SoftwareRedDowl\xml\AnularFEL.xml";
            //xDocAnular.Save(uri);
            var stringxml = xDocAnular.ToString();

            return stringxml;
        }

    }
}
