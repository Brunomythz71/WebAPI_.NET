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


namespace ProAgil_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalestranteController : ControllerBase
    {
         public readonly IProAgilRepository _repo;
        public PalestranteController(IProAgilRepository repo)
        {
            this._repo = repo;
        }
  
        [HttpGet("{PalestranteId}")]
        public async Task<IActionResult> Get (int PalestranteId)
        {
            try
            {
                return Ok(await _repo.GetPalestrantesId(PalestranteId, true));
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            }  
        }
        [HttpGet("getByNome/{nome}")]
        public async Task<IActionResult> Get (string nome)
        {
            try
            {
                return Ok(await _repo.GetAllPalestrantesByName(nome, true));
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            }  
        }

          
        [HttpPost]
        public async Task<IActionResult> Post (Palestrante model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChanges())
                {
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            } 

            return BadRequest("");
        }
        
        [HttpPut ("{Id}")]
        public async Task<IActionResult> Put (int PalestranteId, Palestrante model)
        {
            try
            {
                var palestrante = await _repo.GetPalestrantesId(PalestranteId, false);

                if (palestrante == null)
                    return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChanges())
                {
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            } 
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar banco.");
            } 
            
            return BadRequest("");
        }
        
        [HttpDelete ("{PalestranteId}")]
        public async Task<IActionResult> Delete (int PalestranteId)
        {
            try
            {
                var palestrante = await _repo.GetPalestrantesId(PalestranteId, false);
                if (palestrante == null)
                    return NotFound();
                    
                _repo.Delete(palestrante);

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