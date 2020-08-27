using Sistema.Entidades.Garantias;
using Sistema.Entidades.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Entidades.Jerarquia
{
    public class Rubro
    {
        [Key]
        [Required]
        public int idrubro { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El rubro(ES) no puede ser mayor a 65 ni menor a 3 caracteres")]
        public string rubroes { get; set; }
        [StringLength(65, MinimumLength = 3, ErrorMessage = "El rubro(EN) no puede ser mayor a 65 ni menor a 3 caracteres")]
        public string rubroen { get; set; }
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El orden no puede ser mayor a 5 ni menor a 1 caracter")]
        public string orden { get; set; }
        [Required]
        public bool activo { get; set; }

        public ICollection<Subrubro> subrubros { get; set; }
        public ICollection<Flujocaja> flujocajas { get; set; }
        public ICollection<Garantia> garantias { get; set; }

    }
}
