using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Motion
{
    public class RealmotionViewModel
    {
        public int idrealmotion { get; set; }
        public int idproveedormotion { get; set; }
        public int idproyecto { get; set; }
        public string proyecto { get; set; }
        public string proyectoorden { get; set; }
        public int iditem { get; set; }
        public string itemorden { get; set; }
        public string itemes { get; set; }
        public string itemen { get; set; }
        public int? idsubitem { get; set; }
        public string subitemorden { get; set; }
        public string subitemes { get; set; }
        public string subitemen { get; set; }
        public int idproveedor { get; set; }
        public string razonsocial { get; set; }
        public string cuit { get; set; }
        public decimal tarifadiaria { get; set; }
        public DateTime dtdesde { get; set; }
        public DateTime dthasta { get; set; }
        public decimal hhee { get; set; }
        public decimal porhhee { get; set; }
        public decimal impbase { get; set; }
        public decimal imphhee { get; set; }
        public decimal impjornada { get; set; }
        public decimal impjornadaadicional { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
