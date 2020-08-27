
namespace Sistema.Web.Models.Maestros.Empresas
{
    public class EmpresaViewModel
    {
        public int idempresa { get; set; }
        public string empresa { get; set; }
        public string cuit { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string cpostal { get; set; }
        public int idprovincia { get; set; }
        public string provincia { get; set; }
        public int idpais { get; set; }
        public string pais { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string webpage { get; set; }
        public bool activo { get; set; }
    }
}
