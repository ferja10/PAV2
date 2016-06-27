using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_negocio
{
    public class Gestor_Usuario
    {
        private static string sql;

        public static DataTable obtener_usuarios() 
        {
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "SELECT * FROM Usuario order by nombre_usuario";
            
           return ad.leo_tabla(sql);
        }

        public static Boolean validar_usuario_contraseña(string usuario, string clave ) 
        {
            sql = "SELECT * FROM Usuario WHERE (nombre_usuario='"+usuario+"') and (contraseña='"+clave+"')";

            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            DataTable dt = new DataTable();

            dt=ad.leo_tabla(sql);

            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string[] obtener_roles(string usuario) 
        {
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            string rol="";

            sql = "SELECT * FROM  Usuario where nombre_usuario=@nombre_usuario";
            string parametros = "@nombre_usuario=" + usuario;

            SqlDataReader dr = ad.leo_tabla_lectura(sql, parametros);

            while (dr.Read())
            {
                rol =  dr["rol"].ToString() ;
            }
            return new string[] {rol};
        }

    }
}
