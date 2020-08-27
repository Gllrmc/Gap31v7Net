using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Tipoproys
{
    public class TipoproySelectModel
    {
        public int idtipoproy { get; set; }
        public string tipoproy { get; set; }
        public string descripcion { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impvenmay { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impvenmen { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porganmay { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porganmen { get; set; }
    }
}
