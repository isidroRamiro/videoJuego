using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace usuarioVideoJuego.Modelo
{
    public class email
    {
        [Key]
        public int Id_Email { get; set; }
        public string Email { get; set; }
        

        [ForeignKey("usuario")]
        public int Id_Usuario { get; set; }

        public usuario usuario { get; set; }
    }
}
