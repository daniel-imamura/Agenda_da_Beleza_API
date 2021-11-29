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
    public class SalaoController : Controller
    {
        private readonly AgendaDaBelezaContext _context;

        public SalaoController(AgendaDaBelezaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Salao>> GetAll()
        {
            return _context.Salao.ToList();
        }

        [HttpGet("{nome}")]
        public ActionResult<Salao> Get(string nome)
        {
            try
            {  
                var result = _context.Salao.ToList().Find(item => item.Nome == nome);
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

        [HttpGet("{email}/{senha}")]
        public ActionResult<Salao> Get(string email, string senha)
        {
            try
            {  
                var result = _context.Salao.ToList().Find(item => item.Email == email && item.Senha == senha);                                               
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
        public async Task<ActionResult> post(Salao model)
        {
            try
            {
                _context.Salao.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/salao/{model.IdSalao}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }
        [HttpPut("{idSalao}")]
        public async Task<IActionResult> put(int idSalao, Salao dadosSalao)
        {
            try
            {
                //verifica se existe aluno a ser alterado
                var result = await _context.Salao.FindAsync(idSalao);
                if (idSalao != result.IdSalao)
                {
                    return BadRequest();
                }
                result.Nome = dadosSalao.Nome;
                result.Email = dadosSalao.Email;
                result.Endereco = dadosSalao.Endereco;
                result.Telefone = dadosSalao.Telefone;
                result.Senha = dadosSalao.Senha;
                await _context.SaveChangesAsync();
                return Created($"/api/cliente/{dadosSalao.IdSalao}", dadosSalao);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
    }
}