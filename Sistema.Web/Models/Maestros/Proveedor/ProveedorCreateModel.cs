
using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Maestros.Proveedor
{
    public class ProveedorCreateModel
    {
        public int? idpersona { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La razon social no puede ser mayor a {1} ni menor a {2} caracteres")]
        public string razonsocial { get; set; }
        public string cuit { get; set; }
        [Required]
        public string situacioniva { get; set; }
        [Required]
        public string situacioniibb { get; set; }
        public string jurisdiccion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        [StringLength(50, ErrorMessage = "La direccion no puede ser mayor a {1} caracteres")]
        public string direccion { get; set; }
        [StringLength(50, ErrorMessage = "La localidad no puede ser mayor a {1} caracteres")]
        public string localidad { get; set; }
        public string cpostal { get; set; }
        public int idprovincia { get; set; }
        public int idpais { get; set; }
        public string formadepago { get; set; }
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
        [Required]
        public bool activo { get; set; }
    }
}
