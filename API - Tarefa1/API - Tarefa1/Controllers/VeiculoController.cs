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
                Marca = "1",
                Modelo = "a",
                AnoFab = 2020,
                AnoModelo = 2010,
                Placa = "AAA - 111",
            };

                var veiculo2 = new Veiculo()
                {
                    Marca = "2",
                    Modelo = "b",
                    AnoFab = 2018,
                    AnoModelo = 2011,
                    Placa = "AAA - 222",
                };

                var veiculo3 = new Veiculo()
                {
                    Marca = "3",
                    Modelo = "c",
                    AnoFab = 2024,
                    AnoModelo = 2012,
                    Placa = "AAA - 333",
                };
           
                var veiculo4 = new Veiculo()
                {
                    Marca = "4",
                    Modelo = "c",
                    AnoFab = 2015,
                    AnoModelo = 2005,
                    Placa = "AAA - 444",
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

            [HttpGet("{placa}")]
            public IActionResult GetById(string placa)
            {
                var veiculo = listaVeiculos.Where(item => item.Placa == placa).FirstOrDefault();

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

                var veiculo = new Veiculo();

                veiculo.Marca = veiculo.Marca;
                veiculo.Modelo = veiculo.Modelo;
                veiculo.AnoFab = veiculo.AnoFab;
                veiculo.AnoModelo = veiculo.AnoModelo;

            listaVeiculos.Add(veiculo);

                return StatusCode(StatusCodes.Status201Created, listaVeiculos);

            }
            [HttpPut]
            public IActionResult Put(string placa, [FromBody] TarefaDTO item)
            {
                var veiculo = listaVeiculos.Where(item => item.Placa == placa).FirstOrDefault();

                if (veiculo == null)
                {
                    return NotFound();
                }

            veiculo.Marca = veiculo.Marca;
            veiculo.Modelo = veiculo.Modelo;
            veiculo.AnoFab = veiculo.AnoFab;
            veiculo.AnoModelo = veiculo.AnoModelo;


            return Ok(veiculo);
            }
            [HttpDelete("{placa}")]
            public IActionResult Delete(string placa)
            {
                var veiculo = listaVeiculos.Where(item => item.Placa == placa).FirstOrDefault();

                if (veiculo == null)
                {
                    return NotFound();

                }

                listaVeiculos.Remove(veiculo);
                return Ok(veiculo);
            }
        
    }
}
