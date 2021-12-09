using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.Entity;

namespace PruebaTecnica.BL
{
    public interface IProductos
    {
        public Task<IList<ProductosResponse>> GetListProductos();
        public Task<ProductosResponse> GetProductosbyId(int Id);
        public Task<bool> InsertProductos(ProductosRequest productos);
    }
}
