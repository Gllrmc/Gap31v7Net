using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Pagos
{
    public class OrdenpagoViewModel
    {
        public int idordenpago { get; set; }
        public int idproyecto { get; set; }
        public string proyectoorden { get; set; }
        public string proyecto { get; set; }
        public int iditem { get; set; }
        public string itemorden { get; set; }
        public string itemes { get; set; }
        public string itemen { get; set; }
        public int? idsubitem { get; set; }
        public string subitemorden { get; set; }
        public string subitemes { get; set; }
        public string subitemen { get; set; }
        public int idproveedor { get; set; }
        public string proveedor { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public int idalternativapago { get; set; }
        public string alternativapago { get; set; }
        public string banco { get; set; }
        public string numcuenta { get; set; }
        public string cbu { get; set; }
        public string alias { get; set; }
        public DateTime feccomprobante { get; set; }
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        public decimal impsiniva { get; set; }
        public decimal imptotal { get; set; }
        public DateTime fecpago { get; set; }
        public int idforpago { get; set; }
        public string forpago { get; set; }
        public string pdfcomprobantefac { get; set; }
        public bool pagado { get; set; }
        public DateTime? fecpagado { get; set; }
        public string pdfcomprobantepago { get; set; }
        public string pdfcertificado1 { get; set; }
        public string pdfcertificado2 { get; set; }
        public string pdfcertificado3 { get; set; }
        public string pdfcertificado4 { get; set; }
        public string notas { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
