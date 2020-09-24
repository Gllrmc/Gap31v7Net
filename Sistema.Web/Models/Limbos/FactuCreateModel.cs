using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class FactuCreateModel
    {
        [Required]
        public int idlimbo { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime feccomprobante { get; set; }
        [Required]
        public string tipocomprobante { get; set; }
        [Required]
        public string numcomprobante { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impfactu { get; set; }
        public string nota { get; set; }
        [Required]
        public int iduseralta { get; set; }
    }
}
