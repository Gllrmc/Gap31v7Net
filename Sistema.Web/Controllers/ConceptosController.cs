using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Maestros;
using Sistema.Web.Models.Maestros.Conceptos;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ConceptosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Conceptos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ConceptoViewModel>> Listar()
        {
            var Concepto = await _context.Conceptos.ToListAsync();

            return Concepto.Select(r => new ConceptoViewModel
            {
                idconcepto = r.idconcepto,
                concepto = r.concepto,
                color = r.color,
                texto = r.texto,
                cuentagcom = r.cuentagcom,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Conceptos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ConceptoSelectModel>> Select()
        {
            var concepto = await _context.Conceptos.Where(r => r.activo == true).OrderBy(r => r.concepto).ToListAsync();

            return concepto.Select(r => new ConceptoSelectModel
            {
                idconcepto = r.idconcepto,
                concepto = r.concepto,
                color = r.color,
                texto = r.texto
            });
        }

        // GET: api/Conceptos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var concepto = await _context.Conceptos.FindAsync(id);

            if (concepto == null)
            {
                return NotFound();
            }

            return Ok(new ConceptoViewModel
            {
                idconcepto = concepto.idconcepto,
                concepto = concepto.concepto,
                color = concepto.color,
                texto = concepto.texto,
                cuentagcom = concepto.cuentagcom,
                iduseralta = concepto.iduseralta,
                fecalta = concepto.fecalta,
                iduserumod = concepto.iduserumod,
                fecumod = concepto.fecumod,
                activo = concepto.activo
            });
        }

        // PUT: api/Conceptos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ConceptoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idconcepto <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var concepto = await _context.Conceptos.FirstOrDefaultAsync(c => c.idconcepto == model.idconcepto);

            if (concepto == null)
            {
                return NotFound();
            }

            concepto.concepto = model.concepto;
            concepto.color = model.color;
            concepto.texto = model.texto;
            concepto.cuentagcom = model.cuentagcom;
            concepto.iduserumod = model.iduserumod;
            concepto.fecumod = fechaHora;

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

        // POST: api/Conceptos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ConceptoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Concepto concepto = new Concepto
            {
                concepto = model.concepto,
                color = model.color,
                texto = model.texto,
                cuentagcom = model.cuentagcom,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Conceptos.Add(concepto);
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

        // DELETE: api/Conceptos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var concepto = await _context.Conceptos.FindAsync(id);
            if (concepto == null)
            {
                return NotFound();
            }

            _context.Conceptos.Remove(concepto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(concepto);
        }

        // PUT: api/Conceptos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var concepto = await _context.Conceptos.FirstOrDefaultAsync(c => c.idconcepto == id);

            if (concepto == null)
            {
                return NotFound();
            }

            concepto.activo = false;

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

        // PUT: api/Conceptos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var concepto = await _context.Conceptos.FirstOrDefaultAsync(c => c.idconcepto == id);

            if (concepto == null)
            {
                return NotFound();
            }

            concepto.activo = true;

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

        private bool ConceptoExists(int id)
        {
            return _context.Conceptos.Any(e => e.idconcepto == id);
        }
    }
}
