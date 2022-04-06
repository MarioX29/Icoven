using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accdat;
using System.Data;

namespace LOGICA
{
    public class Contribuyente
    {
        private Manager M = new Manager();
        /*Atributos*/
        #region Atributos
        public int Id { get; set; }
        public int IdT { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public double IvaVenta { get; set; }
        public string Nacimiento { get; set; }
        public char Estado { get; set; }

        #endregion
        /*Constructor Vacio*/
        public Contribuyente()
        {
        }
        /*Constructor con Parametros*/
        public Contribuyente (string CCodigo, string CNombre, string CSiglas, double CIvaVenta, string CNacimiento,char CEstado)
        {
            this.Codigo = CCodigo;
            this.Nombre = CNombre;
            this.Siglas = CSiglas;
            this.IvaVenta = CIvaVenta;
            this.Nacimiento = CNacimiento;          
            this.Estado = CEstado;
              /*this.Id=CId;*/
       }
        public int Agregar()
        {

            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select ctr_nombre from contribuyente where ctr_nombre='" + Nombre + "'),-99,-98)");
                if (existe == -98)
                {
                    string comando = "Insert into contribuyente(ctr_codigo,ctr_nombre,ctr_siglas,ctr_ivaventa,ctr_nacimiento,ctr_estado,ctr_tdc_id) values ('" + Codigo + "','" + Nombre + "','" + Siglas + "','" + IvaVenta + "','" + Nacimiento + "','" + Estado + "','" + IdT + "');SELECT LAST_INSERT_ID(); ";
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
                int existe = M.Verificaexiste(@"Select if (exists (select ctr_nombre from contribuyente where ctr_nombre='" + Nombre + "' and ctr_id <> '" + Id + "' ),-99,-98)");
                if (existe == -98)
                {
                    string comando = @"Update contribuyente set ctr_codigo = '" + Codigo + "',  ctr_nombre = '" + Nombre + "', ctr_siglas = '" + Siglas + "',ctr_ivaventa = '" + IvaVenta + "',ctr_nacimiento = '" + Nacimiento + "',ctr_estado= '" + Estado + "',ctr_tdc_id = '" + IdT + "' where ctr_id = '" + Id + "'; SELECT ROW_COUNT();";
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
        /*Retorno del listado para uso del ID en el UserControl*/
        public DataTable ListadoB()
        {
            return M.Listar("Select  ctr_id as ID , ctr_nombre as Nombre from contribuyente");
        }

        /*Retorno del listado para uso del ID en el UserControl*/
        public DataTable ListadoB1()
        {
            return M.Listar("Select tdc_id as ID , tdc_nombre as Nombre from tipocontribuyente");
        }
        /*Listado para la Exportacion de la tabla Contribuyente*/
        public DataTable Listado()
        {
            return M.Listar("Select ctr_id as ID, ctr_codigo as Codigo, ctr_nombre as Nombre, ctr_siglas as Siglas, ctr_ivaventa as Iva_Venta, ctr_nacimiento as Nacimiento, ctr_estado as Estado, ctr_tdc_id as Id_TC from contribuyente");

        }
    }
}
