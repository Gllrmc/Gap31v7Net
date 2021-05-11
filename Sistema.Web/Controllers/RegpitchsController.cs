using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Limbos;
using Sistema.Web.Models.Limbos;

namespace Sistema.Web.Controllers
{
    //[Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class RegpitchsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RegpitchsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Regpitchs/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RegpitchViewModel>> Listar()
        {
            var Regpitch = await _context.Regpitchs
            .Include(p => p.limbo)
            .ToListAsync();

            return Regpitch.Select(r => new RegpitchViewModel
            {
                idregpitch = r.idregpitch,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numregpitch = r.numregpitch,
                fecregpitch = r.fecregpitch,
                impregpitch = r.impregpitch,
                pdfregpitch = r.pdfregpitch,
                nota = r.nota,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Regpitchs/ListarLimbo
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<RegpitchViewModel>> ListarLimbo([FromRoute] int id)
        {
            var Regpitch = await _context.Regpitchs
                .Include(p => p.limbo)
                .Where(p => p.idlimbo == id)
                .ToListAsync();

            return Regpitch.Select(r => new RegpitchViewModel
            {
                idregpitch = r.idregpitch,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numregpitch = r.numregpitch,
                fecregpitch = r.fecregpitch,
                impregpitch = r.impregpitch,
                pdfregpitch = r.pdfregpitch,
                nota = r.nota,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Regpitchs/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<RegpitchSelectModel>> Select()
        {
            var regpitch = await _context.Regpitchs
                .Include(p => p.limbo)
                .Where(r => r.activo == true)
                .OrderBy(r => r.idregpitch)
                .ToListAsync();

            return regpitch.Select(r => new RegpitchSelectModel
            {
                idregpitch = r.idregpitch,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numregpitch = r.numregpitch,
                fecregpitch = r.fecregpitch,
                impregpitch = r.impregpitch
            });
        }

        // GET: api/Regpitchs/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var regpitch = await _context.Regpitchs.FindAsync(id);

            if (regpitch == null)
            {
                return NotFound();
            }

            return Ok(new RegpitchViewModel
            {
                idregpitch = regpitch.idregpitch,
                idlimbo = regpitch.idlimbo,
                numregpitch = regpitch.numregpitch,
                fecregpitch = regpitch.fecregpitch,
                impregpitch = regpitch.impregpitch,
                pdfregpitch = regpitch.pdfregpitch,
                nota = regpitch.nota,
                iduseralta = regpitch.iduseralta,
                fecalta = regpitch.fecalta,
                iduserumod = regpitch.iduserumod,
                fecumod = regpitch.fecumod,
                activo = regpitch.activo
            });
        }

        // PUT: api/Regpitchs/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] RegpitchUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idregpitch <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var regpitch = await _context.Regpitchs.FirstOrDefaultAsync(c => c.idregpitch == model.idregpitch);

            if (regpitch == null)
            {
                return NotFound();
            }

            regpitch.fecregpitch = model.fecregpitch;
            regpitch.impregpitch = model.impregpitch;
            regpitch.pdfregpitch = model.pdfregpitch;
            regpitch.nota = model.nota;
            regpitch.iduserumod = model.iduserumod;
            regpitch.fecumod = fechaHora;

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

        // POST: api/Regpitchs/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] RegpitchCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            int numregpitch = _context.Regpitchs
                .Where(p => p.idlimbo == model.idlimbo)
                .Max(x => (int?)x.numregpitch) ?? 0;

            Regpitch regpitch = new Regpitch
            {
                idlimbo = model.idlimbo,
                numregpitch = numregpitch + 1,
                fecregpitch = model.fecregpitch,
                impregpitch = model.impregpitch,
                pdfregpitch = model.pdfregpitch,
                nota = model.nota,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Regpitchs.Add(regpitch);
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

        // DELETE: api/Regpitchs/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var regpitch = await _context.Regpitchs.FindAsync(id);
            if (regpitch == null)
            {
                return NotFound();
            }

            _context.Regpitchs.Remove(regpitch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(regpitch);
        }

        // PUT: api/Regpitchs/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var regpitch = await _context.Regpitchs.FirstOrDefaultAsync(c => c.idregpitch == id);

            if (regpitch == null)
            {
                return NotFound();
            }

            regpitch.activo = false;

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

        // PUT: api/Regpitchs/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var regpitch = await _context.Regpitchs.FirstOrDefaultAsync(c => c.idregpitch == id);

            if (regpitch == null)
            {
                return NotFound();
            }

            regpitch.activo = true;

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


        private bool RegpitchExists(int id)
        {
            return _context.Regpitchs.Any(e => e.idregpitch == id);
        }

    }
}
