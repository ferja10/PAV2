using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_entidad
{
    public class Localidad
    {
        public int id_localidad { get; set; }
        public string nombre { get; set; }
        public Provincia provincia { get; set; }
    }
}
