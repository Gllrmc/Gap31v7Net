using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
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
    //[Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ItemsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Items/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ItemViewModel>> Listar()
        {
            var item = await _context.Items
                .Include(a => a.subrubros)
                .ToListAsync();

            return item.Select(a => new ItemViewModel
            {
                iditem = a.iditem,
                idsubrubro = a.idsubrubro,
                subrubroorden = a.subrubros.orden,
                subrubroes = a.subrubros.subrubroes,
                subrubroen = a.subrubros.subrubroen,
                itemes = a.itemes,
                itemen = a.itemen,
                orden = a.orden,
                esdxd = a.esdxd,
                espost = a.espost,
                esmotion = a.esmotion,
                tienesubitems = a.tienesubitems,
                cuentagcom = a.cuentagcom,
                vivo = a.subrubros.vivo,
                post = a.subrubros.post,
                conf = a.subrubros.conf,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Items/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ItemSelectModel>> Select()
        {
            var item = await _context.Items
                .Include(r => r.subrubros)
                .Where(r => r.activo == true)
                .OrderBy(r => r.orden)
                .ToListAsync();

            return item.Select(r => new ItemSelectModel
            {
                iditem = r.iditem,
                orden = r.orden,
                itemes = r.itemes,
                itemen = r.itemen,
                item = String.Concat(r.orden.PadLeft(3,'0'),"-",r.itemes),
                vivo = r.subrubros.vivo,
                post = r.subrubros.post,
                conf = r.subrubros.conf,
                cuentagcom = r.cuentagcom
            });
        }

        // GET: api/Items/SelectGastos
        [HttpGet("[action]")]
        public async Task<IEnumerable<ItemSelectModel>> SelectGastos()
        {
            var item = await _context.Items
                .Include(r => r.subrubros)
                .Where(r => r.activo == true && r.esdxd == false && r.espost == false && r.esmotion == false )
                .OrderBy(r => r.orden)
                .ToListAsync();

            return item.Select(r => new ItemSelectModel
            {
                iditem = r.iditem,
                orden = r.orden,
                itemes = r.itemes,
                itemen = r.itemen,
                item = String.Concat(r.orden.PadLeft(3, '0'), "-", r.itemes),
                vivo = r.subrubros.vivo,
                post = r.subrubros.post,
                conf = r.subrubros.conf
            });
        }


        // GET: api/Items/Selectdxd
        [HttpGet("[action]")]
        public async Task<IEnumerable<ItemSelectModel>> Selectdxd()
        {
            var item = await _context.Items
                .Include(r => r.subrubros)
                .Where(r => r.activo == true && r.esdxd == true)
                .OrderBy(r => r.orden)
                .ToListAsync();

            return item.Select(r => new ItemSelectModel
            {
                iditem = r.iditem,
                orden = r.orden,
                itemes = r.itemes,
                itemen = r.itemen,
                item = String.Concat(r.orden.PadLeft(3, '0'), "-", r.itemes),
                vivo = r.subrubros.vivo,
                post = r.subrubros.post,
                conf = r.subrubros.conf
            });
        }

        // GET: api/Items/Selectpost
        [HttpGet("[action]")]
        public async Task<IEnumerable<ItemSelectModel>> Selectpost()
        {
            var item = await _context.Items
                .Include(r => r.subrubros)
                .Where(r => r.activo == true && r.espost == true)
                .OrderBy(r => r.orden)
                .ToListAsync();

            return item.Select(r => new ItemSelectModel
            {
                iditem = r.iditem,
                orden = r.orden,
                itemes = r.itemes,
                itemen = r.itemen,
                item = String.Concat(r.orden.PadLeft(3, '0'), "-", r.itemes),
                vivo = r.subrubros.vivo,
                post = r.subrubros.post,
                conf = r.subrubros.conf
            });
        }

        // GET: api/Items/Selectmotion
        [HttpGet("[action]")]
        public async Task<IEnumerable<ItemSelectModel>> Selectmotion()
        {
            var item = await _context.Items
                .Include(r => r.subrubros)
                .Where(r => r.activo == true && r.esmotion == true)
                .OrderBy(r => r.orden)
                .ToListAsync();

            return item.Select(r => new ItemSelectModel
            {
                iditem = r.iditem,
                orden = r.orden,
                itemes = r.itemes,
                itemen = r.itemen,
                item = String.Concat(r.orden.PadLeft(3, '0'), "-", r.itemes),
                vivo = r.subrubros.vivo,
                post = r.subrubros.post,
                conf = r.subrubros.conf
            });
        }

        // GET: api/Items/SelectActivo
        [HttpGet("[action]")]
        public async Task<IEnumerable<ItemSelectModel>> SelectActivo()
        {
            var item = await _context.Items
                .Include(r => r.subrubros)
                .Where(r => r.activo == true)
                .OrderBy(r => r.orden)
                .ToListAsync();

            return item.Select(r => new ItemSelectModel
            {
                iditem = r.iditem,
                orden = r.orden,
                itemes = r.itemes,
                itemen = r.itemen,
                item = String.Concat(r.orden.PadLeft(3, '0'), "-", r.itemes),
                vivo = r.subrubros.vivo,
                post = r.subrubros.post,
                conf = r.subrubros.conf
            });
        }

        // GET: api/Items/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var item = await _context.Items.Include(a => a.subrubros).
                            SingleOrDefaultAsync(a => a.iditem == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(new ItemViewModel
            {
                iditem = item.iditem,
                idsubrubro = item.idsubrubro,
                subrubroes = item.subrubros.subrubroes,
                subrubroen = item.subrubros.subrubroen,
                itemes = item.itemes,
                itemen = item.itemen,
                orden = item.orden,
                esdxd = item.esdxd,
                espost = item.espost,
                esmotion = item.esmotion,
                tienesubitems = item.tienesubitems,
                cuentagcom = item.cuentagcom,
                iduseralta = item.iduseralta,
                fecalta = item.fecalta,
                iduserumod = item.iduserumod,
                fecumod = item.fecumod,
                activo = item.activo
            });
        }

        // PUT: api/Items/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ItemUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.iditem <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var item = await _context.Items.FirstOrDefaultAsync(a => a.iditem == model.iditem);

            if (item == null)
            {
                return NotFound();
            }

            item.idsubrubro = model.idsubrubro;
            item.itemes = model.itemes;
            item.itemen = model.itemen;
            item.orden = model.orden;
            item.esdxd = model.esdxd;
            item.espost = model.espost;
            item.esmotion = model.esmotion;
            item.tienesubitems = model.tienesubitems;
            item.cuentagcom = model.cuentagcom;
            item.iduseralta = model.iduseralta;
            item.fecalta = model.fecalta;
            item.iduserumod = model.iduserumod;
            item.fecumod = fechaHora;
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

        // POST: api/Items/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ItemCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Item item = new Item
            {
                idsubrubro = model.idsubrubro,
                itemes = model.itemes,
                itemen = model.itemen,
                orden = model.orden,
                esdxd = model.esdxd,
                espost = model.espost,
                esmotion = model.esmotion,
                tienesubitems = model.tienesubitems,
                cuentagcom = model.cuentagcom,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true

            };

            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Items/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _context.Items.FirstOrDefaultAsync(c => c.iditem == id);

            if (item == null)
            {
                return NotFound();
            }

            item.activo = false;

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

        // PUT: api/Items/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _context.Items.FirstOrDefaultAsync(c => c.iditem == id);

            if (item == null)
            {
                return NotFound();
            }

            item.activo = true;

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

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.iditem == id);
        }
    }
}
