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
using Sistema.Web.Models.Maestros.Paises;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PaisesController(DbContextSistema context)
        {
            _context = context;
        }
        // GET: api/Paises/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PaisViewModel>> Listar()
        {
            var pais = await _context.Paises.ToListAsync();

            return pais.Select(r => new PaisViewModel
            {
                idpais = r.idpais,
                pais = r.pais,
                cuit = r.cuit,
                activo = r.activo
            });

        }

        // GET: api/Paises/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<PaisSelectModel>> Select()
        {
            var pais = await _context.Paises
                .Where(r => r.activo == true)
                .OrderBy(r => r.pais)
                .ToListAsync();

            return pais.Select(r => new PaisSelectModel
            {
                idpais = r.idpais,
                pais = r.pais,
                cuit = r.cuit
            });
        }

        // GET: api/Paises/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var pais = await _context.Paises.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return Ok(new PaisViewModel
            {
                idpais = pais.idpais,
                pais = pais.pais,
                cuit = pais.cuit
            });
        }

        // PUT: api/Paises/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PaisUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idpais <= 0)
            {
                return BadRequest();
            }

            var pais = await _context.Paises.FirstOrDefaultAsync(c => c.idpais == model.idpais);

            if (pais == null)
            {
                return NotFound();
            }

            pais.pais = model.pais;
            pais.cuit = model.cuit;

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

        // POST: api/Paises/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] PaisCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pais pais = new Pais
            {
                pais = model.pais,
                cuit = model.cuit,
                activo = true
            };

            _context.Paises.Add(pais);
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

        // DELETE: api/Paises/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(pais);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(pais);
        }

        // PUT: api/Paises/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var pais = await _context.Paises.FirstOrDefaultAsync(c => c.idpais == id);

            if (pais == null)
            {
                return NotFound();
            }

            pais.activo = false;

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

        // PUT: api/Paises/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var pais = await _context.Paises.FirstOrDefaultAsync(c => c.idpais == id);

            if (pais == null)
            {
                return NotFound();
            }

            pais.activo = true;

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


        private bool PaisExists(int id)
        {
            return _context.Paises.Any(e => e.idpais == id);
        }
    }
}
