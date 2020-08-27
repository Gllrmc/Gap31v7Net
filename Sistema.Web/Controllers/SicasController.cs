using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Daybyday;
using Sistema.Web.Models.Daybyday;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class SicasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public SicasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Sicas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SicaViewModel>> Listar()
        {
            var Sica = await _context.Sicas.ToListAsync();

            return Sica.Select(r => new SicaViewModel
            {
                idsica = r.idsica,
                asignacion = r.asignacion,
                cargo = r.cargo,
                horas8 = r.horas8,
                extras4 = r.extras4,
                total12 = r.total12,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Sicas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SicaViewModel>> Select()
        {
            var sica = await _context.Sicas.Where(r => r.activo == true)
                .OrderBy(r => r.idsica)
                .ToListAsync();

            return sica.Select(r => new SicaViewModel
            {
                idsica = r.idsica,
                asignacion = r.asignacion,
                cargo = r.cargo,
                horas8 = r.horas8,
                extras4 = r.extras4,
                total12 = r.total12,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Sicas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var sica = await _context.Sicas.FindAsync(id);

            if (sica == null)
            {
                return NotFound();
            }

            return Ok(new SicaViewModel
            {
                idsica = sica.idsica,
                asignacion = sica.asignacion,
                cargo = sica.cargo,
                horas8 = sica.horas8,
                extras4 = sica.extras4,
                total12 = sica.total12,
                iduseralta = sica.iduseralta,
                fecalta = sica.fecalta,
                iduserumod = sica.iduserumod,
                fecumod = sica.fecumod,
                activo = sica.activo
            });
        }

        // PUT: api/Sicas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] SicaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idsica <= 0)
            {
                return BadRequest();
            }

            var sica = await _context.Sicas.FirstOrDefaultAsync(c => c.idsica == model.idsica);

            if (sica == null)
            {
                return NotFound();
            }

            sica.idsica = model.idsica;
            sica.asignacion = model.asignacion;
            sica.cargo = model.cargo;
            sica.horas8 = model.horas8;
            sica.extras4 = model.extras4;
            sica.total12 = model.total12;
            sica.iduseralta = model.iduseralta;
            sica.fecalta = model.fecalta;
            sica.iduserumod = model.iduserumod;
            sica.fecumod = model.fecumod;

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

        // POST: api/Sicas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] SicaCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sica sica = new Sica
            {
                asignacion = model.asignacion,
                cargo = model.cargo,
                horas8 = model.horas8,
                extras4 = model.extras4,
                total12 = model.total12,
                iduseralta = model.iduseralta,
                fecalta = model.fecalta,
                iduserumod = model.iduserumod,
                fecumod = model.fecumod,
                activo = true
            };

            _context.Sicas.Add(sica);
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

        // DELETE: api/Sicas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sica = await _context.Sicas.FindAsync(id);
            if (sica == null)
            {
                return NotFound();
            }

            _context.Sicas.Remove(sica);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(sica);
        }

        // PUT: api/Sicas/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var sica = await _context.Sicas.FirstOrDefaultAsync(c => c.idsica == id);

            if (sica == null)
            {
                return NotFound();
            }

            sica.activo = false;

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

        // PUT: api/Sicas/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var sica = await _context.Sicas.FirstOrDefaultAsync(c => c.idsica == id);

            if (sica == null)
            {
                return NotFound();
            }

            sica.activo = true;

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

        private bool SicaExists(int id)
        {
            return _context.Sicas.Any(e => e.idsica == id);
        }
    }
}
