using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.BL;
using PruebaTecnica.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPruebaTecnicaBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public IProductos Productos { get; set; }
        private readonly IProductos _productos;

        public ProductosController(IProductos productos)
        {
            _productos = productos;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        [Route("GetProductos")]
        public async Task<IList<ProductosResponse>> GetProductos()
        {
            return await _productos.GetListProductos();
        }

        // GET api/<ProductosController>/5
        [HttpGet]
        [Route("GetProductosById/{Id}")]
        public async Task<ProductosResponse> GetProductosById(int Id)
        {
            return await _productos.GetProductosbyId(Id);
        }

        // POST api/<ProductosController>
        [HttpPost]
        [Route("CrearProducto")]
        public async Task<bool> CrearProducto(ProductosRequest crearProducto)
        {
            return await _productos.InsertProductos(crearProducto);
        }
    }
}
