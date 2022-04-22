using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_combos
{
    public partial class DetallesCombo : BaseContext
    {
        private CombosRepository _combosRepository = null;
        private List<ComboDetalleLista> detallescombo = null;
        Form FormularioVolver = null;
        ListarCombos Combo;

        public DetallesCombo(Form form)
        {
            FormularioVolver = form;
            InitializeComponent();
        }

        public DetallesCombo(Form form, ListarCombos listarCombos)
        {
            _combosRepository = new CombosRepository(_context);
            Combo = listarCombos;
            FormularioVolver = form;
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms[FormularioVolver.Name] == null)
            {
                FormularioVolver.Show();
            }
            else
            {
                Application.OpenForms[FormularioVolver.Name].Activate();
            }
            Close();
        }

        private void DetallesCombo_Load(object sender, EventArgs e)
        {
            if (Combo != null)
            {
                CargarCombo(Combo);
            }
        }

        private void CargarCombo(ListarCombos combo)
        {
            TxtDescripcion.Text = combo.Descripcion;
            TxtCodigoBarras.Text = combo.CodigoBarras;
            TxtCosto.Text = combo.PrecioCompra.ToString();
            TxtStock.Text = combo.Stock.ToString();
            txtprecioventa.Text = combo.Precioventa.ToString();
            txtpreciomayorista.Text = combo.PrecioMayorista.ToString();
            txtprecioentidad.Text = combo.PrecioMayorista.ToString();
            txtpreciocuentaclave.Text = combo.PrecioCuentaClave.ToString();
            txtrevendedor.Text = combo.PrecioRevendedor.ToString();
            if (combo.Imagen != null)
            {
                byte[] filefoto = combo.Imagen;
                MemoryStream mStream = new MemoryStream(filefoto);
                PbImgCombo.Image = Image.FromStream(mStream);
                PbImgCombo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            detallescombo = _combosRepository.GetListDetalleCombo(combo.IdCombo);
            CargarDGVCombos(detallescombo);
        }

        private void CargarDGVCombos(List<ComboDetalleLista> lista)
        {
            BindingSource recurso = new BindingSource();
            recurso.DataSource = lista;
            DgvDetallesCombo.DataSource = typeof(List<>);
            DgvDetallesCombo.DataSource = recurso;
            DgvDetallesCombo.AutoResizeColumns();
            DgvDetallesCombo.ClearSelection();
        }

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            string txt1 = TxtBuscador.Text.ToLower();
            string txt2 = TxtBuscador.Text.ToUpper();
            var filtro = detallescombo.Where(a => a.Descripcion.Contains(txt1) || 
                                             a.Descripcion.Contains(txt2) || 
                                             a.Descripcion.Contains(TxtBuscador.Text) ||
                                             a.Referencia.Contains(TxtBuscador.Text));
            DgvDetallesCombo.DataSource = filtro.ToList();
            DgvDetallesCombo.ClearSelection();
        }
    }
}
