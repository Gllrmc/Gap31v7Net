using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Usuarios.Usuarioproyecto
{
    public class UsuarioproyectoSelectModel
    {
        public int idusuarioproyecto { get; set; }
        public int idusuario { get; set; }
        public int idproyecto { get; set; }
        public bool vivo { get; set; }
        public bool post { get; set; }
        public bool conf { get; set; }
        public bool confidencial { get; set; }
    }
}
