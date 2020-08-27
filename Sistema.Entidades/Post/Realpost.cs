using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Post
{
    public class Realpost
    {
        [Key]
        [Required]
        public int idrealpost { get; set; }
        [Required]
        [ForeignKey("proveedorpost")]
        public int idproveedorpost { get; set; }
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

        public Proveedorpost proveedorpost { get; set; }
    }
}
