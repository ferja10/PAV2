using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_pav_2
{
    public class Gestor_Habitacion
    {
        public static DataTable obtener_habitaciones() 
        {
            DataTable dt = new DataTable();
            Acceso_A_Datos ad = new Acceso_A_Datos();

            string sql = "select * from Habitacion";

            dt = ad.leo_tabla(sql);

            return dt;
        }
    }
}