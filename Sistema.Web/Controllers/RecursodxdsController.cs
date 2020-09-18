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
    public class RecursodxdsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RecursodxdsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Recursodxds/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RecursodxdViewModel>> Listar()
        {
            var recursodxd = await _context.Recursodxds
                .Include(p => p.proyecto)
                .Where(p => p.proyecto.activo == true)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.crew)
                .ThenInclude(p => p.persona)
                .AsNoTracking()
                .ToListAsync();

            return recursodxd.Select(a => new RecursodxdViewModel
            {
                idrecursodxd = a.idrecursodxd,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                itemen = a.item.itemen,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitem.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitem.subitemes : "",
                subitemen = a.idsubitem.HasValue ? a.subitem.subitemen : "",
                idcrew = a.idcrew,
                nombre = a.crew.persona.nombre,
                cuil = a.crew.cuil,
                sindicato = a.crew.sindicato,
                idcont = a.idcont,
                fecdesde = a.fecdesde,
                fechasta = a.fechasta,
                dias8hs = a.dias8hs,
                dias12hs = a.dias12hs,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            }) ;

        }

        // GET: api/Recursodxds/ListarProyecto/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<RecursodxdViewModel>> ListarProyecto([FromRoute] int id)
        {
            var recursodxd = await _context.Recursodxds
                .Include(p => p.proyecto)
                .Where(p => p.idproyecto == id)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.crew)
                .ThenInclude(p => p.persona)
                .Where(p => p.proyecto.activo == true)
                .AsNoTracking()
                .ToListAsync();

            return recursodxd.Select(a => new RecursodxdViewModel
            {
                idrecursodxd = a.idrecursodxd,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                itemen = a.item.itemen,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitem.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitem.subitemes : "",
                subitemen = a.idsubitem.HasValue ? a.subitem.subitemen : "",
                idcrew = a.idcrew,
                nombre = a.crew.persona.nombre,
                cuil = a.crew.cuil,
                sindicato = a.crew.sindicato,
                idcont = a.idcont,
                fecdesde = a.fecdesde,
                fechasta = a.fechasta,
                dias8hs = a.dias8hs,
                dias12hs = a.dias12hs,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Recursodxds/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var recursodxd = await _context.Recursodxds
                .Include(p => p.proyecto)
                .Where(p => p.idproyecto == id)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.crew)
                .ThenInclude(p => p.persona)
                .Where(p => p.proyecto.activo == true)
                .SingleOrDefaultAsync(a => a.idrecursodxd == id);

            if (recursodxd == null)
            {
                return NotFound();
            }

            return Ok(new RecursodxdViewModel
            {
                idrecursodxd = recursodxd.idrecursodxd,
                idproyecto = recursodxd.idproyecto,
                proyectoorden = recursodxd.proyecto.orden,
                proyecto = recursodxd.proyecto.proyecto,
                iditem = recursodxd.iditem,
                itemorden = recursodxd.item.orden,
                itemes = recursodxd.item.itemes,
                itemen = recursodxd.item.itemen,
                idsubitem = recursodxd.idsubitem,
                subitemorden = recursodxd.idsubitem.HasValue ? recursodxd.subitem.orden : "",
                subitemes = recursodxd.idsubitem.HasValue ? recursodxd.subitem.subitemes : "",
                subitemen = recursodxd.idsubitem.HasValue ? recursodxd.subitem.subitemen : "",
                idcrew = recursodxd.idcrew,
                nombre = recursodxd.crew.persona.nombre,
                cuil = recursodxd.crew.cuil,
                sindicato = recursodxd.crew.sindicato,
                idcont = recursodxd.idcont,
                fecdesde = recursodxd.fecdesde,
                fechasta = recursodxd.fechasta,
                dias8hs = recursodxd.dias8hs,
                dias12hs = recursodxd.dias12hs,
                iduseralta = recursodxd.iduseralta,
                fecalta = recursodxd.fecalta,
                iduserumod = recursodxd.iduserumod,
                fecumod = recursodxd.fecumod,
                activo = recursodxd.activo
            });
        }

        // PUT: api/Recursodxds/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] RecursodxdUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idrecursodxd <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var recursodxd = await _context.Recursodxds.FirstOrDefaultAsync(a => a.idrecursodxd == model.idrecursodxd);

            if (recursodxd == null)
            {
                return NotFound();
            }
            recursodxd.idrecursodxd = model.idrecursodxd;
            recursodxd.idproyecto = model.idproyecto;
            recursodxd.iditem = model.iditem;
            recursodxd.idsubitem = model.idsubitem;
            recursodxd.idcrew = model.idcrew;
            recursodxd.idcont = model.idcont;
            recursodxd.fecdesde = model.fecdesde;
            recursodxd.fechasta = model.fechasta;
            recursodxd.dias8hs = model.dias8hs;
            recursodxd.dias12hs = model.dias12hs;
            recursodxd.iduseralta = model.iduseralta;
            recursodxd.fecalta = model.fecalta;
            recursodxd.iduserumod = model.iduserumod;
            recursodxd.fecumod = fechaHora;
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

        // POST: api/Recursodxds/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] RecursodxdCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            var numorden = _context.Garantias.Where(p => p.idproyecto == model.idproyecto).Max(x => (int?)x.numorden) ?? 0;

            Recursodxd recursodxd = new Recursodxd
            {
                idproyecto = model.idproyecto,
                iditem = model.iditem,
                idsubitem = model.idsubitem,
                idcrew = model.idcrew,
                idcont = numorden + 1,
                fecdesde = model.fecdesde,
                fechasta = model.fechasta,
                dias8hs = model.dias8hs,
                dias12hs = model.dias12hs,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Recursodxds.Add(recursodxd);
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


        // PUT: api/Recursodxds/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var recursodxd = await _context.Recursodxds.FirstOrDefaultAsync(a => a.idrecursodxd == id);

            if (recursodxd == null)
            {
                return NotFound();
            }

            recursodxd.activo = false;

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

        // PUT: api/Recursodxds/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var recursodxd = await _context.Recursodxds.FirstOrDefaultAsync(a => a.idrecursodxd == id);

            if (recursodxd == null)
            {
                return NotFound();
            }

            recursodxd.activo = true;

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

        private bool RecursodxdExists(int id)
        {
            return _context.Recursodxds.Any(e => e.idrecursodxd == id);
        }
    }
}
