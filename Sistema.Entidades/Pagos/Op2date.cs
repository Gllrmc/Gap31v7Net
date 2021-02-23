using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Pagos
{
    public class Op2date
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
        public string beneficiario { get; set; }
        public string cbu { get; set; }
        public DateTime feccomprobante { get; set; }
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impneto{ get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imptotal { get; set; }
        public DateTime fecpago { get; set; }
        public int idforpago { get; set; }
        public string forpago { get; set; }
        public bool pagado { get; set; }
        public DateTime fecpagado { get; set; }
        public string notas { get; set; }
        public string cuentagcom { get; set; }
    }
}
