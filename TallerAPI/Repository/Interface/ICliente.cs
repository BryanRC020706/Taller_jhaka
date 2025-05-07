using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface ICliente
    {
        IEnumerable<Cliente> listadoClientes();
        Cliente buscarCliente(int id);
        string nuevoCliente(Cliente obj);
        string modificaCliente(Cliente obj);
    }
}
