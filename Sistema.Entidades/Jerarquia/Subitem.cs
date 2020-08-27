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
    public class Subitem
    {
        [Key]
        [Required]
        public int? idsubitem { get; set; }
        [Required]
        [ForeignKey("item")]
        public int iditem { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El subitem(ES) no puede ser mayor a 65 ni menor a 3 caracteres")]
        public string subitemes { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El subitem(EN) no puede ser mayor a 65 ni menor a 3 caracteres")]
        public string subitemen { get; set; }
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El orden no puede ser mayor a 5 ni menor a 1 caracter")]
        public string orden { get; set; }
        public bool activo { get; set; }

        public Item item { get; set; }
        public ICollection<Presupuesto> presupuestos { get; set; }
        public ICollection<Rendicionfondo> rendicionfondos { get; set; }
        public ICollection<Ordenpago> ordenpagos { get; set; }
        public ICollection<Recursodxd> recursodxds { get; set; }
        public ICollection<Proveedorpost> proveedorposts { get; set; }
        public ICollection<Proveedormotion> proveedormotions { get; set; }
    }
}
