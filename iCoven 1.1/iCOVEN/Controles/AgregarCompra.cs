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
    public partial class AgregarCompra : DevExpress.XtraEditors.XtraUserControl
    {
        /*********************/
        #region Instancias y Variables
        double TotCI = 0, TotIVA = 0, MercaI = 0, IVAM = 0, OtCiva = 0, OTrIVA = 0;
        //TotIVA, MercaI, IVAM, OtCIVA, OtrIVA;
        string mensaje;
        Compra CR = new Compra();
        DataTable dt = new DataTable();
        public static string Id;
        public static string Nombre; 
        #endregion
        /*********************/
        public AgregarCompra()
        {
            InitializeComponent();
        }
        /*********************/
        #region Metodos para las Acciones 
        private void BtnG()
        {

            if (String.IsNullOrEmpty(CboMes.Text))
            {
                Error.SetError(CboMes, "Seleccione un mes ");
                CboMes.Focus();
            }
            if (String.IsNullOrEmpty(CboAño.Text))
            {
                Error.SetError(CboAño, "Seleccione un año");
            }
            if (String.IsNullOrEmpty(TxtIdProv.Text))
            {
                Error.SetError(TxtIdProv, "Seleccione un ID");
            }
            else
            if(CboMes.Text!=""&&CboAño.Text!=""&&TxtIdProv.Text!="" ) 
                {
                CR.Anio = CboAño.Text;
                CR.Mes = CboMes.Text;
                CR.Serie = TxtSerieFac.Text;
                CR.NumFac = TxtNoFac.Text;
                DateTime fecha = Convert.ToDateTime(Date.Text);
                CR.FechaC = fecha.ToString("yyyy-MM-dd");
                if (SwE.IsOn == true)
                {
                    CR.EstadoCo = '1';
                }
                else
                {
                    CR.EstadoCo = '0';
                }
                CR.idProv = Convert.ToInt32(Idprov.Text);
                TotCI = Convert.ToDouble(TxtTotwiva.Text);
                CR.ToCiva = Convert.ToDouble(TxtTotwiva.Text);
                CR.Ivat = Convert.ToDouble(TxtIVA.Text);
                CR.Descrip = TxtDescrip.Text;
                CR.MerwIva = Convert.ToDouble(TxtMerwiva.Text);
                CR.Meriva = Convert.ToDouble(TxtMerIVA.Text);
                CR.OtrIva = Convert.ToDouble(TxtTotalProd.Text);
                CR.Opiva = Convert.ToDouble(TxtIvaOtros.Text);
                CR.TipCom = CboCombustible.Text;
                CR.Galones = Convert.ToDouble(TxtGalonesCom.Text);
                CR.IdpMon = Convert.ToDouble(TxtIDP.Text);
                CR.IdPIva = Convert.ToDouble(TxtIVA_IDp.Text);
                CR.HoswIva = Convert.ToDouble(TxtHos.Text);
                CR.HosMon = Convert.ToDouble(TxtINguat.Text);
                CR.Hosiva = Convert.ToDouble(TxtIvaHos.Text);
                CR.TExcento = Convert.ToDouble(TxtExento.Text);
                if (SWMEs.IsOn == true)
                {
                    CR.MesCr = '1';
                }
                else
                {
                    CR.MesCr = '0';
                }
                if (SwEliminado.IsOn == true)
                {
                    CR.Eliminado = '1';
                }
                else
                {
                    CR.Eliminado = '0';
                }

                label.Text = mensaje;
                Error.Dispose();
                int resultado = CR.Agregar();
                LblCont.Text = resultado.ToString();
            }
            else
            {
                XtraMessageBox.Show("Campos obligatorios vacios","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        private void Limpiar()
        {
            TxtDescrip.Text = "";
            TxtExento.Text = "";
            TxtGalonesCom.Text = "";
            TxtHos.Text = "";
            TxtIDP.Text = "";
            TxtIdProv.Text = "";
            Idprov.Text = "";
            TxtINguat.Text = "";
            TxtIVA.Text = "";
            TxtIvaHos.Text = "";
            TxtIvaOtros.Text = "";
            TxtIVA_IDp.Text = "";
            TxtMerIVA.Text = "";
            TxtMerwiva.Text = "";
            TxtNoFac.Text = "";
            TxtSerieFac.Text = "";
            TxtTotalProd.Text = "";
            TxtTotwiva.Text = "";
            CboAño.Text = "";
            CboCombustible.Text = "";
            CboMes.Text = "";

            if (SwE.IsOn == false)
            {
                SwE.IsOn = true;
            }
            if (SWMEs.IsOn == false)
            {
                SWMEs.IsOn = true;
            }
            LblCont.Text = "";

        }
        private void Act()
        {
            if (String.IsNullOrEmpty(CboMes.Text))
            {
                Error.SetError(CboMes, "Seleccione un mes ");
                CboMes.Focus();
            }
            if (String.IsNullOrEmpty(CboAño.Text))
            {
                Error.SetError(CboAño, "Seleccione un año");
            }
            if (String.IsNullOrEmpty(TxtIdProv.Text))
            {
                Error.SetError(TxtIdProv, "Seleccione un ID");
            }
            else
            if (CboMes.Text != "" && CboAño.Text != "" && TxtIdProv.Text != "")
            {
                CR.Anio = CboAño.Text;
                CR.Mes = CboMes.Text;
                CR.Serie = TxtSerieFac.Text;
                CR.NumFac = TxtNoFac.Text;
                DateTime fecha = Convert.ToDateTime(Date.Text);
                CR.FechaC = fecha.ToString("yyyy-MM-dd");
                if (SwE.IsOn == true)
                {
                    CR.EstadoCo = '1';
                }
                else
                {
                    CR.EstadoCo = '0';
                }
                CR.idProv = Convert.ToInt32(Idprov.Text);
                CR.ToCiva = Convert.ToDouble(TxtTotwiva.Text);
                CR.Ivat = Convert.ToDouble(TxtIVA.Text);
                CR.Descrip = TxtDescrip.Text;
                CR.MerwIva = Convert.ToDouble(TxtMerwiva.Text);
                CR.Meriva = Convert.ToDouble(TxtMerIVA.Text);
                CR.OtrIva = Convert.ToDouble(TxtTotalProd.Text);
                CR.Opiva = Convert.ToDouble(TxtIvaOtros.Text);
                CR.TipCom = CboCombustible.Text;
                CR.Galones = Convert.ToDouble(TxtGalonesCom.Text);
                CR.IdpMon = Convert.ToDouble(TxtIDP.Text);
                CR.IdPIva = Convert.ToDouble(TxtIVA_IDp.Text);
                CR.HoswIva = Convert.ToDouble(TxtHos.Text);
                CR.HosMon = Convert.ToDouble(TxtINguat.Text);
                CR.Hosiva = Convert.ToDouble(TxtIvaHos.Text);
                CR.TExcento = Convert.ToDouble(TxtExento.Text);
                if (SWMEs.IsOn == true)
                {
                    CR.MesCr = '1';
                }
                else
                {
                    CR.MesCr = '0';
                }
                if (SwEliminado.IsOn == true)
                {
                    CR.Eliminado = '1';
                }
                else
                {
                    CR.Eliminado = '0';
                }
                CR.idComp = Convert.ToInt32(LblCont.Text);
                int resultado = CR.Actualizar();
                label.Text = "Datos Actualizados correctamente";
            }
            else
            {
                XtraMessageBox.Show("Campos obligatorios vacios","Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } 
        #endregion
        /*********************/
     
        double cantidad = 0, superior = 0, /*regular =0, diesel=0,*/montoIdp = 0;

        private void BtnBid_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            DgvCo.Visible = true;
            TxtBuscar.Visible = true;
            LblB.Visible = true;
            dt = CR.ListadoB();
            DgvCo.DataSource = dt;
        }
        private void DgvCo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = DgvCo.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nombre = DgvCo.Rows[e.RowIndex].Cells[1].Value.ToString();
            Idprov.Text = Id;
            
            TxtIdProv.Text = Nombre;
            panelControl1.Hide();
        }
        private void TxtNoFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //else if (Char.IsPunctuation(e.KeyChar))
            //{
            //    e.Handled = false;
            //}

            else
            {
                XtraMessageBox.Show("El campo solo acepta valores numericos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNoFac.Focus();
                e.Handled = true;
            }

        }

        #region Botones 
        private void BtnSalirC1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnSnC1_Click(object sender, EventArgs e)
        {
            /**Se verifica que el label no este
            vacio para poder actualizar*/
            if (LblCont.Text != "")
            {
                Act();
                LblCont.Text = "";
                if (CboAño.Text != "" && CboMes.Text != "" && TxtIdProv.Text != "" && Date.Text != "")
                {
                    Limpiar();
                }
            }
            else
            {
                mensaje = "Datos Guardados:Puede ingresar nuevos datos";
                BtnG();
                if (CboAño.Text != "" && CboMes.Text != "" && TxtIdProv.Text != "" && Date.Text != "")
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
                if (CboAño.Text != "" && CboMes.Text != "" && TxtIdProv.Text != "" && Date.Text != "")
                {
                    this.Dispose();
                }
            }
            else
            {
                BtnG();
                if (CboAño.Text != "" && CboMes.Text != "" && TxtIdProv.Text != "" && Date.Text != "")
                {
                    this.Dispose();
                }
            }
        } 
        #endregion

        private void CboCombustible_SelectedIndexChanged(object sender, EventArgs e)
        {
         }
        private void TxtGalonesCom_EditValueChanged(object sender, EventArgs e)

        {
            if (CboCombustible.Text == "Superior")
            {
                if (TxtGalonesCom.Text != "")
                {
                    cantidad = Convert.ToDouble(TxtGalonesCom.Text);
                    superior = cantidad * 4.70;
                    montoIdp = superior;
                    TxtIDP.Text = Convert.ToString(montoIdp);

                }
            }
        }
        private void AgregarCompra_Load(object sender, EventArgs e)
        {
        }
        private void TxtTotalProd_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtTotalProd.Text != "")
            { 
                 OtCiva= Convert.ToDouble(TxtTotalProd.Text);
                OTrIVA = (OtCiva / 1.12) * 0.12;
                //   TxtIVA.Text = Convert.ToString(TotIVA);
                Math.Round(OTrIVA);
                TxtIvaOtros.Text = Convert.ToString(OTrIVA);
            }
            else
            {
                TxtIvaOtros.Text = "";
            }
        }
        private void TxtTotwiva_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtTotwiva.Text!="")
            { TotCI = Convert.ToDouble(TxtTotwiva.Text);  
            TotIVA = (TotCI / 1.12) * 0.12;
                //   TxtIVA.Text = Convert.ToString(TotIVA);
                TxtIVA.Text = Convert.ToString(TotIVA);
            }
            else
            {
                TxtIVA.Text = "";
             }
        }
        private void TxtMerwiva_EditValueChanged(object sender, EventArgs e)
        {
            if (TxtMerwiva.Text!="")
            {
                MercaI = Convert.ToDouble(TxtMerwiva.Text);
                IVAM = (MercaI / 1.12) * 0.12;

               // MessageBox.Show(IVAM.ToString());

                 TxtMerIVA.Text = Convert.ToString(IVAM);    
            }
            else
            {
                TxtMerIVA.Text = "";
            }
        }
    }
}
