using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Jerarquia;
using Sistema.Web.Models.Jerarquia;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubitemsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public SubitemsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Subitems/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SubitemViewModel>> Listar()
        {
            var subitem = await _context.Subitems.Include(a => a.item).Where(i => i.item.activo == true)
                .OrderBy(a => a.orden)
                .ToListAsync();

            return subitem.Select(a => new SubitemViewModel
            {
                idsubitem = a.idsubitem,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                itemen = a.item.itemen,
                subitemes = a.subitemes,
                subitemen = a.subitemen,
                orden = a.orden,
                activo = a.activo
            });

        }

        // GET: api/Subitems/SelectItems
        [HttpGet("[action]")]
        public async Task<IEnumerable<ItemSelectModel>> SelectItems()
        {
            var item = await _context.Items.Where(i => i.activo == true && i.tienesubitems == true).ToListAsync();

            return item.Select(r => new ItemSelectModel
            {
                iditem = r.iditem,
                orden = r.orden,
                itemes = r.itemes,
                itemen = r.itemen
            });

        }
        // GET: api/Subitems/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SubitemSelectModel>> Select()
        {
            var subitem = await _context.Subitems
                .Where(r => r.activo == true)
                .ToListAsync();

            return subitem.Select(r => new SubitemSelectModel
            {
                idsubitem = r.idsubitem,
                iditem = r.iditem,
                orden = r.orden,
                subitemes = r.subitemes,
                subitemen = r.subitemen
            });
        }

        // GET: api/Subitems/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var subitem = await _context.Subitems.Include(a => a.item).
                            SingleOrDefaultAsync(a => a.iditem == id);

            if (subitem == null)
            {
                return NotFound();
            }

            return Ok(new SubitemViewModel
            {
                idsubitem = subitem.idsubitem,
                iditem = subitem.iditem,
                subitemes = subitem.subitemes,
                subitemen = subitem.subitemen,
                orden = subitem.orden,
                activo = subitem.activo
            });
        }

        // PUT: api/Subitems/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] SubitemUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idsubitem <= 0)
            {
                return BadRequest();
            }

            var subitem = await _context.Subitems.FirstOrDefaultAsync(a => a.idsubitem == model.idsubitem);

            if (subitem == null)
            {
                return NotFound();
            }

            subitem.iditem = model.iditem;
            subitem.subitemes = model.subitemes;
            subitem.subitemen = model.subitemen;
            subitem.orden = model.orden;

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

        // POST: api/Subitems/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] SubitemCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subitem subitem = new Subitem
            {
                iditem = model.iditem,
                subitemes = model.subitemes,
                subitemen = model.subitemen,
                orden = model.orden,
                activo = true
            };

            _context.Subitems.Add(subitem);
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

        // PUT: api/Sububros/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var subitem = await _context.Subitems.FirstOrDefaultAsync(c => c.idsubitem == id);

            if (subitem == null)
            {
                return NotFound();
            }

            subitem.activo = false;

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

        // PUT: api/Subitems/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var subitem = await _context.Subitems.FirstOrDefaultAsync(c => c.idsubitem == id);

            if (subitem == null)
            {
                return NotFound();
            }

            subitem.activo = true;

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

        private bool SubitemExists(int id)
        {
            return _context.Subitems.Any(e => e.idsubitem == id);
        }
    }
}
