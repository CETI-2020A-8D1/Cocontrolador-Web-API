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
    [Produces("application/json")]
    [Route("api/CatMunicipios")]
    [ApiController]
    public class CatMunicipiosController : ControllerBase
    {
        private readonly CocotecaContext _context;

        public CatMunicipiosController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/CatMunicipios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatMunicipios>>> GetCatMunicipios()
        {
            return await _context.CatMunicipios.ToListAsync();
        }

        // GET: api/CatMunicipios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatMunicipios>> GetCatMunicipios(int id)
        {
            var catMunicipios = await _context.CatMunicipios.FindAsync(id);

            if (catMunicipios == null)
            {
                return NotFound();
            }

            return catMunicipios;
        }

        // PUT: api/CatMunicipios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatMunicipios(int id, CatMunicipios catMunicipios)
        {
            if (id != catMunicipios.Idmunicipio)
            {
                return BadRequest();
            }

            _context.Entry(catMunicipios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatMunicipiosExists(id))
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

        // POST: api/CatMunicipios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatMunicipios>> PostCatMunicipios(CatMunicipios catMunicipios)
        {
            _context.CatMunicipios.Add(catMunicipios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatMunicipios", new { id = catMunicipios.Idmunicipio }, catMunicipios);
        }

        // DELETE: api/CatMunicipios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatMunicipios>> DeleteCatMunicipios(int id)
        {
            var catMunicipios = await _context.CatMunicipios.FindAsync(id);
            if (catMunicipios == null)
            {
                return NotFound();
            }

            _context.CatMunicipios.Remove(catMunicipios);
            await _context.SaveChangesAsync();

            return catMunicipios;
        }

        private bool CatMunicipiosExists(int id)
        {
            return _context.CatMunicipios.Any(e => e.Idmunicipio == id);
        }
    }
}
