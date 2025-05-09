using Microsoft.AspNetCore.Mvc;
using TallerAPI.Models;
using TallerAPI.Repository.DAO;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
            [HttpGet("listarClientes")]
            public async Task<ActionResult<List<Cliente>>> listarClientes()
            {
                var lista = await Task.Run(() => new ClienteDAO().listadoClientes());
                return Ok(lista);
            }

            [HttpPost("nuevoCliente")]
            public async Task<ActionResult<string>> nuevoCliente(ClienteO obj)
            {
                var resultado = await Task.Run(() => new ClienteDAO().nuevoCliente(obj));
                return Ok(resultado);
            }

            [HttpPut("actualizarCliente")]
            public async Task<ActionResult<string>> actualizarCliente(ClienteO obj)
            {
                var resultado = await Task.Run(() => new ClienteDAO().modificaCliente(obj));
                return Ok(resultado);
            }

            [HttpGet("buscarCliente/{id}")]
            public async Task<ActionResult<ClienteO>> buscarCliente(int id)
            {
                var lista = await Task.Run(() => new ClienteDAO().buscarCliente(id));
                return Ok(lista);
            }


    }

    
}
