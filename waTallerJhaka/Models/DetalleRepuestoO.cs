using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class DetalleRepuestoO
    {
        [DisplayName("N° DETALLE DE REPUESTO")]
        public int DET_REP { get; set; }
        [DisplayName("COTIZACION")]
        public int IDE_COT { get; set; }
        [DisplayName("REPUESTO")]
        public int IDE_REP { get; set; }
        [DisplayName("CANTIDAD")]
        public int CAN_DET { get; set; }
        [DisplayName("SUB TOTAL")]
        public double STO_DET { get; set; }
    }
}
