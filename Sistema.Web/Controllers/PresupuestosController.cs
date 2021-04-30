using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Proyectos;
using Sistema.Web.Models.Proyectos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PresupuestosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Presupuestos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PresupuestoViewModel>> Listar()
        {
            var presupuesto = await _context.Presupuestos
                .Include(a => a.proyecto)
                .Include(a => a.items)
                .Include(a => a.subitems)
                .AsNoTracking()
                .ToListAsync();

            return presupuesto.Select(a => new PresupuestoViewModel
            {
                idpresupuesto = a.idpresupuesto,
                idproyecto = a.idproyecto,
                proyecto = a.proyecto.proyecto,
                iditem = a.iditem,
                itemorden = a.items.orden,
                itemes = a.items.itemes,
                itemen = a.items.itemen,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitems.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitems.subitemes : "",
                subitemen = a.idsubitem.HasValue ? a.subitems.subitemen : "",
                importe = a.importe,
                origen = a.origen,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Presupuestos/ListarProyecto/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<PresupuestoViewModel>> ListarProyecto([FromRoute] int id)
        {
            var presupuesto = await _context.Presupuestos
                .Include(a => a.proyecto)
                .Where(a => a.idproyecto == id)
                .Include(a => a.items)
                .Include(a => a.subitems)
                .AsNoTracking()
                .ToListAsync();

            return presupuesto.Select(a => new PresupuestoViewModel
            {
                idpresupuesto = a.idpresupuesto,
                idproyecto = a.idproyecto,
                proyecto = a.proyecto.proyecto,
                iditem = a.iditem,
                itemorden = a.items.orden,
                itemes = a.items.itemes,
                itemen = a.items.itemen,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitems.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitems.subitemes : "",
                subitemen = a.idsubitem.HasValue ? a.subitems.subitemen : "",
                importe = a.importe,
                origen = a.origen,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }


        // GET: api/Presupuestos/Controlproyectodate/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProyectodateViewModel>> Controlproyectodate([FromRoute] int id)
        {
            var proyectodate = await _context.Proyectodates
                .FromSqlRaw($@"
                    SELECT cast(ROW_NUMBER() OVER(order by idproyecto) as int) AS id, *
                    FROM (
                    SELECT p.idproyecto as idproyecto, p.orden as proy, p.proyecto as proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem,'Presupuesto' as origen,'Presupuesto' as tipo, 
		                    cast(sum(importe) as decimal(18,2)) as importe, d.conf
                    FROM dbo.presupuestos a
                    LEFT JOIN dbo.items b on a.iditem = b.iditem
                    LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
                    LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
                    LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
                    LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
                    WHERE p.idproyecto = {id} and a.activo = 1
                    GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, d.conf
                    UNION
                    SELECT p.idproyecto as idproyecto, p.orden as proy, p.proyecto as proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, 'Pagos' as origen,'Real' as tipo, 
		                    cast(SUM(impsiniva)*-1 as decimal(18,2)) as importe, d.conf
                    FROM dbo.ordenpagos a
                    LEFT JOIN dbo.items b on a.iditem = b.iditem
                    LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
                    LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
                    LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
                    LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
                    WHERE p.idproyecto = {id} and a.pagado = 1 and a.activo = 1 
                    GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, d.conf
                    UNION
                    SELECT p.idproyecto as idproyecto, p.orden as proy, p.proyecto as proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, 'Pagos' as origen,'Comprometido' as tipo, 
		                    cast(SUM(impsiniva)*-1 as decimal(18,2)) as importe, d.conf
                    FROM dbo.ordenpagos a
                    LEFT JOIN dbo.items b on a.iditem = b.iditem
                    LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
                    LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
                    LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
                    LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
                    WHERE p.idproyecto = {id} and a.pagado <> 1 and a.activo = 1
                    GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, d.conf
                    UNION
                    SELECT p.idproyecto as idproyecto, p.orden as proy, p.proyecto as proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, 'Dxd' as origen,'Real' as tipo, 
		                    cast(sum(f.imptotalneto+f.impcontribucionpatronal) as decimal(18,2))*-1 as importe, d.conf
                    FROM dbo.recursosdxds a
                    LEFT JOIN dbo.items b on a.iditem = b.iditem
                    LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
                    LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
                    LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
                    LEFT JOIN dbo.realdxds f ON a.idrecursodxd = f.idrecursodxd
                    LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
                    WHERE p.idproyecto = {id} and f.activo = 1
                    GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, d.conf
                    UNION
                    SELECT p.idproyecto as idproyecto, p.orden as proy, p.proyecto as proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, 'Post' as origen,'Real' as tipo, 
		                    cast(sum(f.impjornada+f.impjornadaadicional) as decimal(18,2))*-1 as importe, d.conf
                    FROM dbo.proveedorposts a
                    LEFT JOIN dbo.items b on a.iditem = b.iditem
                    LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
                    LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
                    LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
                    LEFT JOIN dbo.realposts f ON a.idproveedorpost = f.idproveedorpost
                    LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
                    WHERE p.idproyecto = {id} and f.activo = 1
                    GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, d.conf
                    UNION
                    SELECT p.idproyecto as idproyecto, p.orden as proy, p.proyecto as proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, 'Motion' as origen,'Real' as tipo, 
		                    cast(sum(f.impjornada+f.impjornadaadicional) as decimal(18,2))*-1 as importe, d.conf
                    FROM dbo.proveedormotions a
                    LEFT JOIN dbo.items b on a.iditem = b.iditem
                    LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
                    LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
                    LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
                    LEFT JOIN dbo.realmotions f ON a.idproveedormotion = f.idproveedormotion
                    LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
                    WHERE p.idproyecto = {id} and f.activo = 1
                    GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, d.conf
                    UNION
                    SELECT p.idproyecto as idproyecto, p.orden as proy, p.proyecto as proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, 'Rendido' as origen,'Real' as tipo, 
		                    cast(sum(a.impsiniva) as decimal(18,2))*-1 as importe, d.conf
                    FROM dbo.rendicionfondos a
                    LEFT JOIN dbo.items b on a.iditem = b.iditem
                    LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
                    LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
                    LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
                    LEFT JOIN dbo.distribucionfondos f ON a.iddistribucionfondo = f.iddistribucionfondo
                    LEFT JOIN dbo.pedidosfondo g ON g.idpedidofondo = f.idpedidofondo
                    LEFT JOIN dbo.proyectos p ON g.idproyecto = p.idproyecto
                    WHERE p.idproyecto = {id} and a.activo = 1
                    GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, d.conf
                    ) u

                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return proyectodate.Select(a => new ProyectodateViewModel
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
                origen = a.origen,
                tipo = a.tipo,
                importe = a.importe,
                conf = a.conf
            });

        }


        // GET: api/Presupuestos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var presupuesto = await _context.Presupuestos
                .Include(a => a.proyecto)
                .Include(a => a.items)
                .Include(a => a.subitems)
                .SingleOrDefaultAsync(a => a.idpresupuesto == id);

            if (presupuesto == null)
            {
                return NotFound();
            }

            return Ok(new PresupuestoViewModel
            {
                idpresupuesto = presupuesto.idpresupuesto,
                idproyecto = presupuesto.idproyecto,
                proyecto = presupuesto.proyecto.proyecto,
                iditem = presupuesto.iditem,
                itemorden = presupuesto.items.orden,
                itemes = presupuesto.items.itemes,
                itemen = presupuesto.items.itemen,
                idsubitem = presupuesto.idsubitem,
                subitemorden = presupuesto.idsubitem.HasValue ? presupuesto.subitems.orden : "",
                subitemes = presupuesto.idsubitem.HasValue ? presupuesto.subitems.subitemes : "",
                subitemen = presupuesto.idsubitem.HasValue ? presupuesto.subitems.subitemen : "",
                importe = presupuesto.importe,
                origen = presupuesto.origen,
                iduseralta = presupuesto.iduseralta,
                fecalta = presupuesto.fecalta,
                iduserumod = presupuesto.iduserumod,
                fecumod = presupuesto.fecumod,
                activo = presupuesto.activo
            });
        }

        // PUT: api/Presupuestos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] PresupuestoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idpresupuesto <= 0)
            {
                return BadRequest();
            }
            var fechaHora = DateTime.Now;
            var presupuesto = await _context.Presupuestos.FirstOrDefaultAsync(a => a.idpresupuesto == model.idpresupuesto);

            if (presupuesto == null)
            {
                return NotFound();
            }
            presupuesto.idpresupuesto = model.idpresupuesto;
            presupuesto.idproyecto = model.idproyecto;
            presupuesto.iditem = model.iditem;
            presupuesto.idsubitem = model.idsubitem;
            presupuesto.importe = model.importe;
            presupuesto.origen = model.origen;
            presupuesto.iduserumod = model.iduserumod;
            presupuesto.fecumod = fechaHora;
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

        // POST: api/Presupuestos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] PresupuestoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Presupuesto presupuesto = new Presupuesto
            {
                idproyecto = model.idproyecto,
                iditem = model.iditem,
                idsubitem = model.idsubitem,
                importe = model.importe,
                origen = model.origen,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Presupuestos.Add(presupuesto);
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

        // DELETE: api/Presupuestos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var presupuesto = await _context.Presupuestos.FindAsync(id);
            if (presupuesto == null)
            {
                return NotFound();
            }

            _context.Presupuestos.Remove(presupuesto);
            try
            {
                await _context.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return BadRequest();
            }

            return Ok(presupuesto);
        }

        // PUT: api/Presupuestos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var presupuesto = await _context.Presupuestos.FirstOrDefaultAsync(a => a.idpresupuesto == id);

            if (presupuesto == null)
            {
                return NotFound();
            }

            presupuesto.activo = false;

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

        // PUT: api/Presupuestos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var presupuesto = await _context.Presupuestos.FirstOrDefaultAsync(a => a.idpresupuesto == id);

            if (presupuesto == null)
            {
                return NotFound();
            }

            presupuesto.activo = true;

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

        private bool PresupuestoExists(int id)
        {
            return _context.Presupuestos.Any(e => e.idpresupuesto == id);
        }
    }
}
