using ComponentFactory.Krypton.Toolkit;
using CapaDatos.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSv2
{
    public partial class BaseContext : KryptonForm
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
            this.SuspendLayout();
            // 
            // BaseContext
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "BaseContext";
            this.Load += new System.EventHandler(this.BaseContext_Load);
            this.ResumeLayout(false);

        }

        private void BaseContext_Load(object sender, EventArgs e)
        {

        }
    }
}
