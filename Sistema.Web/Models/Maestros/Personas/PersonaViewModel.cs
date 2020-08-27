using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Maestros.Personas
{
    public class PersonaViewModel
    {
        public int idpersona { get; set; }
        public string nombre { get; set; }
        public string domicilio { get; set; }
        public string localidad { get; set; }
        public string cpostal { get; set; }
        public int idprovincia { get; set; }
        public string provincia { get; set; }
        public int idpais { get; set; }
        public string pais { get; set; }
        public string emailpersonal { get; set; }
        public string telefonopersonal { get; set; }
        public string tipodocumento { get; set; }
        public string numdocumento { get; set; }
        public bool manejafondos { get; set; }
        public bool esep { get; set; }
        public bool eslp { get; set; }
        public bool escp { get; set; }
        public bool escrew { get; set; }
        public bool esproveedor { get; set; }
        public bool escliente { get; set; }
        public bool esdirector { get; set; }
        public bool activo { get; set; }
    }
}
