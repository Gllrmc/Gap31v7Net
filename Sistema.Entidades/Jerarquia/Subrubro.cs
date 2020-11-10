using Sistema.Entidades.Fondos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Jerarquia
{
    public class Subrubro
    {
        [Key]
        [Required]
        public int idsubrubro { get; set; }
        [Required]
        [ForeignKey("rubros")]
        public int idrubro { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El rubro(ES) no puede ser mayor a 65 ni menor a 3 caracteres")]
        public string subrubroes { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El rubro(EN) no puede ser mayor a 65 ni menor a 3 caracteres")]
        public string subrubroen { get; set; }
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El orden no puede ser mayor a 5 ni menor a 1 caracter")]
        [Required]
        public string orden { get; set; }
        public int numhoja { get; set; }
        [Required]
        public bool post { get; set; }
        [Required]
        public bool vivo { get; set; }
        [Required]
        public bool conf { get; set; }
        [Required]
        public bool activo { get; set; }
        public string subrubro { get; }
        public Rubro rubros { get; set; }
        public ICollection<Item> items { get; set; }
        public ICollection<Pedidofondo> pedidofondos { get; set; }
    }
}
