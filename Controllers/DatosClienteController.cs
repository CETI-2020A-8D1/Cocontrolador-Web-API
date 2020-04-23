﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocontroladorAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocontroladorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosClienteController : ControllerBase
    {
        private readonly CocotecaContext _context;

        public DatosClienteController(CocotecaContext context)
        {
            _context = context;
        }

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


    }
}