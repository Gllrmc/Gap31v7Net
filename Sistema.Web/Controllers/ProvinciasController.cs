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
using Sistema.Web.Models.Maestros.Provincias;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ProvinciasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Provincias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProvinciaViewModel>> Listar()
        {
            var provincia = await _context.Provincias.ToListAsync();

            return provincia.Select(r => new ProvinciaViewModel
            {
                idprovincia = r.idprovincia,
                provincia = r.provincia,
                activo = r.activo
            });

        }

        // GET: api/Provincias/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProvinciaSelectModel>> Select()
        {
            var provincia = await _context.Provincias
                .Where(r => r.activo == true)
                .OrderBy(r => r.provincia)
                .ToListAsync();

            return provincia.Select(r => new ProvinciaSelectModel
            {
                idprovincia = r.idprovincia,
                provincia = r.provincia
            });
        }

        // GET: api/Provincias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var provincia = await _context.Provincias.FindAsync(id);

            if (provincia == null)
            {
                return NotFound();
            }

            return Ok(new ProvinciaViewModel
            {
                idprovincia = provincia.idprovincia,
                provincia = provincia.provincia
            });
        }

        // PUT: api/Provincias/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProvinciaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idprovincia <= 0)
            {
                return BadRequest();
            }

            var provincia = await _context.Provincias.FirstOrDefaultAsync(c => c.idprovincia == model.idprovincia);

            if (provincia == null)
            {
                return NotFound();
            }

            provincia.provincia = model.provincia;

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

        // POST: api/Provicnias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ProvinciaCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Provincia provincia = new Provincia
            {
                provincia = model.provincia,
                activo = true
            };

            _context.Provincias.Add(provincia);
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

        // DELETE: api/Provincias/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }

            _context.Provincias.Remove(provincia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(provincia);
        }

        // PUT: api/Provincias/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var provincia = await _context.Provincias.FirstOrDefaultAsync(c => c.idprovincia == id);

            if (provincia == null)
            {
                return NotFound();
            }

            provincia.activo = false;

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

        // PUT: api/Provincias/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var provincia = await _context.Provincias.FirstOrDefaultAsync(c => c.idprovincia == id);

            if (provincia == null)
            {
                return NotFound();
            }

            provincia.activo = true;

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


        private bool ProvinciaExists(int id)
        {
            return _context.Provincias.Any(e => e.idprovincia == id);
        }
    }
}
