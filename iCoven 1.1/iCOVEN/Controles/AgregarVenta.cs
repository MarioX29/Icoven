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
    public partial class AgregarVenta : DevExpress.XtraEditors.XtraUserControl
    {
        /***********************/
        public AgregarVenta()
        {
            InitializeComponent();
        }
        /*********************/
        #region Instancias y Variables
        DataTable dt = new DataTable();
        public Venta vn = new Venta();
        string mensaje;
        public static string Id;
        public static string Codigo;
        public static string Nombre;
        #endregion
        /*************-*****/
        #region Metodos para las acciones
        private void BtnG()
        {

            if (String.IsNullOrEmpty(CboMesDe.Text))
            {
                Error.SetError(CboMesDe, "Seleccione un mes ");
                CboMesDe.Focus();
            }
            if (String.IsNullOrEmpty(CboAñoDe.Text))
            {
                Error.SetError(CboAñoDe, "Seleccione un año");
            }
            if (String.IsNullOrEmpty(TxtNoI.Text))
            {
                Error.SetError(TxtNoI, "Debe ingresar un Numero inicial");
            }
            if (String.IsNullOrEmpty(Date.Text))
            {
                Error.SetError(Date, "Seleccione una fecha");
            }
            if (String.IsNullOrEmpty(TxtCodCl.Text))
            {
                Error.SetError(TxtCodCl, "Seleccione un cliente");
            }
            if (String.IsNullOrEmpty(TxtSocNom.Text))
            {
                Error.SetError(TxtCodCl, "Seleccione un cliente");
            }
            if (String.IsNullOrEmpty(TxtIdCl.Text))
            {
                Error.SetError(TxtCodCl, "Seleccione un cliente");
            }
            else
           if (CboAñoDe.Text != "" && CboMesDe.Text != "" && TxtNoI.Text != "" && Date.Text != "" && TxtCodCl.Text != "" && TxtIdCl.Text != "" && TxtSocNom.Text != "")
            {
                vn.VAnio = CboAñoDe.Text;
                vn.VMes = CboMesDe.Text;
                vn.VSerie = TxtSerieFV.Text;
                vn.VNumI = TxtNoI.Text;
                vn.VNumF = TxtNoF.Text;
                DateTime fecha = Convert.ToDateTime(Date.Text);
                vn.VFecha = fecha.ToString("yyyy-MM-dd");
                if (SwEstado.IsOn == true)
                {
                    vn.VEstado = '1';
                }
                else
                {
                    vn.VEstado = '0';
                }
                vn.VIdCli = Convert.ToInt32(TxtIdCl.Text);
                vn.VCodigoCli = TxtCodCl.Text;
                vn.VRCli = TxtSocNom.Text;
                vn.VTConIVa = Convert.ToDouble(TxtTFI.Text);
                vn.IvaV = Convert.ToDouble(TxtTIva.Text);
                vn.VDescrip = TxtDV.Text;
                vn.MercaIVA = Convert.ToDouble(TxtMIVA.Text);
                vn.IVATotal = Convert.ToDouble(TxtIVavP.Text);
                vn.Servicios = Convert.ToDouble(TxtTSV.Text);
                vn.SerIVA = Convert.ToDouble(TxtTIvaVS.Text);
                vn.Exento = Convert.ToDouble(TxtExcento.Text);
                if (SwDMensual.IsOn == true)
                {
                    vn.VMesCerrado = '1';
                }
                else
                {
                    vn.VMesCerrado = '0';
                }
                if (SwEliminado.IsOn == true)
                {
                    vn.VEliminado = '1';
                }
                else
                {
                    vn.VEliminado = '0';
                }
                label.Text = mensaje;
                Error.Dispose();
                int resultado = vn.Agregar();
                LblCont.Text = resultado.ToString();
            }
        }
        private void Act()
        {
            /*Actualizacion de datos*/

            if (String.IsNullOrEmpty(CboMesDe.Text))
            {
                Error.SetError(CboMesDe, "Seleccione un mes ");
                CboMesDe.Focus();
            }
            if (String.IsNullOrEmpty(CboAñoDe.Text))
            {
                Error.SetError(CboAñoDe, "Seleccione un año");
            }
            if (String.IsNullOrEmpty(TxtNoI.Text))
            {
                Error.SetError(TxtNoI, "Debe ingresar un Numero inicial");
            }
            if (String.IsNullOrEmpty(Date.Text))
            {
                Error.SetError(Date, "Seleccione una fecha");
            }
            if (String.IsNullOrEmpty(TxtCodCl.Text))
            {
                Error.SetError(TxtCodCl, "Seleccione un cliente");
            }
            if (String.IsNullOrEmpty(TxtSocNom.Text))
            {
                Error.SetError(TxtCodCl, "Seleccione un cliente");
            }
            if (String.IsNullOrEmpty(TxtIdCl.Text))
            {
                Error.SetError(TxtCodCl, "Seleccione un cliente");
            }
            else
           if (CboAñoDe.Text != "" && CboMesDe.Text != "" && TxtNoI.Text != "" && Date.Text != "" && TxtCodCl.Text != "" && TxtIdCl.Text != "" && TxtSocNom.Text != "")
            {
                vn.VAnio = CboAñoDe.Text;
                vn.VMes = CboMesDe.Text;
                vn.VSerie = TxtSerieFV.Text;
                vn.VNumI = TxtNoI.Text;
                vn.VNumF = TxtNoF.Text;
                DateTime fecha = Convert.ToDateTime(Date.Text);
                vn.VFecha = fecha.ToString("yyyy-MM-dd");
                if (SwEstado.IsOn == true)
                {
                    vn.VEstado = '1';
                }
                else
                {
                    vn.VEstado = '0';
                }
                vn.VIdCli = Convert.ToInt32(TxtIdCl.Text);
                vn.VCodigoCli = TxtCodCl.Text;
                vn.VRCli = TxtSocNom.Text;
                vn.VTConIVa = Convert.ToDouble(TxtTFI.Text);
                vn.IvaV = Convert.ToDouble(TxtTIva.Text);
                vn.VDescrip = TxtDV.Text;
                vn.MercaIVA = Convert.ToDouble(TxtMIVA.Text);
                vn.IVATotal = Convert.ToDouble(TxtIVavP.Text);
                vn.Servicios = Convert.ToDouble(TxtTSV.Text);
                vn.SerIVA = Convert.ToDouble(TxtTIvaVS.Text);
                vn.Exento = Convert.ToDouble(TxtExcento.Text);
                if (SwDMensual.IsOn == true)
                {
                    vn.VMesCerrado = '1';
                }
                else
                {
                    vn.VMesCerrado = '0';
                }
                if (SwEliminado.IsOn == true)
                {
                    vn.VEliminado = '1';
                }
                else
                {
                    vn.VEliminado = '0';
                }
                vn.IdV = Convert.ToInt32(LblCont.Text);
                int resultado = vn.Actualizar();
                label.Text = "Datos Actualizados correctamente";
            }
        }
        private void Limpiar()
        {
            TxtCodCl.Text = "";
            TxtDV.Text = "";
            TxtExcento.Text = "";
            TxtIdCl.Text = "";
            TxtIVavP.Text = "";
            TxtMIVA.Text = "";
            TxtNoF.Text = "";
            TxtNoI.Text = "";
            TxtSerieFV.Text = "";
            TxtSocNom.Text = "";
            TxtTFI.Text = "";
            TxtTIva.Text = "";
            TxtTIvaVS.Text = "";
            TxtTSV.Text = "";
            CboAñoDe.Text = "";
            CboMesDe.Text = "";
            if (SwEstado.IsOn == false)
            {
                SwEstado.IsOn = true;
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
            dt = vn.ListadoB();
            DgvCo.DataSource = dt;
        }
        private void DgvCo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = DgvCo.Rows[e.RowIndex].Cells[0].Value.ToString();
            Codigo = DgvCo.Rows[e.RowIndex].Cells[1].Value.ToString();
            Nombre = DgvCo.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSocNom.Text = Nombre;
            TxtIdCl.Text = Id;
            TxtCodCl.Text = Codigo;
            panelControl1.Hide();
        } 
        #endregion
        /***************/
        #region Botones
        private void SwExento_Toggled(object sender, EventArgs e)
        {
            if (SwExento.IsOn == false)
            {
                TxtExcento.Enabled = false;
                TxtExcento.Text = "0";
                TxtIVavP.Enabled = true;
                TxtMIVA.Enabled = true;
                TxtTIvaVS.Enabled = true;
                TxtTIva.Enabled = true;
                TxtTFI.Enabled = true;
                TxtTSV.Enabled = true;
            }
            else
            {
                TxtExcento.Enabled = true;
                TxtIVavP.Enabled = false; TxtIVavP.Text = "0";
                TxtMIVA.Enabled = false; TxtMIVA.Text = "0";
                TxtTIvaVS.Enabled = false; TxtTIvaVS.Text = "0";
                TxtTIva.Enabled = false; TxtTIva.Text = "0";
                TxtTFI.Enabled = false; TxtTFI.Text = "0";
                TxtTSV.Enabled = false; TxtTSV.Text = "0";


            }
        }
        /**Guardar y Continuar*/
        private void BtnSnC1_Click(object sender, EventArgs e)
        {/**Se verifica que el label no este
            vacio para poder actualizar*/
            if (LblCont.Text != "")
            {
                Act();
                LblCont.Text = "";
                if (CboAñoDe.Text != "" && CboMesDe.Text != "" && TxtNoI.Text != "" && Date.Text != "" && TxtCodCl.Text != "" && TxtIdCl.Text != "" && TxtSocNom.Text != "")
                {
                    Limpiar();
                }
            }
            else
            {
                mensaje = "Datos Guardados:Puede ingresar nuevos datos";
                BtnG();
                if (CboAñoDe.Text != "" && CboMesDe.Text != "" && TxtNoI.Text != "" && Date.Text != "" && TxtCodCl.Text != "" && TxtIdCl.Text != "" && TxtSocNom.Text != "")
                {
                    Limpiar();
                }
            }
        }
        /**Guadar*/
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
                if (CboAñoDe.Text != "" && CboMesDe.Text != "" && TxtNoI.Text != "" && Date.Text != "" && TxtCodCl.Text != "" && TxtIdCl.Text != "" && TxtSocNom.Text != "")
                {
                    this.Dispose();
                }
            }
            else
            {
                BtnG();
                if (CboAñoDe.Text != "" && CboMesDe.Text != "" && TxtNoI.Text != "" && Date.Text != "" && TxtCodCl.Text != "" && TxtIdCl.Text != "" && TxtSocNom.Text != "")
                {
                    this.Dispose();
                }
            }
        }
        /**Salir*/
        private void BtnSalirC1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TxtBuscar_EditValueChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $" Razon_Social LIKE '{TxtBuscar.Text}%'";
        }

        private void DgvCo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AgregarVenta_Load(object sender, EventArgs e)
        {

        }
        #endregion
        /************/
    }
}
