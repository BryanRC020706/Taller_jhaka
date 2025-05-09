using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerAPI.Models;
using TallerAPI.Repository.DAO;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestoController : ControllerBase
    {
        [HttpGet("listarRespuestos")]
        public async Task<ActionResult<List<Repuesto>>> listarRespuestos()
        {
            var lista = await Task.Run(() => new RepuestoDAO().listadoRepuestos());
            return Ok(lista);
        }

        [HttpPost("nuevoRepuesto")]
        public async Task<ActionResult<string>> nuevoRepuesto(Repuesto obj)
        {
            var resultado = await Task.Run(() => new RepuestoDAO().nuevoRepuesto(obj));
            return Ok(resultado);
        }

        [HttpPut("actualizarRepuesto")]
        public async Task<ActionResult<string>> actualizarRepuesto(Repuesto obj)
        {
            var resultado = await Task.Run(() => new RepuestoDAO().modificaRepuesto(obj));
            return Ok(resultado);
        }

        [HttpGet("buscarRepuesto/{id}")]
        public async Task<ActionResult<Repuesto>> buscarRepuesto(int id)
        {
            var lista = await Task.Run(() => new RepuestoDAO().buscarRepuesto(id));
            return Ok(lista);
        }
    }
}
