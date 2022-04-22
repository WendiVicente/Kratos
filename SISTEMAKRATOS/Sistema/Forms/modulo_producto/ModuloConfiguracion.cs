using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Clientes;
using CapaDatos.Models.Personal;
using CapaDatos.Models.Proveedores;
using CapaDatos.Repository;
using CapaDatos.Repository.PersonalRepository;
using CapaDatos.Validation;
using ComponentFactory.Krypton.Toolkit;
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

namespace Sistema.Forms.modulo_producto
{
    public partial class ModuloConfiguracion : BaseContext
    {
        public TiposClienteRepository _tiposRepository = null;
        private int estadoCambio = 0;
        private int estadoCategoria = 0;
        private bool botoncategoriacliente=false;
        private bool botontipocliente=false;
        private CategoriaProdRepository _categoriaRepository = null;
        PropiedadesRepository _propiedadesRepository = null;
        private bool botonfrecuenciaproveedor=false;
        private bool botonrubroproveedor = false;
        private bool botontipoproveedor = false;
        int estadoRubro = 0;
        int estadoTipos = 0;
        private bool botondepartamentopersonal = false;
        private bool botonhorariopersonal = false;
        private bool botonpuestopersonal = false;
        private bool botoncontratopersonal = false;
        int estadoDepto = 0;
        int estadoHorario = 0;
        int estadoContrato = 0;
        int estadoPuesto = 0;
        public ModuloConfiguracion()
        {
            _propiedadesRepository = new PropiedadesRepository(_context);
            _categoriaRepository=new CategoriaProdRepository(_context);
            InitializeComponent();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal(this);
        }

        private void ModuloConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal(this, false);
        }

        private void ModuloConfiguracion_Load(object sender, EventArgs e)
        {
            cargarDeptosCombo();

        }
        private void cargarDeptosCombo()
        {
            var Deptos = _propiedadesRepository.GetListDepartamentos();

            cbdepartamento.DataSource = Deptos;
            cbdepartamento.DisplayMember = "Area";
            cbdepartamento.ValueMember = "Id";
            cbdepartamento.Text = "Seleccione una área"; // esto no jalo? no me jalo
            //comboDepartamentos.SelectedIndex = 0;
            cbdepartamento.Invalidate();

        }
        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private CategoriaCliente GetmodeloCategoria(CategoriaCliente categoria)
        {
            categoria.Categoria = txtcategoria.Text;
            categoria.IsActive = checkestadocate.Checked;
            return categoria;
        }

        private CategoriaCliente GetmodeloNewCategoria()
        {

            return new CategoriaCliente()
            {
                Categoria = txttipocliente.Text,
                IsActive = checkestadocate.Checked

            };


        }
        private void GuardarCategoria()
        {
            if (estadoCategoria == 0)
            {
                var modeloCategoria = GetmodeloNewCategoria();
                if (String.IsNullOrEmpty(txttipocliente.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar una nueva categoria"); return; }
                if (!ModelState.IsValid(modeloCategoria)) { return; }

                _tiposRepository.AddCategoriaCliente(modeloCategoria);

                            }
        }
        private Tipos GetViewModelEdit(Tipos tipo)
        {
            tipo.TipoCliente = txttipocliente.Text;
            tipo.IsActive = checkEstado.Checked;
            return tipo;
        }
        private void LimpiarTxtcategorias()
        {
            kryptonLabel3.Text = "";
            txttipocliente.Text = "";
            txtcategoria.Text = "";
            checkestadocate.Checked = false;
        }
        private Tipos getmodeltipos()
        {

            return new Tipos()
            {
                TipoCliente = txttipocliente.Text,
                IsActive = checkEstado.Checked

            };


        }
        private void GuardarTipo()
        {
            if (estadoCambio == 0)
            {
                var modeloTipo = getmodeltipos();
                if (String.IsNullOrEmpty(txttipocliente.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar un nuevo Tipo"); return; }
                if (!ModelState.IsValid(modeloTipo)) { return; }

                _tiposRepository.AddTipos(modeloTipo);

                //RefrescarDataGrid(true);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        
            if (botoncategoriacliente)
            {
                GuardarCategoria();
                RefrescarDataGridCategoria();
            }else if (botontipocliente) { 
         
            GuardarTipo();
                RefrescarDataGridTipoCliente();
            }
            LimpiarTxtcategorias();
        }
        public void RefrescarDataGridCategoria(bool LoadNewContext = true)
        {

            if (LoadNewContext)
            {
                _context = null;
                _context = new Context();
                _tiposRepository = null;
                _tiposRepository = new TiposClienteRepository(_context);
            }

            var listaCategoria = _tiposRepository.GetCategoria();

            BindingSource source = new BindingSource();
            source.DataSource = listaCategoria;
            dgvcliente.DataSource = typeof(List<>);
            dgvcliente.DataSource = source;

        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            RefrescarDataGridCategoria(true);
        }
        public void RefrescarDataGridTipoCliente(bool LoadNewContext = true)
        {

            if (LoadNewContext)
            {
                _context = null;
                _context = new Context();
                _tiposRepository = null;
                _tiposRepository = new TiposClienteRepository(_context);
            }

            var listaTipos = _tiposRepository.GettiposCliente();

            BindingSource source = new BindingSource();
            source.DataSource = listaTipos;
            dgvcliente.DataSource = typeof(List<>);
            dgvcliente.DataSource = source;

        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            RefrescarDataGridTipoCliente(true);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            botoncategoriacliente = true;
            botontipocliente = false;
            RefrescarDataGridCategoria(true);
         
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            botontipocliente=true;
            botoncategoriacliente=false;
            RefrescarDataGridTipoCliente(true);
        }
        private Categoria GetmodeloNewCategoriaProducto()
        {

            return new Categoria()
            {
                Nombre = txtcategoria.Text,
                Inactivo = checkestadocate.Checked

            };


        }
        public void RefrescarDataGridProducto(bool LoadNewContext = true)
        {

            if (LoadNewContext)
            {
                _context = null;
                _context = new Context();
                _categoriaRepository = null;
                _categoriaRepository = new CategoriaProdRepository(_context);
            }

            var listaTipos = _categoriaRepository.GetListcategoria();

            BindingSource source = new BindingSource();
            source.DataSource = listaTipos;
            dgvcategoriaproducto.DataSource = typeof(List<>);
            dgvcategoriaproducto.DataSource = source;

        }
        private void GuardarCategoriaProducto()
        {
            if (estadoCategoria == 0)
            {
                var modeloCategoria = GetmodeloNewCategoriaProducto();
                if (String.IsNullOrEmpty(txtcategoria.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar una nueva categoria"); return; }
                if (!ModelState.IsValid(modeloCategoria)) { return; }

                _categoriaRepository.Add(modeloCategoria);

               RefrescarDataGridProducto(true);
            }
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            GuardarCategoriaProducto();
            LimpiarTxtcategorias();
        }
        private Categoria GetmodeloCategoriaProducto(Categoria categoria)
        {
            categoria.Nombre = txtcategoria.Text;
            categoria.Inactivo = checkestadocate.Checked;
            return categoria;
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {

            if (dgvcategoriaproducto.CurrentRow == null)
            {
                return;
            }
            if (estadoCategoria == 1)
            {
                var tipoRow = (ListarCategoriaProd)dgvCategorias.CurrentRow.DataBoundItem;
                var GetCateg = _categoriaRepository.GetCategoria(tipoRow.Id);

                var modeloEditar = GetmodeloCategoriaProducto(GetCateg);
                if (String.IsNullOrEmpty(txtcategoria.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar una categoria"); return; }
                if (!ModelState.IsValid(modeloEditar)) { return; }

                _categoriaRepository.Update(modeloEditar);

                RefrescarDataGridProducto(true);
                LimpiarTxtcategorias();

            }
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            botonfrecuenciaproveedor = true;
            botonrubroproveedor = false;
            botontipoproveedor=false;
            RefrescarDataGridFrePro(true);
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            botonfrecuenciaproveedor = false;
            botonrubroproveedor = true;
            botontipoproveedor = false;
            RefrescarDataRubrosProveedor(true);
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            botonfrecuenciaproveedor = false;
            botonrubroproveedor = false;
            botontipoproveedor = true;
            RefrescarDataTiposProveedor(true);
        }
        private Frecuencia GetFrecuenciaNuevo()
        {
            return new Frecuencia()
            {
                Periodo = txtdescripcionproveedor.Text,
                IsActive = txtcheckpro.Checked
            };
        }
        public void RefrescarDataGridFrePro(bool LoadNewContext = true)
        {

            var listarFrecuencias = _propiedadesRepository.GetListFrecuencias();

            BindingSource source = new BindingSource();
            source.DataSource = listarFrecuencias;
            dgvproveedor.DataSource = typeof(List<>);
            dgvproveedor.DataSource = source;

        }
        private void guardarFrecuenciaProveedor()
        {
            if (estadoCambio == 0)
            {
                var modeloFre = GetFrecuenciaNuevo();
                if (String.IsNullOrEmpty(txtdescripcionproveedor.Text)) { KryptonMessageBox.Show("Campo Vacio, ingresar un nuevo Periodo"); return; }
                if (!ModelState.IsValid(modeloFre)) { return; }

                _propiedadesRepository.AddFrecuencia(modeloFre);

                RefrescarDataGridFrePro(true);
            }
        }
        private Rubro GetRubroNuevo()
        {

            return new Rubro()
            {
                Descripcion = txtdescripcionproveedor.Text,
                IsActive = txtcheckpro.Checked

            };


        }
        public void RefrescarDataRubrosProveedor(bool LoadNewContext = true)
        {

            var listarRubros = _propiedadesRepository.GetListRubros();

            BindingSource source = new BindingSource();
            source.DataSource = listarRubros;
            dgvproveedor.DataSource = typeof(List<>);
            dgvproveedor.DataSource = source;

        }
        private void guardarRubroProveedor()
        {
            if (estadoRubro == 0)
            {
                var modeloRubro = GetRubroNuevo();
                if (String.IsNullOrEmpty(txtdescripcionproveedor.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un nuevo rubro"); return; }
                if (!ModelState.IsValid(modeloRubro)) { return; }

                _propiedadesRepository.AddRubro(modeloRubro);

                RefrescarDataRubrosProveedor(true);
            }
        }
        private TipoProveedor GetTiposNuevo()
        {

            return new TipoProveedor()
            {
                Descripcion = txtdescripcionproveedor.Text,
                IsActive = txtcheckpro.Checked

            };


        }
        public void RefrescarDataTiposProveedor(bool LoadNewContext = true)
        {

            var listarTiposProve = _propiedadesRepository.GetListTipoProveedores();
            BindingSource source = new BindingSource();
            source.DataSource = listarTiposProve;
            dgvproveedor.DataSource = typeof(List<>);
            dgvproveedor.DataSource = source;

        }
        private void guardarTipoProveedor()
        {
            if (estadoTipos == 0)
            {
                var modeloTipos = GetTiposNuevo();
                if (String.IsNullOrEmpty(txtdescripcionproveedor.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Tipo de proveedor"); return; }
                if (!ModelState.IsValid(modeloTipos)) { return; }

                _propiedadesRepository.AddTipoProveedor(modeloTipos);

                RefrescarDataTiposProveedor(true);
            }
        }
        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            if (botonfrecuenciaproveedor)
            {
                guardarFrecuenciaProveedor();
            }
            if (botonrubroproveedor)
            {
                guardarRubroProveedor();
            }else if(botontipoproveedor)
            {
                guardarTipoProveedor();          
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
         botondepartamentopersonal = true;
         botonhorariopersonal = false;
         botonpuestopersonal = false;
        botoncontratopersonal = false;
            cbdepartamento.Visible = false;
            RefrescarDataGridDeptosPersonal(true);
    }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            botondepartamentopersonal = false;
            botonhorariopersonal = true;
            botonpuestopersonal = false;
            botoncontratopersonal = false;
            RefrescarDataGridHorariosPersonal(true);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            botondepartamentopersonal = false;
            botonhorariopersonal = false;
            botonpuestopersonal = true;
            botoncontratopersonal = false;
            cbdepartamento.Visible = true;
            RefrescarDataGridPuestosPersonal(true);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            botondepartamentopersonal = false;
            botonhorariopersonal = false;
            botonpuestopersonal = false;
            botoncontratopersonal = true;
            RefrescarDataGridTipocontratosPersonal(true);
        }
        private Departamento GetDeptoNuevo()
        {
            return new Departamento()
            {
                Area = txtdescripcionpersonal.Text,
                IsActive = checkEstadoPuesto.Checked
            };
        }
        public void RefrescarDataGridDeptosPersonal(bool LoadNewContext = true)
        {
            var listarDepto = _propiedadesRepository.GetListDepartamentos();
            BindingSource source = new BindingSource();
            source.DataSource = listarDepto;
            dgvpersonal.DataSource = typeof(List<>);
            dgvpersonal.DataSource = source;
        }
        private void guardardeptopersonal()
        {
            if (estadoDepto == 0)
            {
                var modeloDepto = GetDeptoNuevo();
                if (String.IsNullOrEmpty(txtdescripcionpersonal.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Departamento"); return; }
                if (!ModelState.IsValid(modeloDepto)) { return; }

                _propiedadesRepository.AddDepartamento(modeloDepto);

                RefrescarDataGridDeptosPersonal(true);
            }
        }
        private Horario GetHorarioNuevo()
        {
            return new Horario()
            {
                Periodo = txtdescripcionpersonal.Text,
                IsActive = checkEstadoPuesto.Checked
            };
        }
        public void RefrescarDataGridHorariosPersonal(bool LoadNewContext = true)
        {
            var listarhorarios = _propiedadesRepository.GetListHorarios();
            BindingSource source = new BindingSource();
            source.DataSource = listarhorarios;
            dgvpersonal.DataSource = typeof(List<>);
            dgvpersonal.DataSource = source;
        }
        private void guardarHorarioPersonal()
        {
            if (estadoHorario == 0)
            {
                var modeloHorario = GetHorarioNuevo();
                if (String.IsNullOrEmpty(txtdescripcionpersonal.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Horario"); return; }
                if (!ModelState.IsValid(modeloHorario)) { return; }

                _propiedadesRepository.AddHorario(modeloHorario);

                RefrescarDataGridHorariosPersonal(true);
            }
        }
        private Puesto GetPuestoNuevo()
        {
            return new Puesto()
            {
                DepartamentoId = int.Parse(cbdepartamento.SelectedValue.ToString()),
                Descripcion = txtdescripcionpersonal.Text,
                IsActive = checkEstadoPuesto.Checked

            };
        }
        public void RefrescarDataGridPuestosPersonal(bool LoadNewContext = true)
        {
            var listarPuestos = _propiedadesRepository.GetListPuestos();
            BindingSource source = new BindingSource();
            source.DataSource = listarPuestos;
            dgvpersonal.DataSource = typeof(List<>);
            dgvpersonal.DataSource = source;
        }
        private void guardarPuestosPersonal()
        {
            if (estadoPuesto == 0)
            {
                var modeloPuesto = GetPuestoNuevo();
                if (String.IsNullOrEmpty(txtdescripcionpersonal.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un puesto"); return; }
                if (!ModelState.IsValid(modeloPuesto)) { return; }

                _propiedadesRepository.AddPuesto(modeloPuesto);

                RefrescarDataGridPuestosPersonal(true);
            }
        }
        private TipoContrato GetTipoContratoNuevo()
        {
            return new TipoContrato()
            {
                Descripcion = txtdescripcionpersonal.Text,
                IsActive = checkEstadoPuesto.Checked
            };
        }
        public void RefrescarDataGridTipocontratosPersonal(bool LoadNewContext = true)
        {
            var listarTiposContratos = _propiedadesRepository.GetListContratos();
            BindingSource source = new BindingSource();
            source.DataSource = listarTiposContratos;
            dgvpersonal.DataSource = typeof(List<>);
            dgvpersonal.DataSource = source;
        }
        private void guardarContratoPersonal()
        {
            if (estadoContrato == 0)
            {
                var modeloContrato = GetTipoContratoNuevo();
                if (String.IsNullOrEmpty(txtdescripcionpersonal.Text))
                { KryptonMessageBox.Show("Campo Vacio, ingresar un Texto"); return; }
                if (!ModelState.IsValid(modeloContrato)) { return; }
                _propiedadesRepository.AddContrato(modeloContrato);
                RefrescarDataGridTipocontratosPersonal(true);
            }
        }
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (botondepartamentopersonal)
            {
                guardardeptopersonal();
            }
            if (botonhorariopersonal)
            {
                guardarHorarioPersonal();
            }
            if (botonpuestopersonal)
            {
                guardarPuestosPersonal();
            }else if (botoncontratopersonal)
            {
                guardarContratoPersonal();
            }
        }
    }
}
