using CapaDatos.Data;
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

namespace Sistema.Forms.modulo_Bancos
{
    public partial class VerCuentas : BaseContext
    {
        CuentasRepository _cuentasRepository = null;
        public VerCuentas()
        {
            _cuentasRepository = new CuentasRepository(_context);
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void VerCuentas_Load(object sender, EventArgs e)
        {
            RefrescarDataGridProductos();
        }
        public void RefrescarDataGridProductos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _cuentasRepository = null;
                _cuentasRepository = new CuentasRepository(_context);
            }


            BindingSource source = new BindingSource();
            var clientes = _cuentasRepository.GetListarCuentas();
            source.DataSource = clientes;
            dgvlistaCuentas.DataSource = typeof(List<>);
            dgvlistaCuentas.DataSource = source;
            dgvlistaCuentas.Columns[13].ReadOnly = false;
            dgvlistaCuentas.AutoResizeColumns();
        }

        private void checktodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Rows in dgvlistaCuentas.Rows)
            {
                bool acciones = Convert.ToBoolean(Rows.Cells[13].Value);
                if (!acciones)
                {
                    Rows.Cells[13].Value = true;
                }
                else
                {
                    Rows.Cells[13].Value = false;
                }
            }



        }

        private void btnChanceState_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvlistaCuentas.Rows)
            {
                var Id = Guid.Parse(row.Cells[0].Value.ToString());
                var cuentaObtenido = _cuentasRepository.Get(Id);

                string estadoActual = row.Cells[12].Value.ToString();

                if (estadoActual == "Activo")
                {
                    cuentaObtenido.IsActive = false;
                    _cuentasRepository.Update(cuentaObtenido);

                }
               
                else  if(estadoActual=="Inactivo")
                {
                    cuentaObtenido.IsActive = true;

                    _cuentasRepository.Update(cuentaObtenido);
                }
            }

            RefrescarDataGridProductos(true);
        }
    }
}
