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
    /// Este controlador realiza las acciones básicas de los usuarios, tales como crear, actualizar, borrar
    /// u obtener
    /// </summary>
    [Produces("application/json")]
    [Route("api/MtoCatUsuarios")]
    [ApiController]
    public class MtoCatUsuariosController : ControllerBase
    {
        private readonly CocotecaContext _context;
        /// <summary>
        /// Aqui se realiza el constructor para el contexto
        /// </summary>
        /// <param name="context"></param>
        public MtoCatUsuariosController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/MtoCatUsuarios
        /// <summary>
        /// Se realiza una llamada a la base de datos en la cual se retornarán absolutamente todos los 
        /// usuarios creados en el sistema, este metodo se realiza mediante una llamada asincrona
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MtoCatUsuarios>>> GetMtoCatUsuarios()
        {
            return await _context.MtoCatUsuarios.ToListAsync();
        }

        // GET: api/MtoCatUsuarios/5
        /// <summary>
        /// Obtener usuario por id
        /// Aqui se realiza una consulta a la base de datos, en caso que no se obtenga ningun usuario, se 
        /// retornará un no encontrado. En caso contrario, se retornará al usuario encontrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Actualizar usuario
        /// Esta funcion lo primeor que realiza es una verificacion para que el id enviado coincida con el
        /// id del usuaario. En caso que no coincidan, se enviará un mensaje de error, en caso contrario
        /// se realizará una consulta a la base de datos, esta consulta actualizará el usuario con la 
        /// información que se reciba. En caso que el usuario no se encuentre se enviará un no encontrado.
        /// En caso contrario, se enviará el usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mtoCatUsuarios"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Publicar un nuevo usuario
        /// Se obtiene el contexto de la base de datos en el apartado de usuarios, después con el usuario
        /// que se ha recibido se hace la consulta de creación, se le asigna un id al objeto y se retorna.
        /// </summary>
        /// <param name="mtoCatUsuarios">Son los datos del objeto usuario</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MtoCatUsuarios>> PostMtoCatUsuarios(MtoCatUsuarios mtoCatUsuarios)
        {
            _context.MtoCatUsuarios.Add(mtoCatUsuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtoCatUsuarios", new { id = mtoCatUsuarios.Idusuario }, mtoCatUsuarios);
        }

        // DELETE: api/MtoCatUsuarios/5
        /// <summary>
        /// Borrar un usuario
        /// Primeramente, se obtiene el objeto tipo usuario por medio de su id, en caso que no se encuentre
        /// se retornara que no se encontro, en caso contrario, se procederá a realizar la consulta para 
        /// borrar el objeto, si todo es correcto. Se enviará a la pagina que la operación ha sido un exito
        /// </summary>
        /// <param name="id">Es el id del usuario</param>
        /// <returns></returns>
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
