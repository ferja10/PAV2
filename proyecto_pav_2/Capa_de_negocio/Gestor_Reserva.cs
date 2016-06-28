using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_negocio
{
    public class Gestor_Reserva
    {
        private static Capa_de_datos.Acceso_A_Datos ad;
        private static string sql;

        public static void reservar(List<Capa_de_entidad.Detalle_Reserva>lst,string usuario,DateTime fecha_viaje) 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            string sql = "";
            string parametros = "";
            int id_usuario = int.Parse(Capa_de_negocio.Gestor_Usuario.obtener_usuarios(usuario).Rows[0][0].ToString());
            int id_reserva = 0;
            
            try
            {
                sql = "Insert into Reserva (id_usuario,fecha_viaje,id_estado_reserva,fecha_vencimiento,fecha_reserva) values (@id_usuario,@fecha_viaje,@id_estado_reserva,@fecha_vencimiento,@fecha_reserva)";

                parametros = "@id_usuario=" + id_usuario + ",@fecha_viaje=" + fecha_viaje.ToShortDateString() + 
                    ",@id_estado_reserva=1,@fecha_vencimiento=" + fecha_viaje.AddDays(-7).ToShortDateString() +
                    ",@fecha_reserva="+DateTime.Now.ToShortDateString();

                ad.insertar(sql, parametros);

                id_reserva = int.Parse(ad.leo_tabla("SELECT MAX(id_reserva) as id_reserva FROM Reserva").Rows[0][0].ToString());

                ad.abrir_transaccion();

                foreach (var det in lst)
                {
                    sql = "Insert into Detalle_Reserva (id_reserva,item,id_paquete_turistico,id_temporada,cantidad_mayores,cantidad_menores) values(@id_reserva,@item,@id_paquete_turistico,@id_temporada,@cantidad_mayores,@cantidad_menores)";
                    
                    parametros = "@id_reserva="+id_reserva+",@item=" + det.item + ",@id_paquete_turistico=" + det.item_paquete_turistico.paquete_turistico.id_paquete_turistico + 
                        ",@id_temporada=" + det.item_paquete_turistico.paquete_turistico.temporada.id_temporada + ",@cantidad_mayores=" 
                        + det.cantidad_mayor + ",@cantidad_menores=" + det.cantidad_menor;

                    ad.ejecutar_transaccion(sql, parametros);

                    sql = "UPDATE Paquete_X_Temporada SET stock = (stock - " + ( det.cantidad_mayor + det.cantidad_menor ) + ") " +
                        "WHERE id_paquete_turistico=@id_paquete_turistico and id_temporada=@id_temporada";

                    parametros = "@id_paquete_turistico=" + det.item_paquete_turistico.paquete_turistico.id_paquete_turistico +
                        ",@id_temporada=" + det.item_paquete_turistico.paquete_turistico.temporada.id_temporada;

                    ad.ejecutar_transaccion(sql, parametros);
                }

                ad.cerrar_transaccion();
            }
            catch (Exception)
            {
                ad.cerrar_transaccion_con_errores();
                sql = "UPDATE Reserva SET id_estado_reserva=3 where id_reserva=@id_reserva";
                parametros = "@id_reserva=" + id_reserva;
                ad.modificar(sql, parametros);
            }
            finally { ad.cerrar_conexion(); }
        }

        public static DataTable buscar_reservas() 
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "select T.nombre as nombre_temporada,P.nombre_paquete,D.nombre as nombre_destino,SUM(DR.cantidad_mayores + DR.cantidad_menores) as cantidad_reservada from " +
                "Reserva R join Detalle_reserva DR on R.id_reserva = DR.id_reserva " +
                "join Estado_Reserva ER on R.id_estado_reserva = ER.id_estado_reserva " +
                "join Paquete_X_Temporada PXT on (DR.id_paquete_turistico=PXT.id_paquete_turistico and DR.id_temporada = PXT.id_temporada) " +
                "join Paquete_Turistico P on P.id_paquete_turistico = PXT.id_paquete_turistico " +
                "join Temporada T on PXT.id_temporada = T.id_temporada " +
                "join Destino D on P.id_destino = D.id_destino " +
                "where ER.id_estado_reserva <> 3 " +
                "group by T.nombre,P.nombre_paquete,D.nombre";

            DataTable dt = new DataTable();
            dt = ad.leo_tabla(sql);

            return dt;
        }

        public static DataTable buscar_reservas(string id_temporada,string fecha_desde,string fecha_hasta,string id_paquete_turistico)
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "select T.nombre as nombre_temporada,P.nombre_paquete,D.nombre as nombre_destino,SUM(DR.cantidad_mayores + DR.cantidad_menores) as cantidad_reservada from " +
                "Reserva R join Detalle_reserva DR on R.id_reserva = DR.id_reserva " +
                "join Estado_Reserva ER on R.id_estado_reserva = ER.id_estado_reserva " +
                "join Paquete_X_Temporada PXT on (DR.id_paquete_turistico=PXT.id_paquete_turistico and DR.id_temporada = PXT.id_temporada) " +
                "join Paquete_Turistico P on P.id_paquete_turistico = PXT.id_paquete_turistico " +
                "join Temporada T on PXT.id_temporada = T.id_temporada " +
                "join Destino D on P.id_destino = D.id_destino " +
                "where ER.id_estado_reserva <> 3 ";

            if (id_temporada != "Todas las temporadas")
            {
                sql += "and T.id_temporada=" + id_temporada + " ";
            }
            if (fecha_desde != "" && fecha_hasta != "")
            {
                 sql += "and (R.fecha_reserva between '"+fecha_desde+"' and '"+fecha_hasta+"') ";
            }
            if (id_paquete_turistico != "Todos los paquetes")
            {
               sql += "and P.id_paquete_turistico=" + id_paquete_turistico + " ";
            }

               sql += "group by T.nombre,P.nombre_paquete,D.nombre";

            DataTable dt = new DataTable();
            dt = ad.leo_tabla(sql);

            return dt;
        }

    }
}
