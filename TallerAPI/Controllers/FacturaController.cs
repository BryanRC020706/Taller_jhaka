using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerAPI.Models;
using TallerAPI.Repository.DAO;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        [HttpGet("listarFacturas")]
        public async Task<ActionResult<List<Factura>>> listarFacturas()
        {
            var lista = await Task.Run(() => new FacturaDAO().listarFactura());
            return Ok(lista);
        }

        [HttpPost("nuevaFactura")]
        public async Task<ActionResult<string>> nuevaFactura(FacturaIngresar obj)
        {
            var resultado = await Task.Run(() => new FacturaDAO().nuevaFactura(obj));
            return Ok(resultado);
        }

        [HttpGet("buscarFactura/{id}")]
        public async Task<ActionResult<Repuesto>> buscarFactura(int id)
        {
            var lista = await Task.Run(() => new FacturaDAO().buscarFactura(id));
            return Ok(lista);
        }
    }
}
