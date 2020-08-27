

using System;

namespace Sistema.Web.Models.Maestros.Proveedor
{
    public class ProveedorViewModel
    {
        public int idproveedor { get; set; }
        public int? idpersona { get; set; }
        public string razonsocial { get; set; }
        public string cuit { get; set; }
        public string situacioniva { get; set; }
        public string situacioniibb { get; set; }
        public string jurisdiccion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string cpostal { get; set; }
        public int idprovincia { get; set; }
        public string provincia { get; set; }
        public int idpais { get; set; }
        public string pais { get; set; }
        public string formadepago { get; set; }
        public bool generico { get; set; }
        public string tipocomprobantegenerico { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public string persona { get; set; }
        public string emailpersonal { get; set; }
        public string telefonopersonal { get; set; }
        public bool activo { get; set; }
    }
}
