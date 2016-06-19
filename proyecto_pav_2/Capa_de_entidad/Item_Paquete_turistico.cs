using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_entidad
{
    class Item_Paquete_turistico
    {
        public Paquete_Turistico paquete_turistico { get; set; }
        public DateTime fecha_viaje { get; set; }
        public DateTime fecha_regreso { get; set; }
        public Boolean es_mayor { get; set; }
    }
}
