using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Motion;
using Sistema.Web.Models.Motion;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class RealmotionsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RealmotionsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Realmotions/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RealmotionViewModel>> Listar()
        {
            var realmotion = await _context.Realmotions
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.proveedormotion.proyecto.activo == true)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.item)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.subitem)
                .Where(p => p.proveedormotion.item.activo == true && p.proveedormotion.item.esmotion == true)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .Where(p => p.proveedormotion.proveedor.activo == true)
                .AsNoTracking()
                .ToListAsync();

            return realmotion.Select(a => new RealmotionViewModel
            {
                idrealmotion = a.idrealmotion,
                idproveedormotion = a.idproveedormotion,
                idproyecto = a.proveedormotion.proyecto.idproyecto,
                proyecto = a.proveedormotion.proyecto.proyecto,
                proyectoorden = a.proveedormotion.proyecto.orden,
                iditem = a.proveedormotion.iditem,
                itemorden = a.proveedormotion.item.orden,
                itemes = a.proveedormotion.item.itemes,
                itemen = a.proveedormotion.item.itemen,
                idsubitem = a.proveedormotion.idsubitem,
                subitemorden = a.proveedormotion.subitem.orden,
                subitemes = a.proveedormotion.subitem.subitemes,
                subitemen = a.proveedormotion.subitem.subitemen,
                idproveedor = a.proveedormotion.idproveedor,
                razonsocial = a.proveedormotion.proveedor.persona.nombre,
                cuit = a.proveedormotion.proveedor.cuit,
                tarifadiaria = a.proveedormotion.tarifadiaria,
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

        // GET: api/Realmotions/ListarProyecto/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<RealmotionViewModel>> ListarProyecto([FromRoute] int id)
        {
            var realmotion = await _context.Realmotions
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.proveedormotion.idproyecto == id)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.item)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.subitem)
                .Where(p => p.proveedormotion.item.activo == true && p.proveedormotion.item.esmotion == true)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .Where(p => p.proveedormotion.proveedor.activo == true)
                .AsNoTracking()
                .ToListAsync();

            return realmotion.Select(a => new RealmotionViewModel
            {
                idrealmotion = a.idrealmotion,
                idproveedormotion = a.idproveedormotion,
                idproyecto = a.proveedormotion.proyecto.idproyecto,
                proyecto = a.proveedormotion.proyecto.proyecto,
                proyectoorden = a.proveedormotion.proyecto.orden,
                iditem = a.proveedormotion.iditem,
                itemorden = a.proveedormotion.item.orden,
                itemes = a.proveedormotion.item.itemes,
                itemen = a.proveedormotion.item.itemen,
                idsubitem = a.proveedormotion.idsubitem,
                subitemorden = a.proveedormotion.subitem.orden,
                subitemes = a.proveedormotion.subitem.subitemes,
                subitemen = a.proveedormotion.subitem.subitemen,
                idproveedor = a.proveedormotion.idproveedor,
                razonsocial = a.proveedormotion.proveedor.persona.nombre,
                cuit = a.proveedormotion.proveedor.cuit,
                tarifadiaria = a.proveedormotion.tarifadiaria,
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

        // GET: api/Realmotions/Controlmotion2date/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Motion2dateViewModel>> Controlmotion2date([FromRoute] int id)
        {
            var motiondate = await _context.Motion2dates
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
FROM dbo.proveedormotions a
LEFT JOIN dbo.items b on a.iditem = b.iditem
LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
LEFT JOIN dbo.realmotions f ON a.idproveedormotion = f.idproveedormotion
LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
LEFT JOIN dbo.proveedores q ON a.idproveedor = q.idproveedor
WHERE f.activo = 1 and p.idproyecto = {id}
GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, q.razonsocial, q.cuit, f.fecha
) u                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return motiondate.Select(a => new Motion2dateViewModel
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

        // GET: api/Realmotions/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var realmotion = await _context.Realmotions
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.proyecto)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.item)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.subitem)
                .Include(p => p.proveedormotion)
                .ThenInclude(p => p.proveedor)
                .ThenInclude(p => p.persona)
                .SingleOrDefaultAsync(a => a.idrealmotion == id);

            if (realmotion == null)
            {
                return NotFound();
            }

            return Ok(new RealmotionViewModel
            {
                idrealmotion = realmotion.idrealmotion,
                idproveedormotion = realmotion.idproveedormotion,
                dtdesde = realmotion.dtdesde,
                dthasta = realmotion.dthasta,
                hhee = realmotion.hhee,
                porhhee = realmotion.porhhee,
                impbase = realmotion.impbase,
                imphhee = realmotion.imphhee,
                impjornada = realmotion.impjornada,
                impjornadaadicional = realmotion.impjornadaadicional,
                iduseralta = realmotion.iduseralta,
                fecalta = realmotion.fecalta,
                iduserumod = realmotion.iduserumod,
                fecumod = realmotion.fecumod,
                activo = realmotion.activo
            });
        }

        // PUT: api/Realmotions/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] RealmotionUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idrealmotion <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var realmotion = await _context.Realmotions.FirstOrDefaultAsync(a => a.idrealmotion == model.idrealmotion);

            if (realmotion == null)
            {
                return NotFound();
            }
            realmotion.idrealmotion = model.idrealmotion;
            realmotion.idproveedormotion = model.idproveedormotion;
            realmotion.fecha = model.dtdesde;
            realmotion.dtdesde = model.dtdesde;
            realmotion.dthasta = model.dthasta;
            realmotion.hhee = model.hhee;
            realmotion.porhhee = model.porhhee;
            realmotion.impbase = model.impbase;
            realmotion.imphhee = model.imphhee;
            realmotion.impjornada = model.impjornada;
            realmotion.impjornadaadicional = model.impjornadaadicional;
            realmotion.iduseralta = model.iduseralta;
            realmotion.fecalta = model.fecalta;
            realmotion.iduserumod = model.iduserumod;
            realmotion.fecumod = fechaHora;

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

        // POST: api/Realmotions/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] RealmotionCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Realmotion realmotion = new Realmotion
            {
                idproveedormotion = model.idproveedormotion,
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

            _context.Realmotions.Add(realmotion);
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


        // PUT: api/Realmotions/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var realmotion = await _context.Realmotions.FirstOrDefaultAsync(a => a.idrealmotion == id);

            if (realmotion == null)
            {
                return NotFound();
            }

            realmotion.activo = false;

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

        // PUT: api/Realmotions/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var realmotion = await _context.Realmotions.FirstOrDefaultAsync(a => a.idrealmotion == id);

            if (realmotion == null)
            {
                return NotFound();
            }

            realmotion.activo = true;

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


        private bool RealmotionExists(int id)
        {
            return _context.Realmotions.Any(e => e.idrealmotion == id);
        }
    }
}
