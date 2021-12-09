using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Entity
{
    public class FacturasRequest
    {
        public int IdFac { get; set; }
        public string NumeroFac { get; set; }
        public DateTime FechaFac { get; set; }
        public string TipoDePagoFac { get; set; }
        public string DocumentoClienteFac { get; set; }
        public string NombreClienteFac { get; set; }
        public float SubTotalFac { get; set; }
        public float DescuentoFac { get; set; }
        public float IvaFac { get; set; }
        public float TotalDescuentoFac { get; set; }
        public float TotalImpuestoFac { get; set; }
        public float TotalFac { get; set; }
    }
}
