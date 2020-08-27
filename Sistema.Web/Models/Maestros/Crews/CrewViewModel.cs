using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Crews
{
    public class CrewViewModel
    {
        public int idcrew { get; set; }
        public int idpersona { get; set; }
        public string nombre { get; set; }
        public string cuil { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecnacimiento { get; set; }
        public string nacionalidad { get; set; }
        public string estudioscursados { get; set; }
        public string estadocivil { get; set; }
        public string datosconyugue { get; set; }
        public int cantidadhijos { get; set; }
        public string listammaanacimientohijos { get; set; }
        public string sindicato { get; set; }
        public string numafiliadosindicato { get; set; }
        public string obrasocial { get; set; }
        public string numafiliadoobrasocial { get; set; }
        public string cbu { get; set; }
        public bool activo { get; set; }
    }
}
