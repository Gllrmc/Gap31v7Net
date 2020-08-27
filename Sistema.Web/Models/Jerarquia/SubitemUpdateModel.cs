

using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Jerarquia
{
    public class SubitemUpdateModel
    {
        public int? idsubitem { get; set; }
        public int iditem { get; set; }
        [Required]
        public string orden { get; set; }
        [Required]
        public string subitemes { get; set; }
        [Required]
        public string subitemen { get; set; }
        public bool activo { get; set; }
    }
}
