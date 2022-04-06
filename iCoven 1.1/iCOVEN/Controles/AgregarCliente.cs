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
    public partial class AgregarCliente : DevExpress.XtraEditors.XtraUserControl
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }
        /*******************/
        #region Instancias y Variables 
        public DataTable dt = new DataTable();
        Cliente Cl = new Cliente();
        public static string Id;
        string mensaje; 
        #endregion
        /*****************/
        #region Buscar ID
        private void TxtBuscar_EditValueChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $" Nombre LIKE '{TxtBuscar.Text}%'";
        }
        private void BtnBid_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            DgvCo.Visible = true;
            TxtBuscar.Visible = true;
            LblB.Visible = true;
            dt = Cl.ListadoB();
            DgvCo.DataSource = dt;
        }
        private void DgvCo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = DgvCo.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtIdTC.Text = Id;
            DgvCo.Visible = false;
            LblB.Visible = false;
            TxtBuscar.Visible = false;
            panelControl1.Visible = false;
        }
        private void AgregarCliente_Load(object sender, EventArgs e)
        {
        }
        #endregion
        /**************/
        #region Metodos para las Acciones
        private void Act()
        {
            /*Actualizacion de datos*/
            if (String.IsNullOrEmpty(TxtNombre.Text))
            {
                Error.SetError(TxtNombre, "Debe ingresar un Nombre");
                TxtNombre.Focus();
            }
            if (String.IsNullOrEmpty(TxtCodigo.Text))
            {
                Error.SetError(TxtCodigo, "Debe ingresar un Codigo");
            }
            if (String.IsNullOrEmpty(TxtFrec.Text))
            {
                Error.SetError(TxtFrec, "Debe ingresar la Frecuencia");
            }
            if (String.IsNullOrEmpty(TxtIdTC.Text))
            {
                Error.SetError(TxtIdTC, "Debe seleccionar un ID");
            }
            else
            if (TxtNombre.Text != "" && TxtCodigo.Text != "" && TxtFrec.Text != "" && TxtIdTC.Text != "")
            {
                Cl.CodigoC = TxtCodigo.Text;
                Cl.NombreC = TxtNombre.Text;
                Cl.RComecialC = TxtRC.Text;
                if (SWP.IsOn == true)
                {
                    Cl.TPC = 'J';
                }
                else
                {
                    Cl.TPC = 'N';
                }
                Cl.DireccionC = TxtDirc.Text;
                Cl.TelC = TxtTelC.Text;
                Cl.CorreoC = TxtCorreo.Text;
                Cl.WebC = TxtWeb.Text;
                Cl.LnegocioC = TxtLineac.Text;
                if (SwE.IsOn == true)
                {
                    Cl.EstadoC = '1';
                }
                else
                {
                    Cl.EstadoC = '0';
                }
                Cl.FrecuenciaC = Convert.ToInt32(TxtFrec.Text);
                Cl.idTCi = Convert.ToInt32(TxtIdTC.Text);
                /*Se obtiene el id de los datos ingresados*/
                Cl.idC = Convert.ToInt32(LblCont.Text);
                int resultado = Cl.Actualizar();
                label.Text = "Datos Actualizados correctamente";
            }
            else
            {
                XtraMessageBox.Show("Hay campos obligatorios vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            TxtCorreo.Text = "";
            TxtDirc.Text = "";
            TxtFrec.Text = "";
            TxtIdTC.Text = "";
            TxtLineac.Text = "";
            TxtRC.Text = "";
            TxtTelC.Text = "";
            TxtWeb.Text = "";
            if (SwE.IsOn == false)
            {
                SwE.IsOn = true;

            }
            if (SWP.IsOn == true)
            {
                SWP.IsOn = false;
            }
        }
        private void BtnG()
        {

            /*Actualizacion de datos*/
            if (String.IsNullOrEmpty(TxtNombre.Text))
            {
                Error.SetError(TxtNombre, "Debe ingresar un Nombre");
                TxtNombre.Focus();
            }
            if (String.IsNullOrEmpty(TxtCodigo.Text))
            {
                Error.SetError(TxtCodigo, "Debe ingresar un Codigo");
            }
            if (String.IsNullOrEmpty(TxtFrec.Text))
            {
                Error.SetError(TxtFrec, "Debe ingresar la Frecuencia");
            }
            if (String.IsNullOrEmpty(TxtIdTC.Text))
            {
                Error.SetError(TxtIdTC, "Debe seleccionar un ID");
            }
            else
            if (TxtNombre.Text!=""&&TxtCodigo.Text!=""&&TxtFrec.Text!=""&&TxtIdTC.Text!="")
                {
                Cl.CodigoC = TxtCodigo.Text;
                Cl.NombreC = TxtNombre.Text;
                Cl.RComecialC = TxtRC.Text;
                if (SWP.IsOn == true)
                {
                    Cl.TPC = 'J';
                }
                else
                {
                    Cl.TPC = 'N';
                }
                Cl.DireccionC = TxtDirc.Text;
                Cl.TelC = TxtTelC.Text;
                Cl.CorreoC = TxtCorreo.Text;
                Cl.WebC = TxtWeb.Text;
                Cl.LnegocioC = TxtLineac.Text;
                if (SwE.IsOn == true)
                {
                    Cl.EstadoC = '1';
                }
                else
                {
                    Cl.EstadoC = '0';
                }
                Cl.FrecuenciaC = Convert.ToInt32(TxtFrec.Text);
                Cl.idTCi = Convert.ToInt32(TxtIdTC.Text);
                label.Text = mensaje;
                Error.Dispose();
                int resultado = Cl.Agregar();
                LblCont.Text = resultado.ToString();
            }
            else
            {
                XtraMessageBox.Show("Hay campos obligatorios vacios","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
           
        } 
        #endregion
        /************/
        #region Botones
        private void BtnSnC1_Click(object sender, EventArgs e)
        {
            /**Se verifica que el label no este
           vacio para poder actualizar*/
            if (LblCont.Text != "")
            {
                Act();
                LblCont.Text = "";
                if (TxtCodigo.Text != "" && TxtNombre.Text != "" && TxtIdTC.Text != "")
                {
                    Limpiar();
                }
            }
            else
            {
                mensaje = "Datos Guardados:Puede ingresar nuevos datos";
                BtnG();
                if (TxtCodigo.Text != "" && TxtNombre.Text != "" && TxtIdTC.Text != "")
                {
                    Limpiar();
                }
            }
        }
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
        private void BtnSC1_Click(object sender, EventArgs e)
        {
            if (LblCont.Text != "")
            {
                Act();
                if (TxtCodigo.Text != "" && TxtNombre.Text != "" && TxtIdTC.Text != "")
                {
                    this.Dispose();
                }
            }
            else
            {
                BtnG();
                if (TxtCodigo.Text != "" && TxtNombre.Text != "" && TxtIdTC.Text != "")
                {
                    this.Dispose();
                }
            }
        }
        private void BtnSalirC1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        } 
        #endregion
        /**********/
    }
}
