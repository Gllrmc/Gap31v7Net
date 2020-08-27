using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class SicaViewModel
    {
        public int idsica { get; set; }
        public string asignacion { get; set; }
        public string cargo { get; set; }
        public decimal horas8 { get; set; }
        public decimal extras4 { get; set; }
        public decimal total12 { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
