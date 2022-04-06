using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accdatn;
using System.Data;

namespace LOGICA
{
    public class Compra
    {
        Manager M = new Manager();
        /************/
        /*Atributos */
        #region Atributos Compra
        public int idComp { get; set; }
        public string Anio { get; set; }
        public string Mes { get; set; }
        public string Serie { get; set; }
        public string NumFac { get; set; }
        public string FechaC { get; set; }
        public char EstadoCo { get; set; }
        public int idProv { get; set; }
        public double ToCiva { get; set; }
        public double Ivat { get; set; }
        public string Descrip { get; set; }
        public double MerwIva { get; set; }
        public double Meriva { get; set; }
        public double OtrIva { get; set; }
        public double Opiva { get; set; }
        public string TipCom { get; set; }
        public double Galones { get; set; }
        public double IdpGal { get; set; }
        public double IdpMon { get; set; }
        public double IdPIva { get; set; }
        public double HoswIva { get; set; }
        public double HosMon { get; set; }
        public double Hosiva { get; set; }
        public double TExcento { get; set; }
        public char MesCr { get; set; }
        public char Eliminado { get; set; }
        #endregion
        /**************/
        /*Constructor Vacio*/
        public Compra()
        {
            /**/
        }

        /*Constructor con Parametros*/
        public Compra(int idCompc, string AnioC, string Mesc, string SerieC, string NumFacc, char Estadoc, int idProvc, double ToWiva, double Ivac, string Descripc, double MerwIc, double Meriv, double Otrivac, double Opivac, string TipComc, double Galonesc, double IdpGac, double IdoMoc, double idPIva, double HoswIc, double HosMonc, double HosIv, double Excento, char MesCR, char Eliminadoc)
        {
            this.idComp = idCompc;
            this.Anio = AnioC;
            this.Mes = Mesc;
            this.Serie = SerieC;
            this.NumFac = NumFacc;
            this.EstadoCo = Estadoc;
            this.idProv = idProvc;
            this.ToCiva = ToWiva;
            this.Ivat = Ivac;
            this.Descrip = Descripc;
            this.MerwIva = MerwIc;
            this.Meriva = Meriv;
            this.OtrIva = Otrivac;
            this.Opiva = Opivac;
            this.TipCom = TipComc;
            this.Galones = Galonesc;
            this.IdpGal = IdpGac;
            this.IdpMon = IdoMoc;
            this.IdPIva = idPIva;
            this.HoswIva = HoswIc;
            this.HosMon = HosMonc;
            this.Hosiva = HosIv;
            this.TExcento = Excento;
            this.MesCr = MesCR;
            this.Eliminado = Eliminadoc;
        }


        public int Agregar()
        {

            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select com_serie from compra where com_serie='" + Serie+ "'),-99,-98)");
                if (existe == -98)
                {
                    string comando = "Insert into compra(com_anio,com_mes,com_serie,com_numero,com_fecha,com_estado,com_pro_id,com_totconiva,com_totiva, com_totnota,com_merconiva,com_meriva,com_opsconiva, com_opsiva, com_idptipo, com_idpgalones, com_idpmonto, com_idpiva, com_hosconiva, com_hosmonto,com_hosiva,com_totexento,com_mescerrado,com_eliminado ) values ('" + Anio + "','" + Mes + "','" + Serie + "','" + NumFac + "','" + FechaC + "','" + EstadoCo + "','" + idProv + "','" + ToCiva + "','" + Ivat + "','" + Descrip + "','" + MerwIva + "','" + Meriva + "','" + OtrIva + "','" + Opiva + "','" + TipCom + "','" + IdpGal + "','" + IdpMon + "','" + IdPIva + "','" + HoswIva + "','" + HosMon + "','" + Hosiva + "','" + TExcento + "', '" + MesCr + "','" + Eliminado + "' );SELECT LAST_INSERT_ID(); ";
                  
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

        /********************/
        public int Actualizar()
        {
            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select com_serie from compra where com_serie='" + Serie + "' and com_id <> '" + idComp + "' ),-99,-98)");
                if (existe == -98)
                {
                    string comando = @"Update compra set com_anio = '" + Anio + "', com_mes = '" + Mes + "', com_serie = '" + Serie + "',com_numero = '" + NumFac + "',com_fecha = '" + FechaC + "', com_estado = '" + EstadoCo + "',com_pro_id = '" + idProv + "',com_totconiva = '" + ToCiva + "',com_totiva = '" + Ivat + "',com_totnota = '" + Descrip + "',com_merconiva = '" + MerwIva + "',com_meriva = '" + Meriva + "',com_opsconiva = '" + OtrIva + "',com_opsiva = '" + Opiva + "',com_idptipo = '" + TipCom + "',com_idpgalones = '" + Galones + "',com_idpmonto = '" + IdpMon + "',com_idpiva = '" + IdPIva + "',com_hosconiva = '" + HoswIva + "',com_hosmonto = '" + HosMon + "',com_hosiva = '" + Hosiva + "',com_totexento = '" + TExcento + "',com_mescerrado = '" + MesCr + "',com_eliminado = '" + Eliminado + "'  where com_id = '" + idComp + "'; SELECT ROW_COUNT();";
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
            return M.Listar("Select com_id as ID, com_anio as Año, com_mes as Mes, com_serie as Serie_Fac, com_numero as Numero_Fac, com_fecha as Fecha, com_estado as Estado, com_pro_id as ID_Prov, com_totconiva as Total_IVA, com_totiva as IVA, com_totnota as Descripcion, com_merconiva as Merca_IVA, com_meriva as IVA_M, com_opsconiva as Otros_Prod_IVA, com_opsiva IVA_Otros, com_idptipo as Tipo_Combustible, com_idpgalones as Galones_Comb, com_idpmonto as IDP, com_idpiva as IVA_IDP, com_hosconiva as Hospedaje_IVA, com_hosmonto as Imp_INGUAT, com_hosiva as IVA_Hospedaje,com_totexento as Total_Exento, com_mescerrado as Declaracion_IVA, com_eliminado as Eliminado from compra where com_eliminado != '1'");
        }


        public DataTable ListadoB()
        {
            return M.Listar("Select  pro_id as ID, pro_rsocial as Razon_Social from proveedor ");
        }

        

    }
}
