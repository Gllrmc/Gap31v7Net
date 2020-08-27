using Sistema.Entidades.Daybyday;
using Sistema.Entidades.Fondos;
using Sistema.Entidades.Motion;
using Sistema.Entidades.Pagos;
using Sistema.Entidades.Post;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Jerarquia
{
    public class Item
    {
        [Key]
        [Required]
        public int iditem { get; set; }
        [Required]
        [ForeignKey("subrubros")]
        public int idsubrubro { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El item(ES) no puede ser mayor a 65 ni menor a 3 caracteres")]
        public string itemes { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El item(EN) no puede ser mayor a 65 ni menor a 3 caracteres")]
        public string itemen { get; set; }
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El orden no puede ser mayor a 5 ni menor a 1 caracter")]
        public string orden { get; set; }
        [Required]
        public bool esdxd { get; set; }
        [Required]
        public bool espost { get; set; }
        [Required]
        public bool esmotion { get; set; }
        [Required]
        public bool tienesubitems { get; set; }
        [Required]
        public string cuentagcom { get; set; }
        [Required]
        public int iduseralta { get; set; }
        [Required]
        public DateTime fecalta { get; set; }
        [Required]
        public int iduserumod { get; set; }
        [Required]
        public DateTime fecumod { get; set; }
        [Required]
        public bool activo { get; set; }
        public string item { get; set; }

        public Subrubro subrubros { get; set; }
        public ICollection<Subitem> subitems { get; set; }
        public ICollection<Presupuesto> presupuestos { get; set; }
        public ICollection<Rendicionfondo> rendicionfondos { get; set; }
        public ICollection<Ordenpago> ordenpagos { get; set; }
        public ICollection<Recursodxd> recursodxds { get; set; }
        public ICollection<Tarifadxd> tarifadxds { get; set; }
        public ICollection<Proveedorpost> proveedorposts { get; set; }
        public ICollection<Proveedormotion> proveedormotions { get; set; }
    }
}
