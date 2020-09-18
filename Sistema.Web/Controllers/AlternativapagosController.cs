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
using Sistema.Web.Models.Maestros.Alternativapagos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlternativapagosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public AlternativapagosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Alternativapagos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<AlternativapagoViewModel>> Listar()
        {
            var alternativapago = await _context.Alternativapagos
                .Include(p => p.proveedor)
                .OrderBy(p => p.idalternativapago)
                .ToListAsync();

            return alternativapago.Select(a => new AlternativapagoViewModel
            {
                idalternativapago = a.idalternativapago,
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                orden = a.orden,
                beneficiario = a.beneficiario,
                banco = a.banco,
                cuitcuil = a.cuitcuil,
                tipocuenta = a.tipocuenta,
                numcuenta = a.numcuenta,
                cbu = a.cbu,
                alias = a.alias,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Alternativapagos/ListarActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<AlternativapagoViewModel>> ListarActivos()
        {
            var alternativapago = await _context.Alternativapagos
                .Include(p => p.proveedor)
                .OrderBy(p => p.idalternativapago)
                .Where(p => p.activo == true)
                .ToListAsync();

            return alternativapago.Select(a => new AlternativapagoViewModel
            {
                idalternativapago = a.idalternativapago,
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                orden = a.orden,
                beneficiario = a.beneficiario,
                banco = a.banco,
                cuitcuil = a.cuitcuil,
                tipocuenta = a.tipocuenta,
                numcuenta = a.numcuenta,
                cbu = a.cbu,
                alias = a.alias,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Alternativapagos/ListarProveedor/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<AlternativapagoViewModel>> ListarProveedor([FromRoute] int id)
        {
            var alternativapago = await _context.Alternativapagos
                .Include(p => p.proveedor)
                .Where(p => p.idproveedor == id)
                .OrderBy(p => p.idalternativapago)
                .ToListAsync();

            return alternativapago.Select(a => new AlternativapagoViewModel
            {
                idalternativapago = a.idalternativapago,
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                orden = a.orden,
                beneficiario = a.beneficiario,
                banco = a.banco,
                cuitcuil = a.cuitcuil,
                tipocuenta = a.tipocuenta,
                numcuenta = a.numcuenta,
                cbu = a.cbu,
                alias = a.alias,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Alternativapagos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<AlternativapagoSelectModel>> Select()
        {
            var alternativapago = await _context.Alternativapagos
                .Where(p => p.activo == true)
                .OrderBy(p => p.orden)
                .ToListAsync();

            return alternativapago.Select(a => new AlternativapagoSelectModel
            {
                idalternativapago = a.idalternativapago,
                idproveedor = a.idproveedor,
                orden = a.orden,
                beneficiario = a.beneficiario,
                cuitcuil = a.cuitcuil,
                banco = a.banco,
                cbu = a.cbu,
                alias = a.alias,
                activo = a.activo
            });
        }

        // GET: api/Alternativapagos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var alternativapago = await _context.Alternativapagos
                .Where(p => p.idproveedor == id)
                .OrderBy(p => p.idalternativapago)
                .SingleOrDefaultAsync(a => a.idalternativapago == id);

            if (alternativapago == null)
            {
                return NotFound();
            }

            return Ok(new AlternativapagoViewModel
            {
                idalternativapago = alternativapago.idalternativapago,
                idproveedor = alternativapago.idproveedor,
                orden = alternativapago.orden,
                banco = alternativapago.banco,
                beneficiario = alternativapago.beneficiario,
                cuitcuil = alternativapago.cuitcuil,
                tipocuenta = alternativapago.tipocuenta,
                numcuenta = alternativapago.numcuenta,
                cbu = alternativapago.cbu,
                alias = alternativapago.alias,
                iduseralta = alternativapago.iduseralta,
                fecalta = alternativapago.fecalta,
                iduserumod = alternativapago.iduserumod,
                fecumod = alternativapago.fecumod,
                activo = alternativapago.activo
            });
        }

        // PUT: api/Alternativapagos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] AlternativapagoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idalternativapago <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var alternativapago = await _context.Alternativapagos.FirstOrDefaultAsync(a => a.idalternativapago == model.idalternativapago);

            if (alternativapago == null)
            {
                return NotFound();
            }
            alternativapago.idalternativapago = model.idalternativapago;
            alternativapago.idproveedor = model.idproveedor;
            alternativapago.orden = model.orden;
            alternativapago.beneficiario = model.beneficiario;
            alternativapago.banco = model.banco;
            alternativapago.cuitcuil = model.cuitcuil;
            alternativapago.tipocuenta = model.tipocuenta;
            alternativapago.numcuenta = model.numcuenta;
            alternativapago.cbu = model.cbu;
            alternativapago.alias = model.alias;
            alternativapago.iduseralta = model.iduseralta;
            alternativapago.fecalta = model.fecalta;
            alternativapago.iduserumod = model.iduserumod;
            alternativapago.fecumod = fechaHora;
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

        // POST: api/Alternativapagos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] AlternativapagoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Alternativapago alternativapago = new Alternativapago
            {
                idproveedor = model.idproveedor,
                orden = model.orden,
                beneficiario = model.beneficiario,
                banco = model.banco,
                cuitcuil = model.cuitcuil,
                tipocuenta = model.tipocuenta,
                numcuenta = model.numcuenta,
                cbu = model.cbu,
                alias = model.alias,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Alternativapagos.Add(alternativapago);
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


        // PUT: api/Alternativapagos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var alternativapago = await _context.Alternativapagos.FirstOrDefaultAsync(a => a.idalternativapago == id);

            if (alternativapago == null)
            {
                return NotFound();
            }

            alternativapago.activo = false;

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

        // PUT: api/Alternativapagos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var alternativapago = await _context.Alternativapagos.FirstOrDefaultAsync(a => a.idalternativapago == id);

            if (alternativapago == null)
            {
                return NotFound();
            }

            alternativapago.activo = true;

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


        private bool AlternativapagoExists(int id)
        {
            return _context.Alternativapagos.Any(e => e.idalternativapago == id);
        }
    }
}
