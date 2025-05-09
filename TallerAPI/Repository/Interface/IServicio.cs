using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface IServicio
    {
        IEnumerable<Servicio> listadoServicios();
        string nuevoServicio(Servicio obj);
        string modificaServicio(Servicio obj);
        Servicio buscarServicio(int id);
    }
}
