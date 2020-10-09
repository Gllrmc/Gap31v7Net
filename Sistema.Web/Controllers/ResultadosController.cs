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
using Sistema.Web.Models.Maestros.Resultados;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ResultadosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Resultados/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ResultadoViewModel>> Listar()
        {
            var Resultado = await _context.Resultados.ToListAsync();

            return Resultado.Select(r => new ResultadoViewModel
            {
                idresultado = r.idresultado,
                resultado = r.resultado,
                esaprobacion = r.esaprobacion,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });

        }

        // GET: api/Resultados/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ResultadoSelectModel>> Select()
        {
            var resultado = await _context.Resultados.Where(r => r.activo == true).OrderBy(r => r.resultado).ToListAsync();

            return resultado.Select(r => new ResultadoSelectModel
            {
                idresultado = r.idresultado,
                resultado = r.resultado,
                esaprobacion = r.esaprobacion
            });
        }

        // GET: api/Resultados/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var resultado = await _context.Resultados.FindAsync(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(new ResultadoViewModel
            {
                idresultado = resultado.idresultado,
                resultado = resultado.resultado,
                esaprobacion = resultado.esaprobacion,
                iduseralta = resultado.iduseralta,
                fecalta = resultado.fecalta,
                iduserumod = resultado.iduserumod,
                fecumod = resultado.fecumod,
                activo = resultado.activo
            });
        }

        // PUT: api/Resultados/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ResultadoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idresultado <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var resultado = await _context.Resultados.FirstOrDefaultAsync(c => c.idresultado == model.idresultado);

            if (resultado == null)
            {
                return NotFound();
            }

            resultado.resultado = model.resultado;
            resultado.esaprobacion = model.esaprobacion;
            resultado.iduserumod = model.iduserumod;
            resultado.fecumod = fechaHora;

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

        // POST: api/Resultados/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ResultadoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Resultado resultado = new Resultado
            {
                resultado = model.resultado,
                esaprobacion = model.esaprobacion,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Resultados.Add(resultado);
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

        // DELETE: api/Resultados/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado == null)
            {
                return NotFound();
            }

            _context.Resultados.Remove(resultado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(resultado);
        }

        // PUT: api/Resultados/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var resultado = await _context.Resultados.FirstOrDefaultAsync(c => c.idresultado == id);

            if (resultado == null)
            {
                return NotFound();
            }

            resultado.activo = false;

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

        // PUT: api/Resultados/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var resultado = await _context.Resultados.FirstOrDefaultAsync(c => c.idresultado == id);

            if (resultado == null)
            {
                return NotFound();
            }

            resultado.activo = true;

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

        private bool ResultadoExists(int id)
        {
            return _context.Resultados.Any(e => e.idresultado == id);
        }
    }
}
