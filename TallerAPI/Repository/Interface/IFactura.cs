using TallerAPI.Models;

namespace TallerAPI.Repository.Interface
{
    public interface IFactura
    {
        IEnumerable<Factura> listarFactura();
        string nuevaFactura(FacturaIngresar fac);
        Factura buscarFactura(int id);
    }
}
