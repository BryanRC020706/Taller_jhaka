using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace waTallerJhaka.Models
{
    public class VehiculoO
    {
        [DisplayName("ID VEHÍCULO")]
        public int ide_veh { get; set; }
        [DisplayName("MARCA")]
        [Required(ErrorMessage = "La marca es obligatorio")]
        public string mar_veh { get; set; }
        [DisplayName("MODELO")]
        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string mod_veh { get; set; }
        [DisplayName("PLACA")]
        [Required(ErrorMessage = "La placa es obligatorio")]
        [RegularExpression(@"^[A-Z]{3}-[0-9]{3}$", ErrorMessage = "La placa debe tener el formato correcto, AAA-111")]
        public string pla_veh { get; set; }
        [DisplayName("CLIENTE")]
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int ide_cli { get; set; }
    }
}
