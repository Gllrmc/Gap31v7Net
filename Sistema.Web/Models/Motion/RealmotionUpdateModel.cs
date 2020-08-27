using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Motion
{
    public class RealmotionUpdateModel
    {
        [Required]
        public int idrealmotion { get; set; }
        [Required]
        public int idproveedormotion { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public DateTime dtdesde { get; set; }
        [Required]
        public DateTime dthasta { get; set; }
        [Required]
        public decimal hhee { get; set; }
        [Required]
        public decimal porhhee { get; set; }
        [Required]
        public decimal impbase { get; set; }
        [Required]
        public decimal imphhee { get; set; }
        [Required]
        public decimal impjornada { get; set; }
        [Required]
        public decimal impjornadaadicional { get; set; }
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
