using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Pagos
{
    public class OrdenpagoImageModel
    {
        public int idordenpago { get; set; }
        public string pdfcomprobantefac { get; set; }
        public string pdfcomprobantepago { get; set; }
        public string pdfcertificado1 { get; set; }
        public string pdfcertificado2 { get; set; }
        public string pdfcertificado3 { get; set; }
        public string pdfcertificado4 { get; set; }
    }
}
