using TALLER_JHAKA_API.Models;

namespace TALLER_JHAKA_API.Repository.Interface
{
    public interface IRepuesto
    {
        IEnumerable<Repuesto> listadoRepuestos();
        Repuesto buscarRepuesto(int id);
        string nuevoRepuesto(Repuesto obj);
        string modificaRepuesto(Repuesto obj);
    }
}
