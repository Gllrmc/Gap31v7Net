using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Resultados
{
    public class ResultadoSelectModel
    {
        public int idresultado { get; set; }
        public string resultado { get; set; }
        public bool esaprobacion { get; set; }
    }
}
