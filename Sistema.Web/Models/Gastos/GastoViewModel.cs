using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Gastos
{
    public class GastoViewModel
    {
        public int idgasto { get; set; }
        public int idconcepto { get; set; }
        public string concepto { get; set; }
        public string texto { get; set; }
        public string color { get; set; }
        [Column(TypeName = "date")]
        public DateTime fecgasto { get; set; }
        public decimal importe { get; set; }
        public int idforpago { get; set; }
        public string forpago { get; set; }
        public string nota { get; set; }
        public bool pendiente { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
