using Microsoft.AspNetCore.Mvc;
using TallerAPI.Models;
using TallerAPI.Repository.DAO;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        [HttpGet("listarVehiculo")]
        public async Task<ActionResult<List<Vehiculo>>> listarVehiculos()
        {
            var lista = await Task.Run(() => new VehiculoDAO().listadoVehiculos());
            return Ok(lista);
        }

        [HttpGet("listadoClientes")]
        public async Task<ActionResult<List<Cliente>>> listadoClientes()
        {
            var lista = await Task.Run(() =>
            new VehiculoDAO().listadoClientes());
            return Ok(lista);
        }

        [HttpPost("nuevoVehiculo")]
        public async Task<ActionResult<string>> nuevoVehiculo(VehiculoO objVO)
        {
            var resultado = await Task.Run(() => new VehiculoDAO().nuevoVehiculo(objVO));
            return Ok(resultado);
        }

        [HttpPut("actualizarVehiculo")]
        public async Task<ActionResult<string>> actualizarVehiculo(VehiculoO objVO)
        {
            var resultado = await Task.Run(() => new VehiculoDAO().modificaVehiculo(objVO));
            return Ok(resultado);
        }

        [HttpGet("buscarVehiculo/{id}")]
        public async Task<ActionResult<List<Vehiculo>>> buscarVehiculo(int id)
        {
            var lista = await Task.Run(() => new VehiculoDAO().buscarVehiculo(id));
            return Ok(lista);
        }
    }
}
