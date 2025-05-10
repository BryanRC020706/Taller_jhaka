using Microsoft.AspNetCore.Mvc;
using TallerAPI.Models;
using TallerAPI.Repository.DAO;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        [HttpGet("listarVehiculos")]
        public async Task<ActionResult<List<Vehiculo>>> listarVehiculos()
        {
            var lista = await Task.Run(() => new VehiculoDAO().listadoVehiculos());
            return Ok(lista);
        }

        [HttpGet("listarVehiculosBox")]
        public async Task<ActionResult<List<VehiculoBox>>> listarVehiculosBox()
        {
            var lista = await Task.Run(() => new VehiculoDAO().listadoVehiculosBox());
            return Ok(lista);
        }

        [HttpPost("nuevoVehiculo")]
        public async Task<ActionResult<string>> nuevoVehiculo(VehiculoO obj)
        {
            var resultado = await Task.Run(() => new VehiculoDAO().nuevoVehiculo(obj));
            return Ok(resultado);
        }

        [HttpPut("actualizarVehiculo")]
        public async Task<ActionResult<string>> actualizarVehiculo(VehiculoO obj)
        {
            var resultado = await Task.Run(() => new VehiculoDAO().modificaVehiculo(obj));
            return Ok(resultado);
        }

        [HttpGet("buscarVehiculo/{id}")]
        public async Task<ActionResult<VehiculoO>> buscarVehiculo(int id)
        {
            var lista = await Task.Run(() => new VehiculoDAO().buscarVehiculo(id));
            return Ok(lista);
        }
    }
}
