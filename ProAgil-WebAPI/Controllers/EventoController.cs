using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public readonly DataContext _context;
        public EventoController(DataContext context)
        {
            this._context = context;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // private readonly ILogger<EventoController> _logger;

        // public EventoController(ILogger<EventoController> logger)
        // {
        //     _logger = logger;
        // }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _context.Eventos.ToListAsync());
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            }   
            
        }

    
        [HttpGet("{id}")]
        public async Task<IActionResult> Get (int id)
        {
            try
            {
                return Ok(await _context.Eventos.FirstOrDefaultAsync(a => a.EventoID == id));
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            }  
        }
    }
}