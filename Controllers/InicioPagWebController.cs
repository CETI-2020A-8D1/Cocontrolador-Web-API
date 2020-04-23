// ==============================================================
// Autor: Judith Hinojosa
// Creado día: 28/03/2020
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
    /// Crea rutas web que muestran la información de la página de inicio en forma de JSON,
    /// en este caso un listado de categorías con libros por cada uno.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Inicio")]
    [ApiController]
    public class InicioPagWebController : ControllerBase
    {
        /// <summary>
        /// Modelo de la base de datos de donde se saca la información
        /// </summary>
        private readonly CocotecaContext _context;

        /// <summary>
        /// Hace la conexión con el modelo
        /// </summary>
        /// <param name="context">Modelo de la base de datos de donde se saca la información</param>
        public InicioPagWebController(CocotecaContext context)
        {
            _context = context;
        }

        // GET: api/Inicio
        /// <summary>
        /// Busca un listado de máximo 5 categorías que tengan 5 libros que no esten descontinuados
        /// y que haya por lo menos uno en stock.
        /// </summary>
        /// <returns>Listado de categorias y libros en esas categorias</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatCategorias>>> GetInicio()
        {
            var categorias = await _context.CatCategorias.ToListAsync();

            List<CatCategorias> categorias2 = new List<CatCategorias>();
            //Si categorias es menor a cinco
            if (categorias.Count() < 5)
            {
                foreach (var cat in categorias)
                {
                    //Si hay 5 libros o más en la categoría
                    if (CantidadLibros(cat) >= 5)
                    {
                        var libros = await _context.MtoCatLibros.Where(o => o.Descontinuado == false &&
                            o.Idcategoria == cat.Idcategoria && o.Stock > 0).Take(5).ToListAsync();
                        cat.MtoCatLibros = libros;
                        categorias2.Add(cat);
                    }
                }
            }
            else
            {
                Random rnd = new Random();
                int i = 0;
                int cont = 0;
                while (i < 5 && cont < categorias.Count())
                {
                    var cat = categorias.ElementAt(rnd.Next(0, categorias.Count()));
                    //Si hay 5 libros o más en la categoría y no está la categoria ya
                    if (CantidadLibros(cat) >= 5 && !categorias2.Exists(o => o.Idcategoria == cat.Idcategoria))
                    {
                        var libros = await _context.MtoCatLibros.Where(o => o.Descontinuado == false &&
                            o.Idcategoria == cat.Idcategoria && o.Stock > 0).Take(5).ToListAsync();
                        cat.MtoCatLibros = libros;
                        categorias2.Add(cat);
                    }
                    else
                        i--;
                    i++;
                    cont++;
                }
            }

            if (categorias2 == null)
            {
                return NotFound();
            }

            return categorias2;
        }

        /// <summary>
        /// Método busca la  cantidad de libros que hay en stock y que no están descontinuados
        /// de cierta categoría en la base de datos.
        /// </summary>
        /// <param name="categoria">Recibe la categoría donde busca la cantidad de libros</param>
        /// <returns>La cantidad de libros que hay en esa categoría</returns>
        private int CantidadLibros(CatCategorias categoria)
        {
            return _context.MtoCatLibros.Where(o => o.Descontinuado == false &&
                    o.Idcategoria == categoria.Idcategoria && o.Stock > 0).Count();
        }
    }
}