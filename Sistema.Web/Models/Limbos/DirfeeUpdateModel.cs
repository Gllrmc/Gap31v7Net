using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class DirfeeUpdateModel
    {
        [Required]
        public int iddirfee { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fecdirfee { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impdirfee { get; set; }
        public string pdfdirfee { get; set; }
        public string nota { get; set; }
        public int iduserumod { get; set; }
    }
}
