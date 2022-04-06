using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accdat;
using System.Data;
namespace LOGICA
{
    public class UsCo
    {
        private Manager M = new Manager();
        /*Atributos*/
        #region Atributos
        public int Id { get; set; }
        public int IdUs { get; set; }
        public int IdUc { get; set; }
        public char EstadoUC { get; set; }
        #endregion
        /*Constructor vacio*/
        public UsCo()
        {/**/}
       /*Constructor con parametros*/
       public UsCo(int UsId,int idus,int iduc, char Estadouc)
        {
            this.Id = UsId;
            this.IdUs = idus;
            this.IdUc = iduc;
            this.EstadoUC = Estadouc;
        }
        public int Agregar()
        {

            try
            {
            //int existe = M.Verificaexiste(@"Select if (exists (select ucr_ctr_id from usuariocontribuyente where ucr_ctr_id='" + IdUc + "'),-99,-98)");
            //    if (existe == -98)
            //    {
                    string comando = "Insert into usuariocontribuyente(ucr_usu_id,ucr_ctr_id,ucr_estado) values ('" + IdUs+ "','" +  IdUc + "','" + EstadoUC + "')";
                    return M.EjecutarSql(comando);

          }
                
            //    }
            //    else
            //    {
            //        return existe;
            //    }
            //}
            catch (Exception)
            {
                throw;
            }
        }
        public int Actualizar()
        {
            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select ucr_ctr_id  from usuariocontribuyente where ucr_ctr_id ='" + IdUc + "' and ucr_id <> '" + Id + "' ),-99,-98)");
                if (existe == -98)
                {
                    string comando = @"Update usuariocontribuyente set ucr_usu_id = '" + IdUs + "',  ucr_ctr_id = '" + IdUc + "', ucr_estado= '" + EstadoUC + "' where ucr_id = '" + Id + "'; SELECT ROW_COUNT();";
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

    }
}

