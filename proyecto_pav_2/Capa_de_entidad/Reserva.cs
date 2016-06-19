using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_entidad
{
    class Reserva
    {
        public int id_reserva { get; set; }
        public Usuario usuario { get; set; }
        public DateTime fecha_viaje { get; set; }
        public DateTime fecha_regreso { get; set; }
        public Estado_Reserva estado_reserva { get; set; }
        public DateTime fecha_vencimiento { get; set; }
    }
}
