using Microsoft.AspNetCore.Mvc;
using TALLER_JHAKA_API.Models;
using TALLER_JHAKA_API.Repository.DAO;

namespace TALLER_JHAKA_API.Controllers
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
        public async Task<ActionResult<VehiculoO>> buscarVehiculo(int id)
        {
            var lista = await Task.Run(() => new VehiculoDAO().buscarVehiculo(id));
            return Ok(lista);
        }
    }
}
