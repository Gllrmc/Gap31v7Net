using System;

namespace Sistema.Web.Models.Fondos
{
    public class RendicionfondoViewModel
    {
        public int idrendicionfondo { get; set; }
        public int iddistribucionfondo { get; set; }
        public int idproyecto { get; set; }
        public string proyecto { get; set; }
        public int idpedidofondo { get; set; }
        public string responsable { get; set; }
        public DateTime fecdistribucion { get; set; }
        public decimal importedistribucion { get; set; }
        public int iditem { get; set; }
        public string itemorden { get; set; }
        public string itemes { get; set; }
        public string itemen { get; set; }
        public int? idsubitem { get; set; }
        public string subitemorden { get; set; }
        public string subitemes { get; set; }
        public string subitemen { get; set; }
        public int? idproveedor { get; set; }
        public string proveedor { get; set; }
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        public DateTime feccomprobante { get; set; }
        public string indiceinterno { get; set; }
        public decimal impsiniva { get; set; }
        public decimal imptotal { get; set; }
        public string notas { get; set; }
        public string pdfcomprobante { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
