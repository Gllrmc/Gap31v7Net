using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Fondos
{
    public class RendicionfondoCreateModel
    {
        [Required]
        public int iddistribucionfondo { get; set; }
        [Required]
        public int iditem { get; set; }
        public int? idsubitem { get; set; }
        [Required]
        public int? idproveedor { get; set; }
        [Required]
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        [Required]
        public DateTime feccomprobante { get; set; }
        public string indiceinterno { get; set; }
        [Required]
        public decimal impsiniva { get; set; }
        [Required]
        public decimal imptotal { get; set; }
        public string notas { get; set; }
        public string pdfcomprobante { get; set; }
        [Required]
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
