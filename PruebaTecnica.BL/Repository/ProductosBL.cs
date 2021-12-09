using PruebaTecnica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.DL;

namespace PruebaTecnica.BL.Repository
{
    public class ProductosBL : IProductos
    {
        public IProductosDL ProductosDL { get; set; }
        private readonly IProductosDL _productosDL;

        public ProductosBL(IProductosDL productosDL)
        {
            _productosDL = productosDL;
        }

        public async Task<IList<ProductosResponse>> GetListProductos()
        {
            return await _productosDL.GetListProductoAsync();
        }

        public async Task<ProductosResponse> GetProductosbyId(int Id)
        {
            return await _productosDL.GetProductoByIdAsync(Id);
        }

        public async Task<bool> InsertProductos(ProductosRequest productos)
        {
            return await _productosDL.InsertProductoAsync(productos);
        }
    }
}
