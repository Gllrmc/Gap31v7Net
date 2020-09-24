using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Gastos;
using Sistema.Web.Models.Gastos;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public GastosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Gastos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GastoViewModel>> Listar()
        {
            var Gasto = await _context.Gastos
                .Include(p => p.concepto)
                .OrderByDescending(p => p.fecgasto)
                .ToListAsync();

            return Gasto.Select(r => new GastoViewModel
            {
                idgasto = r.idgasto,
                idconcepto = r.idconcepto,
                concepto = r.concepto.concepto,
                texto = r.concepto.texto,
                color = r.concepto.color,
                fecgasto = r.fecgasto.Date,
                importe = r.importe,
                nota = r.nota,
                pendiente = r.pendiente,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Gastos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<GastoSelectModel>> Select()
        {
            var gasto = await _context.Gastos
                .Include(p => p.concepto)
                .Where(r => r.activo == true)
                .OrderBy(r => r.concepto.concepto)
                .ToListAsync();

            return gasto.Select(r => new GastoSelectModel
            {
                idgasto = r.idgasto,
                idconcepto = r.idconcepto,
                concepto = r.concepto.concepto,
                fecgasto = r.fecgasto,
                importe = r.importe
            });
        }

        // GET: api/Gastos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var gasto = await _context.Gastos
                .FindAsync(id);

            if (gasto == null)
            {
                return NotFound();
            }

            return Ok(new GastoViewModel
            {
                idgasto = gasto.idgasto,
                idconcepto = gasto.idconcepto,
                fecgasto = gasto.fecgasto,
                importe = gasto.importe,
                nota = gasto.nota,
                pendiente = gasto.pendiente,
                iduseralta = gasto.iduseralta,
                fecalta = gasto.fecalta,
                iduserumod = gasto.iduserumod,
                fecumod = gasto.fecumod,
                activo = gasto.activo
            });
        }

        // PUT: api/Gastos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] GastoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idgasto <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var gasto = await _context.Gastos.FirstOrDefaultAsync(c => c.idgasto == model.idgasto);

            if (gasto == null)
            {
                return NotFound();
            }

            gasto.idconcepto = model.idconcepto;
            gasto.fecgasto = model.fecgasto;
            gasto.importe = model.importe;
            gasto.nota = model.nota;
            gasto.pendiente = model.pendiente;
            gasto.iduserumod = model.iduserumod;
            gasto.fecumod = fechaHora;

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

        // POST: api/Gastos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] GastoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Gasto gasto = new Gasto
            {
                idconcepto = model.idconcepto,
                fecgasto = model.fecgasto,
                importe = model.importe,
                nota = model.nota,
                pendiente = true,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Gastos.Add(gasto);
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

        // DELETE: api/Gastos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null)
            {
                return NotFound();
            }

            _context.Gastos.Remove(gasto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(gasto);
        }

        // PUT: api/Gastos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var gasto = await _context.Gastos.FirstOrDefaultAsync(c => c.idgasto == id);

            if (gasto == null)
            {
                return NotFound();
            }

            gasto.activo = false;

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

        // PUT: api/Gastos/Activarpendiente/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activarpendiente([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var gasto = await _context.Gastos.FirstOrDefaultAsync(c => c.idgasto == id);

            if (gasto == null)
            {
                return NotFound();
            }

            gasto.pendiente = true;

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



        // PUT: api/Gastos/Desactivarpendiente/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivarpendiente([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var gasto = await _context.Gastos.FirstOrDefaultAsync(c => c.idgasto == id);

            if (gasto == null)
            {
                return NotFound();
            }

            gasto.pendiente = false;

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

        // PUT: api/Gastos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var gasto = await _context.Gastos.FirstOrDefaultAsync(c => c.idgasto == id);

            if (gasto == null)
            {
                return NotFound();
            }

            gasto.activo = true;

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

        private bool GastoExists(int id)
        {
            return _context.Gastos.Any(e => e.idgasto == id);
        }
    }
}
