using Sistema.Entidades.Pagos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Alternativapago
    {
        [Key]
        [Required]
        public int idalternativapago { get; set; }
        [Required]
        [ForeignKey("proveedor")]
        public int idproveedor { get; set; }
        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "El #Orden solo acepta 1 caracter")]
        public string orden { get; set; }
        [Required]
        public string beneficiario { get; set; }
        public string banco { get; set; }
        [Required]
        public string cuitcuil { get; set; }
        public string tipocuenta { get; set; }
        public string numcuenta { get; set; }
        public string cbu { get; set; }
        public string alias { get; set; }
        [Required]
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
        [Required]
        public bool activo { get; set; }

        public Proveedor proveedor { get; set; }
        public ICollection<Ordenpago> ordenpagos { get; set; }
    }
}
