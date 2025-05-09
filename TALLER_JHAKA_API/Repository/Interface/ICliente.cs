using TALLER_JHAKA_API.Models;

namespace TALLER_JHAKA_API.Repository.Interface
{
    public interface ICliente
    {
        IEnumerable<Cliente> listadoClientes();
        ClienteO buscarCliente(int id);
        string nuevoCliente(ClienteO obj);
        string modificaCliente(ClienteO obj);
    }
}
