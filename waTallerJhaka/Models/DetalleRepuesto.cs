using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class DetalleRepuesto
    {
        [DisplayName("COTIZACION")]
        public int IDE_COT { get; set; }
        [DisplayName("REPUESTO")]
        public int IDE_REP { get; set; }
        [DisplayName("CANTIDAD")]
        public int CAN_DET { get; set; }
    }
}
