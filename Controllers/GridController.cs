// ==============================================================
// Author: Mauricio Andres
// Create date: 28/03/2020
// Description: Controller for grid page
// ===============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CocontroladorAPI.Models;

namespace CocontroladorAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GridController : Controller
    {
        private readonly CocotecaContext _context;
        public GridController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/Grid
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatCategorias>>> GetCategorias()
        {
            var categorias = await _context.CatCategorias
                .Where(c => c.MtoCatLibros.Count() > 0 && c.MtoCatLibros.Any(o => !o.Descontinuado && o.Stock > 0))
                .ToListAsync();
            return categorias;
        }

        // GET: api/Grid/id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MtoCatLibros>>> GetBook(int id)
        {
            var books = await _context.MtoCatLibros.Where(b => b.Idcategoria == id && b.Descontinuado == false
                            && b.Stock > 0).ToListAsync();

            return books;
        }
    }
}
