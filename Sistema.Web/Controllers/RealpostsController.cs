using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Post;
using Sistema.Web.Models.Post;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class RealpostsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RealpostsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Realposts/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RealpostViewModel>> Listar()
        {
            var realpost = await _context.Realposts
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.proveedorpost.proyecto.activo == true)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.item)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.subitem)
                .Where(p => p.proveedorpost.item.activo == true && p.proveedorpost.item.espost == true)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .Where(p => p.proveedorpost.proveedor.activo == true)
                .AsNoTracking()
                .ToListAsync();

            return realpost.Select(a => new RealpostViewModel
            {
                idrealpost = a.idrealpost,
                idproveedorpost = a.idproveedorpost,
                idproyecto = a.proveedorpost.proyecto.idproyecto,
                proyecto = a.proveedorpost.proyecto.proyecto,
                proyectoorden = a.proveedorpost.proyecto.orden,
                iditem = a.proveedorpost.iditem,
                itemorden = a.proveedorpost.item.orden,
                itemes = a.proveedorpost.item.itemes,
                itemen = a.proveedorpost.item.itemen,
                idsubitem = a.proveedorpost.idsubitem,
                subitemorden = a.proveedorpost.subitem.orden,
                subitemes = a.proveedorpost.subitem.subitemes,
                subitemen = a.proveedorpost.subitem.subitemen,
                idproveedor = a.proveedorpost.idproveedor,
                razonsocial = a.proveedorpost.proveedor.persona.nombre,
                cuit = a.proveedorpost.proveedor.cuit,
                tarifadiaria = a.proveedorpost.tarifadiaria,
                dtdesde = a.dtdesde,
                dthasta = a.dthasta,
                hhee = a.hhee,
                porhhee = a.porhhee,
                impbase = a.impbase,
                imphhee = a.imphhee,
                impjornada = a.impjornada,
                impjornadaadicional = a.impjornadaadicional,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Realposts/ListarProyecto/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<RealpostViewModel>> ListarProyecto([FromRoute] int id)
        {
            var realpost = await _context.Realposts
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.proveedorpost.idproyecto == id)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.item)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.subitem)
                .Where(p => p.proveedorpost.item.activo == true && p.proveedorpost.item.espost == true)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .Where(p => p.proveedorpost.proveedor.activo == true)
                .AsNoTracking()
                .ToListAsync();

            return realpost.Select(a => new RealpostViewModel
            {
                idrealpost = a.idrealpost,
                idproveedorpost = a.idproveedorpost,
                idproyecto = a.proveedorpost.proyecto.idproyecto,
                proyecto = a.proveedorpost.proyecto.proyecto,
                proyectoorden = a.proveedorpost.proyecto.orden,
                iditem = a.proveedorpost.iditem,
                itemorden = a.proveedorpost.item.orden,
                itemes = a.proveedorpost.item.itemes,
                itemen = a.proveedorpost.item.itemen,
                idsubitem = a.proveedorpost.idsubitem,
                subitemorden = a.proveedorpost.subitem.orden,
                subitemes = a.proveedorpost.subitem.subitemes,
                subitemen = a.proveedorpost.subitem.subitemen,
                idproveedor = a.proveedorpost.idproveedor,
                razonsocial = a.proveedorpost.proveedor.persona.nombre,
                cuit = a.proveedorpost.proveedor.cuit,
                tarifadiaria = a.proveedorpost.tarifadiaria,
                dtdesde = a.dtdesde,
                dthasta = a.dthasta,
                hhee = a.hhee,
                porhhee = a.porhhee,
                impbase = a.impbase,
                imphhee = a.imphhee,
                impjornada = a.impjornada,
                impjornadaadicional = a.impjornadaadicional,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Realposts/Controlpost2date/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Post2dateViewModel>> Controlpost2date([FromRoute] int id)
        {
            var postdate = await _context.Post2dates
                .FromSqlRaw($@"
SELECT cast(ROW_NUMBER() OVER(order by idproyecto) as int) AS id, *
FROM (
SELECT    p.idproyecto AS idproyecto
		, p.orden as proy
		, p.proyecto as proyecto
        , e.idrubro
		, e.rubro
        , d.idsubrubro
		, d.subrubro
        , b.iditem
		, b.item
        , c.idsubitem
		, c.subitem
		, q.razonsocial AS proveedor
		, q.cuit
		, f.fecha as fecha
		, cast(sum(f.hhee) as decimal(5,2)) as hhee
		, cast(sum(f.porhhee) as decimal(5,2)) as porhhee
		, cast(sum(f.impbase) as decimal(18,2)) as impbase
		, cast(sum(f.imphhee) as decimal(18,2)) as imphhee
		, cast(sum(f.impjornada) as decimal(18,2)) as impjorn
		, cast(sum(f.impjornadaadicional) as decimal(18,2)) as impadic
		, cast(sum(f.impjornada+f.impjornadaadicional) as decimal(18,2)) as imptotal
FROM dbo.proveedorposts a
LEFT JOIN dbo.items b on a.iditem = b.iditem
LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
LEFT JOIN dbo.realposts f ON a.idproveedorpost = f.idproveedorpost
LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
LEFT JOIN dbo.proveedores q ON a.idproveedor = q.idproveedor
WHERE f.activo = 1 and p.idproyecto = {id}
GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, q.razonsocial, q.cuit, f.fecha
) u                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return postdate.Select(a => new Post2dateViewModel
            {
                idproyecto = a.idproyecto,
                proy = a.proy,
                proyecto = a.proyecto,
                idrubro = a.idrubro,
                rubro = a.rubro,
                idsubrubro = a.idsubrubro,
                subrubro = a.subrubro,
                iditem = a.iditem,
                item = a.item,
                idsubitem = a.idsubitem,
                subitem = a.subitem,
                proveedor = a.proveedor,
                cuit = a.cuit,
                fecha = a.fecha,
                hhee = a.hhee,
                porhhee = a.porhhee,
                impbase = a.impbase,
                imphhee = a.imphhee,
                impjorn = a.impjorn,
                impadic = a.impadic,
                imptotal = a.imptotal
            });
        }

        // GET: api/Realposts/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var realpost = await _context.Realposts
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.proyecto)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.item)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.subitem)
                .Include(p => p.proveedorpost)
                .ThenInclude(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .SingleOrDefaultAsync(a => a.idrealpost == id);

            if (realpost == null)
            {
                return NotFound();
            }

            return Ok(new RealpostViewModel
            {
                idrealpost = realpost.idrealpost,
                idproveedorpost = realpost.idproveedorpost,
                dtdesde = realpost.dtdesde,
                dthasta = realpost.dthasta,
                hhee = realpost.hhee,
                porhhee = realpost.porhhee,
                impbase = realpost.impbase,
                imphhee = realpost.imphhee,
                impjornada = realpost.impjornada,
                impjornadaadicional = realpost.impjornadaadicional,
                iduseralta = realpost.iduseralta,
                fecalta = realpost.fecalta,
                iduserumod = realpost.iduserumod,
                fecumod = realpost.fecumod,
                activo = realpost.activo
            });
        }

        // PUT: api/Realposts/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] RealpostUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idrealpost <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var realpost = await _context.Realposts.FirstOrDefaultAsync(a => a.idrealpost == model.idrealpost);

            if (realpost == null)
            {
                return NotFound();
            }
            realpost.idrealpost = model.idrealpost;
            realpost.idproveedorpost = model.idproveedorpost;
            realpost.fecha = model.dtdesde;
            realpost.dtdesde = model.dtdesde;
            realpost.dthasta = model.dthasta;
            realpost.hhee = model.hhee;
            realpost.porhhee = model.porhhee;
            realpost.impbase = model.impbase;
            realpost.imphhee = model.imphhee;
            realpost.impjornada = model.impjornada;
            realpost.impjornadaadicional = model.impjornadaadicional;
            realpost.iduseralta = model.iduseralta;
            realpost.fecalta = model.fecalta;
            realpost.iduserumod = model.iduserumod;
            realpost.fecumod = fechaHora;

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

        // POST: api/Realposts/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] RealpostCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Realpost realpost = new Realpost
            {
                idproveedorpost = model.idproveedorpost,
                fecha = model.dtdesde,
                dtdesde = model.dtdesde,
                dthasta = model.dthasta,
                hhee = model.hhee,
                porhhee = model.porhhee,
                impbase = model.impbase,
                imphhee = model.imphhee,
                impjornada = model.impjornada,
                impjornadaadicional = model.impjornadaadicional,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Realposts.Add(realpost);
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


        // PUT: api/Realposts/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var realpost = await _context.Realposts.FirstOrDefaultAsync(a => a.idrealpost == id);

            if (realpost == null)
            {
                return NotFound();
            }

            realpost.activo = false;

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

        // PUT: api/Realposts/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var realpost = await _context.Realposts.FirstOrDefaultAsync(a => a.idrealpost == id);

            if (realpost == null)
            {
                return NotFound();
            }

            realpost.activo = true;

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
        private bool RealpostExists(int id)
        {
            return _context.Realposts.Any(e => e.idrealpost == id);
        }
    }
}
