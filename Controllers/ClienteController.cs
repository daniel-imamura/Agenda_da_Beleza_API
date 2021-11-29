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
    public class ClienteController : Controller
    {
        private readonly AgendaDaBelezaContext _context;

        public ClienteController(AgendaDaBelezaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetAll()
        {
            return _context.Cliente.ToList();
        }
        [HttpGet("{email}/{senha}")]
        public ActionResult<Cliente> Get(string email, string senha)
        {
            try
            {  
                var result = _context.Cliente.ToList().Find(item => item.Email == email && item.Senha == senha);                                               
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
        public async Task<ActionResult> post(Cliente model)
        {

            try
            {
                _context.Cliente.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/cliente/{model.IdCliente}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }
        [HttpPut("{idCliente}")]
        public async Task<IActionResult> put(int idCliente, Cliente dadosCliente)
        {
            try
            {
                //verifica se existe aluno a ser alterado
                var result = await _context.Cliente.FindAsync(idCliente);
                if (idCliente != result.IdCliente)
                {
                    return BadRequest();
                }
                result.Nome = dadosCliente.Nome;
                result.Email = dadosCliente.Email;
                result.Telefone = dadosCliente.Telefone;
                result.Senha = dadosCliente.Senha;
                await _context.SaveChangesAsync();
                return Created($"/api/cliente/{dadosCliente.IdCliente}", dadosCliente);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
    }
}