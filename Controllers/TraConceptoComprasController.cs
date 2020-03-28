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
    [Route("api/TraConceptoCompras")]
    [ApiController]
    public class TraConceptoComprasController : ControllerBase
    {
        private readonly CocotecaPruebaContext _context;

        public TraConceptoComprasController(CocotecaPruebaContext context)
        {
            _context = context;
        }

        // GET: api/TraConceptoCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraConceptoCompra>>> GetTraConceptoCompra()
        {
            return await _context.TraConceptoCompra.ToListAsync();
        }

        // GET: api/TraConceptoCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraConceptoCompra>> GetTraConceptoCompra(int id)
        {
            var traConceptoCompra = await _context.TraConceptoCompra.FindAsync(id);

            if (traConceptoCompra == null)
            {
                return NotFound();
            }

            return traConceptoCompra;
        }

        // PUT: api/TraConceptoCompras/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraConceptoCompra(int id, TraConceptoCompra traConceptoCompra)
        {
            if (id != traConceptoCompra.TraCompras)
            {
                return BadRequest();
            }

            _context.Entry(traConceptoCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraConceptoCompraExists(id))
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

        // POST: api/TraConceptoCompras
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TraConceptoCompra>> PostTraConceptoCompra(TraConceptoCompra traConceptoCompra)
        {
            _context.TraConceptoCompra.Add(traConceptoCompra);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TraConceptoCompraExists(traConceptoCompra.TraCompras))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTraConceptoCompra", new { id = traConceptoCompra.TraCompras }, traConceptoCompra);
        }

        // DELETE: api/TraConceptoCompras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TraConceptoCompra>> DeleteTraConceptoCompra(int id)
        {
            var traConceptoCompra = await _context.TraConceptoCompra.FindAsync(id);
            if (traConceptoCompra == null)
            {
                return NotFound();
            }

            _context.TraConceptoCompra.Remove(traConceptoCompra);
            await _context.SaveChangesAsync();

            return traConceptoCompra;
        }

        private bool TraConceptoCompraExists(int id)
        {
            return _context.TraConceptoCompra.Any(e => e.TraCompras == id);
        }
    }
}
