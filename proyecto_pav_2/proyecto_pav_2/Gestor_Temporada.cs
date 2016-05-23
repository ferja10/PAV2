using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_pav_2
{
    public class Gestor_Temporada
    {
        public static DataTable obtener_temporadas()
        {
            DataTable dt = new DataTable();
            Acceso_A_Datos ad = new Acceso_A_Datos();

            string sql = "SELECT * FROM Temporada";
            dt = ad.leo_tabla(sql);

            return dt;
        }
    }
}