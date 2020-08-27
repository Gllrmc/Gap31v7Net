﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Pagos
{
    public class Sqlordenpago
    {
        public int idordenpago { get; set; }
        public int idproyecto { get; set; }
        public string proyectoorden { get; set; }
        public string proyecto { get; set; }
        public int iditem { get; set; }
        public string itemorden { get; set; }
        public string itemes { get; set; }
        public int? idsubitem { get; set; }
        public string subitemorden { get; set; }
        public string subitemes { get; set; }
        public int idproveedor { get; set; }
        public string razonsocial { get; set; }
        public int idalternativapago { get; set; }
        public string alternativapago { get; set; }
        public DateTime feccomprobante { get; set; }
        public string tipocomprobante { get; set; }
        public string numcomprobante { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal impsiniva { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal imptotal { get; set; }
        public DateTime fecpago { get; set; }
        public string pdfcomprobantefac { get; set; }
        public bool pagado { get; set; }
        public DateTime? fecpagado { get; set; }
        public string pdfcomprobantepago { get; set; }
        public string pdfcertificado1 { get; set; }
        public string pdfcertificado2 { get; set; }
        public string pdfcertificado3 { get; set; }
        public string pdfcertificado4 { get; set; }
        public string notas { get; set; }
        public int iduseralta { get; set; }
        public DateTime fecalta { get; set; }
        public int iduserumod { get; set; }
        public DateTime fecumod { get; set; }
        public bool activo { get; set; }
    }
}
