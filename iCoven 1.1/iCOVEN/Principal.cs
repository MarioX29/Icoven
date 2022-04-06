using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using LOGICA;
namespace iCOVEN
{ public partial class Principal : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private void Principal_Load(object sender, EventArgs e)
        {
        }
        public Principal()
        {
            InitializeComponent();

        }

        /******************/
        #region Instancias 
        public void Buscador()
        {

            TxtBuscar1.Text = "";
            CboOp.Text = "";
            Lbldi.Text = "";
        }
        Exportar exp = new Exportar();
        const int SC_MAXIMIZE = 0xF020;
        const int WM_SYSCOMMAND = 0x112;
        public DataTable dt = new DataTable();
        Contribuyente C = new Contribuyente();
        TContribuyente Tc = new TContribuyente();
        Usuario Us = new Usuario();
        Proveedor PR = new Proveedor();
        Cliente CL = new Cliente();
        Venta vn = new Venta();
        Compra CR = new Compra();
        #endregion
        /******************/

        /******************/
        #region Contribuyente
        #region Contribuyente
        /*Variables para obtener los datos de Tipo contribuyente*/
        public static string IdC;
        public static string NombreC;
        public static string CodigoC;
        public static string SiglasC;
        public static string NacimientoC;
        public static string EstadoC;
        public static string IdTC;
        public static string TasaC;

        #endregion
        /*Boton Agregar Contribuyente*/
        private void AcoCAgregar_Click(object sender, EventArgs e)
        {
            bool existe = panelControl1.Controls.OfType<AgregarContrib>().Any();

            if (!existe)
            {
                AgregarContrib AGc = new AgregarContrib();
                panelControl1.Controls.Add(AGc);

            }

        }
        /***********GRID PARA EDITAR*****************/
        private void DgvContr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Contribuyente*/
            DateTime Fecha;
            Fecha = Convert.ToDateTime(DgvContr.Rows[e.RowIndex].Cells[5].Value.ToString());
            IdC = DgvContr.Rows[e.RowIndex].Cells[0].Value.ToString();
            CodigoC = DgvContr.Rows[e.RowIndex].Cells[1].Value.ToString();
            NombreC = DgvContr.Rows[e.RowIndex].Cells[2].Value.ToString();
            SiglasC = DgvContr.Rows[e.RowIndex].Cells[3].Value.ToString();
            TasaC = DgvContr.Rows[e.RowIndex].Cells[4].Value.ToString();
            NacimientoC = Fecha.ToString("dd-MM-yyyy");
            EstadoC = DgvContr.Rows[e.RowIndex].Cells[6].Value.ToString();
            IdTC = DgvContr.Rows[e.RowIndex].Cells[7].Value.ToString();
            Lbldi.Text = IdC;
        }
        /*Boton editar*/
        private void AcoCEditar_Click(object sender, EventArgs e)
        {
            panelcontrol2.Visible = true;
            dt = C.Listado();
            DgvContr.DataSource = dt;
            panelcontrol2.Visible = true;
            Buscador();
            DgvTipo.Visible = false;
            DgvUsuario.Visible = false;
            DgvP.Visible = false;
            DgvContr.Visible = true;
            DgvVenta.Visible = false;
            BtnContrib.Visible = true;
            DgvCompra.Visible = false;



        }
        /*Exportar*/
        private void AcoExC_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dt = C.Listado();
            dataGridView1.DataSource = dt;
            Cursor.Current = Cursors.WaitCursor;
            exp.ExportarDataGridViewExcel(dataGridView1);
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Exportados Correctamente....");
            dataGridView1.Visible = false;
            Cursor.Current = Cursor.Current;
        }
        private void BtnContrib_Click(object sender, EventArgs e)
        {

            if (Lbldi.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Debe seleccionar una fila para editar", "INFORMACIÓN");
            }
            else
            {
                BtnContrib.Visible = true;
                BtnTC.Visible = false;
                /*Variables para los Switch*/
                string E = "";
                E = EstadoC;
                /*Se instancia un objeto para poder mostrar
                el panel AgregarContrib, y limpiar el panel*/
                AgregarContrib AGc = new AgregarContrib();
                panelcontrol2.Visible = false;
                panelControl1.Controls.Add(AGc);
                /*Asignacion de valores a los Contenedores*/
                AGc.LblCont.Text = IdC;
                AGc.TxtCodigo.Text = CodigoC;
                AGc.TxtSiglas.Text = SiglasC;
                AGc.TxtNombre.Text = NombreC;
                AGc.TxtTasa.Text = TasaC;
                AGc.Date.Text = NacimientoC;
                AGc.TxtIdTC.Text = IdTC;
                AGc.IdTipo.Text = IdTC;
                if (E == "1")
                {
                    AGc.SwEstado.IsOn = true;
                }
                BtnContrib.Visible = false;
            }

        }


        #endregion
        /******************/

        /******************/
        #region Usuario
        /*Variable para obtener los datos */
        #region Usuario
        public static string IdU;
        public static string NombreU;
        public static string ClaveU;
        public static string SuperU;
        public static string EstadoU;
        #endregion
        /*Exportar*/
        private void AcoExU_Click(object sender, EventArgs e)
        {

            dataGridView1.Visible = true;
            dt = Us.Listado();
            dataGridView1.DataSource = dt;
            Cursor.Current = Cursors.WaitCursor;
            exp.ExportarDataGridViewExcel(dataGridView1);
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Exportados Correctamente....");
            dataGridView1.Visible = false;
            Cursor.Current = Cursor.Current;
        }
        private void AcoUEditar_Click(object sender, EventArgs e)
        {
            dt = Us.Listado();
            DgvUsuario.DataSource = dt;
            panelcontrol2.Visible = true;
            Buscador();
            DgvTipo.Visible = false;
            DgvUsuario.Visible = true;
            DgvP.Visible = false;
            DgvContr.Visible = false;
            BtnUsuario.Visible = true; DgvVenta.Visible = false;
            DgvCompra.Visible = false;


        }
        private void DgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*Usuario*/
            IdU = DgvUsuario.Rows[e.RowIndex].Cells[0].Value.ToString();
            NombreU = DgvUsuario.Rows[e.RowIndex].Cells[1].Value.ToString();
            ClaveU = DgvUsuario.Rows[e.RowIndex].Cells[2].Value.ToString();
            SuperU = DgvUsuario.Rows[e.RowIndex].Cells[3].Value.ToString();
            EstadoU = DgvUsuario.Rows[e.RowIndex].Cells[4].Value.ToString();

            Lbldi.Text = IdU;
        }
        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            /*Variables para los Switch*/
            string Super = "";
            string EU = "";

            Super = SuperU;
            EU = EstadoU;
            if (Lbldi.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Debe seleccionar una fila para editar", "INFORMACIÓN");
            }
            else
            {


                /*Se instancia un objeto para poder mostrar
                el panel AgregarTC, y limpiar el panel*/
                AgregarUsuario AGus = new AgregarUsuario();
                panelcontrol2.Visible = false;
                panelControl1.Controls.Add(AGus);
                /*Asignacion de valores a los Contenedores*/
                AGus.LblCont.Text = IdU;
                AGus.TxtNombre.Text = NombreU;
                AGus.TxtClave.Text = ClaveU;
                if (SuperU == "1")
                {
                    AGus.SwTU.IsOn = true;
                }
                if (EU == "1")
                {
                    AGus.SwE.IsOn = true;
                }
                BtnUsuario.Visible = false;
            }

        }
        private void AcoUAgregar_Click(object sender, EventArgs e)
        {
            bool existe = panelControl1.Controls.OfType<AgregarUsuario>().Any();

            if (!existe)
            {
                AgregarUsuario Agu = new AgregarUsuario();
                panelControl1.Controls.Add(Agu);

            }

        }
        #endregion
        /******************/

        /******************/
        #region Tipo_Contribuyente
        /*Variables para obtener datos */
        #region Tipo_Contribuyente
        public static string Id;
        public static string Nombre;
        public static string Credito;
        public static string Debito;
        public static string tasa;
        public static string Estado;
        #endregion
        /*Exportar*/
        private void AcoExTC_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dt = Tc.Listado();
            dataGridView1.DataSource = dt;
            Cursor.Current = Cursors.WaitCursor;
            exp.ExportarDataGridViewExcel(dataGridView1);
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Exportados Correctamente....");

            dataGridView1.Visible = false;
            Cursor.Current = Cursor.Current;
        }
        private void BtnC_Click(object sender, EventArgs e)
        {
            panelcontrol2.Visible = false;
            BtnCliente.Visible = false;
            BtnContrib.Visible = false;
            BtnProv.Visible = false;
            BtnTC.Visible = false;
            BtnUsuario.Visible = false;
        }
        /*Boton Agregar en el menu principal*/
        private void AcoTAgregar_Click(object sender, EventArgs e)
        {

            bool existe = panelControl1.Controls.OfType<AgregarTC>().Any();

            if (!existe)
            {
                AgregarTC AGT = new AgregarTC();
                panelControl1.Controls.Add(AGT);

            }


        }
        // Editar Tipo Contribuyente
        private void AcoTEditar_Click(object sender, EventArgs e)
        {
            dt = Tc.Listado();
            DgvTipo.DataSource = dt;
            panelcontrol2.Visible = true;
            Buscador();
            DgvTipo.Visible = true;
            DgvUsuario.Visible = false;
            DgvContr.Visible = false;
            DgvP.Visible = false;
            BtnTC.Visible = true;
            DgvVenta.Visible = false;
            DgvCompra.Visible = false;
        }
        #region Panel busqueda TipoContribuyente
        private void TxtBuscar_EditValueChanged(object sender, EventArgs e)
        {
            /*Se verifica que se haya seleccionado una opcion para la busqueda*/
            if (CboOp.Text == "Nombre")
            {
                dt.DefaultView.RowFilter = $" Nombre  LIKE '{TxtBuscar1.Text}%'";

            }
            if (CboOp.Text == "Estado")
            {
                dt.DefaultView.RowFilter = $" Estado LIKE '{TxtBuscar1.Text}%'";
            }
            else
            {
                Error.SetError(CboOp, "Seleccione un parametro para buscar");
            }
            if (CboOp.Text != string.Empty)
            {
                Error.Dispose();
            }
        }
        private void DgvTipo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*Tipo_Contribuyente*/
            Id = DgvTipo.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nombre = DgvTipo.Rows[e.RowIndex].Cells[1].Value.ToString();
            Credito = DgvTipo.Rows[e.RowIndex].Cells[2].Value.ToString();
            Debito = DgvTipo.Rows[e.RowIndex].Cells[3].Value.ToString();
            tasa = DgvTipo.Rows[e.RowIndex].Cells[4].Value.ToString();
            Estado = DgvTipo.Rows[e.RowIndex].Cells[5].Value.ToString();
            Lbldi.Text = Id;

        }
        private void BtnTC_Click(object sender, EventArgs e)
        {

            /*Variables para los Switch*/
            string CF = "";
            string DF = "";
            string E = "";

            CF = Credito;
            DF = Debito;
            E = Estado;
            if (Lbldi.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Debe seleccionar una fila para editar", "INFORMACIÓN");
            }
            else
            {

                /*Se instancia un objeto para poder mostrar
                el panel AgregarTC, y limpiar el panel*/
                AgregarTC agt = new AgregarTC();
                panelcontrol2.Visible = false;
                panelControl1.Controls.Add(agt);
                /*Asignacion de valores a los Contenedores*/
                agt.LblCont.Text = Id;
                agt.TxtNombre.Text = Nombre;
                if (CF == "1")
                {
                    agt.SwFiscalC.IsOn = true;
                }
                if (DF == "1")
                {
                    agt.SwDebito.IsOn = true;
                }
                if (E == "1")
                {
                    agt.SwEstado.IsOn = true;
                }
                agt.SpTasa.Text = tasa;
                BtnTC.Visible = false;
            }

        }


        #endregion
        #endregion
        /******************/

        /******************/
        #region Proveedor
        /*Proveedor*/
        #region MyRegion

        /*Variables para obtener los datos de Proveedor*/
        public static string IDI;
        public static string CodigoI;
        public static string RSocI;
        public static string RComI;
        public static string TpersonaI;
        public static string DireccI;
        public static string TelI;
        public static string CorreI;
        public static string WebI;
        public static string LineaI;
        public static string EI;
        public static string FRI;
        public static string IdTCI;
        #endregion
        private void DgvP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDI = DgvP.Rows[e.RowIndex].Cells[0].Value.ToString();
            CodigoI = DgvP.Rows[e.RowIndex].Cells[1].Value.ToString();
            RSocI = DgvP.Rows[e.RowIndex].Cells[2].Value.ToString();
            RComI = DgvP.Rows[e.RowIndex].Cells[3].Value.ToString();
            TpersonaI = DgvP.Rows[e.RowIndex].Cells[4].Value.ToString();
            DireccI = DgvP.Rows[e.RowIndex].Cells[5].Value.ToString();
            TelI = DgvP.Rows[e.RowIndex].Cells[6].Value.ToString();
            CorreI = DgvP.Rows[e.RowIndex].Cells[7].Value.ToString();
            WebI = DgvP.Rows[e.RowIndex].Cells[8].Value.ToString();
            LineaI = DgvP.Rows[e.RowIndex].Cells[9].Value.ToString();
            EI = DgvP.Rows[e.RowIndex].Cells[10].Value.ToString();
            FRI = DgvP.Rows[e.RowIndex].Cells[11].Value.ToString();
            IdTCI = DgvP.Rows[e.RowIndex].Cells[12].Value.ToString();
            Lbldi.Text = IDI;

        }
        private void AcoPAgregar_Click(object sender, EventArgs e)
        {
            bool existe = panelControl1.Controls.OfType<AgregarProv>().Any();

            if (!existe)
            {
                AgregarProv AgP = new AgregarProv();
                panelControl1.Controls.Add(AgP);
            }
        }
        private void AcoExP_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dt = PR.Listado();
            dataGridView1.DataSource = dt;
            Cursor.Current = Cursors.WaitCursor;
            exp.ExportarDataGridViewExcel(dataGridView1);
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Exportados Correctamente....");
            dataGridView1.Visible = false;
            Cursor.Current = Cursor.Current;
        }
        private void AcoPEditar_Click(object sender, EventArgs e)
        {
            panelcontrol2.Visible = true;
            dt = PR.Listado();
            DgvP.DataSource = dt;

            Buscador();
            panelcontrol2.Visible = true;
            DgvP.Visible = true;
            DgvTipo.Visible = false;
            DgvUsuario.Visible = false;
            DgvContr.Visible = false;
            BtnProv.Visible = true;
            DgvVenta.Visible = false;
            DgvCompra.Visible = false;


        }
        private void BtnProv_Click(object sender, EventArgs e)
        {
            /*Variables para los Switch*/
            string Per = "";
            string EP = "";
            Per = SuperU;
            EP = EstadoU;
            if (Lbldi.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Debe seleccionar una fila para editar", "INFORMACIÓN");
            }
            else
            {

                /*Se instancia un objeto para poder mostrar
                el panel AgregarTC, y limpiar el panel*/
                AgregarProv AGreP = new AgregarProv();
                panelcontrol2.Visible = false;
                panelControl1.Controls.Add(AGreP);
                /*Asignacion de valores a los Contenedores*/
                AGreP.LblCont.Text = IDI;
                AGreP.TxtCodP.Text = CodigoI;
                AGreP.TxtNombreP.Text = RSocI;
                AGreP.TxtRComercial.Text = RComI;
                if (TpersonaI == "J")
                {
                    AGreP.SWTipoPe.IsOn = true;
                }

                AGreP.TxtDireccionP.Text = DireccI;
                AGreP.TxtTelProv.Text = TelI;
                AGreP.TxtCorreoPr.Text = CorreI;
                AGreP.TxtWeb.Text = WebI;
                AGreP.TxtLinea.Text = LineaI;
                if (EI == "1")
                {
                    AGreP.SwEsP.IsOn = true;
                }
                AGreP.TxtFr.Text = FRI;
                AGreP.TxtIdtdc.Text = IdTCI;
                AGreP.LbTC.Text = IdTCI;
                BtnProv.Visible = false;
            }

        }

        #endregion
        /******************/

        /******************/
        #region Cliente
        /*Varibales para obtener los datos*/
        #region Cliente
        public static string IDCl;
        public static string CodigoCl;
        public static string RSocCl;
        public static string RComCl;
        public static string TpersonaCl;
        public static string DireccCl;
        public static string TelCl;
        public static string CorreCl;
        public static string WebCl;
        public static string LineaCl;
        public static string ECl;
        public static string FRCl;
        public static string IdTCCl;
        #endregion
        private void AcoCiAgregar_Click(object sender, EventArgs e)
        {

            bool existe = panelControl1.Controls.OfType<AgregarProv>().Any();

            if (!existe)
            {
                AgregarCliente AgCi = new AgregarCliente();
                panelControl1.Controls.Add(AgCi);

            }


        }
        private void AcoExCi_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dt = CL.Listado();
            dataGridView1.DataSource = dt;
            Cursor.Current = Cursors.WaitCursor;
            exp.ExportarDataGridViewExcel(dataGridView1);
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Exportados Correctamente....");
            dataGridView1.Visible = false;
            Cursor.Current = Cursor.Current;
        }
        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            IDCl = DgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            CodigoCl = DgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            RSocCl = DgvClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            RComCl = DgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
            TpersonaCl = DgvClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
            DireccCl = DgvClientes.Rows[e.RowIndex].Cells[5].Value.ToString();
            TelCl = DgvClientes.Rows[e.RowIndex].Cells[6].Value.ToString();
            CorreCl = DgvClientes.Rows[e.RowIndex].Cells[7].Value.ToString();
            WebCl = DgvClientes.Rows[e.RowIndex].Cells[8].Value.ToString();
            LineaCl = DgvClientes.Rows[e.RowIndex].Cells[9].Value.ToString();
            ECl = DgvClientes.Rows[e.RowIndex].Cells[10].Value.ToString();
            FRCl = DgvClientes.Rows[e.RowIndex].Cells[11].Value.ToString();
            IdTCCl = DgvClientes.Rows[e.RowIndex].Cells[12].Value.ToString();
            Lbldi.Text = IDCl;

        }
        private void AcoCiEditar_Click(object sender, EventArgs e)
        {
            panelcontrol2.Visible = true;
            dt = CL.Listado();
            DgvClientes.DataSource = dt;
            panelcontrol2.Visible = true;
            Buscador();
            DgvClientes.Visible = true;
            DgvTipo.Visible = false;
            DgvUsuario.Visible = false;
            DgvP.Visible = false;
            DgvVenta.Visible = false;
            DgvContr.Visible = false;
            BtnCliente.Visible = true;
            DgvCompra.Visible = false;



        }
        private void BtnCliente_Click(object sender, EventArgs e)
        {
            /*Variables para los Switch*/
            string Per = "";
            string EP = "";
            Per = SuperU;
            EP = EstadoU;
            if (Lbldi.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Debe seleccionar una fila para editar", "INFORMACIÓN");
            }
            else
            {

                /*Se instancia un objeto para poder mostrar

                el panel AgregarTC, y limpiar el panel*/
                AgregarCliente AGreCl = new AgregarCliente();
                panelcontrol2.Visible = false;
                panelControl1.Controls.Add(AGreCl);
                /*Asignacion de valores a los Contenedores*/
                AGreCl.LblCont.Text = IDCl;
                AGreCl.TxtCodigo.Text = CodigoCl;
                AGreCl.TxtNombre.Text = RSocCl;
                AGreCl.TxtRC.Text = RComCl;
                if (TpersonaCl == "J")
                {
                    AGreCl.SWP.IsOn = true;
                }
                AGreCl.TxtDirc.Text = DireccCl;
                AGreCl.TxtTelC.Text = TelCl;
                AGreCl.TxtCorreo.Text = CorreCl;
                AGreCl.TxtWeb.Text = WebCl;
                AGreCl.TxtLineac.Text = LineaCl;
                if (ECl == "1")
                {
                    AGreCl.SwE.IsOn = true;
                }
                AGreCl.TxtFrec.Text = FRCl;
                AGreCl.TxtIdTC.Text = IdTCCl;
                BtnCliente.Visible = false;
            }
        }
        #endregion
        /******************/

        /******************/
        #region Venta
        #region Venta
        public static string VID;
        public static string VAnio;
        public static string VMes;
        public static string VSerie;
        public static string VNumI;
        public static string VNumF;
        public static string VFecha;
        public static string VEstado;
        public static string VCliID;
        public static string VCliCod;
        public static string VRazonS;
        public static string VTotConIva;
        public static string TotIva;
        public static string VDescrip;
        public static string VProCon;
        public static string VProIva;
        public static string SercoIVa;
        public static string SerIva;
        public static string VExento;
        public static string VMesC;
        public static string VEliminado;

        #endregion
        private void AcoVAgregar_Click(object sender, EventArgs e)
        {
            bool existe = panelControl1.Controls.OfType<AgregarVenta>().Any();

            if (!existe)
            {
                AgregarVenta AgV = new AgregarVenta();
                panelControl1.Controls.Add(AgV);
            }
        }
        private void AcoVEditar_Click(object sender, EventArgs e)
        {
            dt = vn.Listado();
            DgvVenta.DataSource = dt;
            Buscador();
            panelcontrol2.Visible = true;
            BtnVenta.Visible = true;
            DgvVenta.Visible = true;
            DgvCompra.Visible = false;
        }
        private void DgvVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            VID = DgvVenta.Rows[e.RowIndex].Cells[0].Value.ToString();
            VAnio = DgvVenta.Rows[e.RowIndex].Cells[1].Value.ToString();
            VMes = DgvVenta.Rows[e.RowIndex].Cells[2].Value.ToString();
            VSerie = DgvVenta.Rows[e.RowIndex].Cells[3].Value.ToString();
            VNumI = DgvVenta.Rows[e.RowIndex].Cells[4].Value.ToString();
            VNumF = DgvVenta.Rows[e.RowIndex].Cells[5].Value.ToString();
            VFecha = DgvVenta.Rows[e.RowIndex].Cells[6].Value.ToString();
            VEstado = DgvVenta.Rows[e.RowIndex].Cells[7].Value.ToString();
            VCliID = DgvVenta.Rows[e.RowIndex].Cells[8].Value.ToString();
            VCliCod = DgvVenta.Rows[e.RowIndex].Cells[9].Value.ToString();
            VRazonS = DgvVenta.Rows[e.RowIndex].Cells[10].Value.ToString();
            VTotConIva = DgvVenta.Rows[e.RowIndex].Cells[11].Value.ToString();
            TotIva = DgvVenta.Rows[e.RowIndex].Cells[12].Value.ToString();
            VDescrip = DgvVenta.Rows[e.RowIndex].Cells[13].Value.ToString();
            VProCon = DgvVenta.Rows[e.RowIndex].Cells[14].Value.ToString();
            VProIva = DgvVenta.Rows[e.RowIndex].Cells[15].Value.ToString();
            SercoIVa = DgvVenta.Rows[e.RowIndex].Cells[16].Value.ToString();
            SerIva = DgvVenta.Rows[e.RowIndex].Cells[17].Value.ToString();
            VExento = DgvVenta.Rows[e.RowIndex].Cells[18].Value.ToString();
            VMesC = DgvVenta.Rows[e.RowIndex].Cells[19].Value.ToString();
            VEliminado = DgvVenta.Rows[e.RowIndex].Cells[20].Value.ToString();
            Lbldi.Text = VID;
        }
        private void BtnVenta_Click(object sender, EventArgs e)
        {

            string E = "", D = "";
            E = VEstado;
            D = VMesC;
            if (Lbldi.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Debe seleccionar una fila para editar", "INFORMACIÓN");
            }
            else
            {

                /*Se instancia un objeto para poder mostrar
               el panel AgregarTC, y limpiar el panel*/
                AgregarVenta AGVe = new AgregarVenta();
                panelcontrol2.Visible = false;
                panelControl1.Controls.Add(AGVe);
                /*Asignacion de valores a los Contenedores*/
                AGVe.LblCont.Text = VID;
                AGVe.CboMesDe.Text = VMes;
                AGVe.CboAñoDe.Text = VAnio;
                AGVe.TxtSerieFV.Text = VSerie;
                AGVe.TxtNoI.Text = VNumI;
                AGVe.TxtNoF.Text = VNumF;
                AGVe.Date.Text = VFecha;
                if (E == "1")
                {
                    AGVe.SwEstado.IsOn = true;
                }
                if (D == "1")
                {
                    AGVe.SwDMensual.IsOn = true;
                }
                AGVe.TxtIdCl.Text = VCliID;
                AGVe.TxtCodCl.Text = VCliCod;
                AGVe.TxtSocNom.Text = VRazonS;
                AGVe.TxtTFI.Text = VTotConIva;
                AGVe.TxtTIva.Text = TotIva;
                AGVe.TxtDV.Text = VDescrip;
                AGVe.TxtMIVA.Text = VProCon;
                AGVe.TxtIVavP.Text = VProIva;
                AGVe.TxtTSV.Text = SercoIVa;
                AGVe.TxtTIvaVS.Text = SerIva;
                AGVe.TxtExcento.Text = VExento;
                AGVe.SwEliminado.Visible = true;
                AGVe.LblEliminado.Visible = true;
                BtnVenta.Visible = false;

            }
        }
        #endregion
        /******************/

        /******************/
        #region Compra
        /*Variables para Datos*/
        #region Variables
        public static string CID;
        public static string Canio;
        public static string Cmes;
        public static string CSerie;
        public static string CNumero;
        public static string CFecha;
        public static string CEstado;
        public static string IdProvC;
        public static string CTotConIva;
        public static string CTotIVa;
        public static string CDescrip;
        public static string CMerconiva;
        public static string CMeriva;
        public static string COpsconiva;
        public static string Copiva;
        public static string CIdTipo;
        public static string CIGalones;
        public static string CIdpMonto;
        public static string CIdpIva;
        public static string CHosconiva;
        public static string CHosmonto;
        public static string CHosiva;
        public static string CTotE;
        public static string CMesCerrado;
        public static string CEliminado;
        #endregion
        private void DgvCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            CID = DgvCompra.Rows[e.RowIndex].Cells[0].Value.ToString();
            Canio = DgvCompra.Rows[e.RowIndex].Cells[1].Value.ToString();
            Cmes = DgvCompra.Rows[e.RowIndex].Cells[2].Value.ToString();
            CSerie = DgvCompra.Rows[e.RowIndex].Cells[3].Value.ToString();
            CNumero = DgvCompra.Rows[e.RowIndex].Cells[4].Value.ToString();
            CFecha = DgvCompra.Rows[e.RowIndex].Cells[5].Value.ToString();
            CEstado = DgvCompra.Rows[e.RowIndex].Cells[6].Value.ToString();
            IdProvC = DgvCompra.Rows[e.RowIndex].Cells[7].Value.ToString();
            CTotConIva = DgvCompra.Rows[e.RowIndex].Cells[8].Value.ToString();
            CTotIVa = DgvCompra.Rows[e.RowIndex].Cells[9].Value.ToString();
            CDescrip = DgvCompra.Rows[e.RowIndex].Cells[10].Value.ToString();
            CMerconiva = DgvCompra.Rows[e.RowIndex].Cells[11].Value.ToString();
            CMeriva = DgvCompra.Rows[e.RowIndex].Cells[12].Value.ToString();
            COpsconiva = DgvCompra.Rows[e.RowIndex].Cells[13].Value.ToString();
            Copiva = DgvCompra.Rows[e.RowIndex].Cells[14].Value.ToString();
            CIdTipo = DgvCompra.Rows[e.RowIndex].Cells[15].Value.ToString();
            CIGalones = DgvCompra.Rows[e.RowIndex].Cells[16].Value.ToString();
            CIdpMonto = DgvCompra.Rows[e.RowIndex].Cells[17].Value.ToString();
            CIdpIva = DgvCompra.Rows[e.RowIndex].Cells[18].Value.ToString();
            CHosconiva = DgvCompra.Rows[e.RowIndex].Cells[19].Value.ToString();
            CHosmonto = DgvCompra.Rows[e.RowIndex].Cells[20].Value.ToString();
            CHosiva = DgvCompra.Rows[e.RowIndex].Cells[21].Value.ToString();
            CTotE = DgvCompra.Rows[e.RowIndex].Cells[22].Value.ToString();
            CMesCerrado = DgvCompra.Rows[e.RowIndex].Cells[23].Value.ToString();
            CEliminado = DgvCompra.Rows[e.RowIndex].Cells[24].Value.ToString();
            Lbldi.Text = CID;
        }
        private void ACoACompra_Click(object sender, EventArgs e)
        {
            bool existe = panelControl1.Controls.OfType<AgregarCompra>().Any();

            if (!existe)
            {
                AgregarCompra AGCr = new AgregarCompra();
                panelControl1.Controls.Add(AGCr);
            }
        }
        private void AcoECompra_Click(object sender, EventArgs e)
        {
            panelcontrol2.Visible = true;
            dt = CR.Listado();
            DgvCompra.DataSource = dt;

            Buscador();
            panelcontrol2.Visible = true;
            DgvCompra.Visible = true;
            DgvTipo.Visible = false;
            DgvUsuario.Visible = false;
            DgvContr.Visible = false;
            BtnCompra.Visible = true;
            DgvVenta.Visible = false;
        }
        private void BtnCompra_Click(object sender, EventArgs e)
        {
            string E = "", D = "";
            E = VEstado;
            D = VMesC;
            if (Lbldi.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Debe seleccionar una fila para editar", "INFORMACIÓN");
            }
            else
            {
                /*Se instancia un objeto para poder mostrar
               el panel AgregarTC, y limpiar el panel*/
                AgregarCompra AGCom = new AgregarCompra();
                panelcontrol2.Visible = false;
                panelControl1.Controls.Add(AGCom);
                /*Asignacion de valores a los Contenedores*/
                AGCom.LblCont.Text = CID;
                AGCom.CboAño.Text = Canio;
                AGCom.CboMes.Text = Cmes;
                AGCom.TxtSerieFac.Text = CSerie;
                AGCom.TxtNoFac.Text = CNumero;
                AGCom.Date.Text = CFecha;
                if (E == "1")
                {
                    AGCom.SwE.IsOn = true;
                }
                if (D == "1")
                {
                    AGCom.SWMEs.IsOn = true;
                }
                AGCom.TxtIdProv.Text = IdProvC;
                AGCom.Idprov.Text = IdProvC;
                AGCom.TxtTotwiva.Text = CTotConIva;
                AGCom.TxtIVA.Text = CTotIVa;
                AGCom.TxtDescrip.Text = CDescrip;
                AGCom.TxtMerwiva.Text = CMerconiva;
                AGCom.TxtMerIVA.Text = CMeriva;
                AGCom.TxtTotalProd.Text = COpsconiva;
                AGCom.TxtIvaOtros.Text = Copiva;
                AGCom.CboCombustible.Text = CIdTipo;
                AGCom.TxtGalonesCom.Text = CIGalones;
                AGCom.TxtIDP.Text = CIdpMonto;
                AGCom.TxtIVA_IDp.Text = CIdpIva;
                AGCom.TxtHos.Text = CHosconiva;
                AGCom.TxtINguat.Text = CHosmonto;
                AGCom.TxtIvaHos.Text = CHosiva;
                AGCom.TxtExento.Text = CTotE;
                AGCom.SwEliminado.Visible = true;
                AGCom.LblEliminado.Visible = true;
                BtnCompra.Visible = true;
            }
        }
        #endregion
        /******************/

        /****************Bweteen**/
        #region Usuario_Contribuyente
        private void AcoUSAgregar_Click(object sender, EventArgs e)
        {

            bool existe = panelControl1.Controls.OfType<AgregarUsCo>().Any();

            if (!existe)
            {
                AgregarUsCo Agus = new AgregarUsCo();
            panelControl1.Controls.Add(Agus);      
            }

           
        }

        private void AcoExCompra_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dt = CR.Listado();
            dataGridView1.DataSource = dt;
            Cursor.Current = Cursors.WaitCursor;
            exp.ExportarDataGridViewExcel(dataGridView1);
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Exportados Correctamente....");
            dataGridView1.Visible = false;
            Cursor.Current = Cursor.Current;
        }

        private void AcoExVen_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dt = vn.Listado();
            dataGridView1.DataSource = dt;
            Cursor.Current = Cursors.WaitCursor;
            exp.ExportarDataGridViewExcel(dataGridView1);
            DevExpress.XtraEditors.XtraMessageBox.Show("Datos Exportados Correctamente....");
            dataGridView1.Visible = false;
            Cursor.Current = Cursor.Current;
        }




        #endregion
        /******************/
    }
}

/*   protected override void WndProc(ref Message M)
{
    if (M.Msg == WM_SYSCOMMAND)
    {
        if (M.WParam == (IntPtr)SC_MAXIMIZE)
            MessageBox.Show("");


        base.WndProc(ref M);
    }
    else
        base.WndProc(ref M);
}*/

