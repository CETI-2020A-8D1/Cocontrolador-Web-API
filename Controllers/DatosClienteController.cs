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
    /// Obtiene los datos que el cliente necesita de la BD:
    /// su usuario,
    /// su direccción,
    /// sus compras
    /// y los conceptos de sus compras.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DatosClienteController : ControllerBase
    {
        /// <summary>
        /// Modelo de la base de datos de donde se saca la información
        /// </summary>
        private readonly CocotecaContext _context;

        /// <summary>
        /// Hace la conexión con el modelo
        /// </summary>
        /// <param name="context">Modelo de la base de datos de donde se saca la información</param>
        public DatosClienteController(CocotecaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca a un usuario en la base de datos que cumpla con el IDidentiy, si lo encuentra, busca si
        /// tiene alguna dirección con el IdUsuario en la BD.
        /// </summary>
        /// <param name="id">IDIdentity de un usuaraio.</param>
        /// <returns>La dirección de ese usuario si es que existe, si no encuentra nada retorna un status 404.</returns>
        [HttpGet("Direccion/{id}")]
        public async Task<ActionResult<CatDirecciones>> GetDirecciones(string id)
        {
            var idUsuario = await _context.MtoCatUsuarios.Where(o => o.IDidentity.Equals(id)).Select(o=>o.Idusuario).FirstOrDefaultAsync();
            var direcciones = await _context.CatDirecciones.Where(o => o.Idusuario == idUsuario).FirstOrDefaultAsync();

            if (direcciones == null)
            {
                return NotFound();
            }

            return direcciones;
        }

        /// <summary>
        /// Busca el estado al que pertenece un municipio en la relación estado municipio.
        /// </summary>
        /// <param name="id">Id del municipio del que se desea saber su estado.</param>
        /// <returns>El estado al que pertenece el municipio, si no encuentra nada retorna un status 404.</returns>
        [HttpGet("Estado/{id}")]
        public async Task<ActionResult<CatEstados>> GetEstado(int id)
        {
            var estado = await _context.CatEstados.Where(
                o => o.Idestado == o.CatEstadosMunicipios.Where(
                    e => e.Idmunicipio == id).Select(e => e.Idestado).First()).FirstOrDefaultAsync();

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        /// <summary>
        /// Busca a un usuario en la base de datos que cumpla con el IDidentiy, si lo encuentra, busca si
        /// tiene alguna dirección con el IdUsuario en la BD, si recibe alguna retorna true, de lo contrario false.
        /// </summary>
        /// <param name="id">IDIdentity de un usuaraio.</param>
        /// <returns>true si encuentra una dirección para el usuario, false si no lo encuentra.</returns>
        [HttpGet("DireccionExiste/{id}")]
        public async Task<ActionResult<bool>> GetDireccionExiste(string id)
        {
            var idUsuario = await _context.MtoCatUsuarios.Where(o => o.IDidentity.Equals(id)).Select(o => o.Idusuario).FirstOrDefaultAsync();
            var direcciones = await _context.CatDirecciones.Where(o => o.Idusuario == idUsuario).FirstOrDefaultAsync();

            if (direcciones == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Busca a un usuario en la base de datos que cumpla con el IDidentiy.
        /// </summary>
        /// <param name="id">IDidentity de un usuaraio.</param>
        /// <returns>El usuario que tenga ese IDidentiy, si no encuentra nada retorna un status 404.</returns>
        [HttpGet("Usuario/{id}")]
        public async Task<ActionResult<MtoCatUsuarios>> GetMtoCatUsuarios(string id)
        {
            var mtoCatUsuarios = await _context.MtoCatUsuarios.Where(o => o.IDidentity.Equals(id)).FirstOrDefaultAsync();

            if (mtoCatUsuarios == null)
            {
                return NotFound();
            }

            return mtoCatUsuarios;
        }

        /// <summary>
        /// Busca a un usuario en la base de datos que cumpla con el IDidentiy, si lo encuentra, busca
        /// todas las compras que tiene el usuario con el IdUsuario, que estén pagadas, en la BD.
        /// </summary>
        /// <param name="id">IDidentity de un usuaraio.</param>
        /// <returns>Todas las compras que realizó el usuario, si no encuentra nada retorna un status 404.</returns>
        [HttpGet("Compras/{id}")]
        public async Task<ActionResult<IEnumerable<TraCompras>>> GetCompras(string id)
        {
            var idUsuario = await _context.MtoCatUsuarios.Where(o => o.IDidentity.Equals(id)).Select(o => o.Idusuario).FirstOrDefaultAsync();
            var compras = await _context.TraCompras.Where(o => o.Idusuario == idUsuario && o.Pagado == true).ToListAsync();

            if (compras == null)
            {
                return NotFound();
            }

            return compras;
        }

        //api/DatosCliente/Compra?id=a&idIdentity=b
        /// <summary>
        /// Busca a un usuario en la base de datos que cumpla con el IDidentiy, si lo encuentra, busca en la BD
        /// la compra con el id especificado, se asegura de que esté pagada y que pertenezca al usuario
        /// específicado, si es así, une los elementos que contiene esa compra.
        /// </summary>
        /// <param name="idCompra">Id de la compra</param>
        /// <param name="idIdentity">IDidentity de un usuaraio.</param>
        /// <returns>
        /// La compra que realizó el usuario, con el contenido de la compra
        /// si no encuentra la compra de el usuario retorna un status 404.
        /// </returns>
        [HttpGet("Compra")]
        public async Task<ActionResult<TraCompras>> GetCompra(int idCompra, string idIdentity)
        {
            var idUsuario = await _context.MtoCatUsuarios.Where(o => o.IDidentity.Equals(idIdentity)).Select(o => o.Idusuario).FirstOrDefaultAsync();
            var compra = await _context.TraCompras.Where(o => o.Idusuario == idUsuario && o.Pagado == true && o.Idcompra == idCompra).FirstOrDefaultAsync();
            
            if (compra == null)
            {
                return NotFound();
            }
            var detallescompra = await _context.TraConceptoCompra.Where(o => o.Idcompra == idCompra).ToListAsync();
            compra.TraConceptoCompra = detallescompra;
            return compra;
        }


    }
}