using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using usuarioVideoJuego.Contexto;
using usuarioVideoJuego.Modelo;


namespace usuarioVideoJuego.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class usuarioController : ControllerBase
    {

        private readonly ILogger<usuarioController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public usuarioController(
            ILogger<usuarioController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearEstudiante")]
        [HttpPost]
        [Route("usuario")]
        public async Task<IActionResult> Postusuario([FromBody] usuario usuario)
        {
            _aplicacionContexto.usuario.Add(usuario);
            _aplicacionContexto.SaveChanges();
            return Ok(usuario);
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Getusuario()
        {
            List<usuario> listusuario = _aplicacionContexto.usuario.ToList();

            return StatusCode(StatusCodes.Status200OK, listusuario);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> Editusuario([FromBody] usuario usuario)
        {
            _aplicacionContexto.usuario.Update(usuario);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> Deleteusuario(int? id)
        {
            usuario usuario = _aplicacionContexto.usuario.Find(id);
            _aplicacionContexto.usuario.Remove(usuario);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}