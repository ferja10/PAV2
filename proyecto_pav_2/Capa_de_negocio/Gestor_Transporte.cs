using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Capa_de_negocio
{
    public class Gestor_Transporte
    {
        private static string sql;

        public static DataTable obtener_transportes()
        {
            DataTable dt = new DataTable();
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "select T.id_transporte as 'id_transporte', E.razon_social +' , '+ T.descripcion as 'descripcion' " +
                         "from Transporte T join Empresa E on T.id_empresa = E.id_empresa order by E.razon_social";
            dt = ad.leo_tabla(sql);

            return dt;
        }

        public static DataTable obtener_transportes(int id_destino)
        {
            DataTable dt = new DataTable();
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "select T.id_transporte as 'id_transporte', E.razon_social +' , '+ T.descripcion as 'descripcion' " +
               "from Transporte T join Empresa E on T.id_empresa = E.id_empresa " +
               "join Transporte_X_Destino TXD on TXD.id_transporte = T.id_transporte " +
               "join Destino D on  TXD.id_destino = D.id_destino " +
               "where D.id_destino = " + id_destino + " order by E.razon_social";

            dt = ad.leo_tabla(sql);

            return dt;
        }

    }
}