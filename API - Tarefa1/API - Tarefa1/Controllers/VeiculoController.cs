using API___Tarefa1.Models;
using API___Tarefa1.TTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API___Tarefa1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
            List<Veiculo> listaVeiculos = new List<Veiculo>();

            public VeiculoController()
            {

                var veiculo1 = new Veiculo()
                {
                    Id = 1,
                    Descricao = "Estudo do API 1 Parte",
                };

                var veiculo2 = new Veiculo()
                {
                    Id = 2,
                    Descricao = "Estudo do API 2 Parte",
                };

                var veiculo3 = new Veiculo()
                {
                    Id = 3,
                    Descricao = "Estudo do API 3 Parte",
                };
           
                var veiculo4 = new Veiculo()
                {
                    Id = 3,
                    Descricao = "Estudo do API 3 Parte",
                };
              
                listaVeiculos.Add(veiculo1);
                listaVeiculos.Add(veiculo2);
                listaVeiculos.Add(veiculo3);
                listaVeiculos.Add(veiculo4);

        }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(listaVeiculos);

            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var veiculo = listaVeiculos.Where(item => item.Id == id).FirstOrDefault();

                if (veiculo == null)
                {
                    return NotFound();
                }

                return Ok(veiculo);
            }

            [HttpPost]
            public IActionResult Post([FromBody] TarefaDTO item)
            {
                var contador = listaVeiculos.Count();

                var veiculos = new Veiculo();

                Veiculo.Marca = Veiculo.Descricao;
                Veiculo.Feito = item.Feito;

                listaVeiculos.Add(Veiculo);

                return StatusCode(StatusCodes.Status201Created, listaVeiculo);

            }
            [HttpPut]
            public IActionResult Put(int id, [FromBody] TarefaDTO item)
            {
                var veiculo = listaVeiculos.Where(item => item.Id == id).FirstOrDefault();

                if (veiculo == null)
                {
                    return NotFound();
                }
                veiculo.Descricao = item.Descricao;
                veiculo.Feito = item.Feito;


                return Ok(veiculo);
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var veiculo = listaVeiculos.Where(item => item.Id == id).FirstOrDefault();

                if (veiculo == null)
                {
                    return NotFound();

                }

                listaVeiculos.Remove(veiculo);
                return Ok(veiculo);
            }
        }
    }
}
