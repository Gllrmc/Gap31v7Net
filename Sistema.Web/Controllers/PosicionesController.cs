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
using Sistema.Web.Models.Maestros.Posiciones;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PosicionesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Posiciones/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PosicionViewModel>> Listar()
        {
            var Posicion = await _context.Posiciones.ToListAsync();

            return Posicion.Select(r => new PosicionViewModel
            {
                idposicion = r.idposicion,
                posicion = r.posicion,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Posiciones/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<PosicionSelectModel>> Select()
        {
            var posicion = await _context.Posiciones.Where(r => r.activo == true).OrderBy(r => r.posicion).ToListAsync();

            return posicion.Select(r => new PosicionSelectModel
            {
                idposicion = r.idposicion,
                posicion = r.posicion
            });
        }

        // GET: api/Posiciones/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var posicion = await _context.Posiciones.FindAsync(id);

            if (posicion == null)
            {
                return NotFound();
            }

            return Ok(new PosicionViewModel
            {
                idposicion = posicion.idposicion,
                posicion = posicion.posicion,
                iduseralta = posicion.iduseralta,
                fecalta = posicion.fecalta,
                iduserumod = posicion.iduserumod,
                fecumod = posicion.fecumod,
                activo = posicion.activo
            });
        }

        // PUT: api/Posiciones/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PosicionUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idposicion <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var posicion = await _context.Posiciones.FirstOrDefaultAsync(c => c.idposicion == model.idposicion);

            if (posicion == null)
            {
                return NotFound();
            }

            posicion.posicion = model.posicion;
            posicion.iduserumod = model.iduserumod;
            posicion.fecumod = fechaHora;

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

        // POST: api/Posiciones/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] PosicionCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Posicion posicion = new Posicion
            {
                posicion = model.posicion,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Posiciones.Add(posicion);
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

        // DELETE: api/Posiciones/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posicion = await _context.Posiciones.FindAsync(id);
            if (posicion == null)
            {
                return NotFound();
            }

            _context.Posiciones.Remove(posicion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(posicion);
        }

        // PUT: api/Posiciones/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var posicion = await _context.Posiciones.FirstOrDefaultAsync(c => c.idposicion == id);

            if (posicion == null)
            {
                return NotFound();
            }

            posicion.activo = false;

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

        // PUT: api/Posiciones/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var posicion = await _context.Posiciones.FirstOrDefaultAsync(c => c.idposicion == id);

            if (posicion == null)
            {
                return NotFound();
            }

            posicion.activo = true;

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

        private bool PosicionExists(int id)
        {
            return _context.Posiciones.Any(e => e.idposicion == id);
        }
    }
}
