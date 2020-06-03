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
     */
    [Produces("application/json")]
    [Route("api/CatEstadosMunicipios")]
    [ApiController]
    public class CatEstadosMunicipiosController : ControllerBase
    {
        private readonly CocotecaContext _context;

        /**
        * 
        * 
        * 
        * 
        * 
        */
        public CatEstadosMunicipiosController(CocotecaContext context)
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
        // GET: api/CatEstadosMunicipios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatEstadosMunicipios>>> GetCatEstadosMunicipios()
        {
            return await _context.CatEstadosMunicipios.ToListAsync();
        }

        /**
        * 
        * 
        * 
        * 
        * 
        */
        // GET: api/CatEstadosMunicipios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatEstadosMunicipios>> GetCatEstadosMunicipios(int id)
        {
            var catEstadosMunicipios = await _context.CatEstadosMunicipios.FindAsync(id);

            if (catEstadosMunicipios == null)
            {
                return NotFound();
            }

            return catEstadosMunicipios;
        }

        /**
        * 
        * 
        * 
        * 
        * 
        */

        // PUT: api/CatEstadosMunicipios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatEstadosMunicipios(int id, CatEstadosMunicipios catEstadosMunicipios)
        {
            if (id != catEstadosMunicipios.IdestadoMunicipio)
            {
                return BadRequest();
            }

            _context.Entry(catEstadosMunicipios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatEstadosMunicipiosExists(id))
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

        // POST: api/CatEstadosMunicipios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatEstadosMunicipios>> PostCatEstadosMunicipios(CatEstadosMunicipios catEstadosMunicipios)
        {
            _context.CatEstadosMunicipios.Add(catEstadosMunicipios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatEstadosMunicipios", new { id = catEstadosMunicipios.IdestadoMunicipio }, catEstadosMunicipios);
        }

        /**
        * 
        * 
        * 
        * 
        * 
        */

        // DELETE: api/CatEstadosMunicipios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatEstadosMunicipios>> DeleteCatEstadosMunicipios(int id)
        {
            var catEstadosMunicipios = await _context.CatEstadosMunicipios.FindAsync(id);
            if (catEstadosMunicipios == null)
            {
                return NotFound();
            }

            _context.CatEstadosMunicipios.Remove(catEstadosMunicipios);
            await _context.SaveChangesAsync();

            return catEstadosMunicipios;
        }

        /**
        * 
        * 
        * 
        * 
        * 
        */

        private bool CatEstadosMunicipiosExists(int id)
        {
            return _context.CatEstadosMunicipios.Any(e => e.IdestadoMunicipio == id);
        }
    }
}
