using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Alternativapagos
{
    public class AlternativapagoSelectModel
    {
        public int idalternativapago { get; set; }
        public int idproveedor { get; set; }
        public string proveedor { get; set; }
        public string orden { get; set; }
        public string beneficiario { get; set; }
        public string cuitcuil { get; set; }
        public string banco { get; set; }
        public string cbu { get; set; }
        public string alias { get; set; }
        public bool activo { get; set; }
    }
}
