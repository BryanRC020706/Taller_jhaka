using System.ComponentModel;

namespace waTallerJhaka.Models
{
    public class Cliente
    {
        [DisplayName("ID CLIENTE")]
        public int ide_cli { get; set; }
        [DisplayName("CLIENTE")]
        public string nom_cli { get; set; }
        [DisplayName("DNI")]
        public int dni_cli { get; set; }
        [DisplayName("TELEFONO")]
        public int tel_cli { get; set; }
        [DisplayName("DIRRECCION")]
        public string dir_cli { get; set; }
    }
}
