using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Gastos
{
    public class GastoSelectModel
    {
        public int idgasto { get; set; }
        public int idconcepto { get; set; }
        public string concepto { get; set; }
        public DateTime fecgasto { get; set; }
        public decimal importe { get; set; }
    }
}
