using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using ComponentFactory.Krypton.Toolkit;
using sharedDatabase.Models;
using Sistema.Forms.modulo_combos;
using Sistema.Forms.modulo_producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public class BaseContext : KryptonForm
    {
        private bool _disposed = false;
        protected Context _context { get; set; }

        public BaseContext()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) _context.Dispose();
            _disposed = true;
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseContext));
            this.SuspendLayout();
            // 
            // BaseContext
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseContext";
            this.Load += new System.EventHandler(this.BaseContext_Load);
            this.ResumeLayout(false);

        }

        private void BaseContext_Load(object sender, EventArgs e)
        {

        }


        public void MenuPrincipal(Form formulario, bool cerrar = true)
        {
            if (Application.OpenForms["LayoutV2"] == null)
            {
                LayoutV2 menuPrincipal = new LayoutV2(UsuarioLogeadoSistemas.User);
                menuPrincipal.Show();
            }
            else
            {
                Application.OpenForms["LayoutV2"].Show();
                Application.OpenForms["LayoutV2"].Activate();
            }

            if (cerrar)
            {
                formulario.Close();
            }            
        }

        public void Precios(Form formulario, Producto prod=null )
        {
            if (Application.OpenForms["ModuloPrecios"] == null)
            {
                ModuloPrecios moduloPrecios = new ModuloPrecios(formulario, prod);
                moduloPrecios.Show();
            }
            else
            {
                Application.OpenForms["ModuloPrecios"].Activate();
            }
        }
        public void DetalleProducto(Form formulario, Producto prod = null)
        {
            if (Application.OpenForms["DetalleProductoForm"] == null)
            {
                //DetalleProductoForm detalleprof = new DetalleProductoForm(formulario, prod);
                //detalleprof.Show();
            }
            else
            {
                Application.OpenForms["DetalleProductoForm"].Activate();
            }
        }
       
        public void DetalleProductoPromo(Form formulario, Producto prod = null)
        {
            if (Application.OpenForms["ModuloPromos"] == null)
            {
                ModuloPromos detalleprof = new ModuloPromos(formulario, prod);
                detalleprof.Show();
            }
            else
            {
                Application.OpenForms["ModuloPromos"].Activate();
            }
        }
        //public void DetalleProductoVales(Form formulario, Producto prod = null)
        //{
        //    if (Application.OpenForms["ModuloVales"] != null)
        //    {
        //        ModuloVales detalleprovale = new ModuloVales(formulario, prod);
        //        detalleprovale.Show();
        //    }
        //    else
        //    {
        //        Application.OpenForms["ModuloVales"].Activate();
        //    }
        //}


        public void DetallesCombo(Form formulario, ListarCombos combo = null)
        {
            if (Application.OpenForms["DetalleCombo"] == null)
            {
                if(combo != null)
                {
                    DetallesCombo detalles = new DetallesCombo(formulario, combo);
                    detalles.Show();
                }
                else
                {
                    DetallesCombo detalles = new DetallesCombo(formulario);
                    detalles.Show();
                }
                
            }
            else
            {
                Application.OpenForms["DetalleCombo"].Activate();
            }
        }
    }
}
