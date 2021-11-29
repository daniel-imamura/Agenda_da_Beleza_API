using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Agenda_da_Beleza_API.Data;
using Agenda_da_Beleza_API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace Agenda_da_Beleza_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : Controller
    {
        private readonly AgendaDaBelezaContext _context;

        public AgendamentoController(AgendaDaBelezaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Agendamento>> GetAll()
        {
            return _context.Agendamento.ToList();
        }
        [HttpPost]
        public async Task<ActionResult> post(Agendamento model)
        {
            try
            {                         
                _context.Agendamento.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/agendamento/{model.IdAgendamento}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }/*
        [HttpPost("{dataAgendada}")]
        public async Task<ActionResult> post(string dataAgendada, Agendamento model)
        {
            try
            {                
                DateTime novo = Convert.ToDateTime(dataAgendada);
                model.dataAgendada = novo;
                _context.Agendamento.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/agendamento/{model.IdAgendamento}", model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }*/
    }
}