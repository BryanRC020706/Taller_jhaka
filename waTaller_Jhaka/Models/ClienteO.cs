using System.ComponentModel;

namespace waTaller_Jhaka.Models
{
    public class ClienteO
    {
        [DisplayName("ID CLIENTE")]
        public int ide_cli { get; set; }
        [DisplayName("NOMBRE CLIENTE")]
        public string nom_cli { get; set; }
        [DisplayName("APELLIDO CLIENTE")]
        public string ape_cli { get; set; }
        [DisplayName("DNI")]
        public int dni_cli { get; set; }
        [DisplayName("TELEFONO")]
        public int tel_cli { get; set; }
        [DisplayName("DIRRECCION")]
        public string dir_cli { get; set; }
    }
}
