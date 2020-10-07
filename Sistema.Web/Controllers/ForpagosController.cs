using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Maestros;
using Sistema.Web.Models.Maestros.Forpagos;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForpagosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ForpagosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Forpagos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ForpagoViewModel>> Listar()
        {
            var Forpago = await _context.Forpagos.ToListAsync();

            return Forpago.Select(r => new ForpagoViewModel
            {
                idforpago = r.idforpago,
                forpago = r.forpago,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Forpagos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ForpagoSelectModel>> Select()
        {
            var forpago = await _context.Forpagos.Where(r => r.activo == true).OrderBy(r => r.forpago).ToListAsync();

            return forpago.Select(r => new ForpagoSelectModel
            {
                idforpago = r.idforpago,
                forpago = r.forpago
            });
        }

        // GET: api/Forpagos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var forpago = await _context.Forpagos.FindAsync(id);

            if (forpago == null)
            {
                return NotFound();
            }

            return Ok(new ForpagoViewModel
            {
                idforpago = forpago.idforpago,
                forpago = forpago.forpago,
                iduseralta = forpago.iduseralta,
                fecalta = forpago.fecalta,
                iduserumod = forpago.iduserumod,
                fecumod = forpago.fecumod,
                activo = forpago.activo
            });
        }

        // PUT: api/Forpagos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ForpagoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idforpago <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var forpago = await _context.Forpagos.FirstOrDefaultAsync(c => c.idforpago == model.idforpago);

            if (forpago == null)
            {
                return NotFound();
            }

            forpago.forpago = model.forpago;
            forpago.iduserumod = model.iduserumod;
            forpago.fecumod = fechaHora;

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

        // POST: api/Forpagos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ForpagoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Forpago forpago = new Forpago
            {
                forpago = model.forpago,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Forpagos.Add(forpago);
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

        // DELETE: api/Forpagos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var forpago = await _context.Forpagos.FindAsync(id);
            if (forpago == null)
            {
                return NotFound();
            }

            _context.Forpagos.Remove(forpago);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(forpago);
        }

        // PUT: api/Forpagos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var forpago = await _context.Forpagos.FirstOrDefaultAsync(c => c.idforpago == id);

            if (forpago == null)
            {
                return NotFound();
            }

            forpago.activo = false;

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

        // PUT: api/Forpagos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var forpago = await _context.Forpagos.FirstOrDefaultAsync(c => c.idforpago == id);

            if (forpago == null)
            {
                return NotFound();
            }

            forpago.activo = true;

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

        private bool ForpagoExists(int id)
        {
            return _context.Forpagos.Any(e => e.idforpago == id);
        }
    }
}
