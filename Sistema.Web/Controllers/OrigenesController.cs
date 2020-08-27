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
using Sistema.Web.Models.Maestros.Origenes;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrigenesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public OrigenesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Origenes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<OrigenViewModel>> Listar()
        {
            var Origen = await _context.Origenes
                .Include(p => p.territorio)
                .ToListAsync();

            return Origen.Select(r => new OrigenViewModel
            {
                idorigen = r.idorigen,
                origen = r.origen,
                idterritorio = r.idterritorio,
                territorio = r.territorio.territorio,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Origenes/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<OrigenSelectModel>> Select()
        {
            var origen = await _context.Origenes
                .Include(p => p.territorio)
                .Where(r => r.activo == true).OrderBy(r => r.origen).ToListAsync();

            return origen.Select(r => new OrigenSelectModel
            {
                idorigen = r.idorigen,
                origen = r.origen
            });
        }

        // GET: api/Origenes/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var origen = await _context.Origenes.FindAsync(id);

            if (origen == null)
            {
                return NotFound();
            }

            return Ok(new OrigenViewModel
            {
                idorigen = origen.idorigen,
                origen = origen.origen,
                idterritorio = origen.idterritorio,
                iduseralta = origen.iduseralta,
                fecalta = origen.fecalta,
                iduserumod = origen.iduserumod,
                fecumod = origen.fecumod,
                activo = origen.activo
            });
        }

        // PUT: api/Origenes/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] OrigenUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idorigen <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var origen = await _context.Origenes.FirstOrDefaultAsync(c => c.idorigen == model.idorigen);

            if (origen == null)
            {
                return NotFound();
            }

            origen.origen = model.origen;
            origen.idterritorio = model.idterritorio;
            origen.iduserumod = model.iduserumod;
            origen.fecumod = fechaHora;

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

        // POST: api/Origenes/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] OrigenCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Origen origen = new Origen
            {
                origen = model.origen,
                idterritorio = model.idterritorio,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Origenes.Add(origen);
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

        // DELETE: api/Origenes/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var origen = await _context.Origenes.FindAsync(id);
            if (origen == null)
            {
                return NotFound();
            }

            _context.Origenes.Remove(origen);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(origen);
        }

        // PUT: api/Origenes/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var origen = await _context.Origenes.FirstOrDefaultAsync(c => c.idorigen == id);

            if (origen == null)
            {
                return NotFound();
            }

            origen.activo = false;

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

        // PUT: api/Origenes/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var origen = await _context.Origenes.FirstOrDefaultAsync(c => c.idorigen == id);

            if (origen == null)
            {
                return NotFound();
            }

            origen.activo = true;

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

        private bool OrigenExists(int id)
        {
            return _context.Origenes.Any(e => e.idorigen == id);
        }
    }
}
