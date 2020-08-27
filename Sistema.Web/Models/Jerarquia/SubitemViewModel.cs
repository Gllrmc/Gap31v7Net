using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Jerarquia
{
    public class SubitemViewModel
    {
        public int? idsubitem { get; set; }
        public int iditem { get; set; }
        public string orden { get; set; }
        public string itemorden { get; set; }
        public string itemes { get; set; }
        public string itemen { get; set; }
        public string subitemes { get; set; }
        public string subitemen { get; set; }
        public bool activo { get; set; }
    }
}
