using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class Vehiculo
    {
        [DisplayName("ID VEHÍCULO")]
        public int ide_veh { get; set; }
        [DisplayName("MARCA")]
        public string mar_veh { get; set; }
        [DisplayName("MODELO")]
        public string mod_veh { get; set; }
        [DisplayName("PLACA")]
        public string pla_veh { get; set; }
        public int ide_cli { get; set; }
        [DisplayName("DUEÑO")]
        public string nom_cli { get; set; }
    }
}
