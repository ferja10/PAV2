using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capa_de_negocio
{
    public class Gestor_Alojamento
    {
        private static string sql;

        public static DataTable obtener_alojamientos()
        {
            DataTable dt = new DataTable();
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "SELECT * FROM Alojamiento";
            dt = ad.leo_tabla(sql);

            return dt;
        }

        public static DataTable obtener_alojamientos(int id_destino)
        {
            DataTable dt = new DataTable();
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "select A.id_alojamiento as 'id_alojamiento',A.nombre as 'nombre' " +
                "from Alojamiento A join ALOJAMIENTO_X_DESTINO AXD on A.id_alojamiento = AXD.id_alojamiento " +
                "join Destino D on AXD.id_destino = D.id_destino " +
                "where D.id_destino="+id_destino;

            dt = ad.leo_tabla(sql);

            return dt;
        }

        public static Capa_de_entidad.Alojamiento buscar_por_id(int id_alojamiento) 
        {
            string id = "" + id_alojamiento;

            sql = "SELECT * FROM Alojamiento WHERE id_alojamiento = @id_alojamiento";
            Capa_de_entidad.Alojamiento a = new Capa_de_entidad.Alojamiento();

            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            SqlDataReader dr = ad.leo_tabla_lectura("@id_alojamiento", id, sql);

            while (dr.Read())
            {

                if (dr["id_alojamiento"] != DBNull.Value)
                {
                    a.id_alojamiento = (int)dr["id_alojamiento"];

                }

                a.nombre = dr["nombre"].ToString();

                a.descripcion = dr["descripcion"].ToString();

                if (dr["id_habitacion"] != DBNull.Value)
                {
                    Capa_de_entidad.Habitacion h = new Capa_de_entidad.Habitacion();
                    h.id_habitacion = (int)dr["id_habitacion"];
                    a.habitacion = h;    
                }

                if (dr["id_pension"] != DBNull.Value)
                {
                    Capa_de_entidad.Pension p = new Capa_de_entidad.Pension();
                    p.id_pension = (int)dr["id_pension"];
                    a.pension = p;
                }
                
                }
            
            dr.Close();
            ad.cerrar_conexion();

            return a;
        }
    }
}