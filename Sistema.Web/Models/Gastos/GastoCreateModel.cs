using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Gastos
{
    public class GastoCreateModel
    {
        [Required]
        public int idconcepto { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecgasto { get; set; }
        [Required]
        public decimal importe { get; set; }
        [Required]
        public int idforpago { get; set; }
        public string nota { get; set; }
        [Required]
        public bool pendiente { get; set; }
        [Required]
        public int iduseralta { get; set; }
    }
}
