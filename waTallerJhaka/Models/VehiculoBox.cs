using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class VehiculoBox
    {
        [DisplayName("ID VEHÍCULO")]
        public int IDE_VEH { get; set; }
        [DisplayName("VEHÍCULO")]
        public string VEH { get; set; }
    }
}
