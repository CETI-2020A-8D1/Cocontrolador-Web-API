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
    [Produces("application/json")]
    [Route("api/Inicio")]
    [ApiController]
    public class InicioPagWebController : ControllerBase
    {
        private readonly CocotecaPruebaContext _context;

        public InicioPagWebController(CocotecaPruebaContext context)
        {
            _context = context;
        }

        // GET: api/Inicio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatCategorias>>> GetInicio()
        {
            var categorias = await _context.CatCategorias.ToListAsync();

            List<CatCategorias> categorias2 = new List<CatCategorias>();
            //Si categorias es menor a cinco
            if (categorias.Count < 5)
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
                while(i < 5 && cont < categorias.Count)
                {
                    var cat = categorias.ElementAt(rnd.Next(0, categorias.Count));
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
            return categorias2;
        }

        private int CantidadLibros (CatCategorias categoria)
        {
            return _context.MtoCatLibros.Where(o => o.Descontinuado == false &&
                    o.Idcategoria == categoria.Idcategoria && o.Stock > 0).Count();
        }
    }
}