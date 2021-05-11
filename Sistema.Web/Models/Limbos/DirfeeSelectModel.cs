using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class DirfeeSelectModel
    {
        public int iddirfee { get; set; }
        public int idlimbo { get; set; }
        public string limbo { get; set; }
        public int numdirfee { get; set; }
        public DateTime fecdirfee { get; set; }
        public decimal impdirfee { get; set; }
    }
}
