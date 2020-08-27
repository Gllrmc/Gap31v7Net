using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Maestros;
using Sistema.Web.Models.Maestros.Tipoprods;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoprodsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public TipoprodsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Tipoprods/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoprodViewModel>> Listar()
        {
            var Tipoprod = await _context.Tipoprods.ToListAsync();

            return Tipoprod.Select(r => new TipoprodViewModel
            {
                idtipoprod = r.idtipoprod,
                tipoprod = r.tipoprod,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Tipoprods/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoprodSelectModel>> Select()
        {
            var tipoprod = await _context.Tipoprods.Where(r => r.activo == true).OrderBy(r => r.tipoprod).ToListAsync();

            return tipoprod.Select(r => new TipoprodSelectModel
            {
                idtipoprod = r.idtipoprod,
                tipoprod = r.tipoprod
            });
        }

        // GET: api/Tipoprods/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var tipoprod = await _context.Tipoprods.FindAsync(id);

            if (tipoprod == null)
            {
                return NotFound();
            }

            return Ok(new TipoprodViewModel
            {
                idtipoprod = tipoprod.idtipoprod,
                tipoprod = tipoprod.tipoprod,
                iduseralta = tipoprod.iduseralta,
                fecalta = tipoprod.fecalta,
                iduserumod = tipoprod.iduserumod,
                fecumod = tipoprod.fecumod,
                activo = tipoprod.activo
            });
        }

        // PUT: api/Tipoprods/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] TipoprodUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idtipoprod <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var tipoprod = await _context.Tipoprods.FirstOrDefaultAsync(c => c.idtipoprod == model.idtipoprod);

            if (tipoprod == null)
            {
                return NotFound();
            }

            tipoprod.tipoprod = model.tipoprod;
            tipoprod.iduserumod = model.iduserumod;
            tipoprod.fecumod = fechaHora;

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

        // POST: api/Tipoprods/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] TipoprodCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Tipoprod tipoprod = new Tipoprod
            {
                tipoprod = model.tipoprod,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Tipoprods.Add(tipoprod);
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

        // DELETE: api/Tipoprods/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoprod = await _context.Tipoprods.FindAsync(id);
            if (tipoprod == null)
            {
                return NotFound();
            }

            _context.Tipoprods.Remove(tipoprod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(tipoprod);
        }

        // PUT: api/Tipoprods/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tipoprod = await _context.Tipoprods.FirstOrDefaultAsync(c => c.idtipoprod == id);

            if (tipoprod == null)
            {
                return NotFound();
            }

            tipoprod.activo = false;

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

        // PUT: api/Tipoprods/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var tipoprod = await _context.Tipoprods.FirstOrDefaultAsync(c => c.idtipoprod == id);

            if (tipoprod == null)
            {
                return NotFound();
            }

            tipoprod.activo = true;

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

        private bool TipoprodExists(int id)
        {
            return _context.Tipoprods.Any(e => e.idtipoprod == id);
        }
    }
}
