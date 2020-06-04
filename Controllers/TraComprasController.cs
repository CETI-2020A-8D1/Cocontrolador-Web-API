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
    /// <summary>
    /// Este controlador tiene que ver con todo lo relacionado con las compras realizadas
    /// </summary>
    [Produces("application/json")]
    [Route("api/TraCompras")]
    [ApiController]
    public class TraComprasController : ControllerBase
    {
        private readonly CocotecaContext _context;
        /// <summary>
        /// Aqui se crea el constructor para el objeto del contexto
        /// </summary>
        /// <param name="context"></param>
        public TraComprasController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/TraCompras
        /// <summary>
        /// Aqui se obtienen todas las compras realizadas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraCompras>>> GetTraCompras()
        {
            return await _context.TraCompras.ToListAsync();
        }

        // GET: api/TraCompras/5
        /// <summary>
        /// Obtener compras por medio de un id
        /// Aqui se obtienen los datos de una compra a partir de su id, en caso que no haya ninguna se
        /// retornará que no se encontro. En caso contrario, se retornará la compra
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Actualizar compras
        /// Aqui se corrobora que el id enviado seaa igual que el id de la compra, en caso que sea diferente
        /// se enviará un error. Despues se procederá a realizar la actualizacion.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="traCompras"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Crear Compra
        /// Aqui se obtienen los datos de una compra para despues hacer una cosulta y llamar a la bd para agregar
        /// la nueva compra
        /// </summary>
        /// <param name="traCompras"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TraCompras>> PostTraCompras(TraCompras traCompras)
        {
            _context.TraCompras.Add(traCompras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraCompras", new { id = traCompras.Idcompra }, traCompras);
        }

        // DELETE: api/TraCompras/5
        /// <summary>
        /// Borrar compra
        /// Aqui se realiza una consulta a la bd para corroborar que el objeto que se quiere borrar exita
        /// en caso que exista, se borrará. En caso contrario se retornará un not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
