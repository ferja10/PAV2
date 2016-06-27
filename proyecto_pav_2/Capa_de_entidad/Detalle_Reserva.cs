using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_entidad
{
    public class Detalle_Reserva
    {
        public Item_Paquete_turistico item_paquete_turistico { get; set; }
        public int item { get; set; }
        public int cantidad_mayor { get; set; }
        public int cantidad_menor { get; set; }
        public decimal precio_total_mayor
        {
            get{
                return item_paquete_turistico.paquete_turistico.precio_mayores * cantidad_mayor;
            }
        }
        public decimal precio_total_menor 
        { 
            get {
                return item_paquete_turistico.paquete_turistico.precio_menores * cantidad_menor;
            } 
        }
    }
}
