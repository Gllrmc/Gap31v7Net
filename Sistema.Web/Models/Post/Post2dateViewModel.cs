using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Post
{
    public class Post2dateViewModel
    {
        public int idproyecto { get; set; }
        public string proy { get; set; }
        public string proyecto { get; set; }
        public int idrubro { get; set; }
        public string rubro { get; set; }
        public int idsubrubro { get; set; }
        public string subrubro { get; set; }
        public int iditem { get; set; }
        public string item { get; set; }
        public int idsubitem { get; set; }
        public string subitem { get; set; }
        public string proveedor { get; set; }
        public string cuit { get; set; }
        public DateTime fecha { get; set; }
        public decimal hhee { get; set; }
        public decimal porhhee { get; set; }
        public decimal impbase { get; set; }
        public decimal imphhee { get; set; }
        public decimal impjorn { get; set; }
        public decimal impadic { get; set; }
        public decimal imptotal { get; set; }
    }
}
