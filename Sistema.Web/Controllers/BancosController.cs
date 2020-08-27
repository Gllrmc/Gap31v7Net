﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Maestros;
using Sistema.Web.Models.Maestros.Bancos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public BancosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Bancos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<BancoViewModel>> Listar()
        {
            var Banco = await _context.Bancos.ToListAsync();

            return Banco.Select(r => new BancoViewModel
            {
                idbanco = r.idbanco,
                nombre = r.nombre,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Bancos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<BancoSelectModel>> Select()
        {
            var banco = await _context.Bancos.Where(r => r.activo == true).OrderBy(r => r.nombre).ToListAsync();

            return banco.Select(r => new BancoSelectModel
            {
                idbanco = r.idbanco,
                nombre = r.nombre
            });
        }

        // GET: api/Bancos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var banco = await _context.Bancos.FindAsync(id);

            if (banco == null)
            {
                return NotFound();
            }

            return Ok(new BancoViewModel
            {
                idbanco = banco.idbanco,
                nombre = banco.nombre,
                iduseralta = banco.iduseralta,
                fecalta = banco.fecalta,
                iduserumod = banco.iduserumod,
                fecumod = banco.fecumod,
                activo = banco.activo
            });
        }

        // PUT: api/Bancos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] BancoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idbanco <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var banco = await _context.Bancos.FirstOrDefaultAsync(c => c.idbanco == model.idbanco);

            if (banco == null)
            {
                return NotFound();
            }

            banco.nombre = model.nombre;
            banco.iduserumod = model.iduserumod;
            banco.fecumod = fechaHora;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Bancos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] BancoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Banco banco = new Banco
            {
                nombre = model.nombre,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Bancos.Add(banco);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Bancos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banco = await _context.Bancos.FindAsync(id);
            if (banco == null)
            {
                return NotFound();
            }

            _context.Bancos.Remove(banco);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(banco);
        }

        // PUT: api/Bancos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var banco = await _context.Bancos.FirstOrDefaultAsync(c => c.idbanco == id);

            if (banco == null)
            {
                return NotFound();
            }

            banco.activo = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Bancos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var banco = await _context.Bancos.FirstOrDefaultAsync(c => c.idbanco == id);

            if (banco == null)
            {
                return NotFound();
            }

            banco.activo = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        private bool BancoExists(int id)
        {
            return _context.Bancos.Any(e => e.idbanco == id);
        }
    }
}
