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
                "PT.cantidad_dias as 'cantidad_dias',PT.cantidad_noches as 'cantidad_noches',PXT.fecha_comienzo_funcionamiento, " +
                "PXT.fecha_alta from Paquete_Turistico PT join Paquete_X_Temporada PXT on PT.id_paquete_turistico = PXT.id_paquete_turistico " +
                "join Temporada T on PXT.id_temporada = T.id_temporada join Destino D on PT.id_destino = D.id_destino " +
                "where PXT.estado = 1 order by PT.nombre_paquete";
            
            DataTable dt = new DataTable();
            dt = ad.leo_tabla(sql);

            return dt;
        }

        public static DataTable buscar_por_nombre(string filtro_a_buscar, string orden) 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();
            DataTable dt = new DataTable();

            sql = "select PT.id_paquete_turistico as 'id_paquete_turistico', PT.nombre_paquete as 'nombre_paquete',D.nombre as 'destino', " +
                "PT.cantidad_dias as 'cantidad_dias',PT.cantidad_noches as 'cantidad_noches',PXT.fecha_comienzo_funcionamiento, " +
                "PXT.fecha_alta from Paquete_Turistico PT join Paquete_X_Temporada PXT on PT.id_paquete_turistico = PXT.id_paquete_turistico " +
                "join Temporada T on PXT.id_temporada = T.id_temporada join Destino D on PT.id_destino = D.id_destino " +
                "where PXT.estado = 1 and PT.nombre_paquete like @nombre_paquete order by " + orden;

            dt=ad.leo_tabla("@nombre_paquete", filtro_a_buscar, sql);

            return dt;
        }

        public static Capa_de_entidad.Paquete_Turistico buscar_por_id(int id_paquete_turistico)
        {
            string id = "" + id_paquete_turistico;

            sql = "select PT.*,D.descripcion as descripcion_destino,D.nombre,PXT.fecha_comienzo_funcionamiento,PXT.fecha_alta,T.id_temporada ,A.id_habitacion, " +
                "A.descripcion as 'descripcion_alojamiento',A.id_pension,A.precio as precio_alojamiento,H.nombre as nombre_habitacion,Pe.nombre as nombre_pension, PXT.monto_excurciones, PXT.descuento_menor, " +
                "Tr.nombre as nombre_transporte,Tr.descripcion as descripcion_transporte,Tr.precio as precio_transporte,E.razon_social " +
                "from Paquete_Turistico PT join Paquete_X_Temporada PXT on PT.id_paquete_turistico = PXT.id_paquete_turistico " +
                "join Temporada T on PXT.id_temporada = T.id_temporada join Alojamiento A on PT.id_alojamiento = A.id_alojamiento " +
                "join Transporte Tr on PT.id_transporte = Tr.id_transporte join Destino D on PT.id_destino = D.id_destino " +
                "join Transporte_X_Destino TXD on (Tr.id_transporte = TXD.id_transporte and TXD.id_destino = D.id_destino) " +
                "join Empresa E on Tr.id_empresa = E.id_empresa join Habitacion H on A.id_habitacion = H.id_habitacion " +
                "join Pension Pe on A.id_pension = Pe.id_pension " +
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

                Capa_de_entidad.Destino d = new Capa_de_entidad.Destino();
                if (dr["id_destino"] != DBNull.Value)
                {
                    d.id_destino = (int)dr["id_destino"];
                }
                d.nombre = dr["nombre"].ToString();
                d.descripcion = dr["descripcion_destino"].ToString();
                pt.destino = d;

                Capa_de_entidad.Transporte tr = new Capa_de_entidad.Transporte();
                if (dr["id_transporte"] != DBNull.Value)
                {
                    tr.id_transporte = (int)dr["id_transporte"];
                }
                tr.nombre = dr["nombre_transporte"].ToString();
                tr.descripcion = dr["descripcion_transporte"].ToString();
                Capa_de_entidad.Empresa e = new Capa_de_entidad.Empresa();
                e.razon_social = dr["razon_social"].ToString();
                tr.empresa = e;

                if (dr["precio_transporte"] != DBNull.Value)
                {
                    tr.precio = (decimal)dr["precio_transporte"];
                }
                
                pt.transporte = tr;

                if (dr["id_alojamiento"] != DBNull.Value)
                {
                    Capa_de_entidad.Alojamiento a = new Capa_de_entidad.Alojamiento();
                    a.id_alojamiento = (int)dr["id_alojamiento"];
                    
                    if (dr["id_habitacion"] != DBNull.Value)
                    {
                        Capa_de_entidad.Habitacion h = new Capa_de_entidad.Habitacion();
                        h.id_habitacion = (int)dr["id_habitacion"];
                        h.nombre = dr["nombre_habitacion"].ToString();
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
                        p.nombre = dr["nombre_pension"].ToString();
                        a.pension = p;
                    }

                    if (dr["precio_alojamiento"] != DBNull.Value)
                    {
                        a.precio = (decimal)dr["precio_alojamiento"];
                    }

                    pt.alojamiento = a;
                }

                if (dr["fecha_comienzo_funcionamiento"] != DBNull.Value)
                {
                    pt.fecha_comienzo_funcionamiento = (DateTime)dr["fecha_comienzo_funcionamiento"];
                }

                if (dr["fecha_alta"] != DBNull.Value)
                {
                    pt.fecha_alta = (DateTime)dr["fecha_alta"];   
                }

                if (dr["id_temporada"] != DBNull.Value)
                {
                    Capa_de_entidad.Temporada t = new Capa_de_entidad.Temporada();
                    t.id_temporada = (int)dr["id_temporada"];
                    pt.temporada = t;
                }

                if (dr["monto_excurciones"] != DBNull.Value)
                {
                    pt.monto_excurciones = (decimal)dr["monto_excurciones"];
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

        public static List<Capa_de_entidad.Paquete_Turistico> obtener_lista(int id_temporada) 
        {
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();
            
            lpt = new List<Capa_de_entidad.Paquete_Turistico>();

            sql = "SELECT P.id_paquete_turistico,P.nombre_paquete,P.descripcion,P.cantidad_dias,P.cantidad_noches,D.nombre as nombre_destino,D.imagen,Tr.precio as precio_transporte,A.precio as precio_alojamiento,PXT.monto_excurciones,PXT.descuento_menor " +
                "from Paquete_Turistico P join Paquete_X_Temporada PXT on P.id_paquete_turistico = PXT.id_paquete_turistico " +
                "join Temporada T on PXT.id_temporada = T.id_temporada join Transporte Tr on P.id_transporte = Tr.id_transporte " +
                "join Alojamiento A on P.id_alojamiento = A.id_alojamiento " +
                "join Destino D on P.id_destino = D.id_destino " +
                "WHERE T.id_temporada = @id_temporada and PXT.fecha_comienzo_funcionamiento <= GETDATE() order by P.nombre_paquete";

            SqlDataReader dr = ad.leo_tabla_lectura("@id_temporada", id_temporada.ToString(), sql);

            while (dr.Read())
            {

                Capa_de_entidad.Paquete_Turistico p = new Capa_de_entidad.Paquete_Turistico();
                Capa_de_entidad.Transporte t = new Capa_de_entidad.Transporte();
                Capa_de_entidad.Alojamiento a = new Capa_de_entidad.Alojamiento();
                Capa_de_entidad.Destino d = new Capa_de_entidad.Destino();

                if (dr["id_paquete_turistico"] != DBNull.Value)
                {
                    p.id_paquete_turistico = (int)dr["id_paquete_turistico"];
                }

                p.nombre_paquete = dr["nombre_paquete"].ToString();

                p.descripcion = dr["descripcion"].ToString();

                if (dr["cantidad_dias"] != DBNull.Value)
                {
                    p.cantidad_dias = (int)dr["cantidad_dias"];
                }

                if (dr["cantidad_noches"] != DBNull.Value)
                {
                    p.cantidad_noches = (int)dr["cantidad_noches"];
                }

                p.destino = new Capa_de_entidad.Destino();
                d.nombre = dr["nombre_destino"].ToString();
                d.imagen = dr["imagen"].ToString();
                p.destino = d;

                if (dr["precio_transporte"] != DBNull.Value)
                {
                    p.transporte = new Capa_de_entidad.Transporte();
                    t.precio = (decimal)dr["precio_transporte"];
                    p.transporte = t;
                }

                if (dr["precio_alojamiento"] != DBNull.Value)
                {
                    p.alojamiento = new Capa_de_entidad.Alojamiento();
                    a.precio = (decimal)dr["precio_alojamiento"];
                    p.alojamiento = a;
                }

                if (dr["monto_excurciones"] != DBNull.Value)
                {
                    p.monto_excurciones = (decimal)dr["monto_excurciones"];
                }
                if (dr["descuento_menor"] != DBNull.Value)
                {
                    p.descuento_menor = (decimal)dr["descuento_menor"];
                }

                lpt.Add(p);
            }

            ad.cerrar_conexion();
            return lpt;
        }

        public static void agregar_paquete(Capa_de_entidad.Paquete_Turistico p) 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();
            int id_paquete=0;

            sql = "insert into Paquete_Turistico (nombre_paquete,id_destino,descripcion,cantidad_dias,cantidad_noches,id_transporte,id_alojamiento,estado) values (@nombre_paquete,@id_destino,@descripcion,@cantidad_dias,@cantidad_noches,@id_transporte,@id_alojamiento,1)";

            string parametros = "@nombre_paquete="+p.nombre_paquete+",@id_destino="+p.destino.id_destino+",@descripcion="+p.descripcion.ToString().Replace(",","#")+",@cantidad_dias="+p.cantidad_dias+",@cantidad_noches="+p.cantidad_noches+",@id_transporte="+p.transporte.id_transporte+",@id_alojamiento="+p.alojamiento.id_alojamiento;
            
            ad.insertar(sql, parametros);

            sql = "select MAX(id_paquete_turistico) as 'id_paquete_turistico' from Paquete_Turistico";

            SqlDataReader dr = ad.leo_tabla_lectura(sql);

            while (dr.Read())
            {
                id_paquete = (int)dr["id_paquete_turistico"];
            }

            p.id_paquete_turistico= id_paquete;

            sql = "insert into Paquete_X_Temporada (id_paquete_turistico,id_temporada,fecha_comienzo_funcionamiento,fecha_alta,monto_excurciones,descuento_menor,estado) values(@id_paquete_turistico,@id_temporada,@fecha_comienzo_funcionamiento,@fecha_alta,@monto_excurciones,@descuento_menor,1)";

            parametros = "@id_paquete_turistico=" + p.id_paquete_turistico + ",@id_temporada=" + p.temporada.id_temporada + ",@fecha_comienzo_funcionamiento=" + p.fecha_comienzo_funcionamiento.ToShortDateString() + ",@fecha_alta=" + DateTime.Now.ToShortDateString() + ",@monto_excurciones=" + p.monto_excurciones.ToString().Replace(",", ".") + ",@descuento_menor=" + p.descuento_menor;

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
                ", fecha_comienzo_funcionamiento = '"  + p.fecha_comienzo_funcionamiento.ToString("dd/MM/yyyy") + "'" +
                ", monto_excurciones = " + p.monto_excurciones.ToString().Replace(",",".") + ", descuento_menor = "+ p.descuento_menor +
                " WHERE id_paquete_turistico = @id_paquete_turistico";

            parametro = "@id_paquete_turistico=" + p.id_paquete_turistico;

            ad.modificar(sql, parametro);
        }

        public static void eliminar_paquete(Capa_de_entidad.Paquete_Turistico p) 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "UPDATE Paquete_X_Temporada SET " +
                "estado = 0, fecha_baja = '" + DateTime.Now.ToString("dd/MM/yyyy") + "'" +
                " WHERE id_paquete_turistico = @id_paquete_turistico";

            string parametro = "@id_paquete_turistico="+p.id_paquete_turistico;

            ad.modificar(sql, parametro);
        }

    }
}