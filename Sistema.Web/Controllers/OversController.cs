using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Limbos;
using Sistema.Web.Models.Limbos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class OversController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public OversController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Overs/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<OverViewModel>> Listar()
        {
            var Over = await _context.Overs
            .Include(p => p.limbo)
            .ToListAsync();

            return Over.Select(r => new OverViewModel
            {
                idover = r.idover,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numover = r.numover,
                fecover = r.fecover,
                impover = r.impover,
                pdfover = r.pdfover,
                nota = r.nota,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Overs/ListarLimbo
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<OverViewModel>> ListarLimbo([FromRoute] int id)
        {
            var Over = await _context.Overs
                .Include (p => p.limbo)
                .Where(p => p.idlimbo == id)
                .ToListAsync();

            return Over.Select(r => new OverViewModel
            {
                idover = r.idover,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numover = r.numover,
                fecover = r.fecover,
                impover = r.impover,
                pdfover = r.pdfover,
                nota = r.nota,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Overs/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<OverSelectModel>> Select()
        {
            var over = await _context.Overs
                .Include(p => p.limbo)
                .Where(r => r.activo == true)
                .OrderBy(r => r.idover)
                .ToListAsync();

            return over.Select(r => new OverSelectModel
            {
                idover = r.idover,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numover = r.numover,
                fecover = r.fecover,
                impover = r.impover
            });
        }

        // GET: api/Overs/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var over = await _context.Overs.FindAsync(id);

            if (over == null)
            {
                return NotFound();
            }

            return Ok(new OverViewModel
            {
                idover = over.idover,
                idlimbo = over.idlimbo,
                numover = over.numover,
                fecover = over.fecover,
                impover = over.impover,
                pdfover = over.pdfover,
                nota = over.nota,
                iduseralta = over.iduseralta,
                fecalta = over.fecalta,
                iduserumod = over.iduserumod,
                fecumod = over.fecumod,
                activo = over.activo
            });
        }

        // PUT: api/Overs/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] OverUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idover <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var over = await _context.Overs.FirstOrDefaultAsync(c => c.idover == model.idover);

            if (over == null)
            {
                return NotFound();
            }

            over.fecover = model.fecover;
            over.impover = model.impover;
            over.pdfover = model.pdfover;
            over.nota = model.nota;
            over.iduserumod = model.iduserumod;
            over.fecumod = fechaHora;

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

        // POST: api/Overs/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] OverCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            int numover = _context.Overs
                .Where(p => p.idlimbo == model.idlimbo)
                .Max(x => (int?)x.numover) ?? 0;

            Over over = new Over
            {
                idlimbo = model.idlimbo,
                numover = numover + 1,
                fecover = model.fecover,
                impover = model.impover,
                pdfover= model.pdfover,
                nota = model.nota,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Overs.Add(over);
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

        // DELETE: api/Overs/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var over = await _context.Overs.FindAsync(id);
            if (over == null)
            {
                return NotFound();
            }

            _context.Overs.Remove(over);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(over);
        }

        // PUT: api/Overs/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var over = await _context.Overs.FirstOrDefaultAsync(c => c.idover == id);

            if (over == null)
            {
                return NotFound();
            }

            over.activo = false;

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

        // PUT: api/Overs/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var over = await _context.Overs.FirstOrDefaultAsync(c => c.idover == id);

            if (over == null)
            {
                return NotFound();
            }

            over.activo = true;

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


        private bool OverExists(int id)
        {
            return _context.Overs.Any(e => e.idover == id);
        }
    }
}
