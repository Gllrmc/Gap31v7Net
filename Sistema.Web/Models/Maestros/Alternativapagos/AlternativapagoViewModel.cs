using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Alternativapagos
{
    public class AlternativapagoViewModel
    {
        public int idalternativapago { get; set; }
        public int idproveedor { get; set; }
        public string proveedor { get; set; }
        public string orden { get; set; }
        public string beneficiario { get; set; }
        public string banco { get; set; }
        public string cuitcuil { get; set; }
        public string tipocuenta { get; set; }
        public string numcuenta { get; set; }
        public string cbu { get; set; }
        public string alias { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
