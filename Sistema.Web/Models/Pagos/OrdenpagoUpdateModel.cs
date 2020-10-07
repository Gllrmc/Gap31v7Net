using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Pagos
{
    public class OrdenpagoUpdateModel
    {
        [Required]
        public int idordenpago { get; set; }
        [Required]
        public int idproyecto { get; set; }
        [Required]
        public int iditem { get; set; }
        public int? idsubitem { get; set; }
        [Required]
        public int idproveedor { get; set; }
        [Required]
        public int idalternativapago { get; set; }
        [Required]
        public DateTime feccomprobante { get; set; }
        [Required]
        public string tipocomprobante { get; set; }
        [Required]
        public string numcomprobante { get; set; }
        [Required]
        public decimal impsiniva { get; set; }
        [Required]
        public decimal imptotal { get; set; }
        public DateTime fecpago { get; set; }
        [Required]
        public int idforpago { get; set; }
        public string pdfcomprobantefac { get; set; }
        [Required]
        public bool pagado { get; set; }
        public DateTime? fecpagado { get; set; }
        public string pdfcomprobantepago { get; set; }
        public string pdfcertificado1 { get; set; }
        public string pdfcertificado2 { get; set; }
        public string pdfcertificado3 { get; set; }
        public string pdfcertificado4 { get; set; }
        public string notas { get; set; }
        [Required]
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
    }
}
