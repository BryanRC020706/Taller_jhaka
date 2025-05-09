using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace waTallerJhaka.Models
{
    public class Servicio
    {
        [DisplayName("ID")]
        public int ide_ser { get; set; }
        [DisplayName("SERVICIO")]
        [Required(ErrorMessage = "El  del servicio es obligatorio")]
        public string nom_ser { get; set; }
        [DisplayName("PRECIO")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public double pre_ser { get; set; }

    }
}
