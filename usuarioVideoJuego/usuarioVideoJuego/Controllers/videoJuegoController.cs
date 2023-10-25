using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using usuarioVideoJuego.Contexto;
using usuarioVideoJuego.Modelo;


namespace usuarioVideoJuego.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class videoJuegoController : ControllerBase
    {

        private readonly ILogger<videoJuegoController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public videoJuegoController(
            ILogger<videoJuegoController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearEstudiante")]
        [HttpPost]
        [Route("videoJuego")]
        public async Task<IActionResult> PostvideoJuego([FromBody] videoJuego videoJuego)
        {
            _aplicacionContexto.videoJuegos.Add(videoJuego);
            _aplicacionContexto.SaveChanges();
            return Ok(videoJuego);
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetvideoJuego()
        {
            List<videoJuego> listvideoJuego = _aplicacionContexto.videoJuegos.ToList();

            return StatusCode(StatusCodes.Status200OK, listvideoJuego);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> EditvideoJuego([FromBody] videoJuego videoJuego)
        {
            _aplicacionContexto.videoJuegos.Update(videoJuego);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> DeletevideoJuego(int? id)
        {
            videoJuego videoJuego = _aplicacionContexto.videoJuegos.Find(id);
            _aplicacionContexto.videoJuegos.Remove(videoJuego);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}