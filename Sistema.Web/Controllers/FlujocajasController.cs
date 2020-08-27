using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Proyectos;
using Sistema.Web.Models.Proyectos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class FlujocajasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public FlujocajasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Flujocajas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<FlujocajaViewModel>> Listar()
        {
            var flujocaja = await _context.Flujocajas
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include(p => p.rubro)
                .Where(p => p.proyecto.activo == true && p.proyecto.cierreprod == false && p.proyecto.cierreadmin == false)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();

            return flujocaja.Select(a => new FlujocajaViewModel
            {
                idflujocaja = a.idflujocaja,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                producto = a.proyecto.tipoprod.tipoprod,
                fecdescf = a.proyecto.fecdescf,
                fechascf = a.proyecto.fechascf,
                idrubro = a.idrubro,
                rubroorden = a.rubro.orden,
                rubroes = a.rubro.rubroes,
                rubroen = a.rubro.rubroen,
                yearweek = a.yearweek,
                fromto = a.fromto,
                tasadistribucion = a.tasadistribucion,
                importe = a.importe,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Flujocajas/ListarActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<FlujocajaViewModel>> ListarActivos()
        {
            var flujocaja = await _context.Flujocajas
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include(p => p.rubro)
                .Where(p => p.activo == true && p.proyecto.activo == true && p.proyecto.cierreprod == false && p.proyecto.cierreadmin == false)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();

            return flujocaja.Select(a => new FlujocajaViewModel
            {
                idflujocaja = a.idflujocaja,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                producto = a.proyecto.tipoprod.tipoprod,
                fecdescf = a.proyecto.fecdescf,
                fechascf = a.proyecto.fechascf,
                idrubro = a.idrubro,
                rubroorden = a.rubro.orden,
                rubroes = a.rubro.rubroes,
                rubroen = a.rubro.rubroen,
                yearweek = a.yearweek,
                fromto = a.fromto,
                tasadistribucion = a.tasadistribucion,
                importe = a.importe,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Flujocajas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<FlujocajaSelectModel>> Select()

        {
            var flujocaja = await _context.Flujocajas
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include(p => p.rubro)
                .Where(p => p.activo == true && p.proyecto.activo == true && p.proyecto.cierreprod == false && p.proyecto.cierreadmin == false)
                .OrderBy(p => p.idproyecto)
                .ToListAsync();

            return flujocaja.Select(a => new FlujocajaSelectModel
            {
                idflujocaja = a.idflujocaja,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                producto = a.proyecto.tipoprod.tipoprod,
                fecdescf = a.proyecto.fecdescf,
                fechascf = a.proyecto.fechascf,
            });

        }

        // GET: api/Flujocajas/ListarProyecto/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<FlujocajaViewModel>> ListarProyecto([FromRoute] int id)
        {
            var flujocaja = await _context.Flujocajas
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include(p => p.rubro)
                .Where(p => p.idproyecto == id)
                .OrderBy(p => p.rubro.orden+p.yearweek)
                .ToListAsync();

            return flujocaja.Select(a => new FlujocajaViewModel
            {
                idflujocaja = a.idflujocaja,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                producto = a.proyecto.tipoprod.tipoprod,
                fecdescf = a.proyecto.fecdescf,
                fechascf = a.proyecto.fechascf,
                idrubro = a.idrubro,
                rubroorden = a.rubro.orden,
                rubroes = a.rubro.rubroes,
                rubroen = a.rubro.rubroen,
                yearweek = a.yearweek,
                fromto = a.fromto,
                tasadistribucion = a.tasadistribucion,
                importe = a.importe,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }



        // GET: api/Flujocajas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var flujocaja = await _context.Flujocajas
                .Where(p => p.activo == true)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include(p => p.rubro)
                .SingleOrDefaultAsync(p => p.idflujocaja == id);

            if (flujocaja == null)
            {
                return NotFound();
            }

            return Ok(new FlujocajaViewModel
            {
                idflujocaja = flujocaja.idflujocaja,
                idproyecto = flujocaja.idproyecto,
                proyectoorden = flujocaja.proyecto.orden,
                proyecto = flujocaja.proyecto.proyecto,
                producto = flujocaja.proyecto.tipoprod.tipoprod,
                fecdescf = flujocaja.proyecto.fecdescf,
                fechascf = flujocaja.proyecto.fechascf,
                idrubro = flujocaja.idrubro,
                rubroorden = flujocaja.rubro.orden,
                rubroes = flujocaja.rubro.rubroes,
                rubroen = flujocaja.rubro.rubroen,
                yearweek = flujocaja.yearweek,
                fromto = flujocaja.fromto,
                tasadistribucion = flujocaja.tasadistribucion,
                importe = flujocaja.importe,
                iduseralta = flujocaja.iduseralta,
                fecalta = flujocaja.fecalta,
                iduserumod = flujocaja.iduserumod,
                fecumod = flujocaja.fecumod,
                activo = flujocaja.activo
            });
        }

        // PUT: api/Flujocajas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] FlujocajaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idflujocaja <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var flujocaja = await _context.Flujocajas.FirstOrDefaultAsync(a => a.idflujocaja == model.idflujocaja);

            if (flujocaja == null)
            {
                return NotFound();
            }
            flujocaja.idflujocaja = model.idflujocaja;
            flujocaja.idproyecto = model.idproyecto;
            flujocaja.idrubro = model.idrubro;
            flujocaja.yearweek = model.yearweek;
            flujocaja.fromto = model.fromto;
            flujocaja.tasadistribucion = model.tasadistribucion;
            flujocaja.importe = model.importe;
            flujocaja.iduseralta = model.iduseralta;
            flujocaja.fecalta = model.fecalta;
            flujocaja.iduserumod = model.iduserumod;
            flujocaja.fecumod = fechaHora;
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

        // POST: api/Flujocajas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] FlujocajaCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Flujocaja flujocaja = new Flujocaja
            {
                idproyecto = model.idproyecto,
                idrubro = model.idrubro,
                yearweek = model.yearweek,
                fromto = model.fromto,
                tasadistribucion = model.tasadistribucion,
                importe = model.importe,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Flujocajas.Add(flujocaja);
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

        // DELETE: api/Flujocajas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flujocaja = await _context.Flujocajas.FindAsync(id);
            if (flujocaja == null)
            {
                return NotFound();
            }

            _context.Flujocajas.Remove(flujocaja);
            try
            {
                await _context.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return BadRequest();
            }

            return Ok(flujocaja);
        }


        // PUT: api/Flujocajas/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var flujocaja = await _context.Flujocajas.FirstOrDefaultAsync(a => a.idflujocaja == id);

            if (flujocaja == null)
            {
                return NotFound();
            }

            flujocaja.activo = false;

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

        // PUT: api/Flujocajas/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var flujocaja = await _context.Flujocajas.FirstOrDefaultAsync(a => a.idflujocaja == id);

            if (flujocaja == null)
            {
                return NotFound();
            }

            flujocaja.activo = true;

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

        private bool FlujocajaExists(int id)
        {
            return _context.Flujocajas.Any(e => e.idflujocaja == id);
        }
    }
}
