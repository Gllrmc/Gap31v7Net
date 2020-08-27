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
using Sistema.Web.Models.Maestros.Productoras;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductorasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ProductorasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Productoras/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductoraViewModel>> Listar()
        {
            var Productora = await _context.Productoras.ToListAsync();

            return Productora.Select(r => new ProductoraViewModel
            {
                idproductora = r.idproductora,
                productora = r.productora,
                activo = r.activo
            });

        }

        // GET: api/Productoras/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductoraSelectModel>> Select()
        {
            var productora = await _context.Productoras.Where(r => r.activo == true).ToListAsync();

            return productora.Select(r => new ProductoraSelectModel
            {
                idproductora = r.idproductora,
                productora = r.productora
            });
        }

        // GET: api/Productoras/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var productora = await _context.Productoras.FindAsync(id);

            if (productora == null)
            {
                return NotFound();
            }

            return Ok(new ProductoraViewModel
            {
                idproductora = productora.idproductora,
                productora = productora.productora
            });
        }

        // PUT: api/Productoras/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProductoraUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idproductora <= 0)
            {
                return BadRequest();
            }

            var productora = await _context.Productoras.FirstOrDefaultAsync(c => c.idproductora == model.idproductora);

            if (productora == null)
            {
                return NotFound();
            }

            productora.productora = model.productora;

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

        // POST: api/Productoras/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ProductoraCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Productora productora = new Productora
            {
                productora = model.productora,
                activo = true
            };

            _context.Productoras.Add(productora);
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

        // DELETE: api/Productoras/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productora = await _context.Productoras.FindAsync(id);
            if (productora == null)
            {
                return NotFound();
            }

            _context.Productoras.Remove(productora);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(productora);
        }

        // PUT: api/Productoras/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var productora = await _context.Productoras.FirstOrDefaultAsync(c => c.idproductora == id);

            if (productora == null)
            {
                return NotFound();
            }

            productora.activo = false;

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

        // PUT: api/Productoras/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var productora = await _context.Productoras.FirstOrDefaultAsync(c => c.idproductora == id);

            if (productora == null)
            {
                return NotFound();
            }

            productora.activo = true;

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


        private bool ProductoraExists(int id)
        {
            return _context.Productoras.Any(e => e.idproductora == id);
        }
    }
}
