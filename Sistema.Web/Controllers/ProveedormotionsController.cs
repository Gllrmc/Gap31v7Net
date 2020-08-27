using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Motion;
using Sistema.Web.Models.Motion;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedormotionsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ProveedormotionsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Proveedormotions/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedormotionViewModel>> Listar()
        {
            var proveedormotion = await _context.Proveedormotions
                .Include(p => p.proyecto)
                .Where(p => p.proyecto.activo == true)
                .Include(p => p.item)
                .ThenInclude(p => p.subitems)
                .Include(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .ToListAsync();

            return proveedormotion.Select(a => new ProveedormotionViewModel
            {
                idproveedormotion = a.idproveedormotion,
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
                idproveedor = a.idproveedor,
                razonsocial = a.proveedor.razonsocial,
                cuit = a.proveedor.cuit,
                tarifadiaria = a.tarifadiaria,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Proveedormotions/ListarProyecto/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProveedormotionViewModel>> ListarProyecto([FromRoute] int id)
        {
            var proveedormotion = await _context.Proveedormotions
                .Include(p => p.proyecto)
                .Where(p => p.idproyecto == id)
                .Include(p => p.item)
                .ThenInclude(p => p.subitems)
                .Include(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .Where(p => p.proyecto.activo == true)
                .ToListAsync();

            return proveedormotion.Select(a => new ProveedormotionViewModel
            {
                idproveedormotion = a.idproveedormotion,
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
                idproveedor = a.idproveedor,
                razonsocial = a.proveedor.razonsocial,
                cuit = a.proveedor.cuit,
                tarifadiaria = a.tarifadiaria,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Proveedormotions/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var proveedormotion = await _context.Proveedormotions
                .Include(p => p.proyecto)
                .Where(p => p.idproyecto == id)
                .Include(p => p.item)
                .ThenInclude(p => p.subitems)
                .Include(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .Where(p => p.proyecto.activo == true)
                .SingleOrDefaultAsync(a => a.idproveedormotion == id);

            if (proveedormotion == null)
            {
                return NotFound();
            }

            return Ok(new ProveedormotionViewModel
            {
                idproveedormotion = proveedormotion.idproveedormotion,
                idproyecto = proveedormotion.idproyecto,
                proyectoorden = proveedormotion.proyecto.orden,
                proyecto = proveedormotion.proyecto.proyecto,
                iditem = proveedormotion.iditem,
                itemorden = proveedormotion.item.orden,
                itemes = proveedormotion.item.itemes,
                itemen = proveedormotion.item.itemen,
                idsubitem = proveedormotion.idsubitem,
                subitemorden = proveedormotion.idsubitem.HasValue ? proveedormotion.subitem.orden : "",
                subitemes = proveedormotion.idsubitem.HasValue ? proveedormotion.subitem.subitemes : "",
                subitemen = proveedormotion.idsubitem.HasValue ? proveedormotion.subitem.subitemen : "",
                idproveedor = proveedormotion.idproveedor,
                razonsocial = proveedormotion.proveedor.razonsocial,
                cuit = proveedormotion.proveedor.cuit,
                tarifadiaria = proveedormotion.tarifadiaria,
                iduseralta = proveedormotion.iduseralta,
                fecalta = proveedormotion.fecalta,
                iduserumod = proveedormotion.iduserumod,
                fecumod = proveedormotion.fecumod,
                activo = proveedormotion.activo

            });
        }

        // PUT: api/Proveedormotions/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProveedormotionUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idproveedormotion <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var proveedormotion = await _context.Proveedormotions.FirstOrDefaultAsync(a => a.idproveedormotion == model.idproveedormotion);

            if (proveedormotion == null)
            {
                return NotFound();
            }
            proveedormotion.idproveedormotion = model.idproveedormotion;
            proveedormotion.idproyecto = model.idproyecto;
            proveedormotion.iditem = model.iditem;
            proveedormotion.idsubitem = model.idsubitem;
            proveedormotion.idproveedor = model.idproveedor;
            proveedormotion.tarifadiaria = model.tarifadiaria;
            proveedormotion.iduseralta = model.iduseralta;
            proveedormotion.fecalta = model.fecalta;
            proveedormotion.iduserumod = model.iduserumod;
            proveedormotion.fecumod = fechaHora;

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

        // POST: api/Proveedormotions/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ProveedormotionCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Proveedormotion proveedormotion = new Proveedormotion
            {
                idproyecto = model.idproyecto,
                iditem = model.iditem,
                idsubitem = model.idsubitem,
                idproveedor = model.idproveedor,
                tarifadiaria = model.tarifadiaria,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Proveedormotions.Add(proveedormotion);
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


        // PUT: api/Proveedormotions/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var proveedormotion = await _context.Proveedormotions.FirstOrDefaultAsync(a => a.idproveedormotion == id);

            if (proveedormotion == null)
            {
                return NotFound();
            }

            proveedormotion.activo = false;

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

        // PUT: api/Proveedormotions/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var proveedormotion = await _context.Proveedormotions.FirstOrDefaultAsync(a => a.idproveedormotion == id);

            if (proveedormotion == null)
            {
                return NotFound();
            }

            proveedormotion.activo = true;

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


        private bool ProveedormotionExists(int id)
        {
            return _context.Proveedormotions.Any(e => e.idproveedormotion == id);
        }
    }
}
