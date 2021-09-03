﻿using Sistema.Entidades.Fondos;
using Sistema.Entidades.Garantias;
using Sistema.Entidades.Motion;
using Sistema.Entidades.Pagos;
using Sistema.Entidades.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Maestros
{
    public class Proveedor
    {
        [Key]
        [Required]
        public int idproveedor { get; set; }
        [ForeignKey("persona")]
        public int? idpersona { get; set; }
        [Required]
        public string razonsocial { get; set; }
        public string cuit { get; set; }
        [Required]
        public string situacioniva { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string telefono { get; set; }
        [Required]
        public bool generico { get; set; }
        public string tipocomprobantegenerico { get; set; }
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

        public Persona persona { get; set; }
        public ICollection<Rendicionfondo> rendicionfondos { get; set; }
        public ICollection<Ordenpago> ordenpagos { get; set; }
        public ICollection<Alternativapago> alternativapagos { get; set; }
        public ICollection<Proveedorpost> proveedorposts { get; set; }
        public ICollection<Proveedormotion> proveedormotions { get; set; }
        public ICollection<Garantia> garantias { get; set; }

    }
}
