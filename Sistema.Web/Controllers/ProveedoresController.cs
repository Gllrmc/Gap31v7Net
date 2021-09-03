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
using Sistema.Web.Models.Maestros.Proveedor;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ProveedoresController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Proveedores/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedorViewModel>> Listar()
        {
            var proveedor = await _context.Proveedores.Include(a => a.persona).ToListAsync();

            return proveedor.Select(a => new ProveedorViewModel
            {
                idproveedor = a.idproveedor,
                idpersona = a.idpersona,
                razonsocial = a.razonsocial,
                cuit = a.cuit,
                situacioniva = a.situacioniva,
                email = a.email,
                telefono = a.telefono,
                persona = a.idpersona.HasValue?a.persona.nombre:"",
                emailpersonal = a.idpersona.HasValue?a.persona.emailpersonal:"",
                telefonopersonal = a.idpersona.HasValue?a.persona.telefonopersonal:"",
                generico = a.generico,
                tipocomprobantegenerico = a.tipocomprobantegenerico,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Proveedores/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedorSelectModel>> Select()
        {
            var proveedor = await _context.Proveedores
                .Where(a => !a.generico)
                .OrderBy(a => a.razonsocial)
                .AsNoTracking()
                .ToListAsync();

            return proveedor.Select(a => new ProveedorSelectModel
            {
                idproveedor = a.idproveedor,
                razonsocial = a.razonsocial,
                cuit = a.cuit,
                situacioniva = a.situacioniva
            });

        }

        // GET: api/Proveedores/SelectGenerico
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedorSelectModel>> SelectGenerico()
        {
            var proveedor = await _context.Proveedores
                .Where (a => a.generico )
                .AsNoTracking()
                .OrderBy(a => a.razonsocial)
                .ToListAsync();

            return proveedor.Select(a => new ProveedorSelectModel
            {
                idproveedor = a.idproveedor,
                razonsocial = a.razonsocial,
                cuit = a.cuit,
                situacioniva = a.situacioniva,
                tipocomprobantegenerico = a.tipocomprobantegenerico
            });

        }

        // GET: api/Proveedores/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var proveedor = await _context.Proveedores
                .Include(a => a.persona)
                .SingleOrDefaultAsync(a => a.idproveedor == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(new ProveedorViewModel
            {
                idproveedor = proveedor.idproveedor,
                idpersona = proveedor.idpersona,
                razonsocial = proveedor.razonsocial,
                cuit = proveedor.cuit,
                situacioniva = proveedor.situacioniva,
                email = proveedor.email,
                telefono = proveedor.telefono,
                generico = proveedor.generico,
                tipocomprobantegenerico = proveedor.tipocomprobantegenerico,
                activo = proveedor.activo
            });
        }

        // PUT: api/Proveedores/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProveedorUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idproveedor <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(a => a.idproveedor == model.idproveedor);

            if (proveedor == null)
            {
                return NotFound();
            }
            proveedor.idproveedor = model.idproveedor;
            proveedor.idpersona = model.idpersona;
            proveedor.razonsocial = model.razonsocial;
            proveedor.cuit = model.cuit;
            proveedor.situacioniva = model.situacioniva;
            proveedor.email = model.email;
            proveedor.telefono = model.telefono;
            proveedor.generico = model.generico;
            proveedor.tipocomprobantegenerico = model.tipocomprobantegenerico;
            proveedor.iduseralta = model.iduseralta;
            proveedor.fecalta = model.fecalta;
            proveedor.iduserumod = model.iduserumod;
            proveedor.fecumod = fechaHora;

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

        // POST: api/Proveedores/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ProveedorCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Proveedor proveedor = new Proveedor
            {
                idpersona = model.idpersona,
                razonsocial = model.razonsocial,
                cuit = model.cuit,
                situacioniva = model.situacioniva,
                email = model.email,
                telefono = model.telefono,
                generico = model.generico,
                tipocomprobantegenerico = model.tipocomprobantegenerico,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Proveedores.Add(proveedor);
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

        // PUT: api/Proveedores/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(a => a.idproveedor == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            proveedor.activo = false;

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

        // PUT: api/Proveedores/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(a => a.idproveedor == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            proveedor.activo = true;

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


        private bool ProveedorExists(int id)
        {
            return _context.Proveedores.Any(e => e.idproveedor == id);
        }
    }
}
