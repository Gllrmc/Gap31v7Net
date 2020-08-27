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
using Sistema.Web.Models.Maestros.Clientes;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ClientesController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Clientes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ClienteViewModel>> Listar()
        {
            var cliente = await _context.Clientes.Include(a => a.paises).Include(a => a.provincias).Include(a => a.persona).ToListAsync();

            return cliente.Select(a => new ClienteViewModel
            {
                idcliente = a.idcliente,
                idpersona = a.idpersona,
                razonsocial = a.razonsocial,
                cuit = a.cuit,
                situacioniva = a.situacioniva,
                situacioniibb = a.situacioniibb,
                jurisdiccion = a.jurisdiccion,
                email = a.email,
                telefono = a.telefono,
                direccion = a.direccion,
                localidad = a.localidad,
                cpostal = a.cpostal,
                idprovincia = a.idprovincia,
                provincia = a.provincias.provincia,
                idpais = a.idpais,
                pais = a.paises.pais,
                persona = a.idpersona.HasValue ? a.persona.nombre : "",
                emailpersonal = a.idpersona.HasValue ? a.persona.emailpersonal : "",
                telefonopersonal = a.idpersona.HasValue ? a.persona.telefonopersonal : "",
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Clientes/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var cliente = await _context.Clientes
                .Include(a => a.paises)
                .Include(a => a.provincias)
                .Include(a => a.persona)
                .SingleOrDefaultAsync(a => a.idcliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(new ClienteViewModel
            {
                idcliente = cliente.idcliente,
                idpersona = cliente.idpersona,
                razonsocial = cliente.razonsocial,
                cuit = cliente.cuit,
                situacioniva = cliente.situacioniva,
                situacioniibb = cliente.situacioniibb,
                jurisdiccion = cliente.jurisdiccion,
                email = cliente.email,
                telefono = cliente.telefono,
                direccion = cliente.direccion,
                localidad = cliente.localidad,
                cpostal = cliente.cpostal,
                idprovincia = cliente.idprovincia,
                idpais = cliente.idpais,
                iduseralta = cliente.iduseralta,
                fecalta = cliente.fecalta,
                iduserumod = cliente.iduserumod,
                fecumod = cliente.fecumod,
                activo = cliente.activo
            });
        }

        // GET: api/Clientes/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ClienteSelectModel>> Select()
        {
            var cliente = await _context.Clientes.OrderBy(a => a.razonsocial).ToListAsync();

            return cliente.Select(r => new ClienteSelectModel
            {
                idcliente = r.idcliente,
                razonsocial = r.razonsocial,
                activo = r.activo
            });
        }

        // GET: api/Clientes/SelectActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<ClienteSelectModel>> SelectActivos()
        {
            var cliente = await _context.Clientes.Where(r => r.activo == true).ToListAsync();

            return cliente.Select(r => new ClienteSelectModel
            {
                idcliente = r.idcliente,
                razonsocial = r.razonsocial
            });
        }

        // PUT: api/Clientes/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ClienteUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcliente <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var cliente = await _context.Clientes.FirstOrDefaultAsync(a => a.idcliente == model.idcliente);

            if (cliente == null)
            {
                return NotFound();
            }
            cliente.idcliente = model.idcliente;
            cliente.idpersona = model.idpersona;
            cliente.razonsocial = model.razonsocial;
            cliente.cuit = model.cuit;
            cliente.situacioniva = model.situacioniva;
            cliente.situacioniibb = model.situacioniibb;
            cliente.jurisdiccion = model.jurisdiccion;
            cliente.email = model.email;
            cliente.telefono = model.telefono;
            cliente.direccion = model.direccion;
            cliente.localidad = model.localidad;
            cliente.cpostal = model.cpostal;
            cliente.idprovincia = model.idprovincia;
            cliente.idpais = model.idpais;
            cliente.iduseralta = model.iduseralta;
            cliente.fecalta = model.fecalta;
            cliente.iduserumod = model.iduserumod;
            cliente.fecumod = fechaHora;
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

        // POST: api/Clientes/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ClienteCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            Cliente cliente = new Cliente
            {
                idpersona = model.idpersona,
                razonsocial = model.razonsocial,
                cuit = model.cuit,
                situacioniva = model.situacioniva,
                situacioniibb = model.situacioniibb,
                jurisdiccion = model.jurisdiccion,
                email = model.email,
                telefono = model.telefono,
                direccion = model.direccion,
                localidad = model.localidad,
                cpostal = model.cpostal,
                idprovincia = model.idprovincia,
                idpais = model.idpais,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Clientes.Add(cliente);
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

        // PUT: api/Clientes/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(a => a.idcliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.activo = false;

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

        // PUT: api/Clientes/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(a => a.idcliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.activo = true;

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


        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.idcliente == id);
        }
    }
}
