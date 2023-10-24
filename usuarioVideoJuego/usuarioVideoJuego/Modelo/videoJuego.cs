using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace usuarioVideoJuego.Modelo
{
    public class videoJuego
    {
        [Key]
        public int Id_VideoJuego { get; set; }
        public string Nombre { get; set; }
        public string tipoDePgo { get; set; }
        public string esGrupal { get; set; }
        public bool tipo { get; set; }
        

        [ForeignKey("usuario")]
        public int Id_Usuario { get; set; }

        public  usuario usuario { get; set; }
    }
}
