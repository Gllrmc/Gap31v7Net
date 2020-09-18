using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Garantias;
using Sistema.Web.Models.Garantias;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class GarantiasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public GarantiasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Garantias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<GarantiaViewModel>> Listar()
        {
            var garantia = await _context.Garantias
                .Include(a => a.proyecto)
                .Include(a => a.banco)
                .Include(a => a.rubro)
                .Include(a=>a.proveedor)
                .ToListAsync();

            return garantia.Select(a => new GarantiaViewModel
            {
                idgarantia = a.idgarantia,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                numorden = a.numorden,
                idrubro = a.idrubro,
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                importe = a.importe,
                detalle = a.detalle,
                idbanco = a.idbanco,
                banco = a.idbanco.HasValue?a.banco.nombre:"",
                numcheque = a.numcheque,
                feccheque = a.feccheque,
                fecvencimiento = a.fecvencimiento,
                entregado = a.entregado,
                rendido = a.rendido,
                fhrendido = a.fhrendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Garantias/ListarPendientes
        [HttpGet("[action]")]
        public async Task<IEnumerable<GarantiaViewModel>> ListarPendientes()
        {
            var garantia = await _context.Garantias
                .Include(a => a.proyecto)
                .Include(a => a.banco)
                .Include(a => a.rubro)
                .Include(a => a.proveedor)
                .Where(a => a.rendido == false && a.activo == true && a.entregado == true )
                .ToListAsync();

            return garantia.Select(a => new GarantiaViewModel
            {
                idgarantia = a.idgarantia,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                numorden = a.numorden,
                idrubro = a.idrubro,
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                importe = a.importe,
                detalle = a.detalle,
                idbanco = a.idbanco,
                banco = a.idbanco.HasValue ? a.banco.nombre : "",
                numcheque = a.numcheque,
                feccheque = a.feccheque,
                fecvencimiento = a.fecvencimiento,
                entregado = a.entregado,
                rendido = a.rendido,
                fhrendido = a.fhrendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }


        // GET: api/Garantias/ListarProyecto/1002
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<GarantiaViewModel>> ListarProyecto([FromRoute] int id)
        {
            var garantia = await _context.Garantias
                .Include(a => a.banco)
                .Include(a => a.proyecto)
                .Include(a => a.rubro)
                .Include(a => a.proveedor)
                .Where(p => p.idproyecto == id && p.activo == true)
                .OrderBy(p => p.numorden)
                .AsNoTracking()
                .ToListAsync();

            return garantia.Select(a => new GarantiaViewModel
            {
                idgarantia = a.idgarantia,
                numorden = a.numorden,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idrubro = a.idrubro,
                rubro = a.rubro.rubroes,
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                importe = a.importe,
                detalle = a.detalle,
                idbanco = a.idbanco,
                banco = a.idbanco.HasValue ? a.banco.nombre : "",
                numcheque = a.numcheque,
                feccheque = a.feccheque,
                fecvencimiento = a.fecvencimiento,
                entregado = a.entregado,
                rendido = a.rendido,
                fhrendido = a.fhrendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Garantias/ControlCierreProyecto/1002
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<GarantiaViewModel>> ControlCierreProyecto([FromRoute] int id)
        {
            var garantia = await _context.Garantias
                .Include(a => a.banco)
                .Include(a => a.proyecto)
                .Include(a => a.rubro)
                .Include(a => a.proveedor)
                .Where(p => p.idproyecto == id && p.activo == true && p.entregado == true && p.rendido == false)
                .OrderBy(p => p.numorden)
                .ToListAsync();

            return garantia.Select(a => new GarantiaViewModel
            {
                idgarantia = a.idgarantia,
                numorden = a.numorden,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idrubro = a.idrubro,
                rubro = a.rubro.rubroes,
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                importe = a.importe,
                detalle = a.detalle,
                idbanco = a.idbanco,
                banco = a.idbanco.HasValue ? a.banco.nombre : "",
                numcheque = a.numcheque,
                feccheque = a.feccheque,
                fecvencimiento = a.fecvencimiento,
                entregado = a.entregado,
                rendido = a.rendido,
                fhrendido = a.fhrendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Garantias/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<GarantiaSelectModel>> Select()
        {
            var garantia = await _context.Garantias
                .Include(a => a.proyecto)
                .Include(a => a.banco)
                .Include(a => a.rubro)
                .Include(a => a.proveedor)
                .OrderBy(a => a.numcheque)
                .ToListAsync();

            return garantia.Select(r => new GarantiaSelectModel
            {
                idgarantia = r.idgarantia,
                idproyecto = r.idproyecto,
                proyecto = r.proyecto.proyecto,
                numorden = r.numorden,
                idrubro = r.idrubro,
                idproveedor = r.idproveedor,
                proveedor = r.proveedor.razonsocial,
                idbanco = r.idbanco,
                banco = r.idbanco.HasValue ? r.banco.nombre : "",
                numcheque = r.numcheque,
                feccheque = r.feccheque,
                fecvencimiento = r.fecvencimiento
            });
        }

        // GET: api/Garantias/SelectActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<GarantiaSelectModel>> SelectActivos()
        {
            var garantia = await _context.Garantias
                .Include(a => a.proyecto)
                .Include(a => a.banco)
                .Include(a => a.rubro)
                .Include(a => a.proveedor)
                .Where(a => a.activo == true)
                .OrderBy(a => a.numcheque)
                .ToListAsync();                

            return garantia.Select(r => new GarantiaSelectModel
            {
                idgarantia = r.idgarantia,
                idproyecto = r.idproyecto,
                proyecto = r.proyecto.proyecto,
                numorden = r.numorden,
                idrubro = r.idrubro,
                idproveedor = r.idproveedor,
                proveedor = r.proveedor.razonsocial,
                idbanco = r.idbanco,
                banco = r.idbanco.HasValue ? r.banco.nombre : "",
                numcheque = r.numcheque,
                feccheque = r.feccheque,
                fecvencimiento = r.fecvencimiento
            });
        }

        // GET: api/Garantias/Controlgarantia2date/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Garantia2dateViewModel>> Controlgarantia2date([FromRoute] int id)
        {
            var garantiadate = await _context.Garantia2dates
                .FromSqlRaw($@"
                    SELECT cast(ROW_NUMBER() OVER(order by idproyecto) as int) AS id, *
                    FROM (
                    Select a.idproyecto, p.orden as proy, p.proyecto, a.numorden, u.rubro,
                            r.razonsocial as proveedor, a.importe, a.detalle, b.nombre as banco, a.numcheque, a.feccheque, 
                            a.fecvencimiento, a.entregado, a.rendido, a.fhrendido
                    from garantias a
                    Left Join proyectos p ON a.idproyecto = p.idproyecto
                    Left Join proveedores r ON a.idproveedor = r.idproveedor
                    Left Join rubros u ON a.idrubro = u.idrubro
                    Left Join bancos b ON a.idbanco = b.idbanco
                    WHERE a.activo = 1 and a.idproyecto = {id}
                    ) u                
                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return garantiadate.Select(a => new Garantia2dateViewModel
            {
                idproyecto = a.idproyecto,
                proy = a.proy,
                proyecto = a.proyecto,
                numorden = a.numorden,
                rubro = a.rubro,
                proveedor = a.proveedor,
                importe = a.importe,
                detalle = a.detalle,
                banco = a.banco,
                numcheque = a.numcheque,
                feccheque = a.feccheque,
                fecvencimiento = a.fecvencimiento,
                entregado = a.entregado,
                rendido = a.rendido,
                fhrendido = a.fhrendido
            });

        }

        // GET: api/Garantias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var garantia = await _context.Garantias
                .Include(a => a.proyecto)
                .Include(a => a.banco)
                .Include(a => a.rubro)
                .Include(a => a.proveedor)
                .SingleOrDefaultAsync(a => a.idgarantia == id);

            if (garantia == null)
            {
                return NotFound();
            }

            return Ok(new GarantiaViewModel
            {
                idgarantia = garantia.idgarantia,
                idproyecto = garantia.idproyecto,
                proyecto = garantia.proyecto.proyecto,
                numorden = garantia.numorden,
                idrubro = garantia.idrubro,
                idproveedor = garantia.idproveedor,
                proveedor = garantia.proveedor.razonsocial,
                importe = garantia.importe,
                detalle = garantia.detalle,
                idbanco = garantia.idbanco,
                banco = garantia.banco.nombre,
                numcheque = garantia.numcheque,
                feccheque = garantia.feccheque,
                fecvencimiento = garantia.fecvencimiento,
                entregado = garantia.entregado,
                rendido = garantia.rendido,
                fhrendido = garantia.fhrendido,
                iduseralta = garantia.iduseralta,
                fecalta = garantia.fecalta,
                iduserumod = garantia.iduserumod,
                fecumod = garantia.fecumod,
                activo = garantia.activo
            });
        }

        // PUT: api/Garantias/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] GarantiaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idgarantia <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var garantia = await _context.Garantias.FirstOrDefaultAsync(a => a.idgarantia == model.idgarantia);

            if (garantia == null)
            {
                return NotFound();
            }
            garantia.idgarantia = model.idgarantia;
            garantia.idproyecto = model.idproyecto;
            garantia.numorden = model.numorden;
            garantia.idrubro = model.idrubro;
            garantia.idproveedor = model.idproveedor;
            garantia.importe = model.importe;
            garantia.detalle = model.detalle;
            garantia.idbanco = model.idbanco;
            garantia.numcheque = model.numcheque;
            garantia.feccheque = model.feccheque;
            garantia.fecvencimiento = model.fecvencimiento;
            garantia.entregado = model.entregado;
            garantia.rendido = model.rendido;
            garantia.fhrendido = model.fhrendido;
            garantia.iduserumod = model.iduserumod;
            garantia.fecumod = fechaHora;
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

        // POST: api/Garantias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] GarantiaCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            var numorden = _context.Garantias.Where(p => p.idproyecto == model.idproyecto).Max(x => (int?)x.numorden) ?? 0;

            Garantia garantia = new Garantia
            {
                idproyecto = model.idproyecto,
                numorden = (int) numorden + 1,
                idrubro = model.idrubro,
                idproveedor = model.idproveedor,
                importe = model.importe,
                detalle = model.detalle,
                idbanco = model.idbanco,
                numcheque = model.numcheque,
                feccheque = model.feccheque,
                fecvencimiento = model.fecvencimiento,
                entregado = model.entregado,
                rendido = model.rendido,
                fhrendido = model.fhrendido,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Garantias.Add(garantia);
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

        // PUT: api/Garantias/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var garantia = await _context.Garantias.FirstOrDefaultAsync(a => a.idgarantia == id);

            if (garantia == null)
            {
                return NotFound();
            }

            garantia.activo = false;

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

        // PUT: api/Garantias/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var garantia = await _context.Garantias.FirstOrDefaultAsync(a => a.idgarantia == id);

            if (garantia == null)
            {
                return NotFound();
            }

            garantia.activo = true;

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

        // PUT: api/Garantias/DesactivarRendir/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DesactivarRendir([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var garantia = await _context.Garantias.FirstOrDefaultAsync(a => a.idgarantia == id);

            if (garantia == null)
            {
                return NotFound();
            }

            garantia.rendido = false;

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

        // PUT: api/Garantias/ActivarRendir/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> ActivarRendir([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var garantia = await _context.Garantias.FirstOrDefaultAsync(a => a.idgarantia == id);

            if (garantia == null)
            {
                return NotFound();
            }

            garantia.rendido = true;
            garantia.fhrendido = fechaHora;

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


        private bool GarantiaExists(int id)
        {
            return _context.Garantias.Any(e => e.idgarantia == id);
        }
    }
}
