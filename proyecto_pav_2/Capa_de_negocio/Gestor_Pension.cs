using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Capa_de_negocio
{
    public class Gestor_Pension
    {
        public static DataTable obtener_pensiones() 
        {
            DataTable dt = new DataTable();
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();
            string sql = "select P.id_pension as 'id_pension',P.nombre + ' C/' + P.descripcion as 'descripcion' from Pension P";

            dt = ad.leo_tabla(sql);

            return dt;

        }
    }
}