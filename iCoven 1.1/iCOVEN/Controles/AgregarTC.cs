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
    public partial class AgregarTC : DevExpress.XtraEditors.XtraUserControl
    {
         public AgregarTC()
        {
            InitializeComponent();
        } 
        /***********************/
        #region Instancias y Variables
        public TContribuyente Tc = new TContribuyente();
        public TContribuyente_N Tcn = new TContribuyente_N();
        string mensaje;
        #endregion
        /*********************/
        /********************/
        #region Metodos para las acciones
        private void BtnG()
        {

            if (String.IsNullOrEmpty(TxtNombre.Text))
            {

                XtraMessageBox.Show("No se pueden dejar vacios los campos requeridos (*)","Informacion", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Error.SetError(TxtNombre, "Agregue un Nombre");
                TxtNombre.Focus();
            }
            else
            {
                Tc.Nombre = TxtNombre.Text;
                Tcn.Nombre = TxtNombre.Text;
                /* TC.ivaCredito = SwFiscalC.;*/
                if (SwFiscalC.IsOn == true)
                {
                    Tc.ivaCredito = '1';
                    Tcn.ivaCredito = '1';
                }
                else
                {
                    Tc.ivaCredito = '0';
                    Tcn.ivaCredito = '0';
                }
                if (SwDebito.IsOn == true)
                {
                    Tc.ivaDebito = '1';
                    Tcn.ivaDebito = '1';
                }
                else
                {
                    Tc.ivaDebito = '0';
                    Tcn.ivaDebito = '0';
                }
                Tc.Tasaiva = Convert.ToDouble(SpTasa.Text);
                Tcn.Tasaiva = Convert.ToDouble(SpTasa.Text);
                if (SwEstado.IsOn == true)
                {
                    Tc.Estado = '1';
                    Tcn.Estado = '1';
                }
                else
                {
                    Tc.Estado = '0';
                    Tcn.Estado = '0';
                }
                label.Text = mensaje;
                Error.Dispose();
                int resultado = Tc.Agregar();
                resultado = Tcn.Agregar();
                LblCont.Text=resultado.ToString();
            }
        }
        private void Act()
        {
            /*Actualizacion de datos*/
            if (String.IsNullOrEmpty(TxtNombre.Text))
            {

                XtraMessageBox.Show("No se pueden dejar vacios los campos requeridos (*)", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Error.SetError(TxtNombre, "Agregue un Nombre");
                TxtNombre.Focus();
            }
            else
            {
                Tc.Nombre = TxtNombre.Text;
                Tcn.Nombre = TxtNombre.Text;
                /* TC.ivaCredito = SwFiscalC.;*/
                if (SwFiscalC.IsOn == true)
                {
                    Tc.ivaCredito = '1';
                    Tcn.ivaCredito = '1';
                }
                else
                {
                    Tc.ivaCredito = '0';
                    Tcn.ivaCredito = '0';
                }
                if (SwDebito.IsOn == true)
                {
                    Tc.ivaDebito = '1';
                    Tcn.ivaDebito = '1';
                }
                else
                {
                    Tc.ivaDebito = '0';
                    Tcn.ivaDebito = '0';
                }
                Tc.Tasaiva = Convert.ToDouble(SpTasa.Text);
                Tcn.Tasaiva = Convert.ToDouble(SpTasa.Text);
                if (SwEstado.IsOn == true)
                {
                    Tc.Estado = '1';
                    Tcn.Estado = '1';
                }
                else
                {
                    Tc.Estado = '0';
                    Tcn.Estado = '0';
                }
                Tc.Id = Convert.ToInt32(LblCont.Text);            
                int resultado = Tc.Actualizar();
                Tcn.Id = Convert.ToInt32(LblCont.Text);
                resultado = Tcn.Actualizar();
                label.Text = "Datos Actualizados correctamente";
            }
        }
        private void Limpiar()
        {

            TxtNombre.Text = "";
            
            if (SwEstado.IsOn== false)
            {
                SwEstado.IsOn = true;
            }
            if (SwFiscalC.IsOn== true)
            {
                SwFiscalC.IsOn = false;
            }
            if (SwDebito.IsOn == true)
            {
                SwDebito.IsOn = false;
            }
            SpTasa.Text= "0";

            LblCont.Text = "";
                
        }
        #endregion
        /******************/       
        /*****************/
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
                if (TxtNombre.Text != "")
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
                if (TxtNombre.Text != "")
                {
                    this.Dispose();
                }
            }
            else
            {
                BtnG();
                if (TxtNombre.Text != "")
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
        #endregion
        /***************/
    }
}
