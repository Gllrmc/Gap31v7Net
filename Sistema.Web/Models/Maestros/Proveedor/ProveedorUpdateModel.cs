

using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Proveedor
{
    public class ProveedorUpdateModel
    {
        public int idproveedor { get; set; }
        public int? idpersona { get; set; }
        [Required]
        public string razonsocial { get; set; }
        public string cuit { get; set; }
        [Required]
        public string situacioniva { get; set; }
        [Required]
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
    }
}
