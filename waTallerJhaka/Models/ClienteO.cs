using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace waTallerJhaka.Models
{
    public class ClienteO
    {
        [DisplayName("ID CLIENTE")]
        public int ide_cli { get; set; }
        [DisplayName("NOMBRE CLIENTE")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nom_cli { get; set; }
        [DisplayName("APELLIDO CLIENTE")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string ape_cli { get; set; }
        [DisplayName("DNI")]
        [Required(ErrorMessage = "El dni es obligatorio")]
        [Range(10000000, 99999999, ErrorMessage = "El DNI debe tener exactamente 8 dígitos")]
        public int dni_cli { get; set; }
        [DisplayName("TELÉFONO")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Range(100000000, 999999999, ErrorMessage = "Debe tener exactamente 9 dígitos")]
        public int tel_cli { get; set; }
        [DisplayName("DIRECCIÓN")]
        [Required(ErrorMessage = "La dirección es obligatorio")]
        public string dir_cli { get; set; }
    }
}
