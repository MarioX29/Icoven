using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LOGICA;
namespace iCOVEN
{
    public partial class AgregarProv : DevExpress.XtraEditors.XtraUserControl
    {
        public AgregarProv()
        {
            InitializeComponent();
        }
        /*********************/
        #region Variables e Instancias
        public static string Id;
        public static string Nombre;
        Proveedor PR = new Proveedor();
        DataTable dt = new DataTable();
        string mensaje; 
        #endregion
        /*******************/
        #region Metodos para la acciones 
        private void BtnG()
        {
            if (String.IsNullOrEmpty(TxtCodP.Text))
            {
                Error.SetError(TxtCodP, "Debe ingresar un codigo");

            }
            if (String.IsNullOrEmpty(TxtNombreP.Text))
            {
                Error.SetError(TxtNombreP, "Debe ingresar un Nombre");
                TxtNombreP.Focus();
            }
            if (String.IsNullOrEmpty(TxtFr.Text))
            {
                Error.SetError(TxtFr, "Debe ingresar una fecuencia del Prov");
            }
            if (String.IsNullOrEmpty(TxtIdtdc.Text))
            {
                Error.SetError(TxtIdtdc, "Debe seleccionar un ID");
            }

            else
            if (TxtNombreP.Text!=""&&TxtCodP.Text!=""&&TxtFr.Text!=""&&TxtIdtdc.Text!="")
            {
                PR.CodigoP = TxtCodP.Text;
                PR.NombreProv = TxtNombreP.Text;
                PR.RazonC = TxtRComercial.Text;
                if (SWTipoPe.IsOn == true)
                {
                    PR.TPersona = 'J';
                }
                else
                {
                    PR.TPersona = 'N';
                }
                PR.Direccion = TxtDireccionP.Text;
                PR.Telefono = TxtTelProv.Text;
                PR.Correo = TxtCorreoPr.Text;
                PR.Web = TxtWeb.Text;
                PR.ProfLinea = TxtLinea.Text;
                if (SwEsP.IsOn == true)
                {
                    PR.Estado = '1';
                }
                else
                {
                    PR.Estado = '0';
                }
                PR.Frecuencia = Convert.ToInt32(TxtFr.Text);
                PR.IdTC = Convert.ToInt32(LbTC.Text);
                labelC.Text = mensaje;
                Error.Dispose();
                int resultado = PR.Agregar();
                LblCont.Text = resultado.ToString();
            }
            else
            {
                XtraMessageBox.Show("Hay campos obligatorios vacios");
            }
        }
        private void Act()
        {
            if (String.IsNullOrEmpty(TxtCodP.Text))
            {
                Error.SetError(TxtCodP, "Debe ingresar un codigo");

            }
            if (String.IsNullOrEmpty(TxtNombreP.Text))
            {
                Error.SetError(TxtNombreP, "Debe ingresar un Nombre");
                TxtNombreP.Focus();
            }
            if (String.IsNullOrEmpty(TxtFr.Text))
            {
                Error.SetError(TxtFr, "Debe ingresar una fecuencia del Prov");
            }
            if (String.IsNullOrEmpty(TxtIdtdc.Text))
            {
                Error.SetError(TxtIdtdc, "Debe seleccionar un ID");
            }

            else
            if (TxtNombreP.Text != "" && TxtCodP.Text != "" && TxtFr.Text != "" && TxtIdtdc.Text != "")
            {
                PR.CodigoP = TxtCodP.Text;
                PR.NombreProv = TxtNombreP.Text;
                PR.RazonC = TxtRComercial.Text;
                if (SWTipoPe.IsOn == true)
                {
                    PR.TPersona = 'J';
                }
                else
                {
                    PR.TPersona = 'N';
                }
                PR.Direccion = TxtDireccionP.Text;
                PR.Telefono = TxtTelProv.Text;
                PR.Correo = TxtCorreoPr.Text;
                PR.Web = TxtWeb.Text;
                PR.ProfLinea = TxtLinea.Text;
                if (SwEsP.IsOn == true)
                {
                    PR.Estado = '1';
                }
                else
                {
                    PR.Estado = '0';
                }
                PR.Frecuencia = Convert.ToInt32(TxtFr.Text);
                PR.IdTC = Convert.ToInt32(LbTC.Text);
                PR.IdP = Convert.ToInt32(LblCont.Text);
                int resultado = PR.Actualizar();
                labelC.Text = "Datos Actualizados correctamente";
            }
            else
            {
                XtraMessageBox.Show("Hay campos obligatorios vacios");
            }
        }
        private void Limpiar()
        {
            TxtCodP.Text = "";
            TxtCorreoPr.Text = "";
            TxtDireccionP.Text = "";
            TxtFr.Text = "";
            TxtIdtdc.Text = "";
            TxtLinea.Text = "";
            TxtNombreP.Text = "";
            TxtRComercial.Text = "";
            TxtTelProv.Text = "";
            TxtWeb.Text = "";
            if (SwEsP.IsOn == false)
            {
                SwEsP.IsOn = true;
            }
            if (SWTipoPe.IsOn == true)
            {
                SWTipoPe.IsOn = false;
            }
        }
        #endregion
        /*****************/
        #region Buscar ID
        private void BtnBid_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            DgvCo.Visible = true;
            TxtBuscar.Visible = true;
            LblB.Visible = true;
            dt = PR.ListadoB();
            DgvCo.DataSource = dt;
        }
        private void DgvCo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = DgvCo.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nombre = DgvCo.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtIdtdc.Text = Nombre;
            LbTC.Text = Id;

            panelControl1.Hide();
        }
        private void TxtBuscar_EditValueChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $" Nombre LIKE '{TxtBuscar.Text}%'";
        }
        #endregion
        /***************/
        #region Solo Numeros 
        private void AgregarProv_Load(object sender, EventArgs e)
        {

        }
        private void TxtTelProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                XtraMessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void TxtFr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                XtraMessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        } 
        #endregion
        /*************/
        #region Botones
        /**Salir*/
        private void BtnSalirC1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /**Guardar y Continuar*/
        private void BtnSnC1_Click(object sender, EventArgs e)
        {
            /**Se verifica que el label no este
           vacio para poder actualizar*/
            if (LblCont.Text != "")
            {
                Act();
                LblCont.Text = "";
                if (TxtNombreP.Text != "" && TxtIdtdc.Text != ""  && TxtFr.Text != ""  && TxtCodP.Text != "" )
                {
                    Limpiar();
                }
            }
            else
            {
                mensaje = "Datos Guardados:Puede ingresar nuevos datos";
                BtnG();
               if (TxtNombreP.Text != "" && TxtIdtdc.Text != "" && TxtFr.Text != "" && TxtCodP.Text != "" )
                    {
                    Limpiar();
                }
            }
        }
        /**Guardar*/
        private void BtnGC1_Click(object sender, EventArgs e)
        {
            if (LblCont.Text != "")
            {
                Act();
            }
            else
            {
                mensaje = "Datos Guardados: Ahora puede modificar";
                BtnG();
            }
        }
        /**Guardar y Salir*/
        private void BtnSC1_Click(object sender, EventArgs e)
        {
            if (LblCont.Text != "")
            {
                Act();
                if (TxtNombreP.Text != "" && TxtRComercial.Text != "" && TxtIdtdc.Text != "" && TxtWeb.Text != "" && TxtFr.Text != "" && TxtDireccionP.Text != "" && TxtCodP.Text != "" && TxtIdtdc.Text != "")
                {
                    this.Dispose();
                }
            }
            else
            {
                BtnG();
                if (TxtNombreP.Text != "" && TxtRComercial.Text != "" && TxtIdtdc.Text != "" && TxtWeb.Text != "" && TxtFr.Text != "" && TxtDireccionP.Text != "" && TxtCodP.Text != "" && TxtIdtdc.Text != "")
                {
                    this.Dispose();
                }
            }
        } 
        #endregion
        /***********/
    }
}
