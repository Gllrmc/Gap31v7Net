using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class RealdxdViewModel
    {
        public int idrealdxd { get; set; }
        public int idrecursodxd { get; set; }
        public int idproyecto { get; set; }
        public string proyectoorden { get; set; }
        public string proyecto { get; set; }
        public int iditem { get; set; }
        public string itemorden { get; set; }
        public string itemes { get; set; }
        public string itemen { get; set; }
        public int? idsubitem { get; set; }
        public string subitemorden { get; set; }
        public string subitemes { get; set; }
        public string subitemen { get; set; }
        public int idcrew { get; set; }
        public string nombre { get; set; }
        public string cuil { get; set; }
        public DateTime feccontratodesde { get; set; }
        public DateTime feccontratohasta { get; set; }
        public int horasbase { get; set; }
        public DateTime dtdesde { get; set; }
        public DateTime dthasta { get; set; }
        public bool controlsica { get; set; }
        public decimal horasnormal { get; set; }
        public decimal horasextra { get; set; }
        public decimal horasnocturna { get; set; }
        public decimal horasenganche { get; set; }
        public decimal bolobruto { get; set; }
        public decimal boloneto { get; set; }
        public decimal valhoraextra { get; set; }
        public decimal impextra { get; set; }
        public decimal impadicional { get; set; }
        public bool septimodia { get; set; }
        public decimal imptotalbruto { get; set; }
        public decimal impsac { get; set; }
        public decimal impvacaciones { get; set; }
        public decimal impretenciones { get; set; }
        public decimal impsacvacaciones { get; set; }
        public decimal imptotalneto { get; set; }
        public decimal impcontribucionpatronal { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
