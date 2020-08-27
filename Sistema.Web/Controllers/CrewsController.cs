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
using Sistema.Web.Models.Maestros.Crews;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class CrewsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CrewsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Crews/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CrewViewModel>> Listar()
        {
            var crew = await _context.Crews.Include(a => a.persona).ToListAsync();

            return crew.Select(a => new CrewViewModel
            {
                idcrew = a.idcrew,
                idpersona = a.idpersona,
                nombre = a.persona.nombre,
                cuil = a.cuil,
                fecnacimiento = a.fecnacimiento,
                nacionalidad = a.nacionalidad,
                estudioscursados = a.estudioscursados,
                estadocivil = a.estadocivil,
                datosconyugue = a.datosconyugue,
                cantidadhijos = a.cantidadhijos,
                listammaanacimientohijos = a.listammaanacimientohijos,
                sindicato = a.sindicato,
                numafiliadosindicato = a.numafiliadosindicato,
                obrasocial = a.obrasocial,
                numafiliadoobrasocial = a.numafiliadoobrasocial,
                cbu = a.cbu,
                activo = a.activo
            });

        }

        // GET: api/Crews/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<CrewSelectModel>> Select()
        {
            var crew = await _context.Crews.Include(a => a.persona).OrderBy(a => a.persona.nombre).ToListAsync();

            return crew.Select(a => new CrewSelectModel
            {
                idcrew = a.idcrew,
                idpersona = a.idpersona,
                nombre = a.persona.nombre,
                cuil = a.cuil
            });

        }

        // GET: api/Crews/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var crew = await _context.Crews
                .Include(a => a.persona)
                .SingleOrDefaultAsync(a => a.idcrew == id);

            if (crew == null)
            {
                return NotFound();
            }

            return Ok(new CrewViewModel
            {
                idcrew = crew.idcrew,
                idpersona = crew.idpersona,
                nombre = crew.persona.nombre,
                cuil = crew.cuil,
                fecnacimiento = crew.fecnacimiento,
                nacionalidad = crew.nacionalidad,
                estudioscursados = crew.estudioscursados,
                estadocivil = crew.estadocivil,
                datosconyugue = crew.datosconyugue,
                cantidadhijos = crew.cantidadhijos,
                listammaanacimientohijos = crew.listammaanacimientohijos,
                sindicato = crew.sindicato,
                numafiliadosindicato = crew.numafiliadosindicato,
                obrasocial = crew.obrasocial,
                numafiliadoobrasocial = crew.numafiliadoobrasocial,
                cbu = crew.cbu,
                activo = crew.activo
            });
        }

        // PUT: api/Crews/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] CrewUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcrew <= 0)
            {
                return BadRequest();
            }

            var crew = await _context.Crews.FirstOrDefaultAsync(a => a.idcrew == model.idcrew);

            if (crew == null)
            {
                return NotFound();
            }

            crew.idcrew = model.idcrew;
            crew.idpersona = model.idpersona;
            crew.cuil = model.cuil;
            crew.fecnacimiento = model.fecnacimiento;
            crew.nacionalidad = model.nacionalidad;
            crew.estudioscursados = model.estudioscursados;
            crew.estadocivil = model.estadocivil;
            crew.datosconyugue = model.datosconyugue;
            crew.cantidadhijos = model.cantidadhijos;
            crew.listammaanacimientohijos = model.listammaanacimientohijos;
            crew.sindicato = model.sindicato;
            crew.numafiliadosindicato = model.numafiliadosindicato;
            crew.obrasocial = model.obrasocial;
            crew.numafiliadoobrasocial = model.numafiliadoobrasocial;
            crew.cbu = model.cbu;
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

        // POST: api/Crews/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrewCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Crew crew = new Crew
            {
                idpersona = model.idpersona,
                cuil = model.cuil,
                fecnacimiento = model.fecnacimiento,
                nacionalidad = model.nacionalidad,
                estudioscursados = model.estudioscursados,
                estadocivil = model.estadocivil,
                datosconyugue = model.datosconyugue,
                cantidadhijos = model.cantidadhijos,
                listammaanacimientohijos = model.listammaanacimientohijos,
                sindicato = model.sindicato,
                numafiliadosindicato = model.numafiliadosindicato,
                obrasocial = model.obrasocial,
                numafiliadoobrasocial = model.numafiliadoobrasocial,
                cbu = model.cbu,
                activo = true
            };

            _context.Crews.Add(crew);
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

        // PUT: api/Crews/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var crew = await _context.Crews.FirstOrDefaultAsync(a => a.idcrew == id);

            if (crew == null)
            {
                return NotFound();
            }

            crew.activo = false;

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

        // PUT: api/Crews/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var crew = await _context.Crews.FirstOrDefaultAsync(a => a.idcrew == id);

            if (crew == null)
            {
                return NotFound();
            }

            crew.activo = true;

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



        private bool CrewExists(int id)
        {
            return _context.Crews.Any(e => e.idcrew == id);
        }
    }
}
