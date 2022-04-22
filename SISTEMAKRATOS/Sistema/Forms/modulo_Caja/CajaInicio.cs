using CapaDatos.Data;
using CapaDatos.Repository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models.Caja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_Caja
{
    public partial class CajaInicio : BaseContext
    {
        private CajasRepository _cajasRepository = null;
       // private string UsuarioLogeado = UsuarioLogeadoSistemas.User.Name;
        private int Sucursalid = UsuarioLogeadoSistemas.User.SucursalId;
        Layout _layoutpadre = null;
        public CajaInicio(Layout layoutforms)
        {
            _layoutpadre = layoutforms;
            _cajasRepository = new CajasRepository(_context);
            InitializeComponent();
        }

        private void btnabrir_Click(object sender, EventArgs e)
        {
            var listaCajasAper = _cajasRepository.GetCajaAperturada(Sucursalid, true);



            if (Application.OpenForms["AperturarCaja"] == null)
            {

                if (listaCajasAper ==null)
                {
                    //AperturarCaja aperturarCaja = new AperturarCaja(this);
                    aperturarCaja.Show();
                }
               else
                { KryptonMessageBox.Show("ya tiene una caja aperturada "); }

            }

             else { Application.OpenForms["AperturarCaja"].Activate(); }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            VerCajas verCajas = new VerCajas();
            verCajas.Show();
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            RefrescardgCajaActiva();
          
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //CerrarCaja();
            abrircancelacion();
            //RefrescardgCajaActiva();
            //lbtotalcerrar.Text = "0.00";
            //lbtotalinicio.Text = "0.00";
        }


        private void abrircancelacion()
        {
            if (Application.OpenForms["CierreCaja"] == null)
            {
                if (_cajasRepository.GetCajaAperturada(Sucursalid, true) == null) { KryptonMessageBox.Show("¿No tiene niguna Caja Aperturada?"); return; }

                var obtenercodcajaActiva = _cajasRepository.GetCajaAperturada(Sucursalid, true);

                // CierreCaja aperturarCaja = new CierreCaja(this, obtenercodcajaActiva,_layoutpadre);
                CajaDesinerNew cierrecaja = new CajaDesinerNew(this, obtenercodcajaActiva, _layoutpadre);
                cierrecaja.MdiParent = _layoutpadre;
                cierrecaja.Show();
            

            }

            else { Application.OpenForms["CierreCaja"].Activate(); }
        }
        public void RefrescardgCajaActiva(bool loadNewContext = true)
        {

            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cajasRepository = null;
                _cajasRepository = new CajasRepository(_context);
            }

          
            if (_cajasRepository.GetCajaAperturada(Sucursalid, true) == null) { return; }

            var obtenercodcajaActiva = _cajasRepository.GetCajaAperturada(Sucursalid, true);
                var codigoobtenido = obtenercodcajaActiva.Id;
                var obtenerDetalle = _cajasRepository.GetDetalleCaja(codigoobtenido);
                BindingSource source = new BindingSource();
                source.DataSource = obtenerDetalle;
                dgvDetalleCajaActiva.DataSource = typeof(List<>);
                dgvDetalleCajaActiva.DataSource = source;
                dgvDetalleCajaActiva.AutoResizeColumns();
            // ocultar columnas idcompra idfacturas idcaja
            dgvDetalleCajaActiva.Columns[1].Visible = false;
            dgvDetalleCajaActiva.Columns[2].Visible = false;
            dgvDetalleCajaActiva.Columns[3].Visible = false;
            //operaciones con las columnas y Labels
            var egresos = obtenerDetalle.Sum(a => a.Egreso);
            var efectivototal = obtenerDetalle.Sum(a => a.Efectivo);
            var chequestotal = obtenerDetalle.Sum(a => a.Cheques);
            var tarjetaDebitototal = obtenerDetalle.Sum(a => a.TarjetaDebito);
            var tarjetaCreditototal = obtenerDetalle.Sum(a => a.TarjetaCredito);
            var ingresos = (efectivototal + chequestotal + tarjetaCreditototal + tarjetaDebitototal);
            lbtotalcerrar.Text = (ingresos - egresos).ToString();
            lbtotalinicio.Text = obtenercodcajaActiva.MontoApertura.ToString();

                

        }


        // modelo a enviar de caja
       

        //funcion para cerrar caja
       

        private void btningresoadicional_Click(object sender, EventArgs e)
        {
            validarCaja();
        }

        private void btnegresosadicional_Click(object sender, EventArgs e)
        {
            var listaCajasAper = _cajasRepository.GetCajaAperturada(Sucursalid, true);

            if (listaCajasAper != null)
            {
                EgresoExtra egresoadd = new EgresoExtra(listaCajasAper, this);
                egresoadd.Show();
            }
            else
            { KryptonMessageBox.Show("No hay Caja Aperturada"); }
        }


        private void validarCaja()
        {
            var listaCajasAper = _cajasRepository.GetCajaAperturada(Sucursalid, true);

                if (listaCajasAper != null)
                {
                     IngresoExtra ingresoadd= new IngresoExtra(listaCajasAper, this);
                      ingresoadd.Show();
                }
                else
                { KryptonMessageBox.Show("No hay Caja Aperturada"); }

            

          

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            RefrescardgCajaActiva(true);
        }

    }
}
