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
    /// Este controlador lo que hace es realizar todas las acciones relacionadas con libros
    /// Crear, actualizar, obtener y borrar libros
    /// </summary>
    [Produces("application/json")]
    [Route("api/MtoCatLibros")]
    [ApiController]
    public class MtoCatLibrosController : ControllerBase
    {
        private readonly CocotecaContext _context;
        /// <summary>
        /// Aqui se realiza el constructor del contexto para que las funciones puedan realizar las llamadas
        /// a la base de datos a partir de este contexto
        /// </summary>
        /// <param name="context">Es el contexto de la base de datos</param>
        public MtoCatLibrosController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/MtoCatLibros
        /// <summary>
        /// Esta funcion nos ayuda para esperar el contexto de los libros, este proceso se realoza de manera
        /// asincrona
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MtoCatLibros>>> GetMtoCatLibros()
        {
            return await _context.MtoCatLibros.ToListAsync();
        }

        // GET: api/MtoCatLibros/5
        /// <summary>
        /// Esta funcion realiza una consulta a la base de datos, en la cual busca un libro especifico por
        /// medio de un id, en dado caso que no encuentre ningun libro, se Retornará un no encontrado. En
        /// caso contrario, se retornará el libro en cuestión
        /// </summary>
        /// <param name="id">Es el id del libro que se busca</param>
        /// <returns></returns>
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
        /// <summary>
        /// Actualizar libro
        /// La función de este controlador se basa en actializar un libro, la primer cosa realizada es una
        /// comprobación en la cual se verifica que el id enviado coincida con el id del libro. Una ves que
        /// si coincidan, se procederá a realizar la actualización y se coloca la operación en la cola. En 
        /// caso que sea correcta la operación, se retornará todo normal. En caso que algo haya fallado,
        /// se retornará un error
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mtoCatLibros"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Aqui se crea un nuevo libro
        /// Lo que se hace es utilizando el contexto, se realiza una llamada a la base de datos y se añade
        /// el libro, el id del libro se guarda depende del id que le proporcione la base de datos y se
        /// retorna el libro creado
        /// </summary>
        /// <param name="mtoCatLibros">Es el modelo del libro para ser creado</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MtoCatLibros>> PostMtoCatLibros(MtoCatLibros mtoCatLibros)
        {
            _context.MtoCatLibros.Add(mtoCatLibros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtoCatLibros", new { id = mtoCatLibros.Idlibro }, mtoCatLibros);
        }

        // DELETE: api/MtoCatLibros/5
        /// <summary>
        /// Borrar libro
        /// Aqui a partir de un id se realiza la búsqueda del libro. En caso que no se encunetre se
        /// procederá a retornar un no encontrado. En caso contrario se eliminará el libro
        /// </summary>
        /// <param name="id">Id del libro que se borrará</param>
        /// <returns></returns>
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
