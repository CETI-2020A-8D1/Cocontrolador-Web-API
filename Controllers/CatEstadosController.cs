using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CocontroladorAPI.Models;

namespace CocontroladorAPI.Controllers
{
    /**
     * 
     * 
     * 
     * 
     * 
     */
    [Produces("application/json")]
    [Route("api/CatEstados")]
    [ApiController]
    public class CatEstadosController : ControllerBase
    {
        private readonly CocotecaContext _context;


        /**
        * 
        * 
        * 
        * 
        * 
        */
        public CatEstadosController(CocotecaContext context)
        {
            _context = context;
        }


        /**
        * 
        * 
        * 
        * 
        * 
        */
        // GET: api/CatEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatEstados>>> GetCatEstados()
        {
            return await _context.CatEstados.ToListAsync();
        }

        /**
        * 
        * 
        * 
        * 
        * 
        */

        // GET: api/CatEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatEstados>> GetCatEstados(int id)
        {
            var catEstados = await _context.CatEstados.FindAsync(id);

            if (catEstados == null)
            {
                return NotFound();
            }

            return catEstados;
        }


        /**
        * 
        * 
        * 
        * 
        * 
        */
        // PUT: api/CatEstados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatEstados(int id, CatEstados catEstados)
        {
            if (id != catEstados.Idestado)
            {
                return BadRequest();
            }

            _context.Entry(catEstados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatEstadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /**
        * 
        * 
        * 
        * 
        * 
        */
        // POST: api/CatEstados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatEstados>> PostCatEstados(CatEstados catEstados)
        {
            _context.CatEstados.Add(catEstados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatEstados", new { id = catEstados.Idestado }, catEstados);
        }

        /**
        * 
        * 
        * 
        * 
        * 
        */

        // DELETE: api/CatEstados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatEstados>> DeleteCatEstados(int id)
        {
            var catEstados = await _context.CatEstados.FindAsync(id);
            if (catEstados == null)
            {
                return NotFound();
            }

            _context.CatEstados.Remove(catEstados);
            await _context.SaveChangesAsync();

            return catEstados;
        }

        /**
        * 
        * 
        * 
        * 
        * 
        */
        private bool CatEstadosExists(int id)
        {
            return _context.CatEstados.Any(e => e.Idestado == id);
        }
    }
}
