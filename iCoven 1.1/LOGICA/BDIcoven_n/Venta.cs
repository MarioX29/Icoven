using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress;
using Accdatn;

namespace LOGICA
{
    public class Venta
    {
        public Manager M = new Manager();
        /*Atributos*/
        #region Venta
        public int IdV { get; set; }
        public string VAnio { get; set; }
        public string VMes { get; set; }
        public string VSerie { get; set; }
        public string VNumI { get; set; }
        public string VNumF { get; set; }
        public string VFecha { get; set; }
        public char VEstado { get; set; }
        public int VIdCli { get; set; }
        public string VCodigoCli { get; set; }
        public string VRCli { get; set; }
        public double VTConIVa { get; set; }
        public double IvaV { get; set; }
        public string VDescrip { get; set; }
        public double MercaIVA { get; set; }
        public double IVATotal { get; set; }
        public double Servicios { get; set; }
        public double SerIVA { get; set; }
        public double Exento { get; set; }
        public char VMesCerrado { get; set; }
        public char VEliminado { get; set; }
        #endregion

        /*Constructor Vacio*/
      public Venta ()
        {


        }
        
        /*Constructor con Parametros*/
        public Venta(int vid, string vanio, string vmes, string vserie, string vnumi, string vnumf, string vfecha, char vestado, int vidcli, string vcodigocli, string vrcli, double vtconiva, double ivav, string vdescrip, double mercaiva, double ivatotal, double servicios, double seriva, double exento, char mescr, char veliminado)
        {
            this.IdV = vid;
            this.VAnio = vanio;
            this.VMes = vmes;
            this.VSerie = vserie;
            this.VNumI = vnumi;
            this.VNumF = vnumf;
            this.VFecha = vfecha;
            this.VEstado = vestado;
            this.VIdCli = vidcli;
            this.VCodigoCli = vcodigocli;
            this.VRCli = vrcli;
            this.VTConIVa = vtconiva;
            this.IvaV = ivav;
            this.VDescrip = vdescrip;
            this.MercaIVA = mercaiva;
            this.IVATotal = ivatotal;
            this.Servicios = servicios;
            this.SerIVA = seriva;
            this.Exento = exento;
            this.VMesCerrado = mescr;
            this.VEliminado = veliminado;
        }
        public int Agregar()
        {
            try
            {
                int existe = M.Verificaexiste(@"Select if (exists (select ven_serie from venta where ven_serie='" + VSerie + "'),-99,-98)");
                if (existe == -98)
                {
                    string comando = "Insert into venta(ven_anio,ven_mes,ven_serie,ven_numinicial,ven_numfinal,ven_fecha,ven_estado,ven_cli_id,ven_cli_codigo,ven_cli_razonsocial,ven_totconiva,ven_totiva, ven_totnota,ven_proconiva,ven_proiva,ven_serconiva,ven_seriva, ven_totexento ,ven_mescerrado,ven_eliminado ) values ('" + VAnio + "','" + VMes + "','" + VSerie + "','" + VNumI + "','" + VNumF + "','" + VFecha + "','" + VEstado + "','" + VIdCli + "','" + VCodigoCli + "','" + VRCli + "','" + VTConIVa + "','" + IvaV + "','" + VDescrip + "','" + MercaIVA + "','" + IVATotal + "','" + Servicios + "','" + SerIVA + "','" + Exento + "','" + VMesCerrado + "','" + VEliminado + "' );SELECT LAST_INSERT_ID(); ";

                    return M.EjecutarSql(comando);

                }
                else
                {
                    return existe;
                DevExpress.XtraEditors.XtraMessageBox.Show("El valor existe");
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
                int existe = M.Verificaexiste(@"Select if (exists (select ven_serie from venta where ven_serie='" + VSerie+ "' and ven_id <> '" + IdV + "' ),-99,-98)");
                if (existe == -98)
                {
                    string comando = @"Update venta set ven_anio = '" + VAnio + "',ven_mes = '" + VMes + "', ven_serie = '" + VSerie + "',ven_numinicial = '" + VNumI + "',ven_numfinal = '" + VNumF + "',ven_fecha = '" + VFecha + "', ven_estado = '" + VEstado + "',ven_cli_id = '" + VIdCli + "', ven_cli_id = '" + VIdCli + "',ven_cli_codigo = '" + VCodigoCli + "',ven_cli_razonsocial = '" + VRCli + "', ven_totconiva = '" + VTConIVa + "',ven_totiva = '" + IvaV + "',ven_totnota = '" + VDescrip + "',ven_proconiva = '" + MercaIVA + "',ven_proiva = '" + IVATotal + "',ven_serconiva = '" + Servicios + "',ven_seriva = '" + SerIVA + "',ven_totexento = '" + Exento + "',ven_mescerrado = '" + VMesCerrado + "',ven_eliminado = '" + VEliminado + "'  where ven_id = '" + IdV + "'; SELECT ROW_COUNT();";
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
            return M.Listar("Select ven_id as ID, ven_anio as Año, ven_mes as Mes, ven_serie as Serie, ven_numinicial as No_Inicial, ven_numfinal as No_Final, ven_fecha as Fecha, ven_estado as Estado, ven_cli_id as id_Cliente,ven_cli_codigo as Cod_Cliente, ven_cli_razonsocial as Razon_Social, ven_totconiva as Total_con_Iva, ven_totiva as Iva_Total, ven_totnota as Descripcion, ven_proconiva as Total_Mercaderia, ven_proiva as Iva_Mercaderia, ven_serconiva as Total_Servicios, ven_seriva as Iva_Servicios, ven_totexento as Monto_Exento, ven_mescerrado as Mes_Cerrado, ven_eliminado as Eliminado  from venta where ven_eliminado != '1'");

        }
        public DataTable ListadoB()
        {
            return M.Listar("Select  cli_id as id_Cliente,cli_codigo as Cod_Cliente, cli_razonsocial as Razon_Social from cliente");
        }
    }
}
