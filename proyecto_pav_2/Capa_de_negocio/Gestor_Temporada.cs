﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Capa_de_negocio
{
    public class Gestor_Temporada
    {
        public static DataTable obtener_temporadas()
        {
            DataTable dt = new DataTable();
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            string sql = "SELECT * FROM Temporada order by nombre";
            dt = ad.leo_tabla(sql);

            return dt;
        }
    }
}