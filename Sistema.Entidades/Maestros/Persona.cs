using Sistema.Entidades.Fondos;
using Sistema.Entidades.Limbos;
using Sistema.Entidades.Proyectos;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Persona
    {
        [Key]
        [Required]
        public int idpersona { get; set; }
        [Required]
        public string nombre { get; set; }
        public string domicilio { get; set; }
        public string localidad { get; set; }
        public string cpostal { get; set; }
        [ForeignKey("provincias")]
        public int idprovincia { get; set; }
        [ForeignKey("paises")]
        public int idpais { get; set; }
        public string emailpersonal { get; set; }
        public string telefonopersonal { get; set; }
        public string tipodocumento { get; set; }
        public string numdocumento { get; set; }
        public bool manejafondos { get; set; }
        public bool esep { get; set; }
        public bool eslp { get; set; }
        public bool escp { get; set; }
        public bool escrew { get; set; }
        public bool esproveedor { get; set; }
        public bool escliente { get; set; }
        public bool esdirector { get; set; }
        public bool activo { get; set; }

        public Pais paises { get; set; }
        public Provincia provincias { get; set; }
        public Usuario usuario { get; set; }
        public ICollection<Cliente> clientes { get; set; }
        public ICollection<Proveedor> proveedores { get; set; }
        [InverseProperty("director")]
        public ICollection<Proyecto> directorproyectos { get; set; }
        [InverseProperty("codirector")]
        public ICollection<Proyecto> codirectorproyectos { get; set; }
        [InverseProperty("ep")]
        public ICollection<Proyecto> epproyectos { get; set; }
        [InverseProperty("lp")]
        public ICollection<Proyecto> lpproyectos { get; set; }
        [InverseProperty("cp")]
        public ICollection<Proyecto> cpproyectos { get; set; }
        [InverseProperty("responsable")]
        public ICollection<Pedidofondo> responsablefondos { get; set; }
        [InverseProperty("lep")]
        public ICollection<Limbo> eplimbos { get; set; }
        [InverseProperty("ldirector")]
        public ICollection<Limbo> directorlimbos { get; set; }
        [InverseProperty("lcodirector")]
        public ICollection<Limbo> codirectorlimbos { get; set; }

    }
}
