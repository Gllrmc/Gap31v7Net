using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Daybyday
{
    public class Realdxd
    {
        [Key]
        [Required]
        public int idrealdxd { get; set; }
        [Required]
        [ForeignKey("tupladxd")]
        public int idrecursodxd { get; set; }
        [Required]
        public int horasbase { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }
        [Required]
        public DateTime dtdesde { get; set; }
        [Required]
        public DateTime dthasta { get; set; }
        [Required]
        public bool controlsica { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal horasnormal { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal horasextra { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal horasnocturna { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal horasenganche { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal bolobruto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal boloneto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal valhoraextra { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impextra { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impadicional { get; set; }
        [Required]
        public bool septimodia { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imptotalbruto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impsac { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impvacaciones { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impretenciones { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impsacvacaciones { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imptotalneto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impcontribucionpatronal { get; set; }
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

        public Recursodxd recursodxd { get; set; }
    }
}
