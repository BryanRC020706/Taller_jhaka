using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface ICotizacion
    {
        IEnumerable<Cotizacion> listadoCotizaciones();
        CotizacionO buscarCotizacion(int id);
        string nuevaCotizacion(CotizacionO obj);
        string modificaCotizacion(CotizacionO obj);
        public string agregarServicio(DetalleServicio obj);
        public string agregarRepuesto(DetalleRepuesto obj);

    }
}
