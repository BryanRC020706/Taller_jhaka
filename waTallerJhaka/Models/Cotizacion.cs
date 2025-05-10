using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class Cotizacion
    {
        [DisplayName("ID COTIZACION")]
        public int ide_cot { get; set; }
        [DisplayName("FECHA DE REGISTRO")]
        public DateTime fec_cot { get; set; }
        [DisplayName("VEHICULO")]
        public string nom_veh { get; set; }
        [DisplayName("CLIENTE")]
        public string nom_cli { get; set; }
    }
}
