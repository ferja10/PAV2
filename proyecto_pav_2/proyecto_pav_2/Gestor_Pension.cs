using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_pav_2
{
    public class Gestor_Pension
    {
        public static DataTable obtener_pensiones() 
        {
            DataTable dt = new DataTable();
            Acceso_A_Datos ad = new Acceso_A_Datos();
            string sql = "select P.id_pension as 'id_pension',P.nombre + ' C/' + P.descripcion as 'descripcion' from Pension P";

            dt = ad.leo_tabla(sql);

            return dt;

        }
    }
}