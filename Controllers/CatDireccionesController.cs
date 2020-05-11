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
    [Route("api/CatDirecciones")]
    [ApiController]
    public class CatDireccionesController : ControllerBase
    {
        private readonly CocotecaContext _context;

        public CatDireccionesController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/CatDirecciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatDirecciones>>> GetCatDirecciones()
        {
            return await _context.CatDirecciones.ToListAsync();
        }

        // GET: api/CatDirecciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatDirecciones>> GetCatDirecciones(int id)
        {
            var catDirecciones = await _context.CatDirecciones.FindAsync(id);

            if (catDirecciones == null)
            {
                return NotFound();
            }

            return catDirecciones;
        }

        // PUT: api/CatDirecciones/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatDirecciones(int id, CatDirecciones catDirecciones)
        {
            if (id != catDirecciones.Iddireccion)
            {
                return BadRequest();
            }

            _context.Entry(catDirecciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatDireccionesExists(id))
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

        // POST: api/CatDirecciones
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CatDirecciones>> PostCatDirecciones(CatDirecciones catDirecciones)
        {
            _context.CatDirecciones.Add(catDirecciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatDirecciones", new { id = catDirecciones.Iddireccion }, catDirecciones);
        }

        // DELETE: api/CatDirecciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatDirecciones>> DeleteCatDirecciones(int id)
        {
            var catDirecciones = await _context.CatDirecciones.FindAsync(id);
            if (catDirecciones == null)
            {
                return NotFound();
            }

            _context.CatDirecciones.Remove(catDirecciones);
            await _context.SaveChangesAsync();

            return catDirecciones;
        }

        private bool CatDireccionesExists(int id)
        {
            return _context.CatDirecciones.Any(e => e.Iddireccion == id);
        }
    }
}
