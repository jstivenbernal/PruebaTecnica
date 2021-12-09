using PruebaTecnica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.BL
{
    public interface IFacturas
    {
        public Task<IList<FacturasResponse>> GetListFacturas();
        public Task<FacturasResponse> GetFacturabyId(int Id);
        public Task<bool> InsertFactura(FacturasRequest facturas);
    }
}
