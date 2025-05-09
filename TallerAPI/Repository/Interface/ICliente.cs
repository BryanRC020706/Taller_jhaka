using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface ICliente
    {
        IEnumerable<Cliente> listadoClientes();
        ClienteO buscarCliente(int id);
        string nuevoCliente(ClienteO obj);
        string modificaCliente(ClienteO obj);
    }
}
