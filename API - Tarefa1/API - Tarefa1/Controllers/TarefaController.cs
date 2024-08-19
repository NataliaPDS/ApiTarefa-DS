using API___Tarefa1.Models;
using API___Tarefa1.TTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API___Tarefa1.Controllers
{
    [Route("Tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        List<Tarefa> listaTarefas = new List<Tarefa>();

        public TarefasController() 
        {
   
            var tarefa1 = new Tarefa()
            {
                Id = 1,
                Descricao = "Estudo do API 1 Parte",
            };

            var tarefa2 = new Tarefa()
            {
                Id = 2,
                Descricao = "Estudo do API 2 Parte",
            };

            var tarefa3 = new Tarefa()
            {
                Id = 3,
                Descricao = "Estudo do API 3 Parte",
            };
            listaTarefas.Add(tarefa1);
            listaTarefas.Add(tarefa2);
            listaTarefas.Add(tarefa3);

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaTarefas);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarefa = listaTarefas.Where (item => item.Id == id).FirstOrDefault();

            if(tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TarefaDTO item)
        {
            var contador = listaTarefas.Count();

            var tarefa = new Tarefa();
            
            tarefa.Id = contador + 1;
            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;

            listaTarefas.Add (tarefa);

            return StatusCode(StatusCodes.Status201Created, listaTarefas);

        }
        [HttpPut]
        public IActionResult Put(int id, [FromBody] TarefaDTO item) 
        {
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();

            if (tarefa == null)
            {
                return NotFound();
            }
            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;


            return Ok(tarefa);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();

            if (tarefa == null)
            {
                return NotFound();

            }

            listaTarefas.Remove(tarefa);
            return Ok(tarefa);
        }
    }
    
}
