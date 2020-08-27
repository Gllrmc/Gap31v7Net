using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Daybyday
{
    public class Shoot2dateViewModel
    {
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
        public int hsbase { get; set; }
        public decimal horas { get; set; }
        public decimal hsext { get; set; }
        public decimal hseng { get; set; }
        public decimal hsnoc { get; set; }
        public decimal impbruto { get; set; }
        public decimal impret { get; set; }
        public decimal impsac { get; set; }
        public decimal impvac { get; set; }
        public decimal impsacv { get; set; }
        public decimal impneto { get; set; }
        public decimal impcontr { get; set; }
        public decimal imptotal { get; set; }
    }
}
