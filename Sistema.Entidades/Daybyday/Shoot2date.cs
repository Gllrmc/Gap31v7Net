using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Daybyday
{
    public class Shoot2date
    {
        public int id { get; set; }
        public int idproyecto { get; set; }
        public string proy { get; set; }
        public string proyecto { get; set; }
        public int idrubro { get; set; }
        public string rubro { get; set; }
        public int idsubrubro { get; set; }
        public string subrubro { get; set; }
        public int iditem { get; set; }
        public string item { get; set; }
        public int idsubitem { get; set; }
        public string subitem { get; set; }
        public string cargo { get; set; }
        public string nombre { get; set; }
        public string cuil { get; set; }
        public DateTime fecha { get; set; }
        public int hsbase {get; set;}
        [Column(TypeName = "decimal(5, 2)")]
        public decimal horas { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal hsext { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal hseng { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal hsnoc { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impbruto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impret { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impsac { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impvac { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impsacv { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impneto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impcontr { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imptotal { get; set; }
    }
}
