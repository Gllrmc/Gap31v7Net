using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Fondos;
using Sistema.Web.Models.Fondos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class DistribucionfondosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public DistribucionfondosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Distribucionfondos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<DistribucionfondoViewModel>> Listar()
        {
            var distribucionfondo = await _context.Distribucionfondos
                .Include(p => p.usuario)
                .Include(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.pedidofondo.activo == true && p.pedidofondo.proyecto.activo == true && p.pedidofondo.proyecto.cierreprod == false && p.pedidofondo.proyecto.cierreadmin == false)
                .OrderBy(p => p.iddistribucionfondo)
                .ToListAsync();

            return distribucionfondo.Select(a => new DistribucionfondoViewModel
            {
                iddistribucionfondo = a.iddistribucionfondo,
                idproyecto = a.pedidofondo.idproyecto,
                proyecto = a.pedidofondo.proyecto.proyecto,
                orden = a.pedidofondo.proyecto.orden,
                idusuario = a.idusuario,
                idpedidofondo = a.idpedidofondo,
                usuario = a.usuario.userid,
                numpedido = a.pedidofondo.numpedido,
                fecdistribucion = a.fecdistribucion,
                devolucion = a.devolucion,
                importe = a.importe,
                notas = a.notas,
                rendido = a.rendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Distribucionfondos/ListarActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<DistribucionfondoViewModel>> ListarActivos()
        {
            var distribucionfondo = await _context.Distribucionfondos
                .Include(p => p.usuario)
                .Include(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.activo == true && p.pedidofondo.activo == true && p.pedidofondo.proyecto.activo == true && p.pedidofondo.proyecto.cierreprod == false && p.pedidofondo.proyecto.cierreadmin == false)
                .OrderBy(p => p.iddistribucionfondo)
                .ToListAsync();

            return distribucionfondo.Select(a => new DistribucionfondoViewModel
            {
                iddistribucionfondo = a.iddistribucionfondo,
                idproyecto = a.pedidofondo.idproyecto,
                proyecto = a.pedidofondo.proyecto.proyecto,
                orden = a.pedidofondo.proyecto.orden,
                idusuario = a.idusuario,
                usuario = a.usuario.userid,
                idpedidofondo = a.idpedidofondo,
                numpedido = a.pedidofondo.numpedido,
                fecdistribucion = a.fecdistribucion,
                devolucion = a.devolucion,
                importe = a.importe,
                notas = a.notas,
                rendido = a.rendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Distribucionfondos/Listaractivosusuario/6
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<DistribucionfondoViewModel>> Listaractivosusuario([FromRoute] int id)
        {
            var distribucionfondo = await _context.Distribucionfondos
                .Include(p => p.usuario)
                .Include(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.idusuario == id && p.activo == true && p.pedidofondo.activo == true && p.pedidofondo.proyecto.activo == true && p.pedidofondo.proyecto.cierreprod == false && p.pedidofondo.proyecto.cierreadmin == false)
                .OrderBy(p => p.iddistribucionfondo)
                .ToListAsync();

            return distribucionfondo.Select(a => new DistribucionfondoViewModel
            {
                iddistribucionfondo = a.iddistribucionfondo,
                idproyecto = a.pedidofondo.idproyecto,
                proyecto = a.pedidofondo.proyecto.proyecto,
                orden = a.pedidofondo.proyecto.orden,
                idusuario = a.idusuario,
                idpedidofondo = a.idpedidofondo,
                usuario = a.usuario.userid,
                numpedido = a.pedidofondo.numpedido,
                fecdistribucion = a.fecdistribucion,
                devolucion = a.devolucion,
                importe = a.importe,
                notas = a.notas,
                rendido = a.rendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Distribucionfondos/ListarPedidofondo
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<DistribucionfondoViewModel>> ListarPedidofondo([FromRoute] int id)
        {
            var distribucionfondo = await _context.Distribucionfondos
                .Include(p => p.usuario)
                .Include(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.idpedidofondo == id)
                .ToListAsync();

            return distribucionfondo.Select(a => new DistribucionfondoViewModel
            {
                iddistribucionfondo = a.iddistribucionfondo,
                idproyecto = a.pedidofondo.idproyecto,
                orden = a.pedidofondo.proyecto.orden,
                proyecto = a.pedidofondo.proyecto.proyecto,
                idpedidofondo = a.idpedidofondo,
                idusuario = a.idusuario,
                usuario = a.usuario.userid,
                numpedido = a.pedidofondo.numpedido,
                fecdistribucion = a.fecdistribucion,
                devolucion = a.devolucion,
                importe = a.importe,
                notas = a.notas,
                rendido = a.rendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Distribucionfondos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<DistribucionfondoSelectModel>> Select()

        {
            var distribucionfondo = await _context.Distribucionfondos
                .Include(p => p.usuario)
                .Include(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.pedidofondo.activo == true && p.pedidofondo.proyecto.activo == true && p.pedidofondo.proyecto.cierreprod == false && p.pedidofondo.proyecto.cierreadmin == false)
                .OrderBy(p => p.iddistribucionfondo)
                .ToListAsync();

            return distribucionfondo.Select(a => new DistribucionfondoSelectModel
            {
                iddistribucionfondo = a.iddistribucionfondo,
                idproyecto = a.pedidofondo.idproyecto,
                orden = a.pedidofondo.proyecto.orden,
                proyecto = a.pedidofondo.proyecto.proyecto,
                numpedido = a.pedidofondo.numpedido,
                idpedidofondo = a.idpedidofondo,
                idusuario = a.idusuario,
                usuario = a.usuario.userid
            });

        }

        // GET: api/Distribucionfondos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var distribucionfondo = await _context.Distribucionfondos
                .Include(p => p.usuario)
                .Include(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.activo == true && p.pedidofondo.activo == true && p.pedidofondo.proyecto.activo == true && p.pedidofondo.proyecto.cierreprod == false && p.pedidofondo.proyecto.cierreadmin == false)
                .OrderBy(p => p.iddistribucionfondo)
                .SingleOrDefaultAsync(p => p.iddistribucionfondo == id);

            if (distribucionfondo == null)
            {
                return NotFound();
            }

            return Ok(new DistribucionfondoViewModel
            {
                iddistribucionfondo = distribucionfondo.iddistribucionfondo,
                idproyecto = distribucionfondo.pedidofondo.idproyecto,
                orden = distribucionfondo.pedidofondo.proyecto.orden,
                proyecto = distribucionfondo.pedidofondo.proyecto.proyecto,
                idpedidofondo = distribucionfondo.idpedidofondo,
                idusuario = distribucionfondo.idusuario,
                usuario = distribucionfondo.usuario.userid,
                numpedido = distribucionfondo.pedidofondo.numpedido,
                fecdistribucion = distribucionfondo.fecdistribucion,
                devolucion = distribucionfondo.devolucion,
                importe = distribucionfondo.importe,
                notas = distribucionfondo.notas,
                rendido = distribucionfondo.rendido,
                iduseralta = distribucionfondo.iduseralta,
                fecalta = distribucionfondo.fecalta,
                iduserumod = distribucionfondo.iduserumod,
                fecumod = distribucionfondo.fecumod,
                activo = distribucionfondo.activo
            });
        }

        // PUT: api/Distribucionfondos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] DistribucionfondoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.iddistribucionfondo <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var distribucionfondo = await _context.Distribucionfondos.FirstOrDefaultAsync(a => a.iddistribucionfondo == model.iddistribucionfondo);

            if (distribucionfondo == null)
            {
                return NotFound();
            }

            distribucionfondo.iddistribucionfondo = model.iddistribucionfondo;
            distribucionfondo.idpedidofondo = model.idpedidofondo;
            distribucionfondo.idusuario = model.idusuario;
            distribucionfondo.fecdistribucion = model.fecdistribucion;
            distribucionfondo.devolucion = model.devolucion;
            distribucionfondo.importe = model.importe;
            distribucionfondo.notas = model.notas;
            distribucionfondo.rendido = model.rendido;
            distribucionfondo.iduserumod = model.iduserumod;
            distribucionfondo.fecumod = model.fecumod;

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

        // POST: api/Distribucionfondos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] DistribucionfondoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Distribucionfondo distribucionfondo = new Distribucionfondo
            {

                idpedidofondo = model.idpedidofondo,
                idusuario = model.idusuario,
                fecdistribucion = model.fecdistribucion,
                devolucion = model.devolucion,
                importe = model.importe,
                notas = model.notas,
                rendido = model.rendido,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Distribucionfondos.Add(distribucionfondo);
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

        // PUT: api/Distribucionfondos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var distribucionfondo = await _context.Distribucionfondos.FirstOrDefaultAsync(a => a.iddistribucionfondo == id);

            if (distribucionfondo == null)
            {
                return NotFound();
            }

            distribucionfondo.activo = false;

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

        // PUT: api/Distribucionfondos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var distribucionfondo = await _context.Distribucionfondos.FirstOrDefaultAsync(a => a.iddistribucionfondo == id);

            if (distribucionfondo == null)
            {
                return NotFound();
            }

            distribucionfondo.activo = true;

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

        // PUT: api/Distribucionfondos/DesactivarRendido/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DesactivarRendido([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var distribucionfondo = await _context.Distribucionfondos.FirstOrDefaultAsync(a => a.iddistribucionfondo == id);

            if (distribucionfondo == null)
            {
                return NotFound();
            }

            distribucionfondo.rendido = false;

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

        // PUT: api/Distribucionfondos/ActivarRendido/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> ActivarRendido([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var distribucionfondo = await _context.Distribucionfondos.FirstOrDefaultAsync(a => a.iddistribucionfondo == id);

            if (distribucionfondo == null)
            {
                return NotFound();
            }

            distribucionfondo.rendido = true;

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

        private bool DistribucionfondoExists(int id)
        {
            return _context.Distribucionfondos.Any(e => e.iddistribucionfondo == id);
        }
    }
}
