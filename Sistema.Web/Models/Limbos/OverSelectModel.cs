using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class OverSelectModel
    {
        public int idover { get; set; }
        public int idlimbo { get; set; }
        public string limbo { get; set; }
        public int numover { get; set; }
        public DateTime fecover { get; set; }
        public decimal impover { get; set; }
    }
}
