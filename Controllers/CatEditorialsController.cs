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
    [Route("api/Editorial")]
    [ApiController]
    public class CatEditorialsController : ControllerBase
    {
        private readonly CocotecaContext _context;

        public CatEditorialsController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/CatEditorials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatEditorial>>> GetCatEditorial()
        {
            return await _context.CatEditorial.ToListAsync();
        }

        // GET: api/CatEditorials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatEditorial>> GetCatEditorial(int id)
        {
            var catEditorial = await _context.CatEditorial.FindAsync(id);

            if (catEditorial == null)
            {
                return NotFound();
            }

            return catEditorial;
        }

        // PUT: api/CatEditorials/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatEditorial(int id, CatEditorial catEditorial)
        {
            if (id != catEditorial.Ideditorial)
            {
                return BadRequest();
            }

            _context.Entry(catEditorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatEditorialExists(id))
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

        // POST: api/CatEditorials
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatEditorial>> PostCatEditorial(CatEditorial catEditorial)
        {
            _context.CatEditorial.Add(catEditorial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatEditorial", new { id = catEditorial.Ideditorial }, catEditorial);
        }

        // DELETE: api/CatEditorials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatEditorial>> DeleteCatEditorial(int id)
        {
            var catEditorial = await _context.CatEditorial.FindAsync(id);
            if (catEditorial == null)
            {
                return NotFound();
            }

            _context.CatEditorial.Remove(catEditorial);
            await _context.SaveChangesAsync();

            return catEditorial;
        }

        private bool CatEditorialExists(int id)
        {
            return _context.CatEditorial.Any(e => e.Ideditorial == id);
        }
    }
}
