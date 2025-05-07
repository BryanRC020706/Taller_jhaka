using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface IDiagnostico
    {
        IEnumerable<Solicitud> listadoSolicitudes();
        Solicitud buscarSolicitud(int id);
        string nuevaSolicitud(Solicitud obj);
        string modificaSolicitud(Solicitud obj);
    }
}
