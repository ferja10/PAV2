﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_pav_2
{
    public class Alojamiento
    {
        public int id_alojamiento { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Pension pension { get; set; }
        public Habitacion habitacion { get; set; }
        public float precio { get; set; }
    }
}