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
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public decimal descuento_menor { get; set; }
    }
}