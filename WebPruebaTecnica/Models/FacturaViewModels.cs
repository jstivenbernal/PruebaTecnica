using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPruebaTecnica.Models
{
    public class FacturaViewModels
    {
        public int IdFactura { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoDePago { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public float SubTotal { get; set; }
        public float Descuento { get; set; }
        public float Iva { get; set; }
        public float TotalDescuento { get; set; }
        public float TotalImpuesto { get; set; }
        public float Total { get; set; }
    }
}