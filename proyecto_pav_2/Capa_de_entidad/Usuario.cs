using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_entidad
{
    class Usuario
    {
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public Cliente cliente { get; set; }

    }
}
