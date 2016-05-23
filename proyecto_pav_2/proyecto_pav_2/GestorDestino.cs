using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_pav_2
{
    public class Gestor_Destino
    {
        public static DataTable obtener_destinos()
        {
            DataTable dt = new DataTable();
            Acceso_A_Datos ad = new Acceso_A_Datos();

            string sql = "SELECT * FROM Destino";
            dt = ad.leo_tabla(sql);

            return dt;
        } 
    }
}