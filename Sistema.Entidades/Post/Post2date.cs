using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Post
{
    public class Post2date
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
        public string proveedor { get; set; }
        public string cuit { get; set; }
        public DateTime fecha { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal hhee { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal porhhee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impbase { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imphhee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impjorn { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impadic { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imptotal { get; set; }
    }
}
