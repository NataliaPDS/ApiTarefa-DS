using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API___Tarefa1.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {

        [HttpGet("/")]
        public IActionResult Get()
        {
            return Ok("API Tarefas: online");
        }

        [HttpGet("/hello-world")]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hello World Natalia");
        }

        [HttpGet("autor")]
        public IActionResult GetAutor()
        {
            return Ok("Desenvolvimento de Natalia");
        }

    }
}
