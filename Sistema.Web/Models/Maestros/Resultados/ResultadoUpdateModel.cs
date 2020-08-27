using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Resultados
{
    public class ResultadoUpdateModel
    {
        [Required]
        public int idresultado { get; set; }
        [Required]
        public bool esaprobacion { get; set; }
        [Required]
        public string resultado { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
    }
}
