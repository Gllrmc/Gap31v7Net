using Sistema.Entidades.Daybyday;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Crew
    {
        [Key]
        [Required]
        public int idcrew { get; set; }
        [ForeignKey("persona")]
        public int idpersona { get; set; }
        public string cuil { get; set; }
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

        public Persona persona { get; set; }
        public ICollection<Recursodxd> recursodxds { get; set; }
    }
}
