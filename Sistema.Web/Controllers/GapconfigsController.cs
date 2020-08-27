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
using Sistema.Web.Models.Maestros.Gapconfig;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class GapconfigsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public GapconfigsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Gapconfigs/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GapconfigViewModel>> Listar()
        {
            var gapconfig = await _context.Gapconfigs.ToListAsync();

            return gapconfig.Select(r => new GapconfigViewModel
            {
                id = r.id,
                parametro = r.parametro,
                valor = r.valor,
                texto = r.texto
            });

        }

        // PUT: api/Gapconfigs/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] GapconfigUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id <= 0)
            {
                return BadRequest();
            }

            var gapconfig = await _context.Gapconfigs.FirstOrDefaultAsync(c => c.id == model.id);

            if (gapconfig == null)
            {
                return NotFound();
            }

            gapconfig.parametro = model.parametro;
            gapconfig.valor = model.valor;
            gapconfig.texto = model.texto;

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

        // POST: api/Gapconfigs/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] GapconfigCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Gapconfig gapconfig = new Gapconfig
            {
                parametro = model.parametro,
                valor = model.valor,
                texto = model.texto
            };

            _context.Gapconfigs.Add(gapconfig);
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

        // DELETE: api/Gapconfigs/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gapconfig = await _context.Paises.FindAsync(id);
            if (gapconfig == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(gapconfig);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(gapconfig);
        }

        private bool GapconfigExists(int id)
        {
            return _context.Gapconfigs.Any(e => e.id == id);
        }
    }
}
