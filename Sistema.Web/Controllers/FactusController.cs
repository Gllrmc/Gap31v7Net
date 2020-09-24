using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Limbos;
using Sistema.Web.Models.Limbos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class FactusController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public FactusController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Factus/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<FactuViewModel>> Listar()
        {
            var Factu = await _context.Factus
                .Include(p => p.limbo)
                .ToListAsync();

            return Factu.Select(r => new FactuViewModel
            {
                idfactu = r.idfactu,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numfactu = r.numfactu,
                feccomprobante = r.feccomprobante,
                tipocomprobante = r.tipocomprobante,
                numcomprobante = r.numcomprobante,
                impfactu = r.impfactu,
                nota = r.nota,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Factus/ListarLimbo/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<FactuViewModel>> ListarLimbo([FromRoute] int id)
        {
            var Factu = await _context.Factus
                .Include(p => p.limbo)
                .Where(p => p.idlimbo == id)
                .ToListAsync();

            return Factu.Select(r => new FactuViewModel
            {
                idfactu = r.idfactu,
                idlimbo = r.idlimbo,
                limbo = r.limbo.proyecto,
                numfactu = r.numfactu,
                feccomprobante = r.feccomprobante,
                tipocomprobante = r.tipocomprobante,
                numcomprobante = r.numcomprobante,
                impfactu = r.impfactu,
                nota = r.nota,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Factus/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<FactuSelectModel>> Select()
        {
            var factu = await _context.Factus
                .Include(p => p.limbo)
                .Where(r => r.activo == true)
                .OrderBy(r => r.idfactu)
                .ToListAsync();

            return factu.Select(r => new FactuSelectModel
            {
                idfactu = r.idfactu,
                idlimbo = r.idlimbo,
                numfactu = r.numfactu,
                feccomprobante = r.feccomprobante,
                tipocomprobante = r.tipocomprobante,
                numcomprobante = r.numcomprobante,
                impfactu = r.impfactu
            });
        }

        // GET: api/Factus/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var factu = await _context.Factus.FindAsync(id);

            if (factu == null)
            {
                return NotFound();
            }

            return Ok(new FactuViewModel
            {
                idfactu = factu.idfactu,
                idlimbo = factu.idlimbo,
                numfactu = factu.numfactu,
                feccomprobante = factu.feccomprobante,
                tipocomprobante = factu.tipocomprobante,
                numcomprobante = factu.numcomprobante,
                impfactu = factu.impfactu,
                nota = factu.nota,
                iduseralta = factu.iduseralta,
                fecalta = factu.fecalta,
                iduserumod = factu.iduserumod,
                fecumod = factu.fecumod,
                activo = factu.activo
            });
        }

        // PUT: api/Factus/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] FactuUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idfactu <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var factu = await _context.Factus.FirstOrDefaultAsync(c => c.idfactu == model.idfactu);

            if (factu == null)
            {
                return NotFound();
            }

            factu.feccomprobante = model.feccomprobante;
            factu.tipocomprobante = model.tipocomprobante;
            factu.numcomprobante = model.numcomprobante;
            factu.impfactu = model.impfactu;
            factu.nota = model.nota;
            factu.iduserumod = model.iduserumod;
            factu.fecumod = fechaHora;

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

        // POST: api/Factus/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] FactuCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            int numfactu = _context.Factus
                .Where(p => p.idlimbo == model.idlimbo)
                .Max(x => (int?)x.numfactu) ?? 0;

            Factu factu = new Factu
            {
                idlimbo = model.idlimbo,
                numfactu = numfactu + 1,
                feccomprobante = model.feccomprobante,
                tipocomprobante = model.tipocomprobante,
                numcomprobante = model.numcomprobante,
                impfactu = model.impfactu,
                nota = model.nota,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Factus.Add(factu);
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

        // DELETE: api/Factus/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var factu = await _context.Factus.FindAsync(id);
            if (factu == null)
            {
                return NotFound();
            }

            _context.Factus.Remove(factu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(factu);
        }

        // PUT: api/Factus/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var factu = await _context.Factus.FirstOrDefaultAsync(c => c.idfactu == id);

            if (factu == null)
            {
                return NotFound();
            }

            factu.activo = false;

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

        // PUT: api/Factus/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var factu = await _context.Factus.FirstOrDefaultAsync(c => c.idfactu == id);

            if (factu == null)
            {
                return NotFound();
            }

            factu.activo = true;

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

        private bool FactuExists(int id)
        {
            return _context.Factus.Any(e => e.idfactu == id);
        }
    }
}
