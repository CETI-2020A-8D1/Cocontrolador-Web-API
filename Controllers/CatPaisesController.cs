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
    [Route("api/CatPaises")]
    [ApiController]
    public class CatPaisesController : ControllerBase
    {
        private readonly CocotecaPruebaContext _context;

        public CatPaisesController(CocotecaPruebaContext context)
        {
            _context = context;
        }

        // GET: api/CatPaises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatPaises>>> GetCatPaises()
        {
            return await _context.CatPaises.ToListAsync();
        }

        // GET: api/CatPaises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatPaises>> GetCatPaises(int id)
        {
            var catPaises = await _context.CatPaises.FindAsync(id);

            if (catPaises == null)
            {
                return NotFound();
            }

            return catPaises;
        }

        // PUT: api/CatPaises/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatPaises(int id, CatPaises catPaises)
        {
            if (id != catPaises.Idpais)
            {
                return BadRequest();
            }

            _context.Entry(catPaises).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatPaisesExists(id))
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

        // POST: api/CatPaises
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatPaises>> PostCatPaises(CatPaises catPaises)
        {
            _context.CatPaises.Add(catPaises);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatPaises", new { id = catPaises.Idpais }, catPaises);
        }

        // DELETE: api/CatPaises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatPaises>> DeleteCatPaises(int id)
        {
            var catPaises = await _context.CatPaises.FindAsync(id);
            if (catPaises == null)
            {
                return NotFound();
            }

            _context.CatPaises.Remove(catPaises);
            await _context.SaveChangesAsync();

            return catPaises;
        }

        private bool CatPaisesExists(int id)
        {
            return _context.CatPaises.Any(e => e.Idpais == id);
        }
    }
}
