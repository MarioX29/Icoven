using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accdatn;
using System.Data;
namespace LOGICA
{
     public class TContribuyente_N
    {
        Manager M = new Manager();
        /*Atributos*/
        #region Atributos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public char ivaCredito { get; set; }
        public char ivaDebito { get; set; }
        public double Tasaiva { get; set; }
        public char Estado { get; set; }
        #endregion
        /*Constructor Vacio*/
        public TContribuyente_N()
        {
            /**/
        }
        /*Constructor con parametros*/
        public TContribuyente_N(string tNombre, char tIC, char tID, double tTI, char tEstado, int tId)
        {
            this.Nombre = tNombre;
            this.ivaCredito = tIC;
            this.ivaDebito = tID;
            this.Tasaiva = tTI;
            this.Estado = tEstado;
            this.Id = Id;
        }
        public int Agregar()
        {

            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select tdc_nombre from tipocontribuyente where tdc_nombre='" + Nombre + "'),-99,-98)");
                if (existe == -98)
                {
                    string comando = "Insert into tipocontribuyente(tdc_nombre,tdc_ivacredito,tdc_ivadebito,tdc_tasaiva,tdc_estado ) values ('" + Nombre + "','" + ivaCredito + "','" + ivaDebito + "','" + Tasaiva + "','" + Estado + "');SELECT LAST_INSERT_ID(); ";
                    return M.EjecutarSql(comando);
                }
                else
                {
                    return existe;
                    //DevExpress.XtraEditors.XtraMessageBox.Show("El valor existe");
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
                int existe = M.Verificaexiste(@"Select if (exists (select tdc_nombre from tipocontribuyente where tdc_nombre='" + Nombre + "' and tdc_id <> '" + Id + "' ),-99,-98)");
                if (existe == -98)
                {
                    string comando = @"Update tipocontribuyente set tdc_nombre = '" + Nombre + "', tdc_ivacredito = '" + ivaCredito + "',tdc_ivadebito = '" + ivaDebito + "',tdc_tasaiva = '" + Tasaiva + "',tdc_estado= '" + Estado + "' where tdc_id = '" + Id + "'; SELECT ROW_COUNT();";
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
            return M.Listar("Select  tdc_id as ID, tdc_nombre as Nombre, tdc_ivacredito as Credito, tdc_ivadebito as Debito, tdc_tasaiva as Tasa, tdc_estado as Estado from tipocontribuyente");
        }
    }
}

