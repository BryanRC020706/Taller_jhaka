using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface IDetalleCotizacion
    {
        IEnumerable<DetalleCotizacion> listadoDetalles();
        DetalleCotizacion buscarDetalle(int id);
        string nuevoDetalle(DetalleCotizacion obj);
        string modificaDetalle(DetalleCotizacion obj);
    }
}
