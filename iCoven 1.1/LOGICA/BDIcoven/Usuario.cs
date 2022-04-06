using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Accdat;
namespace LOGICA
{
    public class Usuario
    {
        Manager M = new Manager();
        #region 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public char Super { get; set; }
        public char Estado { get; set; }
        #endregion

        /*Constructor Vacio*/
        public Usuario()
        {
            /**/
        }

        /*Constructor con Parametros*/
        public Usuario(string UNombre, string UClave, char USuper, char UEstado, int UId)
        {
            this.Nombre = UNombre;
            this.Clave = UClave;
            this.Super = USuper;
            this.Estado = UEstado;
            this.Id = UId;
        }
        public int Agregar()
        {
            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select usu_nombre from usuario where usu_nombre='" + Nombre + "'),-99,-98)");
                if (existe == -98)
                {
                    string comando = "Insert into usuario(usu_nombre,usu_clave,usu_super,usu_estado  ) values ('" + Nombre + "','" + Clave + "','" + Super + "','" + Estado + "');SELECT LAST_INSERT_ID(); ";
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
                int existe = M.Verificaexiste(@"Select if (exists (select usu_nombre from usuario where usu_nombre='" + Nombre + "' and usu_id <> '" + Id + "' ),-99,-98)");
                if (existe == -98)
                {
                    string comando = @"Update usuario set usu_nombre = '" + Nombre + "', usu_clave = '" + Clave + "',usu_super= '" + Super + "',usu_estado = '" +Estado + "' where usu_id = '" + Id + "'; SELECT ROW_COUNT();";
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
            return M.Listar("Select usu_id as ID, usu_nombre as Nombre, usu_clave as clave, usu_super as T_Usuario, usu_estado as Estado from usuario");

        }
        public DataTable ListadoB1()
        {
            return M.Listar("Select  usu_id as ID , usu_nombre as Nombre from usuario");
        }
    }
}

