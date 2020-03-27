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
    [Route("api/MtoCatLibros")]
    [ApiController]
    public class MtoCatLibrosController : ControllerBase
    {
        private readonly CocotecaPruebaContext _context;

        public MtoCatLibrosController(CocotecaPruebaContext context)
        {
            _context = context;
        }

        // GET: api/MtoCatLibros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MtoCatLibros>>> GetMtoCatLibros()
        {
            return await _context.MtoCatLibros.ToListAsync();
        }

        // GET: api/MtoCatLibros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MtoCatLibros>> GetMtoCatLibros(int id)
        {
            var mtoCatLibros = await _context.MtoCatLibros.FindAsync(id);

            if (mtoCatLibros == null)
            {
                return NotFound();
            }

            return mtoCatLibros;
        }

        // PUT: api/MtoCatLibros/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtoCatLibros(int id, MtoCatLibros mtoCatLibros)
        {
            if (id != mtoCatLibros.Idlibro)
            {
                return BadRequest();
            }

            _context.Entry(mtoCatLibros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtoCatLibrosExists(id))
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

        // POST: api/MtoCatLibros
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MtoCatLibros>> PostMtoCatLibros(MtoCatLibros mtoCatLibros)
        {
            _context.MtoCatLibros.Add(mtoCatLibros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtoCatLibros", new { id = mtoCatLibros.Idlibro }, mtoCatLibros);
        }

        // DELETE: api/MtoCatLibros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MtoCatLibros>> DeleteMtoCatLibros(int id)
        {
            var mtoCatLibros = await _context.MtoCatLibros.FindAsync(id);
            if (mtoCatLibros == null)
            {
                return NotFound();
            }

            _context.MtoCatLibros.Remove(mtoCatLibros);
            await _context.SaveChangesAsync();

            return mtoCatLibros;
        }

        private bool MtoCatLibrosExists(int id)
        {
            return _context.MtoCatLibros.Any(e => e.Idlibro == id);
        }
    }
}
