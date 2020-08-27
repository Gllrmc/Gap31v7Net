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
using Sistema.Web.Models.Maestros.Tipoproys;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoproysController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TipoproysController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Tipoproys/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoproyViewModel>> Listar()
        {
            var Tipoproy = await _context.Tipoproys.ToListAsync();

            return Tipoproy.Select(r => new TipoproyViewModel
            {
                idtipoproy = r.idtipoproy,
                tipoproy = r.tipoproy,
                descripcion = r.descripcion,
                impvenmay = r.impvenmay,
                impvenmen = r.impvenmen,
                porganmay = r.porganmay,
                porganmen = r.porganmen,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Tipoproys/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoproySelectModel>> Select()
        {
            var tipoproy = await _context.Tipoproys.Where(r => r.activo == true).OrderBy(r => r.tipoproy).ToListAsync();

            return tipoproy.Select(r => new TipoproySelectModel
            {
                idtipoproy = r.idtipoproy,
                tipoproy = r.tipoproy,
                descripcion = r.descripcion,
                impvenmay = r.impvenmay,
                impvenmen = r.impvenmen,
                porganmay = r.porganmay,
                porganmen = r.porganmen
            });
        }

        // GET: api/Tipoproys/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var tipoproy = await _context.Tipoproys.FindAsync(id);

            if (tipoproy == null)
            {
                return NotFound();
            }

            return Ok(new TipoproyViewModel
            {
                idtipoproy = tipoproy.idtipoproy,
                tipoproy = tipoproy.tipoproy,
                descripcion = tipoproy.descripcion,
                impvenmay = tipoproy.impvenmay,
                impvenmen = tipoproy.impvenmen,
                porganmay = tipoproy.porganmay,
                porganmen = tipoproy.porganmen,
                iduseralta = tipoproy.iduseralta,
                fecalta = tipoproy.fecalta,
                iduserumod = tipoproy.iduserumod,
                fecumod = tipoproy.fecumod,
                activo = tipoproy.activo
            });
        }

        // PUT: api/Tipoproys/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] TipoproyUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idtipoproy <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var tipoproy = await _context.Tipoproys.FirstOrDefaultAsync(c => c.idtipoproy == model.idtipoproy);

            if (tipoproy == null)
            {
                return NotFound();
            }

            tipoproy.tipoproy = model.tipoproy;
            tipoproy.descripcion = model.descripcion;
            tipoproy.impvenmay = model.impvenmay;
            tipoproy.impvenmen = model.impvenmen;
            tipoproy.porganmay = model.porganmay;
            tipoproy.porganmen = model.porganmen;
            tipoproy.iduserumod = model.iduserumod;
            tipoproy.fecumod = fechaHora;

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

        // POST: api/Tipoproys/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] TipoproyCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Tipoproy tipoproy = new Tipoproy
            {
                tipoproy = model.tipoproy,
                descripcion = model.descripcion,
                impvenmay = model.impvenmay, 
                impvenmen = model.impvenmen,
                porganmay = model.porganmay,
                porganmen = model.porganmen,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Tipoproys.Add(tipoproy);
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

        // DELETE: api/Tipoproys/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoproy = await _context.Tipoproys.FindAsync(id);
            if (tipoproy == null)
            {
                return NotFound();
            }

            _context.Tipoproys.Remove(tipoproy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(tipoproy);
        }

        // PUT: api/Tipoproys/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tipoproy = await _context.Tipoproys.FirstOrDefaultAsync(c => c.idtipoproy == id);

            if (tipoproy == null)
            {
                return NotFound();
            }

            tipoproy.activo = false;

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

        // PUT: api/Tipoproys/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tipoproy = await _context.Tipoproys.FirstOrDefaultAsync(c => c.idtipoproy == id);

            if (tipoproy == null)
            {
                return NotFound();
            }

            tipoproy.activo = true;

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

        private bool TipoproyExists(int id)
        {
            return _context.Tipoproys.Any(e => e.idtipoproy == id);
        }
    }
}
