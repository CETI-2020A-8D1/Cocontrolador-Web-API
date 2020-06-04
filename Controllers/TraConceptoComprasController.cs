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
    /// Aqui se realizan todos las operaciones que tienen que ver con el concepto de la compra
    /// </summary>
    [Produces("application/json")]
    [Route("api/TraConceptoCompra")]
    [ApiController]
    public class TraConceptoComprasController : ControllerBase
    {
        private readonly CocotecaContext _context;
        /// <summary>
        /// Aqui se hace el constructor para el contexto
        /// </summary>
        /// <param name="context">Contexto de la bd</param>
        public TraConceptoComprasController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/TraConceptoCompras
        /// <summary>
        /// Aqui se obtienen todos los conceptos de compras
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraConceptoCompra>>> GetTraConceptoCompra()
        {
            return await _context.TraConceptoCompra.ToListAsync();
        }

        // GET: api/TraConceptoCompras/5
        /// <summary>
        /// Aqui se obtiene el concepto de una compra por id, se verifica que obtenga algo de la base de
        /// datos, si es null se retorna un not found. En caso contrario se retorna la compra con sus datos
        /// </summary>
        /// <param name="id">Id de la compra</param>
        /// <returns></returns>
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
        /// <summary>
        /// Actualizar Compra
        /// Aqui se verifica que el id enviado coincida con el del objeto, en caso de que no son iguales se 
        /// envia un error. En caso contrario, se realiza la modificacion en la base de datos con una llamada en
        /// la que se envian los nuevos datos
        /// </summary>
        /// <param name="id">Id de la compra</param>
        /// <param name="traConceptoCompra">Datos de la compra</param>
        /// <returns></returns>
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
        /// <summary>
        /// Crear Compra
        /// Aqui se crea una compra, se reciben los datos y a partir del contexto se crea el nuevo objeto, se le
        /// asigna el id que le da la base de datos y se retorna
        /// </summary>
        /// <param name="traConceptoCompra"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TraConceptoCompra>> PostTraConceptoCompra(TraConceptoCompra traConceptoCompra)
        {
            _context.TraConceptoCompra.Add(traConceptoCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraConceptoCompra", new { id = traConceptoCompra.TraCompras }, traConceptoCompra);
        }

        // DELETE: api/TraConceptoCompras/5
        /// <summary>
        /// Borrar Compras
        /// Aqui se verifica que el id enviado referencie a una compra, de ser asi se eliminará el objeto, y se 
        /// guardaran los datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
