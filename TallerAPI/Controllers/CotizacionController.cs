using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerAPI.Models;
using TallerAPI.Repository.DAO;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        [HttpGet("listarCotizacion")]
        public async Task<ActionResult<List<Cotizacion>>> listarCotizacion()
        {
            var lista = await Task.Run(() => new CotizacionDAO().listadoCotizaciones());
            return Ok(lista);
        }

        [HttpPost("nuevoCotizacion")]
        public async Task<ActionResult<string>> nuevoCotizacion(CotizacionO obj)
        {
            var resultado = await Task.Run(() => new CotizacionDAO().nuevaCotizacion(obj));
            return Ok(resultado);
        }

        [HttpPut("actualizarCotizacion")]
        public async Task<ActionResult<string>> actualizarCotizacion(CotizacionO obj)
        {
            var resultado = await Task.Run(() => new CotizacionDAO().modificaCotizacion(obj));
            return Ok(resultado);
        }

        [HttpGet("buscarCotizacion/{id}")]
        public async Task<ActionResult<CotizacionO>> buscarCotizacion(int id)
        {
            var lista = await Task.Run(() => new CotizacionDAO().buscarCotizacion(id));
            return Ok(lista);
        }

        [HttpPost("agregarRepuesto")]
        public async Task<ActionResult<string>> agregarRepuesto(DetalleRepuesto obj)
        {
            var resultado = await Task.Run(() => new CotizacionDAO().agregarRepuesto(obj));
            return Ok(resultado);
        }

        [HttpPost("agregarServicio")]
        public async Task<ActionResult<string>> agregarServicio(DetalleServicio obj)
        {
            var resultado = await Task.Run(() => new CotizacionDAO().agregarServicio(obj));
            return Ok(resultado);
        }

        [HttpGet("listarDetalleRepuesto/{id}")]
        public async Task<ActionResult<List<DetalleRepuestoLista>>> listarDetalleRepuesto(int id)
        {
            var lista = await Task.Run(() => new CotizacionDAO().listadoDetellaRepuesto(id));
            return Ok(lista);
        }

        [HttpGet("listarDetalleServicio/{id}")]
        public async Task<ActionResult<List<DetalleServicioLista>>> listarDetalleServicio(int id)
        {
            var lista = await Task.Run(() => new CotizacionDAO().listadoDetalleServicio(id));
            return Ok(lista);
        }


        [HttpPost("eliminarDetalleRepuesto/{id}")]
        public async Task<ActionResult<string>> eliminarDetalleRepuesto(int id)
        {
            var resultado = await Task.Run(() => new CotizacionDAO().eliminarDetalleRepuesto(id));
            return Ok(resultado);
        }
        [HttpPost("eliminarDetalleServicio/{id}")]
        public async Task<ActionResult<string>> eliminarDetalleServicio(int id)
        {
            var resultado = await Task.Run(() => new CotizacionDAO().eliminarDetallesServicio(id));
            return Ok(resultado);
        }







    }
}
