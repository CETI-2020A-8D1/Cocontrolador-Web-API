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
    [Route("api/MtoCatUsuarios")]
    [ApiController]
    public class MtoCatUsuariosController : ControllerBase
    {
        private readonly CocotecaContext _context;

        public MtoCatUsuariosController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/MtoCatUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MtoCatUsuarios>>> GetMtoCatUsuarios()
        {
            return await _context.MtoCatUsuarios.ToListAsync();
        }

        // GET: api/MtoCatUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MtoCatUsuarios>> GetMtoCatUsuarios(int id)
        {
            var mtoCatUsuarios = await _context.MtoCatUsuarios.FindAsync(id);

            if (mtoCatUsuarios == null)
            {
                return NotFound();
            }

            return mtoCatUsuarios;
        }

        // PUT: api/MtoCatUsuarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtoCatUsuarios(int id, MtoCatUsuarios mtoCatUsuarios)
        {
            if (id != mtoCatUsuarios.Idusuario)
            {
                return BadRequest();
            }

            _context.Entry(mtoCatUsuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtoCatUsuariosExists(id))
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

        // POST: api/MtoCatUsuarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MtoCatUsuarios>> PostMtoCatUsuarios(MtoCatUsuarios mtoCatUsuarios)
        {
            _context.MtoCatUsuarios.Add(mtoCatUsuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtoCatUsuarios", new { id = mtoCatUsuarios.Idusuario }, mtoCatUsuarios);
        }

        // DELETE: api/MtoCatUsuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MtoCatUsuarios>> DeleteMtoCatUsuarios(int id)
        {
            var mtoCatUsuarios = await _context.MtoCatUsuarios.FindAsync(id);
            if (mtoCatUsuarios == null)
            {
                return NotFound();
            }

            _context.MtoCatUsuarios.Remove(mtoCatUsuarios);
            await _context.SaveChangesAsync();

            return mtoCatUsuarios;
        }

        private bool MtoCatUsuariosExists(int id)
        {
            return _context.MtoCatUsuarios.Any(e => e.Idusuario == id);
        }
    }
}
