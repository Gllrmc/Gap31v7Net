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
using Sistema.Web.Models.Maestros.Personas;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PersonasController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Personas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaViewModel>> Listar()
        {
            var persona = await _context.Personas.Include(a => a.paises).Include(a => a.provincias).OrderBy(a => a.nombre).ToListAsync();

            return persona.Select(a => new PersonaViewModel
            {
                idpersona = a.idpersona,
                nombre = a.nombre,
                domicilio = a.domicilio,
                localidad = a.localidad,
                cpostal = a.cpostal,
                idpais = a.idpais,
                pais = a.paises.pais,
                idprovincia = a.idprovincia,
                provincia = a.provincias.provincia,
                emailpersonal = a.emailpersonal,
                telefonopersonal = a.telefonopersonal,
                tipodocumento = a.tipodocumento,
                numdocumento = a.numdocumento,
                manejafondos = a.manejafondos,
                esep = a.esep,
                eslp = a.eslp,
                escp = a.escp,
                escrew = a.escrew,
                esproveedor = a.esproveedor,
                escliente = a.escliente,
                esdirector = a.esdirector,
                activo = a.activo
            });

        }

        // GET: api/Personas/SelectContactoCliente
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectContactoCliente()
        {
            var persona = await _context.Personas
                .Where(r => r.activo == true && r.escliente == true)
                .OrderBy(a => a.nombre)
                .ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/SelectContactoProveedor
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectContactoProveedor()
        {
            var persona = await _context.Personas.Where(r => r.activo == true && r.esproveedor == true).OrderBy(a => a.nombre).ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/SelectContactoCrew
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectContactoCrew()
        {
            var persona = await _context.Personas
                .Where(r => r.activo == true && r.escrew == true)
                .OrderBy(a => a.nombre)
                .ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/SelectDirectores
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectDirectores()
        {
            var persona = await _context.Personas
                .Where(r => r.activo == true && r.esdirector == true)
                .OrderBy(a => a.nombre)
                .ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/SelectEps
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectEps()
        {
            var persona = await _context.Personas.Where(r => r.activo == true && r.esep == true).OrderBy(a => a.nombre).ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/SelectEpsusuario/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectEpsusuario([FromRoute] int id)
        {
            var persona = await _context.Personas
                .Include(p => p.usuario)
                .Where(r => r.usuario.idusuario == id && r.usuario.idpersona == r.idpersona && r.activo == true && r.esep == true)
                .OrderBy(a => a.nombre).ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/SelectLps
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectLps()
        {
            var persona = await _context.Personas.Where(r => r.activo == true && r.eslp == true).OrderBy(a => a.nombre).ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/SelectCps
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectCps()
        {
            var persona = await _context.Personas.Where(r => r.activo == true && r.escp == true).OrderBy(a => a.nombre).ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/SelectResponsables
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> SelectResponsables()
        {
            var persona = await _context.Personas.Where(r => r.activo == true && r.manejafondos == true).OrderBy(a => a.nombre).ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<PersonaSelectModel>> Select()
        {
            var persona = await _context.Personas.Where(r => r.activo == true).OrderBy(a => a.nombre).ToListAsync();

            return persona.Select(r => new PersonaSelectModel
            {
                idpersona = r.idpersona,
                nombre = r.nombre
            });
        }

        // GET: api/Personas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var persona = await _context.Personas
                .Include(a => a.paises)
                .Include(a => a.provincias)
                .SingleOrDefaultAsync(a => a.idpersona == id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(new PersonaViewModel
            {
                idpersona = persona.idpersona,
                idpais = persona.idpais,
                idprovincia = persona.idprovincia,
                pais = persona.paises.pais,
                provincia = persona.provincias.provincia,
                nombre = persona.nombre,
                domicilio = persona.domicilio,
                localidad = persona.localidad,
                cpostal = persona.cpostal,
                emailpersonal = persona.emailpersonal,
                telefonopersonal = persona.telefonopersonal,
                tipodocumento = persona.tipodocumento,
                numdocumento = persona.numdocumento,
                manejafondos = persona.manejafondos,
                esep = persona.esep,
                eslp = persona.eslp,
                escp = persona.escp,
                escrew = persona.escrew,
                esproveedor = persona.esproveedor,
                escliente = persona.escliente,
                esdirector = persona.esdirector,
                activo = persona.activo
            });
        }

        // PUT: api/Personas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PersonaUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idpersona <= 0)
            {
                return BadRequest();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(a => a.idpersona == model.idpersona);

            if (persona == null)
            {
                return NotFound();
            }

            persona.idpersona = model.idpersona;
            persona.nombre = model.nombre;
            persona.domicilio = model.domicilio;
            persona.localidad = model.localidad;
            persona.cpostal = model.cpostal;
            persona.idprovincia = model.idprovincia;
            persona.idpais = model.idpais;
            persona.emailpersonal = model.emailpersonal;
            persona.telefonopersonal = model.telefonopersonal;
            persona.tipodocumento = model.tipodocumento;
            persona.numdocumento = model.numdocumento;
            persona.manejafondos = model.manejafondos;
            persona.esep = model.esep;
            persona.eslp = model.eslp;
            persona.escp = model.escp;
            persona.escrew = model.escrew;
            persona.esproveedor = model.esproveedor;
            persona.escliente = model.escliente;
            persona.esdirector = model.esdirector;
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

        // POST: api/Personas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] PersonaCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Persona persona = new Persona
            {
                idpais = model.idpais,
                idprovincia = model.idprovincia,
                nombre = model.nombre,
                domicilio = model.domicilio,
                localidad = model.localidad,
                cpostal = model.cpostal,
                emailpersonal = model.emailpersonal,
                telefonopersonal = model.telefonopersonal,
                tipodocumento = model.tipodocumento,
                numdocumento = model.numdocumento,
                manejafondos = model.manejafondos,
                esep = model.esep,
                eslp = model.eslp,
                escp = model.escp,
                escrew = model.escrew,
                esproveedor = model.esproveedor,
                escliente = model.escliente,
                esdirector = model.esdirector,
                activo = true
            };

            _context.Personas.Add(persona);
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

        // PUT: api/Personas/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(a => a.idpersona == id);

            if (persona == null)
            {
                return NotFound();
            }

            persona.activo = false;

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

        // PUT: api/Personas/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(a => a.idpersona == id);

            if (persona == null)
            {
                return NotFound();
            }

            persona.activo = true;

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


        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.idpersona == id);
        }
    }
}
