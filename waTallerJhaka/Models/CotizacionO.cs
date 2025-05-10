using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class CotizacionO
    {
        [DisplayName("ID COTIZACION")]  
        public int ide_cot { get; set; }
        [DisplayName("FECHA DE REGISTRO")]
        public DateTime fec_cot { get; set; }
        [DisplayName("VEHICULO")]
        public int ide_veh { get; set; }
    }
}
