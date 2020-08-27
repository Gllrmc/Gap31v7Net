using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using Sistema.Web.Models.Usuarios.Usuarioproyecto;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioproyectosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public UsuarioproyectosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Usuarioproyectos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioproyectoViewModel>> Listar()
        {
            var usuarioproyecto = await _context.Usuarioproyectos
                .Include(p => p.usuario)
                .Include(p => p.proyecto)
                .OrderBy(p => p.idproyecto)
                .Where(p => p.proyecto.activo == true && p.proyecto.cierreadmin == false && p.proyecto.cierreprod == false)
                .AsNoTracking()
                .ToListAsync();

            return usuarioproyecto.Select(a => new UsuarioproyectoViewModel
            {
                idusuarioproyecto = a.idusuarioproyecto,
                idusuario = a.idusuario,
                userid = a.usuario.userid,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                vivo = a.vivo,
                post = a.post,
                confidencial = a.confidencial,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Usuarioproyectos/ListarActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioproyectoViewModel>> ListarActivos()
        {
            var usuarioproyecto = await _context.Usuarioproyectos
                .Include(p => p.usuario)
                .Include(p => p.proyecto)
                .Where(p => p.activo == true)
                .AsNoTracking()
                .ToListAsync();

            return usuarioproyecto.Select(a => new UsuarioproyectoViewModel
            {
                idusuarioproyecto = a.idusuarioproyecto,
                idusuario = a.idusuario,
                idproyecto = a.idproyecto,
                vivo = a.vivo,
                post = a.post,
                confidencial = a.confidencial,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Usuarioproyectos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioproyectoSelectModel>> Select()
        {
            var usuarioproyecto = await _context.Usuarioproyectos
                .Include(p => p.usuario)
                .Include(p => p.proyecto)
                .OrderBy(p => p.idproyecto)
                .Where(p => p.proyecto.activo == true && p.proyecto.cierreadmin == false && p.proyecto.cierreprod == false)
                .AsNoTracking()
                .ToListAsync();

            return usuarioproyecto.Select(a => new UsuarioproyectoSelectModel
            {
                idusuarioproyecto = a.idusuarioproyecto,
                idusuario = a.idusuario,
                idproyecto = a.idproyecto,
                vivo = a.vivo,
                post = a.post,
                confidencial = a.confidencial,
            });
        }

        // GET: api/Usuarioproyectos/SelectDeUsuario/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<UsuarioproyectoSelectModel>> SelectDeUsuario([FromRoute] int id)
        {
            var usuarioproyecto = await _context.Usuarioproyectos
                .Include(p => p.usuario)
                .Include(p => p.proyecto)
                .OrderBy(p => p.idproyecto)
                .Where(p => p.idusuario == id && p.proyecto.activo == true && p.proyecto.cierreadmin == false && p.proyecto.cierreprod == false)
                .AsNoTracking()
                .ToListAsync();

            return usuarioproyecto.Select(a => new UsuarioproyectoSelectModel
            {
                idusuarioproyecto = a.idusuarioproyecto,
                idusuario = a.idusuario,
                idproyecto = a.idproyecto,
                vivo = a.vivo,
                post = a.post,
                confidencial = a.confidencial,
            });
        }

        // PUT: api/Usuarioproyectos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioproyectoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idproyecto <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == model.idusuarioproyecto);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }
            usuarioproyecto.idusuarioproyecto = model.idusuarioproyecto;
            usuarioproyecto.idusuario = model.idusuario;
            usuarioproyecto.idproyecto = model.idproyecto;
            usuarioproyecto.vivo = model.vivo;
            usuarioproyecto.post = model.post;
            usuarioproyecto.confidencial = model.confidencial;
            usuarioproyecto.iduserumod = model.iduserumod;
            usuarioproyecto.fecumod = fechaHora;
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

        // POST: api/Usuarioproyectos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] UsuarioproyectoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Usuarioproyecto usuarioproyecto = new Usuarioproyecto
            {
                idusuario = model.idusuario,
                idproyecto = model.idproyecto,
                vivo = model.vivo,
                post = model.post,
                confidencial = model.confidencial,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Usuarioproyectos.Add(usuarioproyecto);
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

        // PUT: api/Usuarioproyectos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == id);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }

            usuarioproyecto.activo = false;

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

        // PUT: api/Usuarioproyectos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == id);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }

            usuarioproyecto.activo = true;

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

        // PUT: api/Usuarioproyectos/DesactivarC/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DesactivarC([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == id);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }

            usuarioproyecto.confidencial = false;

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

        // PUT: api/Usuarioproyectos/ActivarC/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> ActivarC([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == id);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }

            usuarioproyecto.confidencial = true;

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

        // PUT: api/Usuarioproyectos/DesactivarV/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DesactivarV([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == id);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }

            usuarioproyecto.vivo = false;

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

        // PUT: api/Usuarioproyectos/ActivarV/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> ActivarV([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == id);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }

            usuarioproyecto.vivo = true;

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

        // PUT: api/Usuarioproyectos/DesactivarP/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DesactivarP([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == id);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }

            usuarioproyecto.post = false;

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

        // PUT: api/Usuarioproyectos/ActivarP/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> ActivarP([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuarioproyecto = await _context.Usuarioproyectos.FirstOrDefaultAsync(a => a.idusuarioproyecto == id);

            if (usuarioproyecto == null)
            {
                return NotFound();
            }

            usuarioproyecto.post = true;

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


        private bool UsuarioproyectoExists(int id)
        {
            return _context.Usuarioproyectos.Any(e => e.idusuarioproyecto == id);
        }
    }
}
