using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Agenda_da_Beleza_API.Data;
using Agenda_da_Beleza_API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Agenda_da_Beleza_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : Controller
    {
        private readonly AgendaDaBelezaContext _context;

        public ServicosController(AgendaDaBelezaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Servicos>> GetAll()
        {
            return _context.Servicos.ToList();
        }

        [HttpGet("{idSalao}")]
        public ActionResult<Servicos> Get(int idSalao)
        {
            try
            {  
                var result = _context.Servicos.ToList().Find(item => item.IdSalao == idSalao);
                if (result == null)
                {
                    return NotFound(); 
                }
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> post(Servicos model)
        {
            try
            {
                _context.Servicos.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/servicos/{model.IdServicos}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }
        [HttpPut("{idSalao}/{valorNovo}/{indice}")]
        public async Task<IActionResult> put(int idSalao, decimal valorNovo, int indice)
        {
            try
            {
                var result = _context.Servicos.ToList().Find(item => item.IdSalao == idSalao);
                if (idSalao != result.IdSalao)
                {
                    return BadRequest();
                }
                switch(indice)
                {
                    case 0:
                        result.AlongamentoDeCilios = valorNovo;
                        break;
                    case 1:
                        result.Maquiagem = valorNovo;
                        break;
                    case 2:
                        result.Tintura = valorNovo;
                        break;
                    case 3:
                        result.CorteDeCabelo = valorNovo;
                        break;
                    case 4:
                        result.Penteado = valorNovo;
                        break;
                    case 5:
                        result.Progressiva = valorNovo;
                        break;
                    case 6:
                        result.Luzes = valorNovo;
                        break;
                    case 7:
                        result.LimpezaDePele = valorNovo;
                        break;
                    case 8:
                        result.DesignDeSobrancelha = valorNovo;
                        break;
                    case 9:
                        result.Hidratacao = valorNovo;
                        break;
                    case 10:
                        result.Unha = valorNovo;
                        break;
                    default:
                        break;
                }                    
                await _context.SaveChangesAsync();
                return Created($"/api/servicos/{result.IdServicos}", result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
    }
}