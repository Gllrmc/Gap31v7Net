using Sistema.Entidades.Daybyday;
using Sistema.Entidades.Fondos;
using Sistema.Entidades.Garantias;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Motion;
using Sistema.Entidades.Pagos;
using Sistema.Entidades.Post;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Proyectos
{
    public class Proyecto
    {
        [Key]
        [Required]
        public int idproyecto { get; set; }
        public int? idraiz { get; set; }
        [Required]
        public string orden { get; set; }
        public string proyecto { get; set; }
        [Required]
        [ForeignKey("origenes")]
        public int idorigen { get; set; }
        [ForeignKey("empresas")]
        public int? idempresa { get; set; }
        [Required]
        [ForeignKey("tipoprod")]
        public int idtipoprod { get; set; }
        [Required]
        [ForeignKey("agencias")]
        public int idagencia { get; set; }
        [Required]
        [ForeignKey("productoras")]
        public int idproductora { get; set; }
        [Required]
        [ForeignKey("cliente")]
        public int idcliente { get; set; }
        [Required]
        public Cliente cliente { get; set; }
        [Required]
        [ForeignKey("director")]
        public int iddirector { get; set; }
        public Persona director { get; set; }
        [ForeignKey("codirector")]
        public int? idcodirector { get; set; }
        public Persona codirector { get; set; }
        [Required]
        [ForeignKey("ep")]
        public int idep { get; set; }
        public Persona ep { get; set; }
        [ForeignKey("lp")]
        public int? idlp { get; set; }
        public Persona lp { get; set; }
        [ForeignKey("cp")]
        public int? idcp { get; set; }
        public Persona cp { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ars1usd { get; set; }
        [Required]
        public DateTime fecadjudicacion { get; set; }
        public DateTime? fecdesdxd { get; set; }
        public DateTime? fechasdxd { get; set; }
        public DateTime? fecdescf { get; set; }
        public DateTime? fechascf { get; set; }
        public DateTime? fecrodaje { get; set; }
        public DateTime? fecoffline { get; set; }
        public DateTime? feconline { get; set; }
        public bool cierreprod { get; set; }
        public DateTime? feccierreprod { get; set; }
        public bool cierreadmin { get; set; }
        public DateTime? feccierreadmin { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }

        public Empresa empresas { get; set; }
        public Origen origenes { get; set; }
        public Agencia agencias { get; set; }
        public Productora productoras { get; set; }
        public Tipoprod tipoprod { get; set; }
        public ICollection<Presupuesto> presupuestos { get; set; }
        public ICollection<Pedidofondo> pedidofondos { get; set; }
        public ICollection<Ordenpago> ordenpagos { get; set; }
        public ICollection<Flujocaja> flujocajas { get; set; }
        public ICollection<Recursodxd> recursodxds { get; set; }
        public ICollection<Proveedorpost> proveedorposts { get; set; }
        public ICollection<Proveedormotion> proveedormotions { get; set; }
        public ICollection<Usuarioproyecto> usuarioproyectos { get; set; }
        public ICollection<Garantia> garantias { get; set; }

        //public Proyecto padre { get; set; }
        //public virtual ICollection<Proyecto> hijos { get; set; }
    }
}
