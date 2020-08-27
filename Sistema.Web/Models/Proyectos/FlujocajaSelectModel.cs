using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Proyectos
{
    public class FlujocajaSelectModel
    {
        public int idflujocaja { get; set; }
        public int idproyecto { get; set; }
        public string proyectoorden { get; set; }
        public string proyecto { get; set; }
        public string producto { get; set; }
        public DateTime? fecdescf { get; set; }
        public DateTime? fechascf { get; set; }
    }
}
