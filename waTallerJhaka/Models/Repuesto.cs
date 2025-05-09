using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace waTallerJhaka.Models
{
    public class Repuesto
    {
        [DisplayName("ID")]
        public int ide_rep { get; set; }
        [DisplayName("REPUESTO")]
        [Required(ErrorMessage = "El nombre del repuesto es obligatorio")]
        public string nom_rep { get; set; }
        [DisplayName("STOCK")]
        [Required(ErrorMessage = "El stock es obligatorio")]
        public int sto_rep { get; set; }
        [DisplayName("PRECIO")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public double pre_rep { get; set; }
    }
}
