using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class Factura
    {
        [DisplayName("ID DE FACTURA")]
        public int ide_fac { get; set; }
        [DisplayName("ID DE COTIZACIÓN")]
        public int ide_cot { get; set; }
        [DisplayName("FECHA")]
        public DateTime fec_fac { get; set; }
        [DisplayName("TOTAL")]
        public double tot_fac { get; set; }
    }
}
