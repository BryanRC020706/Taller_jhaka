using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface iVehiculo
    {
        IEnumerable<Vehiculo> listadoVehiculos();
        IEnumerable<Cliente> listadoClientes();
        Vehiculo buscarVehiculo(int id);
        string nuevoVehiculo(VehiculoO obj);
        string modificaVehiculo(VehiculoO obj);
    }
}
