using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface IReporteInventario
    {
        IEnumerable<ReporteInventario> listadoReportesInventario();
        ReporteInventario buscarReporteInventario(int id);
        string nuevoReporteInventario(ReporteInventario obj);
        string modificaReporteInventario(ReporteInventario obj);
    }
}
