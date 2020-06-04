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
        //Esta función recibe el contexto de la cocotecaApi y construye el contexto según lo que
        //reciba la función
        public GridController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/Grid
        //Obtener Libros por categorias
        //Primeramente se realiza una consulta a la base de datos, esta consulta corroborará que la categoria
        //tenga libros, al haber corroborado. Se enviaran las categorías que tenagn libros. En dado caso que
        //la categoría no tenga ningun libro, retornará una función que dice que está vacio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatCategorias>>> GetCategorias()
        {
            var categorias = await _context.CatCategorias
                .Where(c => c.MtoCatLibros.Count() > 0 && c.MtoCatLibros.Any(o => !o.Descontinuado && o.Stock > 0))
                .ToListAsync();

            if (categorias == null)
            {
                return NotFound();
            }

            return categorias;
        }

        // GET: api/Grid/id
        // Retornar libros conforme a categoría
        // Esta función lo que recibe es un id de la categoría, el cual utilizaremos para realizar la
        // consulta. Esta consulta nos retornará los libros de la categoría a partir del id recibido
        // en dado caso que no encuentre ningun libro. Retornará un not found, en caso contrario se
        // retornarán los libros de esa categoría
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MtoCatLibros>>> GetBook(int id)
        {
            var books = await _context.MtoCatLibros.Where(b => b.Idcategoria == id && b.Descontinuado == false
                            && b.Stock > 0).ToListAsync();

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }
    }
}
