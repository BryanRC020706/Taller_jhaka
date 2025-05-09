using TALLER_JHAKA_API.Models;

namespace TALLER_JHAKA_API.Repository.Interface
{
    public interface iVehiculo
    {
        IEnumerable<Vehiculo> listadoVehiculos();
        VehiculoO buscarVehiculo(int id);
        string nuevoVehiculo(VehiculoO obj);
        string modificaVehiculo(VehiculoO obj);
    }
}
