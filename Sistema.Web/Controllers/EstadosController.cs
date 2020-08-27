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
using Sistema.Web.Models.Maestros.Estados;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public EstadosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Estados/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<EstadoViewModel>> Listar()
        {
            var Estado = await _context.Estados.ToListAsync();

            return Estado.Select(r => new EstadoViewModel
            {
                idestado = r.idestado,
                estado = r.estado,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Estados/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<EstadoSelectModel>> Select()
        {
            var estado = await _context.Estados.Where(r => r.activo == true).OrderBy(r => r.estado).ToListAsync();

            return estado.Select(r => new EstadoSelectModel
            {
                idestado = r.idestado,
                estado = r.estado
            });
        }

        // GET: api/Estados/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var estado = await _context.Estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return Ok(new EstadoViewModel
            {
                idestado = estado.idestado,
                iduseralta = estado.iduseralta,
                fecalta = estado.fecalta,
                iduserumod = estado.iduserumod,
                fecumod = estado.fecumod,
                activo = estado.activo
            });
        }

        // PUT: api/Estados/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] EstadoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idestado <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var estado = await _context.Estados.FirstOrDefaultAsync(c => c.idestado == model.idestado);

            if (estado == null)
            {
                return NotFound();
            }

            estado.estado = model.estado;
            estado.iduserumod = model.iduserumod;
            estado.fecumod = fechaHora;

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

        // POST: api/Estados/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] EstadoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Estado estado = new Estado
            {
                estado = model.estado,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Estados.Add(estado);
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

        // DELETE: api/Estados/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(estado);
        }

        // PUT: api/Estados/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var estado = await _context.Estados.FirstOrDefaultAsync(c => c.idestado == id);

            if (estado == null)
            {
                return NotFound();
            }

            estado.activo = false;

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

        // PUT: api/Estados/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var estado = await _context.Estados.FirstOrDefaultAsync(c => c.idestado == id);

            if (estado == null)
            {
                return NotFound();
            }

            estado.activo = true;

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

        private bool EstadoExists(int id)
        {
            return _context.Estados.Any(e => e.idestado == id);
        }
    }
}
