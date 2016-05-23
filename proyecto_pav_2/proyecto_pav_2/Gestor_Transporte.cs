using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_pav_2
{
    public class Gestor_Transporte
    {
        private static string sql;

        public static DataTable obtener_transportes()
        {
            DataTable dt = new DataTable();
            Acceso_A_Datos ad = new Acceso_A_Datos();

            sql = "select T.id_transporte as 'id_transporte', E.razon_social +' , '+ T.descripcion as 'descripcion' " +
                         "from Transporte T join Empresa E on T.id_empresa = E.id_empresa";
            dt = ad.leo_tabla(sql);

            return dt;
        }

        public static DataTable obtener_transportes(int id_destino)
        {
            DataTable dt = new DataTable();
            Acceso_A_Datos ad = new Acceso_A_Datos();

            sql = "select T.id_transporte as 'id_transporte', E.razon_social +' , '+ T.descripcion as 'descripcion' " +
               "from Transporte T join Empresa E on T.id_empresa = E.id_empresa " +
               "join Transporte_X_Destino TXD on TXD.id_transporte = T.id_transporte " +
               "join Destino D on  TXD.id_destino = D.id_destino " +
               "where D.id_destino = " + id_destino;

            dt = ad.leo_tabla(sql);

            return dt;
        }

    }
}