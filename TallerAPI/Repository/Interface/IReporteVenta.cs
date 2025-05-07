using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface IReporteVenta
    {
        IEnumerable<ReporteVenta> listadoReportesVenta();
        ReporteVenta buscarReporteVenta(int id);
        string nuevoReporteVenta(ReporteVenta obj);
        string modificaReporteVenta(ReporteVenta obj);

    }
}
