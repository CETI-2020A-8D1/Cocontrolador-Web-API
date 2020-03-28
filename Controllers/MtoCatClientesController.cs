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
    [Route("api/MtoCatClientes")]
    [ApiController]
    public class MtoCatClientesController : ControllerBase
    {
        private readonly CocotecaPruebaContext _context;

        public MtoCatClientesController(CocotecaPruebaContext context)
        {
            _context = context;
        }

        // GET: api/MtoCatClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MtoCatCliente>>> GetMtoCatCliente()
        {
            return await _context.MtoCatCliente.ToListAsync();
        }

        // GET: api/MtoCatClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MtoCatCliente>> GetMtoCatCliente(int id)
        {
            var mtoCatCliente = await _context.MtoCatCliente.FindAsync(id);

            if (mtoCatCliente == null)
            {
                return NotFound();
            }

            return mtoCatCliente;
        }

        // PUT: api/MtoCatClientes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtoCatCliente(int id, MtoCatCliente mtoCatCliente)
        {
            if (id != mtoCatCliente.Idcliente)
            {
                return BadRequest();
            }

            _context.Entry(mtoCatCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtoCatClienteExists(id))
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

        // POST: api/MtoCatClientes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MtoCatCliente>> PostMtoCatCliente(MtoCatCliente mtoCatCliente)
        {
            _context.MtoCatCliente.Add(mtoCatCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtoCatCliente", new { id = mtoCatCliente.Idcliente }, mtoCatCliente);
        }

        // DELETE: api/MtoCatClientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MtoCatCliente>> DeleteMtoCatCliente(int id)
        {
            var mtoCatCliente = await _context.MtoCatCliente.FindAsync(id);
            if (mtoCatCliente == null)
            {
                return NotFound();
            }

            _context.MtoCatCliente.Remove(mtoCatCliente);
            await _context.SaveChangesAsync();

            return mtoCatCliente;
        }

        private bool MtoCatClienteExists(int id)
        {
            return _context.MtoCatCliente.Any(e => e.Idcliente == id);
        }
    }
}
