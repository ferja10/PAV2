using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_entidad
{
    class Cliente
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Tipo_Documento tipo_documento { get; set; }
        public int numero_documento { get; set; }
        public int telefono { get; set; }
        public int celular { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public Localidad localidad { get; set; }
        public string mail { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string sexo { get; set; }
    }
}
