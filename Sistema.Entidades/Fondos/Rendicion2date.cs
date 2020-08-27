using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Fondos
{
    public class Rendicion2date
    {
        public int id { get; set; }
        public int idproyecto { get; set; }
        public string proy { get; set; }
        public string proyecto { get; set; }
        public int numpedido { get; set; }
        public string nombre { get; set; }
        public string origen { get; set; }
        public string rubro { get; set; }
        public int idsubrubro { get; set; }
        public string subrubro { get; set; }
        public string item { get; set; }
        public string subitem { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal importe { get; set; }
    }
}
