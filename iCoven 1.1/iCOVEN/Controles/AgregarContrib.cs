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
    public partial class AgregarContrib : DevExpress.XtraEditors.XtraUserControl
    {
        public AgregarContrib()
        {
            InitializeComponent();
        } 
        /************************/
        #region Instancias y Variables

        public DataTable dt = new DataTable();
        Contribuyente C = new Contribuyente();
        public static string Id;
        public static string Nombre;
        string mensaje;
        #endregion
        /**********************/
        /********************/
        #region Metodos para las Acciones
        private void BtnG()
        {
            if (String.IsNullOrEmpty(TxtNombre.Text))
            {
                Error.SetError(TxtNombre, "Debe ingresar un Nombre");
                TxtNombre.Focus();
              
            }
            if (String.IsNullOrEmpty(TxtCodigo.Text))
            {
                Error.SetError(TxtCodigo, "Debe ingresar un codigo");
                TxtCodigo.Focus();
                
            }
            if (String.IsNullOrEmpty(Date.Text))
            {
                Error.SetError(Date, "Debe seleccionar una  fecha ");
                Date.Focus();
                
            }
            if (String.IsNullOrEmpty(TxtIdTC.Text))
            {
                Error.SetError(TxtIdTC, "Debe seleccionar un ID");
               
            }  
            else
            if (TxtCodigo.Text != "" && TxtNombre.Text != "" && Date.Text != "" && IdTipo.Text != "")
            {

                C.Codigo = TxtCodigo.Text;
                C.Nombre = TxtNombre.Text;
                C.Siglas = TxtSiglas.Text;
                C.IvaVenta = Convert.ToDouble(TxtTasa.Text);
                DateTime fecha = Convert.ToDateTime(Date.Text);
                C.Nacimiento = fecha.ToString("yyyy-MM-dd");
                C.IdT = Convert.ToInt32(IdTipo.Text);
                if (SwEstado.IsOn == true)
                {
                    C.Estado = '1';
                }
                else
                {
                    C.Estado = '0';
                }

                label.Text = mensaje;
                Error.Dispose();
                int resultado = C.Agregar();
                LblCont.Text = resultado.ToString();
            }
            else
            {
                XtraMessageBox.Show("Hay campos obligatorios vacios","Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
            }

        }
        /*Metodo para la actualizacion de datos*/
        private void Act()
        {
            if (String.IsNullOrEmpty(TxtNombre.Text))
            {
                Error.SetError(TxtNombre, "Debe ingresar un Nombre");
                TxtNombre.Focus();
            }
            if (String.IsNullOrEmpty(TxtCodigo.Text))
            {
                Error.SetError(TxtCodigo, "Debe ingresar un codigo");
                TxtCodigo.Focus();
            }
            if (String.IsNullOrEmpty(Date.Text))
            {
                Error.SetError(Date, "Debe seleccionar una  fecha ");
                Date.Focus();
            }
            if (String.IsNullOrEmpty(TxtIdTC.Text))
            {
                Error.SetError(TxtIdTC, "Debe seleccionar un ID");
            }
            else
            if (TxtCodigo.Text != "" && TxtNombre.Text != "" && Date.Text != "" && IdTipo.Text != "")
            {

                C.Codigo = TxtCodigo.Text;
                C.Nombre = TxtNombre.Text;
                C.Siglas = TxtSiglas.Text;
                C.IvaVenta = Convert.ToDouble(TxtTasa.Text);
                DateTime fecha = Convert.ToDateTime(Date.Text);
                C.Nacimiento = fecha.ToString("yyyy-MM-dd");
                C.IdT = Convert.ToInt32(IdTipo.Text);
                if (SwEstado.IsOn == true)
                {
                    C.Estado = '1';
                }
                else
                {
                    C.Estado = '0';
                }
                /*Se obtiene el id de los datos ingresados*/
                C.Id = Convert.ToInt32(LblCont.Text);
                int resultado = C.Actualizar();
                label.Text = "Datos Actualizados correctamente";
            }
        }
        /*Metodo para limpiar los contenedores de datos*/
        private void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            TxtSiglas.Text = "";
            TxtTasa.Text = "0";
            Date.Text = "";
            if (SwEstado.IsOn == false)
            {
                SwEstado.IsOn = true;
            }
            TxtIdTC.Text = "";
            LblCont.Text = "";

        }
        #endregion
        /******************/
        /****************/
        #region Botones
        /**Guardar y Continuar*/
        private void BtnSnC1_Click(object sender, EventArgs e)
        {
            /**Se verifica que el label no este
            vacio para poder actualizar*/
            if (LblCont.Text != "")
            {
                Act();
                LblCont.Text = "";
                if(TxtNombre.Text!="")
                {
                     Limpiar();
                }
            }
            else
            {
                mensaje = "Datos Guardados:Puede ingresar nuevos datos";
                BtnG();
                if (TxtNombre.Text != "")
                {
                    Limpiar();
                }
            }
        }
        /**Guardar y Salir*/ 
        private void BtnSC1_Click(object sender, EventArgs e)
        {
            if (LblCont.Text != "")
            {
                Act();
                if (TxtCodigo.Text != "" && TxtNombre.Text != "" && Date.Text != "" && IdTipo.Text != "")
                {
                    this.Dispose();
                }
            }
            else
            {
                BtnG();
                if (TxtCodigo.Text != "" && TxtNombre.Text != "" && Date.Text != "" && IdTipo.Text != "")
                {
                    this.Dispose();
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
        /**Salir*/
        private void BtnSalirC1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion         
        /**************/
        /************/
        #region Agregar ID_TC
        private void DgvCo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /**Se obtienen los valores del grid para el ID_TC*/
            Id = DgvCo.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nombre = DgvCo.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtIdTC.Text = Nombre;
            IdTipo.Text = Id;
            DgvCo.Visible = false;
            LblB.Visible = false;
            TxtBuscar.Visible = false;
        }
        private void BtnBid_Click(object sender, EventArgs e)
        {
            DgvCo.Visible = true;
            TxtBuscar.Visible = true;
            LblB.Visible = true;
            dt = C.ListadoB1();
            DgvCo.DataSource = dt;
        }
        private void TxtBuscar_EditValueChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $" Nombre LIKE '{TxtBuscar.Text}%'";
        } 
        #endregion
        /**********/

    }
}
