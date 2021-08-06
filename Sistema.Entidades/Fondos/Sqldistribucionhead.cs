using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Entidades.Fondos
{
    public class Sqldistribucionhead
    {
        public int idproyecto { get; set; }
        public string orden { get; set; }
        public string proyecto { get; set; }
        public int idusuario { get; set; }
        public string userid { get; set; }
        public int cantidad { get; set; }
        public decimal importe { get; set; }
        public int ultdist { get; set; }
    }
}
