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
    public partial class AgregarUsuario : DevExpress.XtraEditors.XtraUserControl
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }
        /*********************/
        #region Instancias y variables
        public Usuario Us = new Usuario();
        string mensaje;
        #endregion
        /*******************/
        /******************/
        #region Metodos para las acciones
        private void BtnG()
        {

            if (TxtNombre.Text == "")
            {
                Error.SetError(TxtNombre, "Agregue un Nombre");
                TxtNombre.Focus();
            }
            else
            if (TxtClave.Text == "")
            {
                Error.SetError(TxtClave, "Agregue una Clave");
                TxtClave.Focus();
            }
            else
            {
                Us.Nombre = TxtNombre.Text;
                Us.Clave = TxtClave.Text;
                if (SwTU.IsOn == true)
                {
                    Us.Super = '1';
                }
                else
                {
                    Us.Super = '0';
                }

                if (SwE.IsOn == true)
                {
                    Us.Estado = '1';
                }
                else
                {
                    Us.Estado = '0';
                }
                label.Text = mensaje;
                Error.Dispose();
                int resultado = Us.Agregar();
                LblCont.Text = resultado.ToString();
            }
        }
        private void Act()
        {
            /*Actualizacion de datos*/
            if (TxtNombre.Text == "")
            {
                Error.SetError(TxtNombre, "Agregue un Nombre");
                TxtNombre.Focus();
            }
            else
            {
                Us.Nombre = TxtNombre.Text;
                Us.Clave = TxtClave.Text;
                if (SwTU.IsOn == true)
                {
                    Us.Super = '1';
                }
                else
                {
                    Us.Super = '0';
                }

                if (SwE.IsOn == true)
                {
                    Us.Estado = '1';
                }
                else
                {
                    Us.Estado = '0';
                }

                Us.Id = Convert.ToInt32(LblCont.Text);
                int resultado = Us.Actualizar();
                label.Text = "Datos Actualizados correctamente";
            }
        }
        private void Limpiar()
        {
            TxtNombre.Text = "";
            TxtClave.Text = "";
            if (SwE.IsOn == false)
            {
                SwE.IsOn = true;
            }
            if (SwTU.IsOn == true)
            {
                SwTU.IsOn = false;
            }
        }
        #endregion
        /****************/
        /***************/
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
                if (TxtNombre.Text != "" && TxtClave.Text != "")
                {
                    this.Dispose();
                }
            }
            else
            {
                BtnG();
                if (TxtNombre.Text != "" && TxtClave.Text != "")
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
        /*************/
    }
}
