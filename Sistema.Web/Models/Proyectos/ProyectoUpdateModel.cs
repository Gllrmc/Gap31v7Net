﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Proyectos
{
    public class ProyectoUpdateModel
    {
        public int idproyecto { get; set; }
        public int? idraiz { get; set; }
        [Required]
        public string orden { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El proyecto no puede ser mayor a {1} ni menor a {2} caracteres")]
        public string proyecto { get; set; }
        [Required]
        public int idtipoprod { get; set; }
        [Required]
        public int? idempresa { get; set; }
        [Required]
        public int idorigen { get; set; }
        [Required]
        public int idagencia { get; set; }
        [Required]
        public int idproductora { get; set; }
        [Required]
        public int idcliente { get; set; }
        [Required]
        public int iddirector { get; set; }
        public int? idcodirector { get; set; }
        [Required]
        public int idep { get; set; }
        public int? idlp { get; set; }
        public int? idcp { get; set; }
        public decimal ars1usd { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecadjudicacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecdesdxd { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechasdxd { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecdescf { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechascf { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecrodaje { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fecoffline { get; set; }
        [DataType(DataType.Date)]
        public DateTime? feconline { get; set; }
        public bool cierreprod { get; set; }
        public DateTime? feccierreprod { get; set; }
        public bool cierreadmin { get; set; }
        public DateTime? feccierreadmin { get; set; }
        public int iduserumod { get; set; }
    }
}
