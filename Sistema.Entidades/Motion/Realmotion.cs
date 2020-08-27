using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Motion
{
    public class Realmotion
    {
        [Key]
        [Required]
        public int idrealmotion { get; set; }
        [Required]
        [ForeignKey("proveedormotion")]
        public int idproveedormotion { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }
        [Required]
        public DateTime dtdesde { get; set; }
        [Required]
        public DateTime dthasta { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal hhee { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal porhhee { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal impbase { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal imphhee { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal impjornada { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal impjornadaadicional { get; set; }
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

        public Proveedormotion proveedormotion { get; set; }
    }
}
