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
using Sistema.Web.Models.Maestros.Agencias;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController] 
    public class AgenciasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public AgenciasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Agencias/Listar
        [HttpGet("[action]")] 
        public async Task<IEnumerable<AgenciaViewModel>> Listar()
        {
            var Agencia = await _context.Agencias.ToListAsync();

            return Agencia.Select(r => new AgenciaViewModel
            {
                idagencia = r.idagencia,
                agencia = r.agencia,
                activo = r.activo
            });

        }

        // GET: api/Agencias/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<AgenciaSelectModel>> Select()
        {
            var agencia = await _context.Agencias.Where(r => r.activo == true).OrderBy(r => r.agencia).ToListAsync();

            return agencia.Select(r => new AgenciaSelectModel
            {
                idagencia = r.idagencia,
                agencia = r.agencia
            });
        }

        // GET: api/Agencias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var agencia = await _context.Agencias.FindAsync(id);

            if (agencia == null)
            {
                return NotFound();
            }

            return Ok(new AgenciaViewModel
            {
                idagencia = agencia.idagencia,
                agencia = agencia.agencia
            });
        }

        // PUT: api/Agencias/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] AgenciaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idagencia <= 0)
            {
                return BadRequest();
            }

            var agencia = await _context.Agencias.FirstOrDefaultAsync(c => c.idagencia == model.idagencia);

            if (agencia == null)
            {
                return NotFound();
            }

            agencia.agencia = model.agencia;

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

        // POST: api/Agencias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] AgenciaCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Agencia agencia = new Agencia
            {
                agencia = model.agencia,
                activo = true
            };

            _context.Agencias.Add(agencia);
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

        // DELETE: api/Agencias/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agencia = await _context.Agencias.FindAsync(id);
            if (agencia == null)
            {
                return NotFound();
            }

            _context.Agencias.Remove(agencia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(agencia);
        }

        // PUT: api/Agencias/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var agencia = await _context.Agencias.FirstOrDefaultAsync(c => c.idagencia == id);

            if (agencia == null)
            {
                return NotFound();
            }

            agencia.activo = false;

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

        // PUT: api/Agencias/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var agencia = await _context.Agencias.FirstOrDefaultAsync(c => c.idagencia == id);

            if (agencia == null)
            {
                return NotFound();
            }

            agencia.activo = true;

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


        private bool AgenciaExists(int id)
        {
            return _context.Agencias.Any(e => e.idagencia == id);
        }
    }
}
