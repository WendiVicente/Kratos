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
    public partial class Rechazadas : BaseContext
    {
        private TransaccionRepository _transaccionRepository = null;
        private int estadoCancelId;
        private int estadoDenegarId;
        public Rechazadas()
        {
            _transaccionRepository = new TransaccionRepository(_context);
            InitializeComponent();
            
        }

        private void Rechazadas_Load(object sender, EventArgs e)
        {
            TraerTipoMovimiento();
            RefrescarDataGridProductos();
        }


        public void RefrescarDataGridProductos(bool loadNewContext = true)
        {
            var transacciones = _transaccionRepository.GetListaTransacciones(0, estadoDenegarId);
            var listacancelT = _transaccionRepository.GetListaTransacciones(estadoCancelId, 0);

            transacciones = transacciones.Concat(listacancelT).ToList();

            BindingSource source = new BindingSource();
            source.DataSource = transacciones;
            dgvlistaCuentas.DataSource = typeof(List<>);
            dgvlistaCuentas.DataSource = source;
            dgvlistaCuentas.AutoResizeColumns();
        }


        private void TraerTipoMovimiento()
        {
            var listaTipos = _transaccionRepository.GetlistEstadosT();
            var estadoCancel = listaTipos.Where(x => x.Estado == "Cancelada").FirstOrDefault();
            var estadoDenegar = listaTipos.Where(x => x.Estado == "Denegada").FirstOrDefault();

             estadoCancelId = estadoCancel.Id;
             estadoDenegarId = estadoDenegar.Id;

        }
    }
}
