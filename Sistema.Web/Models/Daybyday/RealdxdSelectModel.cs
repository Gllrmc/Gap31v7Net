using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class RealdxdSelectModel
    {
        public int idrealdxd { get; set; }
        public int idrecursodxd { get; set; }
        public int idproyecto { get; set; }
        public int iditem { get; set; }
        public int? idsubitem { get; set; }
        public int idcrew { get; set; }
        public DateTime dtdesde { get; set; }
        public DateTime dthasta { get; set; }
        public bool septimodia { get; set; }
    }
}
