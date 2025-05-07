using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface ISolicitud
    {
        IEnumerable<Solicitud> listadoSolicitud();
        Solicitud buscarSolicitud(int id);
        string nuevaSolicitud(Solicitud obj);
        string modificaSolicitud(Solicitud obj);
    }
}
