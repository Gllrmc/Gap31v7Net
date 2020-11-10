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
    public class PedidofondosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PedidofondosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Pedidofondos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PedidofondoViewModel>> Listar()
        {
            var pedidofondo = await _context.Pedidosfondo
                .Include(p => p.proyecto)
                .Where(p => p.proyecto.activo == true && p.proyecto.cierreprod == false && p.proyecto.cierreadmin == false)
                .Include(p => p.responsable)
                .Include(p => p.subrubro)
                .OrderBy(p => p.idpedidofondo)
                .AsNoTracking()
                .ToListAsync();

            return pedidofondo.Select(a => new PedidofondoViewModel
            {
                idpedidofondo = a.idpedidofondo,
                idproyecto = a.idproyecto,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idsubrubro = a.subrubro.idsubrubro,
                subrubro = String.Concat(a.subrubro.orden,'-',a.subrubro.subrubroes),
                idresponsable = a.idresponsable,
                responsable = a.responsable.nombre,
                numpedido = a.numpedido,
                fecpedido = a.fecpedido,
                importe = a.importe,
                notas = a.notas,
                entregado = a.entregado,
                rendido = a.rendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Pedidofondos/ListarProyecto
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<PedidofondoViewModel>> ListarProyecto([FromRoute] int id)
        {
            var pedidofondo = await _context.Pedidosfondo
                .Include(p => p.proyecto)
                .Where(p => p.idproyecto == id && p.proyecto.activo == true && p.proyecto.cierreprod == false && p.proyecto.cierreadmin == false)
                .Include(p => p.responsable)
                .Include(p => p.subrubro)
                .OrderBy(p => p.idpedidofondo)
                .AsNoTracking()
                .ToListAsync();

            return pedidofondo.Select(a => new PedidofondoViewModel
            {
                idpedidofondo = a.idpedidofondo,
                idproyecto = a.idproyecto,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idsubrubro = a.subrubro.idsubrubro,
                subrubro = String.Concat(a.subrubro.orden,'-',a.subrubro.subrubroes),
                idresponsable = a.idresponsable,
                responsable = a.responsable.nombre,
                numpedido = a.numpedido,
                fecpedido = a.fecpedido,
                importe = a.importe,
                notas = a.notas,
                entregado = a.entregado,
                rendido = a.rendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Pedidofondos/ListarActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<PedidofondoViewModel>> ListarActivos()
        {
            var pedidofondo = await _context.Pedidosfondo
                .Include(p => p.proyecto)
                .Where(p => p.entregado == true && p.activo == true && p.proyecto.activo == true && p.proyecto.cierreprod == false && p.proyecto.cierreadmin == false)
                .Include(p => p.responsable)
                .Include(p => p.subrubro)
                .OrderBy(p => p.idpedidofondo)
                .AsNoTracking()
                .ToListAsync();

            return pedidofondo.Select(a => new PedidofondoViewModel
            {
                idpedidofondo = a.idpedidofondo,
                idproyecto = a.idproyecto,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idsubrubro = a.subrubro.idsubrubro,
                subrubro = String.Concat(a.subrubro.orden, '-', a.subrubro.subrubroes),
                idresponsable = a.idresponsable,
                responsable = a.responsable.nombre,
                numpedido = a.numpedido,
                fecpedido = a.fecpedido,
                importe = a.importe,
                notas = a.notas,
                entregado = a.entregado,
                rendido = a.rendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Pedidofondos/Listaractivosusuario/2
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<PedidofondoViewModel>> Listaractivosusuario([FromRoute] int id)
        {
            var pedidofondo = await _context.Sqlpedidofondo
                .FromSqlRaw($@"
                    Select f.idpedidofondo, p.idproyecto, p.orden, p.proyecto, s.idsubrubro, s.subrubro,
                        r.idpersona idresponsable, r.nombre responsable, f.numpedido, f.fecpedido, f.importe, f.notas, f.entregado, f.rendido, 
                        f.iduseralta, f.fecalta, f.iduserumod, f.fecumod, f.activo
                    From usuarioproyectos u
                    Left Join proyectos p ON p.idproyecto = u.idproyecto
                    left join pedidosfondo f ON f.idproyecto = p.idproyecto
                    left join subrubros s ON s.idsubrubro = f.idsubrubro
                    left join personas r ON r.idpersona = f.idresponsable
                    Where idpedidofondo is not null and f.entregado is not null and f.activo is not null and u.idusuario = {id}
                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return pedidofondo.Select(a => new PedidofondoViewModel
            {
                idpedidofondo = a.idpedidofondo,
                idproyecto = a.idproyecto,
                orden = a.orden,
                proyecto = a.proyecto,
                idsubrubro = a.idsubrubro,
                subrubro = a.subrubro,
                idresponsable = a.idresponsable,
                responsable = a.responsable,
                numpedido = a.numpedido,
                fecpedido = a.fecpedido,
                importe = a.importe,
                notas = a.notas,
                entregado = a.entregado,
                rendido = a.rendido,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Pedidofondos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<PedidofondoSelectModel>> Select()

        {
            var pedidofondo = await _context.Pedidosfondo
                .Where(p => p.activo == true)
                .Include(p => p.proyecto)
                .Where(p => p.proyecto.activo == true && p.proyecto.cierreprod == false && p.proyecto.cierreadmin == false)
                .Include(p => p.responsable)
                .OrderBy(p => p.idpedidofondo)
                .ToListAsync();

            return pedidofondo.Select(a => new PedidofondoSelectModel
            {
                idpedidofondo = a.idpedidofondo,
                idproyecto = a.idproyecto,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                numpedido = a.numpedido,
                idresponsable = a.idresponsable,
                responsable = a.responsable.nombre
            });

        }

        // GET: api/Pedidofondos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var pedidofondo = await _context.Pedidosfondo
                .Where(p => p.activo == true)
                .Include(p => p.proyecto)
                .Where(p => p.proyecto.activo == true && p.proyecto.cierreprod == false && p.proyecto.cierreadmin == false)
                .Include(p => p.responsable)
                .OrderBy(p => p.idpedidofondo)
                .SingleOrDefaultAsync(p => p.idpedidofondo == id);

            if (pedidofondo == null)
            {
                return NotFound();
            }

            return Ok(new PedidofondoViewModel
            {
                idpedidofondo = pedidofondo.idpedidofondo,
                idproyecto = pedidofondo.idproyecto,
                proyecto = pedidofondo.proyecto.proyecto,
                numpedido = pedidofondo.numpedido,
                idresponsable = pedidofondo.idresponsable,
                responsable = pedidofondo.responsable.nombre
            });
        }

        // PUT: api/Pedidofondos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PedidofondoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idpedidofondo <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var pedidofondo = await _context.Pedidosfondo.FirstOrDefaultAsync(a => a.idpedidofondo == model.idpedidofondo);

            if (pedidofondo == null)
            {
                return NotFound();
            }

            pedidofondo.idpedidofondo = model.idpedidofondo;
            pedidofondo.idproyecto = model.idproyecto;
            pedidofondo.idsubrubro = model.idsubrubro;
            pedidofondo.idresponsable = model.idresponsable;
            pedidofondo.numpedido = model.numpedido;
            pedidofondo.fecpedido = model.fecpedido;
            pedidofondo.importe = model.importe;
            pedidofondo.notas = model.notas;
            pedidofondo.entregado = model.entregado;
            pedidofondo.rendido = model.rendido;
            pedidofondo.iduserumod = model.iduserumod;
            pedidofondo.fecumod = fechaHora;

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

        // POST: api/Pedidofondos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] PedidofondoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            var numpedido = _context.Pedidosfondo.Where(p => p.idproyecto == model.idproyecto).Max(x => (int?)x.numpedido) ?? 0;

            Pedidofondo pedidofondo = new Pedidofondo
            {

                idproyecto = model.idproyecto,
                idsubrubro = model.idsubrubro,
                idresponsable = model.idresponsable,
                numpedido = numpedido + 1,
                fecpedido = model.fecpedido,
                importe = model.importe,
                notas = model.notas,
                entregado = model.entregado,
                rendido = model.rendido,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Pedidosfondo.Add(pedidofondo);
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

        // PUT: api/Pedidofondos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var pedidofondo = await _context.Pedidosfondo.FirstOrDefaultAsync(a => a.idpedidofondo == id);

            if (pedidofondo == null)
            {
                return NotFound();
            }

            pedidofondo.activo = false;

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

        // PUT: api/Pedidofondos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var pedidofondo = await _context.Pedidosfondo.FirstOrDefaultAsync(a => a.idpedidofondo == id);

            if (pedidofondo == null)
            {
                return NotFound();
            }

            pedidofondo.activo = true;

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

        // PUT: api/Pedidofondos/DesactivarEntrega/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DesactivarEntrega([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var pedidofondo = await _context.Pedidosfondo.FirstOrDefaultAsync(a => a.idpedidofondo == id);

            if (pedidofondo == null)
            {
                return NotFound();
            }

            var haydistribucionfondo = await _context.Distribucionfondos
                .Include(p => p.pedidofondo)
                .Where(p => p.idpedidofondo == id)
                .CountAsync();

            if ( haydistribucionfondo > 0 )
            {
                return BadRequest();
            }

            pedidofondo.entregado = false;

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

        // PUT: api/Pedidofondos/ActivarEntrega/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> ActivarEntrega([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var pedidofondo = await _context.Pedidosfondo.FirstOrDefaultAsync(a => a.idpedidofondo == id);

            if (pedidofondo == null)
            {
                return NotFound();
            }

            pedidofondo.entregado = true;

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

        private bool PedidofondoExists(int id)
        {
            return _context.Pedidosfondo.Any(e => e.idpedidofondo == id);
        }
    }
}
