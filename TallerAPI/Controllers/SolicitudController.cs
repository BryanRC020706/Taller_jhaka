using Microsoft.AspNetCore.Mvc;
using TallerAPI.Models;
using TallerAPI.Repository.DAO;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        [HttpGet("listarSolicitudes")]
        public async Task<ActionResult<List<Solicitud>>> listarSolicitudes()
        {
            var lista = await Task.Run(() => new SolicitudDAO().listadoSolicitud());
            return Ok(lista);
        }

        [HttpPost("nuevoSolicitud")]
        public async Task<ActionResult<string>> nuevoSolicitud(Solicitud objVO)
        {
            var resultado = await Task.Run(() => new SolicitudDAO().nuevaSolicitud(objVO));
            return Ok(resultado);
        }

        [HttpPut("actualizarSolicitud")]
        public async Task<ActionResult<string>> actualizarSolicitud(Solicitud objVO)
        {
            var resultado = await Task.Run(() => new SolicitudDAO().modificaSolicitud(objVO));
            return Ok(resultado);
        }

        [HttpGet("buscarSolicitud/{id}")]
        public async Task<ActionResult<List<Solicitud>>> buscarSolicitud(int id)
        {
            var lista = await Task.Run(() => new SolicitudDAO().buscarSolicitud(id));
            return Ok(lista);
        }
    }
}
