using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface IRepuesto
    {
        IEnumerable<Repuesto> listadoRepuestos();
        Repuesto buscarRepuesto(int id);
        string nuevoRepuesto(Repuesto obj);
        string modificaRepuesto(Repuesto obj);
    }
}
