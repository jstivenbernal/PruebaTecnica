using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.Entity;

namespace PruebaTecnica.DL
{
    public interface IProductosDL
    {
        public Task<IList<ProductosResponse>> GetListProductoAsync();
        public Task<ProductosResponse> GetProductoByIdAsync(int Id);
        public Task<bool> InsertProductoAsync(ProductosRequest producto);
    }
}
