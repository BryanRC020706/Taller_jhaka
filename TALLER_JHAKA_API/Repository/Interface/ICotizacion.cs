using TALLER_JHAKA_API.Models;

namespace TALLER_JHAKA_API.Repository.Interface
{
    public interface ICotizacion
    {
        IEnumerable<Cotizacion> listadoCotizaciones();
        Cotizacion buscarCotizacion(int id);
        string nuevaCotizacion(Cotizacion obj);
        string modificaCotizacion(Cotizacion obj);
    }
}
