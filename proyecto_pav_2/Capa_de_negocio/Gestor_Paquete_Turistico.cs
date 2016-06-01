using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Capa_de_negocio
{
    public class Gestor_Paquete_Turistico
    {
        private static Capa_de_datos.Acceso_A_Datos ad;
        private static List<Capa_de_entidad.Paquete_Turistico> lpt;
        private static string sql;

        public static DataTable buscar_paquetes()
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "select PT.id_paquete_turistico as 'id_paquete_turistico', PT.nombre_paquete as 'nombre_paquete',D.nombre as 'destino', " +
            "PT.cantidad_dias as 'cantidad_dias',PT.cantidad_noches as 'cantidad_noches', " +
            "PXT.fecha_desde,PXT.fecha_hasta from Paquete_Turistico PT join Paquete_X_Temporada PXT on PT.id_paquete_turistico = PXT.id_paquete_turistico " +
            "join Temporada T on PXT.id_temporada = T.id_temporada join Destino D on PT.id_destino = D.id_destino " +
            "where PT.estado = 1";
            
            DataTable dt = new DataTable();
            dt = ad.leo_tabla(sql);

            return dt;
        }

        public static DataTable buscar_por_nombre(string filtro_a_buscar, string orden) 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();
            DataTable dt = new DataTable();

            sql = "select PT.id_paquete_turistico as 'id_paquete_turistico', PT.nombre_paquete as 'nombre_paquete',D.nombre as 'destino', " +
            "PT.cantidad_dias as 'cantidad_dias',PT.cantidad_noches as 'cantidad_noches', " +
            "PXT.fecha_desde,PXT.fecha_hasta from Paquete_Turistico PT join Paquete_X_Temporada PXT on PT.id_paquete_turistico = PXT.id_paquete_turistico " +
            "join Temporada T on PXT.id_temporada = T.id_temporada join Destino D on PT.id_destino = D.id_destino " +
            "where PT.estado = 1 and PT.nombre_paquete like @nombre_paquete order by " + orden;

            dt=ad.leo_tabla("@nombre_paquete", filtro_a_buscar, sql);

            return dt;
        }

        public static Capa_de_entidad.Paquete_Turistico buscar_por_id(int id_paquete_turistico)
        {
            string id = "" + id_paquete_turistico;

            sql = "select PT.*,PXT.fecha_desde,PXT.fecha_hasta,T.id_temporada ,A.id_habitacion,A.descripcion as 'descripcion_alojamiento',A.id_pension, PXT.descuento_menor as 'descuento_menor' from " +
                "Paquete_Turistico PT join Paquete_X_Temporada PXT on PT.id_paquete_turistico = PXT.id_paquete_turistico " +
                "join Temporada T on PXT.id_temporada = T.id_temporada join Alojamiento A on PT.id_alojamiento = A.id_alojamiento " +
                "where PT.id_paquete_turistico = @id_paquete_turistico";

            Capa_de_entidad.Paquete_Turistico pt = new Capa_de_entidad.Paquete_Turistico();

            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            SqlDataReader dr = ad.leo_tabla_lectura("@id_paquete_turistico", id, sql);

            while (dr.Read())
            {
                
                if (dr["id_paquete_turistico"] != DBNull.Value)
                
                {
                    pt.id_paquete_turistico = (int)dr["id_paquete_turistico"];
                
                }

                pt.nombre_paquete = dr["nombre_paquete"].ToString();
                pt.descripcion = dr["descripcion"].ToString();

                if (dr["cantidad_dias"] != DBNull.Value)
                {
                    pt.cantidad_dias = (int)dr["cantidad_dias"];
                }

                if (dr["cantidad_noches"] != DBNull.Value)
                {
                    pt.cantidad_noches = (int)dr["cantidad_noches"];
                }

                if (dr["id_destino"] != DBNull.Value)
                {
                    Capa_de_entidad.Destino d = new Capa_de_entidad.Destino();
                    d.id_destino = (int)dr["id_destino"];
                    pt.destino = d;
                }

                if (dr["id_transporte"] != DBNull.Value)
                {
                    Capa_de_entidad.Transporte t = new Capa_de_entidad.Transporte();
                    t.id_transporte = (int)dr["id_transporte"];
                    pt.transporte = t;
                }

                if (dr["id_alojamiento"] != DBNull.Value)
                {
                    Capa_de_entidad.Alojamiento a = new Capa_de_entidad.Alojamiento();
                    a.id_alojamiento = (int)dr["id_alojamiento"];
                    
                    if (dr["id_habitacion"] != DBNull.Value)
                    {
                        Capa_de_entidad.Habitacion h = new Capa_de_entidad.Habitacion();
                        h.id_habitacion = (int)dr["id_habitacion"];
                        a.habitacion = h;
                    }

                    if (dr["descripcion_alojamiento"] != DBNull.Value)
                    {
                        a.descripcion = dr["descripcion_alojamiento"].ToString();
                    }

                    if (dr["id_pension"] != DBNull.Value)
                    {
                        Capa_de_entidad.Pension p = new Capa_de_entidad.Pension();
                        p.id_pension = (int)dr["id_pension"];
                        a.pension = p;
                    }

                    pt.alojamiento = a;
                }

                if (dr["fecha_desde"] != DBNull.Value)
                {
                    pt.fecha_inicio = (DateTime)dr["fecha_desde"];
                }

                if (dr["fecha_hasta"] != DBNull.Value)
                {
                    pt.fecha_fin = (DateTime)dr["fecha_hasta"];   
                }

                if (dr["id_temporada"] != DBNull.Value)
                {
                    Capa_de_entidad.Temporada t = new Capa_de_entidad.Temporada();
                    t.id_temporada = (int)dr["id_temporada"];
                    pt.temporada = t;
                }

                if (dr["descuento_menor"] != DBNull.Value)
                {
                    pt.descuento_menor = (decimal)dr["descuento_menor"];
                }

            }
            
            dr.Close();
            ad.cerrar_conexion();

            return pt;
        }

        public static void agregar_paquete(Capa_de_entidad.Paquete_Turistico p) 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();
            int id_paquete=0;

            sql = "insert into Paquete_Turistico (nombre_paquete,id_destino,descripcion,cantidad_dias,cantidad_noches,id_transporte,id_alojamiento,estado) values (@nombre_paquete,@id_destino,@descripcion,@cantidad_dias,@cantidad_noches,@id_transporte,@id_alojamiento,1)";

            string parametros = "@nombre_paquete='"+p.nombre_paquete+"',@id_destino="+p.destino.id_destino+",@descripcion='"+p.descripcion.ToString().Replace(",","#")+"',@cantidad_dias="+p.cantidad_dias+",@cantidad_noches="+p.cantidad_noches+",@id_transporte="+p.transporte.id_transporte+",@id_alojamiento="+p.alojamiento.id_alojamiento;
            
            ad.insertar(sql, parametros);

            sql = "select MAX(id_paquete_turistico) as 'id_paquete_turistico' from Paquete_Turistico";

            SqlDataReader dr = ad.leo_tabla_lectura(sql);

            while (dr.Read())
            {
                id_paquete = (int)dr["id_paquete_turistico"];
            }

            p.id_paquete_turistico= id_paquete;

            sql = "insert into Paquete_X_Temporada (id_paquete_turistico,id_temporada,fecha_desde,fecha_hasta,descuento_menor,estado) values(@id_paquete_turistico,@id_temporada,@fecha_desde,@fecha_hasta,@descuento_menor,1)";

            parametros = "@id_paquete_turistico=" + p.id_paquete_turistico + ",@id_temporada=" + p.temporada.id_temporada + ",@fecha_desde='" + p.fecha_inicio.ToString("dd/MM/yyyy") + "',@fecha_hasta='" + p.fecha_fin.ToString("dd/MM/yyyy") + "'" + ",@descuento_menor=" + p.descuento_menor.ToString().Replace(",", ".");

            ad.insertar(sql, parametros);
        }

        public static void modificar_paquete(Capa_de_entidad.Paquete_Turistico p) 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "UPDATE Paquete_Turistico SET " +
                "nombre_paquete = '" + p.nombre_paquete + "', id_destino = " + p.destino.id_destino + 
                ", descripcion = '" + p.descripcion + "', cantidad_dias = " + p.cantidad_dias + 
                ", cantidad_noches = " + p.cantidad_noches + ", id_transporte = " + p.transporte.id_transporte + 
                ", id_alojamiento = " + p.alojamiento.id_alojamiento +
                " WHERE id_paquete_turistico = @id_paquete_turistico";

            string parametro = "@id_paquete_turistico=" + p.id_paquete_turistico;

            ad.modificar(sql, parametro);

            sql = "UPDATE Paquete_X_Temporada SET " +
                "id_paquete_turistico = " + p.id_paquete_turistico + ", id_temporada = " + p.temporada.id_temporada + 
                ", fecha_desde = '"  + p.fecha_inicio.ToString("dd/MM/yyyy") + "', fecha_hasta = '" + p.fecha_fin.ToString("dd/MM/yyyy") + "'"+
                ", descuento_menor = " + p.descuento_menor.ToString().Replace(",",".") +
                " WHERE id_paquete_turistico = @id_paquete_turistico and id_temporada = @id_temporada";

            parametro = "@id_paquete_turistico=" + p.id_paquete_turistico + ",@id_temporada=" + p.temporada.id_temporada;

            ad.modificar(sql, parametro);
        }

        public static void eliminar_paquete(Capa_de_entidad.Paquete_Turistico p) 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "UPDATE Paquete_Turistico SET " +
                "estado = 0 " +
                "WHERE id_paquete_turistico = @id_paquete_turistico";

            string parametro = "@id_paquete_turistico="+p.id_paquete_turistico;

            ad.modificar(sql, parametro);
        }

    }
}