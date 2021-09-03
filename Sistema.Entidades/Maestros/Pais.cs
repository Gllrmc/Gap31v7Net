using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Pais
    {
        [Key]
        [Required]
        public int idpais { get; set; }
        [Required]
        public string pais { get; set; }
        public string cuit { get; set; }
        public bool activo { get; set; }

        public ICollection<Empresa> empresas { get; set; }
        public ICollection<Persona> personas { get; set; }
        public ICollection<Cliente> clientes { get; set; }
    }
}
