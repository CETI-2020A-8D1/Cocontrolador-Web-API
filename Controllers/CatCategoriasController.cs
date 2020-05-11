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
    [Route("api/CatCategorias")]
    [ApiController]
    public class CatCategoriasController : ControllerBase
    {
        private readonly CocotecaContext _context;

        public CatCategoriasController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/CatCategorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatCategorias>>> GetCatCategorias()
        {
            return await _context.CatCategorias.ToListAsync();
        }

        // GET: api/CatCategorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatCategorias>> GetCatCategorias(int id)
        {
            var catCategorias = await _context.CatCategorias.FindAsync(id);

            if (catCategorias == null)
            {
                return NotFound();
            }

            return catCategorias;
        }

        // PUT: api/CatCategorias/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatCategorias(int id, CatCategorias catCategorias)
        {
            if (id != catCategorias.Idcategoria)
            {
                return BadRequest();
            }

            _context.Entry(catCategorias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatCategoriasExists(id))
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

        // POST: api/CatCategorias
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatCategorias>> PostCatCategorias(CatCategorias catCategorias)
        {
            _context.CatCategorias.Add(catCategorias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatCategorias", new { id = catCategorias.Idcategoria }, catCategorias);
        }

        // DELETE: api/CatCategorias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatCategorias>> DeleteCatCategorias(int id)
        {
            var catCategorias = await _context.CatCategorias.FindAsync(id);
            if (catCategorias == null)
            {
                return NotFound();
            }

            _context.CatCategorias.Remove(catCategorias);
            await _context.SaveChangesAsync();

            return catCategorias;
        }

        private bool CatCategoriasExists(int id)
        {
            return _context.CatCategorias.Any(e => e.Idcategoria == id);
        }
    }
}
