using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class RealdxdUpdateModel
    {
        [Required]
        public int idrealdxd { get; set; }
        [Required]
        public int idrecursodxd { get; set; }
        [Required]
        public int horasbase { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public DateTime dtdesde { get; set; }
        [Required]
        public DateTime dthasta { get; set; }
        [Required]
        public bool controlsica { get; set; }
        public decimal horasnormal { get; set; }
        public decimal horasnocturna { get; set; }
        public decimal horasenganche { get; set; }
        public decimal horasextra { get; set; }
        public decimal bolobruto { get; set; }
        public decimal boloneto { get; set; }
        public decimal valhoraextra { get; set; }
        public decimal impextra { get; set; }
        public decimal impadicional { get; set; }
        public bool septimodia { get; set; }
        public decimal imptotalbruto { get; set; }
        public decimal impsac { get; set; }
        public decimal impvacaciones { get; set; }
        public decimal impretenciones { get; set; }
        public decimal impsacvacaciones { get; set; }
        public decimal imptotalneto { get; set; }
        public decimal impcontribucionpatronal { get; set; }
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
