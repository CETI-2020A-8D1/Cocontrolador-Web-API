// ==============================================================
// Autor: Judith Hinojosa
// Creado día: 28/04/2020
// Descripción: Controlador para página de inicio
// ===============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocontroladorAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocontroladorAPI.Controllers
{
    /// <summary>
    /// Obtiene los municipios en un estado.
    /// </summary>
    [Route("api/MunicipiosEstado")]
    [ApiController]
    public class MunicipiosEstadoController : ControllerBase
    {
        /// <summary>
        /// Modelo de la base de datos de donde se saca la información
        /// </summary>
        private readonly CocotecaContext _context;

        /// <summary>
        /// Hace la conexión con el modelo
        /// </summary>
        /// <param name="context">Modelo de la base de datos de donde se saca la información</param>
        public MunicipiosEstadoController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/MunicipiosEstado/1
        /// <summary>
        /// Busca los municipios que pertenecen a un estado por medio del id del estado, buscando los que tienen
        /// una relación en la tabla estado municipio.
        /// </summary>
        /// <param name="id">Recibe un entero del id del estado de donde se desean obtener los municipios</param>
        /// <returns>Un listado de municipios de ese estado, si no encuentra nada retorna un status 404</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CatMunicipios>>> GetMunicipios(int id)
        {
            var municipios = await _context.CatMunicipios
                .Where(c => c.CatEstadosMunicipios.All(o => o.Idestado == id))
                .OrderBy(o => o.Nombre)
                .ToListAsync();

            if (municipios == null)
            {
                return NotFound();
            }

            return municipios;
        }
    }
}