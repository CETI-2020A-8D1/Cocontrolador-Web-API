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
    [Route("api/MunicipiosEstado")]
    [ApiController]
    public class MunicipiosEstadoController : ControllerBase
    {
        private readonly CocotecaContext _context;
        public MunicipiosEstadoController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/MunicipiosEstado/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CatMunicipios>>> GetCategorias(int id)
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