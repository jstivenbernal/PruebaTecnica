using PruebaTecnica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DL
{
    public interface IFacturasDL
    {
        public Task<IList<FacturasResponse>> GetListFacturasAsync();
        public Task<FacturasResponse> GetFacturaByIdAsync(int Id);
        public Task<bool> InsertFacturaAsync(FacturasRequest factura);
    }
}
