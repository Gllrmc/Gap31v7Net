using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Crews
{
    public class CrewSelectModel
    {
        public int idcrew { get; set; }
        public int idpersona { get; set; }
        public string nombre { get; set; }
        public string cuil { get; set; }
    }
}
