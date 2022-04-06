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
    public partial class AgregarUsCo : DevExpress.XtraEditors.XtraUserControl
    {

        #region Instancias y Variables
        Usuario U = new Usuario();
        Contribuyente C = new Contribuyente();
        public DataTable dt = new DataTable();
        UsCo Usc = new UsCo();
        public static string Id;
        string mensaje; 
        #endregion
        public AgregarUsCo()
        {
            InitializeComponent();
        }
        
        #region Metodos para la Acciones
        private void Act()
        {
            /*Actualizacion de datos*/
            if (TxtIdUs.Text == "")
            {
                Error.SetError(TxtIdUs, "Agregue un Codigo");
                TxtIdUs.Focus();
            }
            else
            {
                Usc.IdUc = Convert.ToInt32(TxtIdE.Text);
                Usc.IdUs = Convert.ToInt32(TxtIdUs.Text);
                if (SwE.IsOn == true)
                {
                    Usc.EstadoUC = '1';
                }
                else
                {
                    Usc.EstadoUC = '0';
                }

                /*Se obtiene el id de los datos ingresados*/
                Usc.Id = Convert.ToInt32(LblCont.Text);
                int resultado = Usc.Actualizar();
                label.Text = "Datos Actualizados correctamente";
            }
        }
        private void BtnG()
        {
            if (TxtIdUs.Text == "")
            {
                Error.SetError(TxtIdUs, "Agregue un Codigo");
                TxtIdUs.Focus();
            }
            else
            {
                Usc.IdUc = Convert.ToInt32(TxtIdE.Text);
                Usc.IdUs = Convert.ToInt32(TxtIdUs.Text);
                if (SwE.IsOn == true)
                {
                    Usc.EstadoUC = '1';
                }
                else
                {
                    Usc.EstadoUC = '0';
                }
                label.Text = mensaje;
                Error.Dispose();
                int resultado = Usc.Agregar();
                LblCont.Text = resultado.ToString();
            }
        }
        private void Limpiar()
        {
            TxtIdE.Text = "";
            TxtIdUs.Text = "";
            if (SwE.IsOn == false)
            {
                SwE.IsOn = true;
            }
        } 
        #endregion
        private void BtnGC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        private void BtnSnC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LblCont.Text != "")
            {
                Act();
                LblCont.Text = "";
                Limpiar();
            }
            else
            {
                mensaje = "Datos Guardados:Puede ingresar nuevos datos";
                BtnG();
                Limpiar();
            }
        }  
        private void TxtBuscar_EditValueChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $" Nombre LIKE '{TxtBuscar.Text}%'";
        }
        private void BtnBid_Click(object sender, EventArgs e)
        {

            dt = U.ListadoB1();
            DgvB1.DataSource = dt;
            LblB.Visible = true;
            TxtBuscar.Visible = true;
            DgvB1.Visible = true;
            DgvB2.Visible = false;

        }
        public static string IdUs;
        public static string IdE;
        private void DgvBUsco_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*ID Usuario*/
            IdUs = DgvB1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtIdUs.Text = IdUs;
            DgvB1.Visible = false;
            LblB.Visible = false;
            TxtBuscar.Visible = false;

        }
        private void BtnIe_Click(object sender, EventArgs e)
        {

            dt = C.ListadoB();
            DgvB2.DataSource = dt;
            LblB.Visible = true;
            TxtBuscar.Visible = true;
            DgvB1.Visible = false;
            DgvB2.Visible = true;
        }
        private void DgvB2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*ID de la empresa*/
            IdE = DgvB2.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtIdE.Text = IdE;
            DgvB2.Visible = false;
            LblB.Visible = false;
            TxtBuscar.Visible = false;
        }
        private void AgregarUsCo_Load(object sender, EventArgs e)
        {
        }
        private void BtnSC1_Click(object sender, EventArgs e)
        {
            if (LblCont.Text != "")
            {
                Act();
                this.Hide();
            }
            else
            {
                BtnG();
                this.Hide();
            }
        }
        private void BtnSalirC1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
