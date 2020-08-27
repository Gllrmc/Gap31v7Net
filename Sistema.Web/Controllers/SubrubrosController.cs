using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Jerarquia;
using Sistema.Web.Models.Jerarquia;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubrubrosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public SubrubrosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Subrubros/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SubrubroViewModel>> Listar()
        {
            var subrubro = await _context.Subrubros
                .Include(a => a.rubros)
                .ToListAsync();

            return subrubro.Select(a => new SubrubroViewModel
            {
                idsubrubro = a.idsubrubro,
                idrubro = a.idrubro,
                rubroorden = a.rubros.orden,
                rubroes = a.rubros.rubroes,
                rubroen = a.rubros.rubroen,
                subrubroes = a.subrubroes,
                subrubroen = a.subrubroen,
                post = a.post,
                vivo = a.vivo,
                conf = a.conf,
                orden = a.orden,
                numhoja = a.numhoja,
                activo = a.activo
            });

        }

        // GET: api/Subrubros/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SubrubroSelectModel>> Select()
        {
            var subrubro = await _context.Subrubros
                .Where(r => r.activo == true)
                .OrderBy(r => r.orden)
                .ToListAsync();

            return subrubro.Select(r => new SubrubroSelectModel
            {
                idsubrubro = r.idsubrubro,
                orden = r.orden,
                subrubroes = r.subrubroes,
                subrubroen = r.subrubroen,
                subrubro = r.subrubro,
                post = r.post,
                vivo = r.vivo,
                conf = r.conf
            });
        }

        // GET: api/Subrubros/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var subrubro = await _context.Subrubros.Include(a => a.rubros).
                            SingleOrDefaultAsync(a => a.idsubrubro == id);

            if (subrubro == null)
            {
                return NotFound();
            }

            return Ok(new SubrubroViewModel
            {
                idsubrubro = subrubro.idsubrubro,
                idrubro = subrubro.idrubro,
                rubroes = subrubro.rubros.rubroes,
                rubroen = subrubro.rubros.rubroen,
                subrubroes = subrubro.subrubroes,
                subrubroen = subrubro.subrubroen,
                orden = subrubro.orden,
                numhoja = subrubro.numhoja,
                post = subrubro.post,
                vivo = subrubro.vivo,
                conf = subrubro.conf,
                activo = subrubro.activo
            });
        }

        // PUT: api/Subrubros/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] SubrubroUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idsubrubro <= 0)
            {
                return BadRequest();
            }

            var subrubro = await _context.Subrubros.FirstOrDefaultAsync(a => a.idsubrubro == model.idsubrubro);

            if (subrubro == null)
            {
                return NotFound();
            }

            subrubro.idrubro = model.idrubro;
            subrubro.subrubroes = model.subrubroes;
            subrubro.subrubroen = model.subrubroen;
            subrubro.orden = model.orden;
            subrubro.numhoja = model.numhoja;
            subrubro.post = model.post;
            subrubro.vivo = model.vivo;
            subrubro.conf = model.conf;

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

        // POST: api/Sububros/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] SubrubroCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Subrubro subrubro = new Subrubro
            {
                idrubro = model.idrubro,
                subrubroes = model.subrubroes,
                subrubroen = model.subrubroen,
                orden = model.orden,
                numhoja = model.numhoja,
                post = model.post,
                vivo = model.vivo,
                conf = model.conf,
                activo = true
            };

            _context.Subrubros.Add(subrubro);
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

        // PUT: api/Sububros/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var subrubro = await _context.Subrubros.FirstOrDefaultAsync(c => c.idsubrubro == id);

            if (subrubro == null)
            {
                return NotFound();
            }

            subrubro.activo = false;

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

        // PUT: api/Subrubros/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var subrubro = await _context.Subrubros.FirstOrDefaultAsync(c => c.idsubrubro == id);

            if (subrubro == null)
            {
                return NotFound();
            }

            subrubro.activo = true;

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

        private bool SubrubroExists(int id)
        {
            return _context.Subrubros.Any(e => e.idsubrubro == id);
        }
    }
}
