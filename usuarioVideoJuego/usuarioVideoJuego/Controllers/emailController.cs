using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using usuarioVideoJuego.Contexto;
using usuarioVideoJuego.Modelo;

namespace usuarioVideoJuego.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class emailController : ControllerBase
    {

        private readonly ILogger<emailController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public emailController(
            ILogger<emailController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //[HttpPost(Name = "CrearEstudiante")]
        [HttpPost]
        [Route("email")]
        public async Task<IActionResult> Postemail([FromBody] email email)
        {
            _aplicacionContexto.email.Add(email);
            _aplicacionContexto.SaveChanges();
            return Ok(email);
        }


        // [HttpGet(Name = "GetEstudiante")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Getemail()
        {
            List<email> listemail = _aplicacionContexto.email.ToList();

            return StatusCode(StatusCodes.Status200OK, listemail);
        }

        //[HttpPut(Name = "PutEstudiante")]
        [HttpPut]
        [Route("EditarEstudiante/")]
        public async Task<IActionResult> Editemail([FromBody] email email)
        {
            _aplicacionContexto.email.Update(email);
            _aplicacionContexto.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarEstudiante/")]
        //[HttpDelete(Name = "DeleteEstudiante")]
        public async Task<IActionResult> Deleteemail(int? id)
        {
            email email = _aplicacionContexto.email.Find(id);
            _aplicacionContexto.email.Remove(email);
            _aplicacionContexto.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}