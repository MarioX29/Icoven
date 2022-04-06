using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Accdatn;
namespace LOGICA
{
    public class Proveedor
    {
        Manager M = new Manager();
        #region Atributos 
        public int IdP { get; set; }
        public string CodigoP { get; set; }
        public string NombreProv { get; set; }
        public string RazonC { get; set; }
        public char TPersona { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Web { get; set; }
        public string ProfLinea { get; set; }
        public char Estado { get; set; }
        public int Frecuencia { get; set; }
        public int IdTC { get; set; } 
        #endregion

        /*Constructor Vacio*/
        public Proveedor ()
        {
            /**/
        }

        /*Constructor con Parametros*/
        public Proveedor(int IdP, string CodigoP,string PNombre,string PRazonC, char PTPersona, string PDireccion, string PTelefono, string PCorreo, string PWeb, string PProfLinea, char PEstado, int PFrecuencia,int PIdTC)
        {
            this.IdP = IdP;
            this.CodigoP = CodigoP;
            this.NombreProv = PNombre;
            this.RazonC = PRazonC;
            this.TPersona = PTPersona;
            this.Direccion = PDireccion;
            this.Telefono = PTelefono;
            this.Correo = PCorreo;
            this.Web = PWeb;
            this.ProfLinea = PProfLinea;
            this.Estado = PEstado;
            this.Frecuencia = PFrecuencia;
            this.IdTC = PIdTC;
        }
        public int Agregar()
        {
            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select pro_rsocial from proveedor where pro_rsocial='" + NombreProv + "'),-99,-98)");
                if (existe == -98)
                {
                    string comando = "Insert into proveedor(pro_codigo,pro_rsocial,pro_rcomercial,pro_tipopersona,pro_direccion,pro_telefonos,pro_correos,pro_pagina,pro_negocio,pro_estado,pro_frecuencia,pro_tdc_id)values ('" + CodigoP + "','" + NombreProv + "','" + RazonC + "','" + TPersona + "','" + Direccion + "','" + Telefono + "','" + Correo + "','" + Web + "','" + ProfLinea+ "','" + Estado + "','" + Frecuencia + "','" + IdTC + "');SELECT LAST_INSERT_ID(); ";
                    return M.EjecutarSql(comando);
                }
                else
                {
                    return existe;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int Actualizar()
        {
            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select pro_rsocial from proveedor where pro_rsocial='" + NombreProv + "' and pro_id <> '" + IdP + "' ),-99,-98)");
                if (existe == -98)
                {
                    string comando = @"Update proveedor set pro_codigo='" + CodigoP + "',pro_rsocial= '" + NombreProv + "',pro_rcomercial='" + RazonC + "',pro_tipopersona='" + TPersona+ "',pro_direccion='" + Direccion + "',pro_telefonos='" + Telefono + "',pro_correos='" + Correo + "',pro_pagina='" +Web + "',pro_negocio='" + ProfLinea + "',pro_estado='" + Estado + "',pro_frecuencia='" + Frecuencia+ "',pro_tdc_id='"+IdTC+"' where pro_id = '" + IdP + "'; SELECT ROW_COUNT();";
                    return M.EjecutarSql(comando);
                }
                else
                {
                    return existe;

                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable Listado()
        {
            return M.Listar("Select  pro_id as ID, pro_codigo as Codigo,pro_rsocial as Nombre_Proveedor, pro_rcomercial as Razon_Comercial, pro_tipopersona as Tipo_Persona, pro_direccion as Direccion, pro_telefonos as Telefono, pro_correos as Correo, pro_pagina as WEB,pro_negocio as Line_Negocio, pro_estado as Estado, pro_frecuencia as Frecuencia, pro_tdc_id as Id_Tipo_Contrib from proveedor");
        }
        public DataTable ListadoB()
        {
            return M.Listar("Select  tdc_id as ID , tdc_nombre as Nombre from tipocontribuyente");
        }
    }
}


