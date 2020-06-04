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

    /**
     * Clase CatDireccionesController
     * 
     * Esta clase es en donde se llevan a cabo todas las funciones de la API para 
     * esta tabla de la base de datos, esas funciones estan los GET, POST, DELETE
     * y PUT.
     * 
     */
    [Produces("application/json")]
    [Route("api/CatDirecciones")]
    [ApiController]
    public class CatDireccionesController : ControllerBase
    {
        private readonly CocotecaContext _context;

        /**
         * Método Constructor
         * 
         * Este es el método constructor para el objeto de esta clase, la cual recibe el
         * contexto de la clase CocotecaContext, y la variable de el controlador se
         * iguala con la que le llega del contexto la invoca.
         */
        public CatDireccionesController(CocotecaContext context)
        {
            _context = context;
        }

        /**
          * Método GET (Todos)
          * 
          * Este es el método GET que retorna toda la lista de elementos de la 
          * tabla en cuestión.
          * 
          */
        // GET: api/CatDirecciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatDirecciones>>> GetCatDirecciones()
        {
            return await _context.CatDirecciones.ToListAsync();
        }

        /**
         * Método GET por ID
         * 
         * Este método regresa toda la información de un elemento de la tabla 
         * pasanlo el ID de ese elemento a esta función, si el elemento no existe
         * se devuelve un NotFound.
         * 
         */
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

        /**
          * Método PUT por ID
          * 
          * Este método recibe el ID del elemento de la tabla que deseas alterar y el objeto
          * de con el que alteraras la tabla, primero checa si el id del elemento es igual
          * al id del objeto, si son diferentes manda un BadRequest, en caso contrario sigue.
          * Hace que el contexto se actualice con el nuevo objeto y se modifica y despues 
          * trata de salvar los cambios.
          */

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

        /**
         * Método POST
         * 
         * Este método recibe el objeto el cual debe de agregar a la tabla, 
         * simplemente utiliza el método Add del contexto para agregar el objeto
         * y despues guarda los cambios y retorna la accion con el id y el objeto.
         * 
         */

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

        /**
          * Método Delete por ID
          * 
          * Este método recibe el ID del elemento de la tabla que se elimina
          * se crea una variable bucando en la lista del contexto el id que sea
          * igual, si este es null quiere decir que no existe por lo que se retorna
          * un NotFound, pero si existe se utiliza el método Remove del contexto
          * pasandole el objeto y se guardan los cambios.
          * 
          */

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

        /**
          * Método CatCategoriasExists 
          * 
          * Este método por medio de la ID que recibe si el objeto existe
          * en el contexto y si es así regresa un true o false.
          * 
          */
        private bool CatDireccionesExists(int id)
        {
            return _context.CatDirecciones.Any(e => e.Iddireccion == id);
        }
    }
}
