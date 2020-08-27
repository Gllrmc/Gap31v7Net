using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Jerarquia;
using Sistema.Web.Models.Jerarquia;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class RubrosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RubrosController(DbContextSistema context)
        {
            _context = context;
        }
        // GET: api/Rubros/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RubroViewModel>> Listar()
        {
            var rubro = await _context.Rubros.ToListAsync();

            return rubro.Select(r => new RubroViewModel
            {
                idrubro = r.idrubro,
                rubroes = r.rubroes,
                rubroen = r.rubroen,
                orden = r.orden,
                activo = r.activo
            });

        }
        // GET: api/Rubros/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<RubroSelectModel>> Select()
        {
            var rubro = await _context.Rubros.Where(r => r.activo == true)
                .OrderBy(r => r.idrubro)
                .ToListAsync();

            return rubro.Select(r => new RubroSelectModel
            {
                idrubro = r.idrubro,
                orden = r.orden,
                rubroes = r.rubroes,
                rubroen = r.rubroen,
            });
        }

        // GET: api/Rubros/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var rubro = await _context.Rubros.FindAsync(id);

            if (rubro == null)
            {
                return NotFound();
            }

            return Ok(new RubroViewModel
            {
                idrubro = rubro.idrubro,
                rubroes = rubro.rubroes,
                rubroen = rubro.rubroen,
                orden = rubro.orden,
                activo = rubro.activo
            });
        }

        // PUT: api/Rubros/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] RubroUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idrubro <= 0)
            {
                return BadRequest();
            }

            var rubro = await _context.Rubros.FirstOrDefaultAsync(c => c.idrubro == model.idrubro);

            if (rubro == null)
            {
                return NotFound();
            }

            rubro.rubroes = model.rubroes;
            rubro.rubroen = model.rubroen;
            rubro.orden = model.orden;
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

        // POST: api/Rubros/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] RubroCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rubro rubro = new Rubro
            {
                rubroes = model.rubroes,
                rubroen = model.rubroen,
                orden = model.orden,
                activo = true
            };

            _context.Rubros.Add(rubro);
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

        // DELETE: api/Rubros/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rubro = await _context.Rubros.FindAsync(id);
            if (rubro == null)
            {
                return NotFound();
            }

            _context.Rubros.Remove(rubro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(rubro);
        }

        // PUT: api/Rubros/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var rubro = await _context.Rubros.FirstOrDefaultAsync(c => c.idrubro == id);

            if (rubro == null)
            {
                return NotFound();
            }

            rubro.activo = false;

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

        // PUT: api/Rubros/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var rubro = await _context.Rubros.FirstOrDefaultAsync(c => c.idrubro == id);

            if (rubro == null)
            {
                return NotFound();
            }

            rubro.activo = true;

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


        private bool RubroExists(int id)
        {
            return _context.Rubros.Any(e => e.idrubro == id);
        }
    }
}
