using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Proyectos
{
    public class ProyectoViewModel
    {
        public int idproyecto { get; set; }
        public int? idraiz { get; set; }
        public string orden { get; set; }
        public string proyecto { get; set; }
        public int idtipoprod { get; set; }
        public string tipoprod { get; set; }
        public int? idempresa { get; set; }
        public string empresa { get; set; }
        public int idorigen { get; set; }
        public string origen { get; set; }
        public int idterritorio { get; set; }
        public string territorio { get; set; }
        public int? idagencia { get; set; }
        public string agencia { get; set; }
        public int? idproductora { get; set; }
        public string productora { get; set; }
        public int? idcliente { get; set; }
        public string cliente { get; set; }
        public int iddirector { get; set; }
        public string director { get; set; }
        public int? idcodirector { get; set; }
        public string codirector { get; set; }
        public int idep { get; set; }
        public string ep { get; set; }
        public int? idlp { get; set; }
        public string lp { get; set; }
        public int? idcp { get; set; }
        public string cp { get; set; }
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
        [DataType(DataType.Date)]
        public DateTime? feccierreprod { get; set; }
        public bool cierreadmin { get; set; }
        [DataType(DataType.Date)]
        public DateTime? feccierreadmin { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
