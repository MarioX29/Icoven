using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accdatn;
using System.Data;
namespace LOGICA
{
    public class Cliente
    {
        public Manager M = new Manager();
        /*Atributos*/
        #region Cliente
        public int idC { get; set; }
        public string CodigoC { get; set; }
        public string NombreC { get; set; }
        public string RComecialC { get; set; }
        public char TPC { get; set; }
        public string DireccionC { get; set; }
        public string TelC { get; set; }
        public string CorreoC { get; set; }
        public string WebC { get; set; }
        public string LnegocioC { get; set; }
        public char EstadoC { get; set; }
        public int FrecuenciaC { get; set; }
        public int idTCi { get; set; }
        #endregion
       
        /*Constructor Vacio*/
        public Cliente ()
        {
            /**/
        } 
        /*Constructor con Parametros*/
        public Cliente(int Cid, string CodigoC, string CNombre, string RComerC,char TipoC, string DirC, string TeC, string CorrC, string CWeb, string LNC, char EstadoC, int FrC,int idTCi)
        {
            this.idC = Cid;
            this.CodigoC = CodigoC;
            this.NombreC = CNombre;
            this.RComecialC = RComerC;
            this.TPC = TipoC;
            this.DireccionC = DirC;
            this.TelC = TeC;
            this.CorreoC = CorrC;
            this.WebC = CWeb;
            this.LnegocioC = LNC;
            this.EstadoC = EstadoC;
            this.FrecuenciaC = FrC;
            this.idTCi = idTCi;

        }
        public int Agregar()
        {

            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select cli_razonsocial from cliente where cli_razonsocial='" + NombreC + "'),-99,-98)");
                if (existe == -98)
                {
                    string comando = "Insert into cliente(cli_codigo,cli_razonsocial,cli_razoncomercial,cli_tipopersona,cli_direccion,cli_telefonos,cli_correos,cli_pagina,cli_negocio,cli_estado,cli_frecuencia,cli_tdc_id ) values ('" + CodigoC + "','" + NombreC + "','" + RComecialC + "','"+TPC + "','" + DireccionC+ "','" + TelC+ "','" + CorreoC + "','" + WebC + "','" + LnegocioC + "','" + EstadoC + "','" + FrecuenciaC + "','" + idTCi + "');SELECT LAST_INSERT_ID(); ";
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
                int existe = M.Verificaexiste(@"Select if (exists (select cli_razonsocial from cliente where cli_razonsocial ='" + NombreC + "' and cli_id <> '" + idC + "' ),-99,-98)");
                if (existe == -98)
                {
                    string comando = @"Update cliente set cli_codigo  = '" + CodigoC + "', cli_razonsocial  = '" + NombreC + "',cli_razoncomercial  = '" + RComecialC + "', cli_tipopersona = '" + TPC + "',cli_direccion = '" + DireccionC + "',cli_telefonos = '" + TelC + "',cli_correos= '" + CorreoC + "',cli_pagina  = '" + WebC + "',cli_negocio  = '" + LnegocioC + "',cli_estado  = '" + EstadoC + "',cli_frecuencia  = '" + FrecuenciaC + "',cli_tdc_id  = '" + idTCi + "' where cli_id = '" + idC + "'; SELECT ROW_COUNT();";
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
            return M.Listar("Select  cli_id as ID, cli_codigo as Codigo, cli_razonsocial as Razon_Social, cli_razoncomercial as Razon_Com, cli_tipopersona as Tipo_Persona, cli_direccion as Direccion, cli_telefonos as Telefono, cli_correos as Correo, cli_pagina as WEB, cli_negocio as L_Negocio, cli_estado as Estado, cli_frecuencia as Frecuencia, cli_tdc_id as id_Tipo_Cont from cliente");
        }


        public DataTable ListadoB()
        {
            return M.Listar("Select  tdc_id as ID , tdc_nombre as Nombre from tipocontribuyente");
        }
    }
}
