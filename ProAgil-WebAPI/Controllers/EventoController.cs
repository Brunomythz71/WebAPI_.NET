using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public readonly IProAgilRepository _repo;
        public EventoController(IProAgilRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repo.GetAllEvento(true));
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            }   
            
        }

    
        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get (int EventoId)
        {
            try
            {
                return Ok(await _repo.GetAllEventoById(EventoId, true));
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            }  
        }
        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get (string tema)
        {
            try
            {
                return Ok(await _repo.GetAllEventoByTema(tema, true));
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            }  
        }

          
        [HttpPost]
        public async Task<IActionResult> Post (Evento model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChanges())
                {
                    return Created($"/api/evento/{model.EventoID}", model);
                }
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            } 

            return BadRequest("");
        }
        
        [HttpPut ("{EventoId}")]
        public async Task<IActionResult> Put (int EventoId, Evento model)
        {
            try
            {
                var evento = await _repo.GetAllEventoById(EventoId, false);

                if (evento == null)
                    return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChanges())
                {
                    return Created($"/api/evento/{model.EventoID}", model);
                }
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            } 
            
            return BadRequest("");
        }
        
        [HttpDelete ("{EventoId}")]
        public async Task<IActionResult> Delete (int EventoId)
        {
            try
            {
                var evento = await _repo.GetAllEventoById(EventoId, false);
                if (evento == null)
                    return NotFound();
                    
                _repo.Delete(evento);

                if (await _repo.SaveChanges())
                {
                    return Ok();
                }
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            } 
            
            return BadRequest("");
        }
    }
}