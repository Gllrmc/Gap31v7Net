using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Maestros;

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

        // GET: api/Conceptos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concepto>>> GetConceptos()
        {
            return await _context.Conceptos.ToListAsync();
        }

        // GET: api/Conceptos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concepto>> GetConcepto(int id)
        {
            var concepto = await _context.Conceptos.FindAsync(id);

            if (concepto == null)
            {
                return NotFound();
            }

            return concepto;
        }

        // PUT: api/Conceptos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcepto(int id, Concepto concepto)
        {
            if (id != concepto.idconcepto)
            {
                return BadRequest();
            }

            _context.Entry(concepto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConceptoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Conceptos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Concepto>> PostConcepto(Concepto concepto)
        {
            _context.Conceptos.Add(concepto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcepto", new { id = concepto.idconcepto }, concepto);
        }

        // DELETE: api/Conceptos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Concepto>> DeleteConcepto(int id)
        {
            var concepto = await _context.Conceptos.FindAsync(id);
            if (concepto == null)
            {
                return NotFound();
            }

            _context.Conceptos.Remove(concepto);
            await _context.SaveChangesAsync();

            return concepto;
        }

        private bool ConceptoExists(int id)
        {
            return _context.Conceptos.Any(e => e.idconcepto == id);
        }
    }
}
