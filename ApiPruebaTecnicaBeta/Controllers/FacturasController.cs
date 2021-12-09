using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.BL;
using PruebaTecnica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPruebaTecnicaBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        public IFacturas Productos { get; set; }
        private readonly IFacturas _facturas;

        public FacturasController(IFacturas facturas)
        {
            _facturas = facturas;
        }

        // GET: api/<FacturasController>
        [HttpGet]
        [Route("GetFacturas")]
        public async Task<IList<FacturasResponse>> GetFacturas()
        {
            return await _facturas.GetListFacturas();
        }

        // GET api/<FacturasController>/5
        [HttpGet]
        [Route("GetFacturasById/{Id}")]
        public async Task<FacturasResponse> GetFacturasById(int Id)
        {
            return await _facturas.GetFacturabyId(Id);
        }

        // POST api/<FacturasController>
        [HttpPost]
        [Route("CrearFactura")]
        public async Task<bool> CrearFactura(FacturasRequest crearFactura)
        {
            return await _facturas.InsertFactura(crearFactura);
        }
    }
}
