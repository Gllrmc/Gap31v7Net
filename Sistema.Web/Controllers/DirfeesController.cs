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
    public class DirfeesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public DirfeesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Dirfees/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<DirfeeViewModel>> Listar()
        {
            var Dirfee = await _context.Dirfees
            .Include(p => p.limbo)
            .ToListAsync();

            return Dirfee.Select(r => new DirfeeViewModel
            {
                iddirfee = r.iddirfee,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numdirfee = r.numdirfee,
                fecdirfee = r.fecdirfee,
                impdirfee = r.impdirfee,
                pdfdirfee = r.pdfdirfee,
                nota = r.nota,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Dirfees/ListarLimbo
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<DirfeeViewModel>> ListarLimbo([FromRoute] int id)
        {
            var Dirfee = await _context.Dirfees
                .Include(p => p.limbo)
                .Where(p => p.idlimbo == id)
                .ToListAsync();

            return Dirfee.Select(r => new DirfeeViewModel
            {
                iddirfee = r.iddirfee,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numdirfee = r.numdirfee,
                fecdirfee = r.fecdirfee,
                impdirfee = r.impdirfee,
                pdfdirfee = r.pdfdirfee,
                nota = r.nota,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Dirfees/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<DirfeeSelectModel>> Select()
        {
            var dirfee = await _context.Dirfees
                .Include(p => p.limbo)
                .Where(r => r.activo == true)
                .OrderBy(r => r.iddirfee)
                .ToListAsync();

            return dirfee.Select(r => new DirfeeSelectModel
            {
                iddirfee = r.iddirfee,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numdirfee = r.numdirfee,
                fecdirfee = r.fecdirfee,
                impdirfee = r.impdirfee
            });
        }

        // GET: api/Dirfees/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var dirfee = await _context.Dirfees.FindAsync(id);

            if (dirfee == null)
            {
                return NotFound();
            }

            return Ok(new DirfeeViewModel
            {
                iddirfee = dirfee.iddirfee,
                idlimbo = dirfee.idlimbo,
                numdirfee = dirfee.numdirfee,
                fecdirfee = dirfee.fecdirfee,
                impdirfee = dirfee.impdirfee,
                pdfdirfee = dirfee.pdfdirfee,
                nota = dirfee.nota,
                iduseralta = dirfee.iduseralta,
                fecalta = dirfee.fecalta,
                iduserumod = dirfee.iduserumod,
                fecumod = dirfee.fecumod,
                activo = dirfee.activo
            });
        }

        // PUT: api/Dirfees/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] DirfeeUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.iddirfee <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var dirfee = await _context.Dirfees.FirstOrDefaultAsync(c => c.iddirfee == model.iddirfee);

            if (dirfee == null)
            {
                return NotFound();
            }

            dirfee.fecdirfee = model.fecdirfee;
            dirfee.impdirfee = model.impdirfee;
            dirfee.pdfdirfee = model.pdfdirfee;
            dirfee.nota = model.nota;
            dirfee.iduserumod = model.iduserumod;
            dirfee.fecumod = fechaHora;

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

        // POST: api/Dirfees/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] DirfeeCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            int numdirfee = _context.Dirfees
                .Where(p => p.idlimbo == model.idlimbo)
                .Max(x => (int?)x.numdirfee) ?? 0;

            Dirfee dirfee = new Dirfee
            {
                idlimbo = model.idlimbo,
                numdirfee = numdirfee + 1,
                fecdirfee = model.fecdirfee,
                impdirfee = model.impdirfee,
                pdfdirfee = model.pdfdirfee,
                nota = model.nota,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Dirfees.Add(dirfee);
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

        // DELETE: api/Dirfees/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dirfee = await _context.Dirfees.FindAsync(id);
            if (dirfee == null)
            {
                return NotFound();
            }

            _context.Dirfees.Remove(dirfee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(dirfee);
        }

        // PUT: api/Dirfees/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var dirfee = await _context.Dirfees.FirstOrDefaultAsync(c => c.iddirfee == id);

            if (dirfee == null)
            {
                return NotFound();
            }

            dirfee.activo = false;

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

        // PUT: api/Dirfees/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var dirfee = await _context.Dirfees.FirstOrDefaultAsync(c => c.iddirfee == id);

            if (dirfee == null)
            {
                return NotFound();
            }

            dirfee.activo = true;

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


        private bool DirfeeExists(int id)
        {
            return _context.Dirfees.Any(e => e.iddirfee == id);
        }

    }
}
