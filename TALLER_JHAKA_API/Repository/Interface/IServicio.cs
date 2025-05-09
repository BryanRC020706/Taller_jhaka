using TALLER_JHAKA_API.Models;

namespace TALLER_JHAKA_API.Repository.Interface
{
    public interface IServicio
    {
        IEnumerable<Servicio> listadoServicios();
        string nuevoServicio(Servicio obj);
        string modificaServicio(Servicio obj);
        Servicio buscarServicio(int id);
    }
}
