using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Proyectos
{
    public class FlujocajaViewModel
    {

        public int idflujocaja { get; set; }
        public int idproyecto { get; set; }
        public string proyectoorden { get; set; }
        public string proyecto { get; set; }
        public string producto { get; set; }
        public DateTime fecadjudicacion { get; set; }
        public DateTime? fecdesdxd { get; set; }
        public DateTime? fechasdxd { get; set; }
        public DateTime? fecdescf { get; set; }
        public DateTime? fechascf { get; set; }
        public DateTime? fecrodaje { get; set; }
        public DateTime? fecoffline { get; set; }
        public DateTime? feconline { get; set; }
        public decimal ars1usd { get; set; }
        public int idrubro { get; set; }
        public string rubroorden { get; set; }
        public string rubroes { get; set; }
        public string rubroen { get; set; }
        public string yearweek { get; set; }
        public string fromto { get; set; }
        public decimal tasadistribucion { get; set; }
        public decimal importe { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
