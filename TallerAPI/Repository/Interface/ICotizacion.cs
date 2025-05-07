using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface ICotizacion
    {
        IEnumerable<Cotizacion> listadoCotizaciones();
        Cotizacion buscarCotizacion(int id);
        string nuevaCotizacion(Cotizacion obj);
        string modificaCotizacion(Cotizacion obj);
    }
}
