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
        public static void reservar(List<Capa_de_entidad.Detalle_Reserva>lst,string usuario,DateTime fecha_viaje) 
        {
            Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();

            string sql = "";
            string parametros = "";
            int id_usuario = int.Parse(Capa_de_negocio.Gestor_Usuario.obtener_usuarios().Rows[0][0].ToString());
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
    }
}
