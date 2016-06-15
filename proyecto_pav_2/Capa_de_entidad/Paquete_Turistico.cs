using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capa_de_entidad
{
    public class Paquete_Turistico
    {
        public int id_paquete_turistico { get; set; }
        public string nombre_paquete { get; set; }
        public string descripcion { get; set; }
        public int cantidad_dias { get; set; }
        public int cantidad_noches { get; set; }
        public Destino destino { get; set; }
        public Transporte transporte { get; set; }
        public Alojamiento alojamiento { get; set; }
        public Temporada temporada { get; set; }
        public DateTime fecha_comienzo_funcionamiento { get; set;}
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_baja { get; set; }
        public decimal monto_excurciones { get; set; }
        public decimal descuento_menor { get; set; }

        public decimal precio
        {
            get { return transporte.precio + alojamiento.precio + monto_excurciones; }
        }

        public decimal precio_menor
        {
            get { return precio * (descuento_menor/100) ; }
        }

    }
}