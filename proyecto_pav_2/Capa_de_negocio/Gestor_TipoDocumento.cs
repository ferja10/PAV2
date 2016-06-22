using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capa_de_negocio
{
    public class Gestor_TipoDocumento
    {
        public static DataTable obtener_TiposDocumento()
        {
            DataTable dt = new DataTable();
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            string sql = "SELECT * FROM Tipo_Documento";
            dt = ad.leo_tabla(sql);

            return dt;
        }
    }
}