using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class DetalleServicioO
    {
        [DisplayName("N° DETALLE DE SERVICIO")]
        public int DET_SER { get; set; }
        [DisplayName("COTIZACION")]
        public int IDE_COT { get; set; }
        [DisplayName("SERVICIO")]
        public int IDE_SER { get; set; }
        [DisplayName("PRECIO")]
        public double PRE_SER { get; set; }
    }
}
