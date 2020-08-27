using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Maestros;
using Sistema.Web.Models.Maestros.Pitchs;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class PitchsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PitchsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Pitchs/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PitchViewModel>> Listar()
        {
            var Pitch = await _context.Pitchs.ToListAsync();

            return Pitch.Select(r => new PitchViewModel
            {
                idpitch = r.idpitch,
                pitch = r.pitch,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Pitchs/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<PitchSelectModel>> Select()
        {
            var pitch = await _context.Pitchs.Where(r => r.activo == true).OrderBy(r => r.pitch).ToListAsync();

            return pitch.Select(r => new PitchSelectModel
            {
                idpitch = r.idpitch,
                pitch = r.pitch
            });
        }

        // GET: api/Pitchs/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var pitch = await _context.Pitchs.FindAsync(id);

            if (pitch == null)
            {
                return NotFound();
            }

            return Ok(new PitchViewModel
            {
                idpitch = pitch.idpitch,
                pitch = pitch.pitch,
                iduseralta = pitch.iduseralta,
                fecalta = pitch.fecalta,
                iduserumod = pitch.iduserumod,
                fecumod = pitch.fecumod,
                activo = pitch.activo
            });
        }

        // PUT: api/Pitchs/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PitchUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idpitch <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var pitch = await _context.Pitchs.FirstOrDefaultAsync(c => c.idpitch == model.idpitch);

            if (pitch == null)
            {
                return NotFound();
            }

            pitch.pitch = model.pitch;
            pitch.iduserumod = model.iduserumod;
            pitch.fecumod = fechaHora;

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

        // POST: api/Pitchs/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] PitchCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Pitch pitch = new Pitch
            {
                pitch = model.pitch,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Pitchs.Add(pitch);
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

        // DELETE: api/Pitchs/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pitch = await _context.Pitchs.FindAsync(id);
            if (pitch == null)
            {
                return NotFound();
            }

            _context.Pitchs.Remove(pitch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(pitch);
        }

        // PUT: api/Pitchs/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var pitch = await _context.Pitchs.FirstOrDefaultAsync(c => c.idpitch == id);

            if (pitch == null)
            {
                return NotFound();
            }

            pitch.activo = false;

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

        // PUT: api/Pitchs/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var pitch = await _context.Pitchs.FirstOrDefaultAsync(c => c.idpitch == id);

            if (pitch == null)
            {
                return NotFound();
            }

            pitch.activo = true;

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

        private bool PitchExists(int id)
        {
            return _context.Pitchs.Any(e => e.idpitch == id);
        }
    }
}
