using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Usuarios.Usuarioproyecto
{
    public class UsuarioproyectoViewModel
    {
        public int idusuarioproyecto { get; set; }
        public int idusuario { get; set; }
        public string userid { get; set; }
        public int idproyecto { get; set; }
        public string proyectoorden { get; set; }
        public string proyecto { get; set; }
        public bool vivo { get; set; }
        public bool post { get; set; }
        public bool confidencial { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
