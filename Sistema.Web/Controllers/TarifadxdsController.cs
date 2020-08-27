using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Daybyday;
using Sistema.Web.Models.Daybyday;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class TarifadxdsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TarifadxdsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Tarifadxds/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TarifadxdViewModel>> Listar()
        {
            var tarifadxd = await _context.Tarifadxds
                .Include(a => a.proyecto)
                .Include(a => a.item)
                .Include(a => a.sica)
                .AsNoTracking()
                .ToListAsync();

            return tarifadxd.Select(a => new TarifadxdViewModel
            {
                idtarifadxd = a.idtarifadxd,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                itemen = a.item.itemen,
                idsica = a.idsica,
                cargosica = a.sica.cargo + ' ' + a.sica.asignacion,
                bruto8hs = a.bruto8hs,
                extra4hs = a.extra4hs,
                bruto12hs = a.bruto12hs,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Tarifadxds/ListarProyecto/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<TarifadxdViewModel>> ListarProyecto([FromRoute] int id)
        {
            var tarifadxd = await _context.Tarifadxds
                .Include(a => a.proyecto)
                .Include(a => a.item)
                .Include(a => a.sica)
                .Where(a => a.idproyecto == id)
                .AsNoTracking()
                .ToListAsync();

            return tarifadxd.Select(a => new TarifadxdViewModel
            {
                idtarifadxd = a.idtarifadxd,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                itemen = a.item.itemen,
                idsica = a.idsica,
                cargosica = a.sica.cargo + ' ' + a.sica.asignacion,
                bruto8hs = a.bruto8hs,
                extra4hs = a.extra4hs,
                bruto12hs = a.bruto12hs,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Tarifadxds/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<TarifadxdSelectModel>> Select()
        {
            var tarifadxd = await _context.Tarifadxds
                .Include(a => a.proyecto)
                .Include(a => a.item)
                .Include(a => a.sica)
                .Where(a => a.activo == true)
                .ToListAsync();

            return tarifadxd.Select(a => new TarifadxdSelectModel
            {
                idtarifadxd = a.idtarifadxd,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                itemen = a.item.itemen,
                idsica = a.idsica,
                cargosica = a.sica.cargo + ' ' + a.sica.asignacion,
                bruto8hs = a.bruto8hs,
                extra4hs = a.extra4hs,
                bruto12hs = a.bruto12hs
            });
        }


        // GET: api/Tarifadxds/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var tarifadxd = await _context.Tarifadxds
                .Include(a => a.proyecto)
                .Include(a => a.item)
                .Include(a => a.sica)
                .SingleOrDefaultAsync(a => a.idtarifadxd == id);

            if (tarifadxd == null)
            {
                return NotFound();
            }

            return Ok(new TarifadxdViewModel
            {
                idtarifadxd = tarifadxd.idtarifadxd,
                idproyecto = tarifadxd.idproyecto,
                iditem = tarifadxd.iditem,
                idsica = tarifadxd.idsica,
                cargosica = tarifadxd.sica.cargo + ' ' + tarifadxd.sica.asignacion,
                bruto8hs = tarifadxd.bruto8hs,
                extra4hs = tarifadxd.extra4hs,
                bruto12hs = tarifadxd.bruto12hs,
                iduseralta = tarifadxd.iduseralta,
                fecalta = tarifadxd.fecalta,
                iduserumod = tarifadxd.iduserumod,
                fecumod = tarifadxd.fecumod,
                activo = tarifadxd.activo
            });
        }

        // PUT: api/Tarifadxds/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] TarifadxdUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idtarifadxd <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var tarifadxd = await _context.Tarifadxds.FirstOrDefaultAsync(a => a.iditem == model.iditem);

            if (tarifadxd == null)
            {
                return NotFound();
            }

            tarifadxd.idtarifadxd = model.idtarifadxd;
            tarifadxd.idproyecto = model.idproyecto;
            tarifadxd.iditem = model.iditem;
            tarifadxd.idsica = model.idsica;
            tarifadxd.bruto8hs = model.bruto8hs;
            tarifadxd.bruto12hs = model.bruto12hs;
            tarifadxd.extra4hs = model.extra4hs;
            tarifadxd.iduseralta = model.iduseralta;
            tarifadxd.fecalta = model.fecalta;
            tarifadxd.iduserumod = model.iduserumod;
            tarifadxd.fecumod = fechaHora;
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

        // POST: api/Tarifadxds/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] TarifadxdCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Tarifadxd tarifadxd = new Tarifadxd
            {
                idproyecto = model.idproyecto,
                iditem = model.iditem,
                idsica = model.idsica,
                bruto8hs = model.bruto8hs,
                bruto12hs = model.bruto12hs,
                extra4hs = model.extra4hs,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true

            };

            try
            {
                _context.Tarifadxds.Add(tarifadxd);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Tarifadxds/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tarifadxd = await _context.Tarifadxds.FirstOrDefaultAsync(c => c.iditem == id);

            if (tarifadxd == null)
            {
                return NotFound();
            }

            tarifadxd.activo = false;

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

        // PUT: api/Tarifadxds/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tarifadxd = await _context.Tarifadxds.FirstOrDefaultAsync(c => c.iditem == id);

            if (tarifadxd == null)
            {
                return NotFound();
            }

            tarifadxd.activo = true;

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

        private bool TarifadxdExists(int id)
        {
            return _context.Tarifadxds.Any(e => e.idtarifadxd == id);
        }
    }
}
