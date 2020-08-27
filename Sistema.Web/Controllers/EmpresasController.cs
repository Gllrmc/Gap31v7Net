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
using Sistema.Web.Models.Maestros.Empresas;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public EmpresasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Empresas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<EmpresaViewModel>> Listar()
        {
            var empresa = await _context.Empresas.Include(a => a.provincia).Include(a => a.pais).ToListAsync();

            return empresa.Select(a => new EmpresaViewModel
            {
                idempresa = a.idempresa,
                empresa = a.empresa,
                cuit = a.cuit,
                direccion = a.direccion,
                localidad = a.localidad,
                cpostal = a.cpostal,
                idprovincia = a.idprovincia,
                provincia = a.provincia.provincia,
                idpais = a.idpais,
                pais = a.pais.pais,
                telefono = a.telefono,
                email = a.email,
                webpage = a.webpage,
                activo = a.activo
            });

        }

        // GET: api/Empresas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<EmpresaSelectModel>> Select()
        {
            var empresa = await _context.Empresas.Where(r => r.activo == true).OrderBy(r => r.empresa).ToListAsync();

            return empresa.Select(r => new EmpresaSelectModel
            {
                idempresa = r.idempresa,
                empresa = r.empresa
            });
        }

        // GET: api/Empresas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var empresa = await _context.Empresas.Include(a => a.pais).Include(a => a.provincia).SingleOrDefaultAsync(a => a.idempresa == id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(new EmpresaViewModel
            {
                idempresa = empresa.idempresa,
                empresa = empresa.empresa,
                cuit = empresa.cuit,
                direccion = empresa.direccion,
                localidad = empresa.localidad,
                cpostal = empresa.cpostal,
                idprovincia = empresa.idprovincia,
                provincia = empresa.provincia.provincia,
                idpais = empresa.idpais,
                pais = empresa.pais.pais,
                telefono = empresa.telefono,
                email = empresa.email,
                webpage = empresa.webpage,
                activo = empresa.activo
            });
        }

        // PUT: api/Empresas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] EmpresaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idempresa <= 0)
            {
                return BadRequest();
            }

            var empresa = await _context.Empresas.FirstOrDefaultAsync(a => a.idempresa == model.idempresa);

            if (empresa == null)
            {
                return NotFound();
            }

            empresa.empresa = model.empresa;
            empresa.cuit = model.cuit;
            empresa.direccion = model.direccion;
            empresa.localidad = model.localidad;
            empresa.cpostal = model.cpostal;
            empresa.idprovincia = model.idprovincia;
            empresa.idpais = model.idpais;
            empresa.telefono = model.telefono;
            empresa.email = model.email;
            empresa.webpage = model.webpage;

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
        public async Task<IActionResult> Crear([FromBody] EmpresaCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Empresa empresa = new Empresa
            {
                empresa = model.empresa,
                cuit = model.cuit,
                direccion = model.direccion,
                localidad = model.localidad,
                cpostal = model.cpostal,
                idprovincia = model.idprovincia,
                idpais = model.idpais,
                telefono = model.telefono,
                email = model.email,
                webpage = model.webpage,
                activo = true
            };

            _context.Empresas.Add(empresa);
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

            var empresa = await _context.Empresas.FirstOrDefaultAsync(c => c.idempresa == id);

            if (empresa == null)
            {
                return NotFound();
            }

            empresa.activo = false;

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

        // PUT: api/Empresas/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var empresa = await _context.Empresas.FirstOrDefaultAsync(c => c.idempresa == id);

            if (empresa == null)
            {
                return NotFound();
            }

            empresa.activo = true;

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


        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.idempresa == id);
        }
    }
}
