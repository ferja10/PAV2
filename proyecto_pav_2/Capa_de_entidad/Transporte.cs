using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capa_de_entidad
{
    public class Transporte
    {
        public int id_transporte { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Empresa empresa { get; set; }
        public decimal precio { get; set; }
    }
}