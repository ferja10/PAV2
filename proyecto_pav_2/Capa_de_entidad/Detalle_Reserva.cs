using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_entidad
{
    class Detalle_Reserva
    {
        public Item_Paquete_turistico item_paquete_turistico { get; set; }
        public int item { get; set; }
        public int cantidad { get; set; }
        public decimal precio_total
        {
            get
            {
                if (item_paquete_turistico.es_mayor)
                {
                    return item_paquete_turistico.paquete_turistico.precio * cantidad;
                }
                else
                {
                    return item_paquete_turistico.paquete_turistico.precio_menor * cantidad;
                }
            }
        }
    }
}
