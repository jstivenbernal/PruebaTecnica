using PruebaTecnica.DL;
using PruebaTecnica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BL.Repository
{
    public class FacturasBL : IFacturas
    {
        public IFacturasDL FacturasDL { get; set; }
        private readonly IFacturasDL _facturasDL;

        public FacturasBL(IFacturasDL facturasDL)
        {
            _facturasDL = facturasDL;
        }

        public async Task<IList<FacturasResponse>> GetListFacturas()
        {
            return await _facturasDL.GetListFacturasAsync();
        }

        public async Task<FacturasResponse> GetFacturabyId(int Id)
        {
            return await _facturasDL.GetFacturaByIdAsync(Id);
        }

        public async Task<bool> InsertFactura(FacturasRequest facturas)
        {
            return await _facturasDL.InsertFacturaAsync(facturas);
        }
    }
}
