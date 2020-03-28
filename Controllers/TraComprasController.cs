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
    [Route("api/TraCompras")]
    [ApiController]
    public class TraComprasController : ControllerBase
    {
        private readonly CocotecaPruebaContext _context;

        public TraComprasController(CocotecaPruebaContext context)
        {
            _context = context;
        }

        // GET: api/TraCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraCompras>>> GetTraCompras()
        {
            return await _context.TraCompras.ToListAsync();
        }

        // GET: api/TraCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraCompras>> GetTraCompras(int id)
        {
            var traCompras = await _context.TraCompras.FindAsync(id);

            if (traCompras == null)
            {
                return NotFound();
            }

            return traCompras;
        }

        // PUT: api/TraCompras/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraCompras(int id, TraCompras traCompras)
        {
            if (id != traCompras.Idcompra)
            {
                return BadRequest();
            }

            _context.Entry(traCompras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraComprasExists(id))
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

        // POST: api/TraCompras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TraCompras>> PostTraCompras(TraCompras traCompras)
        {
            _context.TraCompras.Add(traCompras);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TraComprasExists(traCompras.Idcompra))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTraCompras", new { id = traCompras.Idcompra }, traCompras);
        }

        // DELETE: api/TraCompras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TraCompras>> DeleteTraCompras(int id)
        {
            var traCompras = await _context.TraCompras.FindAsync(id);
            if (traCompras == null)
            {
                return NotFound();
            }

            _context.TraCompras.Remove(traCompras);
            await _context.SaveChangesAsync();

            return traCompras;
        }

        private bool TraComprasExists(int id)
        {
            return _context.TraCompras.Any(e => e.Idcompra == id);
        }
    }
}
