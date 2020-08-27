using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Provincia
    {
        [Key]
        [Required]
        public int idprovincia { get; set; }
        [Required]
        public string provincia { get; set; }
        public bool activo { get; set; }

        public ICollection<Empresa> empresas { get; set; }
        public ICollection<Persona> personas { get; set; }
        public ICollection<Cliente> clientes { get; set; }
        public ICollection<Proveedor> proveedores { get; set; }
    }
}
