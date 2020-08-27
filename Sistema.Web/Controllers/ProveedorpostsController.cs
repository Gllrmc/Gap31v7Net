using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Post;
using Sistema.Web.Models.Post;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorpostsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ProveedorpostsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Proveedorposts/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedorpostViewModel>> Listar()
        {
            var proveedorpost = await _context.Proveedorposts
                .Include(p => p.proyecto)
                .Where(p => p.proyecto.activo == true)
                .Include(p => p.item)
                .ThenInclude(p => p.subitems)
                .Include(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .ToListAsync();

            return proveedorpost.Select(a => new ProveedorpostViewModel
            {
                idproveedorpost = a.idproveedorpost,
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

        // GET: api/Proveedorposts/ListarProyecto/5
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProveedorpostViewModel>> ListarProyecto([FromRoute] int id)
        {
            var proveedorpost = await _context.Proveedorposts
                .Include(p => p.proyecto)
                .Where(p => p.idproyecto == id)
                .Include(p => p.item)
                .ThenInclude(p => p.subitems)
                .Include(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .Where(p => p.proyecto.activo == true)
                .ToListAsync();

            return proveedorpost.Select(a => new ProveedorpostViewModel
            {
                idproveedorpost = a.idproveedorpost,
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

        // GET: api/Proveedorposts/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var proveedorpost = await _context.Proveedorposts
                .Include(p => p.proyecto)
                .Where(p => p.idproyecto == id)
                .Include(p => p.item)
                .ThenInclude(p => p.subitems)
                .Include(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .Where(p => p.proyecto.activo == true)
                .SingleOrDefaultAsync(a => a.idproveedorpost == id);

            if (proveedorpost == null)
            {
                return NotFound();
            }

            return Ok(new ProveedorpostViewModel
            {
                idproveedorpost = proveedorpost.idproveedorpost,
                idproyecto = proveedorpost.idproyecto,
                proyectoorden = proveedorpost.proyecto.orden,
                proyecto = proveedorpost.proyecto.proyecto,
                iditem = proveedorpost.iditem,
                itemorden = proveedorpost.item.orden,
                itemes = proveedorpost.item.itemes,
                itemen = proveedorpost.item.itemen,
                idsubitem = proveedorpost.idsubitem,
                subitemorden = proveedorpost.idsubitem.HasValue ? proveedorpost.subitem.orden : "",
                subitemes = proveedorpost.idsubitem.HasValue ? proveedorpost.subitem.subitemes : "",
                subitemen = proveedorpost.idsubitem.HasValue ? proveedorpost.subitem.subitemen : "",
                idproveedor = proveedorpost.idproveedor,
                razonsocial = proveedorpost.proveedor.razonsocial,
                cuit = proveedorpost.proveedor.cuit,
                tarifadiaria = proveedorpost.tarifadiaria,
                iduseralta = proveedorpost.iduseralta,
                fecalta = proveedorpost.fecalta,
                iduserumod = proveedorpost.iduserumod,
                fecumod = proveedorpost.fecumod,
                activo = proveedorpost.activo

            });
        }

        // PUT: api/Proveedorposts/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProveedorpostUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idproveedorpost <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var proveedorpost = await _context.Proveedorposts.FirstOrDefaultAsync(a => a.idproveedorpost == model.idproveedorpost);

            if (proveedorpost == null)
            {
                return NotFound();
            }
            proveedorpost.idproveedorpost = model.idproveedorpost;
            proveedorpost.idproyecto = model.idproyecto;
            proveedorpost.iditem = model.iditem;
            proveedorpost.idsubitem = model.idsubitem;
            proveedorpost.idproveedor = model.idproveedor;
            proveedorpost.tarifadiaria = model.tarifadiaria;
            proveedorpost.iduseralta = model.iduseralta;
            proveedorpost.fecalta = model.fecalta;
            proveedorpost.iduserumod = model.iduserumod;
            proveedorpost.fecumod = fechaHora;

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

        // POST: api/Proveedorposts/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ProveedorpostCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Proveedorpost proveedorpost = new Proveedorpost
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

            _context.Proveedorposts.Add(proveedorpost);
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


        // PUT: api/Proveedorposts/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var proveedorpost = await _context.Proveedorposts.FirstOrDefaultAsync(a => a.idproveedorpost == id);

            if (proveedorpost == null)
            {
                return NotFound();
            }

            proveedorpost.activo = false;

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

        // PUT: api/Proveedorposts/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var proveedorpost = await _context.Proveedorposts.FirstOrDefaultAsync(a => a.idproveedorpost == id);

            if (proveedorpost == null)
            {
                return NotFound();
            }

            proveedorpost.activo = true;

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

        private bool ProveedorpostExists(int id)
        {
            return _context.Proveedorposts.Any(e => e.idproveedorpost == id);
        }
    }
}
