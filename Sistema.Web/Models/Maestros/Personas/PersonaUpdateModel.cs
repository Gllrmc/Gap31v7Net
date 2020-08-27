using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.Web.Models.Maestros.Personas
{
    public class PersonaUpdateModel
    {
        [Required]
        public int idpersona { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 100 caracteres, ni menos de 3 caracteres.")]
        public string nombre { get; set; }
        public string domicilio { get; set; }
        public string localidad { get; set; }
        public string cpostal { get; set; }
        [Required]
        public int idprovincia { get; set; }
        [Required]
        public int idpais { get; set; }
        [EmailAddress]
        public string emailpersonal { get; set; }
        public string telefonopersonal { get; set; }
        public string tipodocumento { get; set; }
        public string numdocumento { get; set; }
        [Required]
        public bool manejafondos { get; set; }
        [Required]
        public bool esep { get; set; }
        [Required]
        public bool eslp { get; set; }
        [Required]
        public bool escp { get; set; }
        [Required]
        public bool escrew { get; set; }
        [Required]
        public bool esproveedor { get; set; }
        [Required]
        public bool escliente { get; set; }
        [Required]
        public bool esdirector { get; set; }
    }
}
