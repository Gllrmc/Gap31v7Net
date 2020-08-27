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
using Sistema.Web.Models.Maestros.Territorios;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoriosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TerritoriosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Territorios/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TerritorioViewModel>> Listar()
        {
            var territorio = await _context.Territorios.ToListAsync();

            return territorio.Select(r => new TerritorioViewModel
            {
                idterritorio = r.idterritorio,
                territorio = r.territorio,
                activo = r.activo
            });

        }

        // GET: api/Territorios/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<TerritorioSelectModel>> Select()
        {
            var territorio = await _context.Territorios
                .Where(r => r.activo == true)
                .OrderBy(r => r.territorio)
                .ToListAsync();

            return territorio.Select(r => new TerritorioSelectModel
            {
                idterritorio = r.idterritorio,
                territorio = r.territorio
            });
        }

        // GET: api/Territorios/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var territorio = await _context.Territorios.FindAsync(id);

            if (territorio == null)
            {
                return NotFound();
            }

            return Ok(new TerritorioViewModel
            {
                idterritorio = territorio.idterritorio,
                territorio = territorio.territorio
            });
        }

        // PUT: api/Territorios/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] TerritorioUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idterritorio <= 0)
            {
                return BadRequest();
            }

            var territorio = await _context.Territorios.FirstOrDefaultAsync(c => c.idterritorio == model.idterritorio);

            if (territorio == null)
            {
                return NotFound();
            }

            territorio.territorio = model.territorio;

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

        // POST: api/Territorios/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] TerritorioCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Territorio territorio = new Territorio
            {
                territorio = model.territorio,
                activo = true
            };

            _context.Territorios.Add(territorio);
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

        // DELETE: api/Territorios/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var territorio = await _context.Territorios.FindAsync(id);
            if (territorio == null)
            {
                return NotFound();
            }

            _context.Territorios.Remove(territorio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(territorio);
        }

        // PUT: api/Territorios/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var territorio = await _context.Territorios.FirstOrDefaultAsync(c => c.idterritorio == id);

            if (territorio == null)
            {
                return NotFound();
            }

            territorio.activo = false;

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

        // PUT: api/Territorios/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var territorio = await _context.Territorios.FirstOrDefaultAsync(c => c.idterritorio == id);

            if (territorio == null)
            {
                return NotFound();
            }

            territorio.activo = true;

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


        private bool TerritorioExists(int id)
        {
            return _context.Territorios.Any(e => e.idterritorio == id);
        }
    }
}
