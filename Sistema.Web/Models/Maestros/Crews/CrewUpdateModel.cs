using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Crews
{
    public class CrewUpdateModel
    {
        [Required]
        public int idcrew { get; set; }
        [Required]
        public int idpersona { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El cuil debe tener 11 digitos")]
        public string cuil { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime fecnacimiento { get; set; }
        [Required]
        public string nacionalidad { get; set; }
        [Required]
        public string estudioscursados { get; set; }
        [Required]
        public string estadocivil { get; set; }
        public string datosconyugue { get; set; }
        [Required]
        public int cantidadhijos { get; set; }
        public string listammaanacimientohijos { get; set; }
        public string sindicato { get; set; }
        public string numafiliadosindicato { get; set; }
        public string obrasocial { get; set; }
        public string numafiliadoobrasocial { get; set; }
        public string cbu { get; set; }
    }
}
