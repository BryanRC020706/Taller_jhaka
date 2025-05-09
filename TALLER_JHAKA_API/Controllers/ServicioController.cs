using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TALLER_JHAKA_API.Models;
using TALLER_JHAKA_API.Repository.DAO;

namespace TALLER_JHAKA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        [HttpGet("listarServicios")]
        public async Task<ActionResult<List<Servicio>>> listarServicios()
        {
            var lista = await Task.Run(() => new ServicioDAO().listadoServicios());
            return Ok(lista);
        }

        [HttpPost("nuevoServicio")]
        public async Task<ActionResult<string>> nuevoServicio(Servicio obj)
        {
            var resultado = await Task.Run(() => new ServicioDAO().nuevoServicio(obj));
            return Ok(resultado);
        }

        [HttpPut("actualizarServicio")]
        public async Task<ActionResult<string>> actualizarServicio(Servicio obj)
        {
            var resultado = await Task.Run(() => new ServicioDAO().modificaServicio(obj));
            return Ok(resultado);
        }
        [HttpGet("buscarServicio/{id}")]
        public async Task<ActionResult<Servicio>> buscarServicio(int id)
        {
            var lista = await Task.Run(() => new ServicioDAO().buscarServicio(id));
            return Ok(lista);
        }
    }
}
