using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Fondos
{
    public class RendicionfondoUpdateModel
    {
        [Required]
        public int idrendicionfondo { get; set; }
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
    }
}
