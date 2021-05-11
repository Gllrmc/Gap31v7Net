using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Limbos
{
    public class DirfeeCreateModel
    {
        [Required]
        public int idlimbo { get; set; }
        [Required]
        public DateTime fecdirfee { get; set; }
        [Required]
        public decimal impdirfee { get; set; }
        public string pdfdirfee { get; set; }
        public string nota { get; set; }
        [Required]
        public int iduseralta { get; set; }
    }
}
