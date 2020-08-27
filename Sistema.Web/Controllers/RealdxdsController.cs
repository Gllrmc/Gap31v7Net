using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Daybyday;
using Sistema.Web.Models.Daybyday;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class RealdxdsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RealdxdsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Realdxds/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RealdxdViewModel>> Listar()
        {
            var realdxd = await _context.Realdxds
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.recursodxd.proyecto.activo == true)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.item)
                .Where(p => p.recursodxd.item.activo == true && p.recursodxd.item.esdxd == true)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.subitem)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.crew)
                .ThenInclude(p => p.persona)
                .Where(p => p.recursodxd.crew.activo == true)
                .AsNoTracking()
                .ToListAsync();

            return realdxd.Select(a => new RealdxdViewModel
            {
                idrealdxd = a.idrealdxd,
                idrecursodxd = a.idrecursodxd,
                idproyecto = a.recursodxd.proyecto.idproyecto,
                proyecto = a.recursodxd.proyecto.proyecto,
                proyectoorden = a.recursodxd.proyecto.orden,
                iditem = a.recursodxd.item.iditem,
                itemorden = a.recursodxd.item.orden,
                itemes = a.recursodxd.item.itemes,
                itemen = a.recursodxd.item.itemen,
                idsubitem = a.recursodxd.subitem.idsubitem,
                subitemorden = a.recursodxd.subitem.idsubitem.HasValue ? a.recursodxd.subitem.orden : "",
                subitemes = a.recursodxd.subitem.idsubitem.HasValue ? a.recursodxd.subitem.subitemes : "",
                subitemen = a.recursodxd.subitem.idsubitem.HasValue ? a.recursodxd.subitem.subitemen : "",
                idcrew = a.recursodxd.crew.idcrew,
                nombre = a.recursodxd.crew.persona.nombre,
                cuil = a.recursodxd.crew.cuil,
                horasbase = a.horasbase,
                dtdesde = a.dtdesde,
                dthasta = a.dthasta,
                controlsica = a.controlsica,
                horasnormal = a.horasnormal,
                horasextra = a.horasextra,
                horasnocturna = a.horasnocturna,
                horasenganche = a.horasenganche,
                bolobruto = a.bolobruto,
                boloneto = a.boloneto,
                valhoraextra = a.valhoraextra,
                impextra = a.impextra,
                impadicional = a.impadicional,
                septimodia = a.septimodia,
                imptotalbruto = a.imptotalbruto,
                impsac = a.impsac,
                impvacaciones = a.impvacaciones,
                impretenciones = a.impretenciones,
                impsacvacaciones = a.impsacvacaciones,
                imptotalneto = a.imptotalneto,
                impcontribucionpatronal = a.impcontribucionpatronal,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Realdxds/ListarProyecto/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<RealdxdViewModel>> ListarProyecto([FromRoute] int id)
        {
            var realdxd = await _context.Realdxds
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.recursodxd.idproyecto == id)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.item)
                .Where(p => p.recursodxd.item.activo == true && p.recursodxd.item.esdxd == true)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.subitem)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.crew)
                .ThenInclude(p => p.persona)
                .Where(p => p.recursodxd.crew.activo == true)
                .AsNoTracking()
                .ToListAsync();

            return realdxd.Select(a => new RealdxdViewModel
            {
                idrealdxd = a.idrealdxd,
                idrecursodxd = a.idrecursodxd,
                idproyecto = a.recursodxd.proyecto.idproyecto,
                proyecto = a.recursodxd.proyecto.proyecto,
                proyectoorden = a.recursodxd.proyecto.orden,
                iditem = a.recursodxd.item.iditem,
                itemorden = a.recursodxd.item.orden,
                itemes = a.recursodxd.item.itemes,
                itemen = a.recursodxd.item.itemen,
                idsubitem = a.recursodxd.subitem.idsubitem,
                subitemorden = a.recursodxd.subitem.idsubitem.HasValue ? a.recursodxd.subitem.orden : "",
                subitemes = a.recursodxd.subitem.idsubitem.HasValue ? a.recursodxd.subitem.subitemes : "",
                subitemen = a.recursodxd.subitem.idsubitem.HasValue ? a.recursodxd.subitem.subitemen : "",
                idcrew = a.recursodxd.crew.idcrew,
                nombre = a.recursodxd.crew.persona.nombre,
                cuil = a.recursodxd.crew.cuil,
                horasbase = a.horasbase,
                dtdesde = a.dtdesde,
                dthasta = a.dthasta,
                controlsica = a.controlsica,
                horasnormal = a.horasnormal,
                horasextra = a.horasextra,
                horasnocturna = a.horasnocturna,
                horasenganche = a.horasenganche,
                bolobruto = a.bolobruto,
                boloneto = a.boloneto,
                valhoraextra = a.valhoraextra,
                impextra = a.impextra,
                impadicional = a.impadicional,
                septimodia = a.septimodia,
                imptotalbruto = a.imptotalbruto,
                impsac = a.impsac,
                impvacaciones = a.impvacaciones,
                impretenciones = a.impretenciones,
                impsacvacaciones = a.impsacvacaciones,
                imptotalneto = a.imptotalneto,
                impcontribucionpatronal = a.impcontribucionpatronal,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Realdxds/ListarActividades
        [HttpGet("[action]")]
        public async Task<IEnumerable<RealdxdSelectModel>> ListarActividades()
        {
            var realdxd = await _context.Realdxds
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.proyecto)
                .Where(p => p.recursodxd.proyecto.activo == true && p.recursodxd.proyecto.cierreprod==false)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.item)
                .Where(p => p.recursodxd.item.activo == true && p.recursodxd.item.esdxd == true)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.subitem)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.crew)
                .ThenInclude(p => p.persona)
                .Where(p => p.recursodxd.crew.activo == true)
                .AsNoTracking()
                .OrderBy(v => v.dtdesde)
                .ToListAsync();

            return realdxd.Select(a => new RealdxdSelectModel
            {
                idrealdxd = a.idrealdxd,
                idrecursodxd = a.idrecursodxd,
                idproyecto = a.recursodxd.idproyecto,
                iditem = a.recursodxd.iditem,
                idsubitem = a.recursodxd.idsubitem,
                idcrew = a.recursodxd.idcrew,
                dtdesde = a.dtdesde,
                dthasta = a.dthasta,
                septimodia = a.septimodia
            });

        }

        // GET: api/Realdxds/ListarRecursoProyecto/1/2/2019-12-19/2019-12-25
        //[HttpGet("[action]/{idproyecto}/{idrecursodxd}/{FechaDesde}/{FechaHasta}")]
        //public async Task<IEnumerable<RealdxdSelectModel>> ListarRecursoProyecto([FromRoute] int idproyecto, [FromRoute] int idrecursodxd, 
        //    [FromRoute] string FechaDesde, [FromRoute] string FechaHasta)
        //{
        //    var realdxd = await _context.Realdxds
        //        .Include(p => p.recursodxd)
        //        .Where(p => p.recursodxd.idproyecto == idproyecto &&  
        //                    p.recursodxd.idrecursodxd == idrecursodxd && 
        //                    p.dtdesde >= Convert.ToDateTime(FechaDesde) && 
        //                    p.dtdesde < Convert.ToDateTime(FechaHasta) )
        //        .OrderBy(v => v.dtdesde)
        //        .ToListAsync();
        //
        //    return realdxd.Select(a => new RealdxdSelectModel
        //    {
        //        idrealdxd = a.idrealdxd,
        //        idrecursodxd = a.idrecursodxd,
        //        idproyecto = a.recursodxd.idproyecto,
        //        iditem = a.recursodxd.iditem,
        //        idsubitem = a.recursodxd.idsubitem,
        //        idcrew = a.recursodxd.idcrew,
        //        dtdesde = a.dtdesde,
        //        dthasta = a.dthasta,
        //        septimodia = a.septimodia
        //    });
        //}

        // GET: api/Realdxds/Controlshoot2date/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Shoot2dateViewModel>> Controlshoot2date([FromRoute] int id)
        {
            var shoottodate = await _context.Shoot2dates
                .FromSqlRaw($@"
SELECT cast(ROW_NUMBER() OVER(order by idproyecto) as int) AS id, *
FROM (
SELECT p.idproyecto, 
    p.orden as proy, 
    p.proyecto as proyecto,
    e.idrubro,
    e.rubro,
    d.idsubrubro,
    d.subrubro,
    b.iditem,
    b.item, 
    c.idsubitem,
    c.subitem, 
	trim(t.cargo)+' '+trim(t.asignacion) as cargo, r.nombre, q.cuil, f.fecha, f.horasbase as hsbase,
	cast(sum(f.horasnormal) as decimal(18,2)) as horas, cast(sum(f.horasextra) as decimal(18,2)) as hsext, cast(sum(f.horasenganche) as decimal(18,2)) as hseng, 
	cast(sum(f.horasnocturna) as decimal(18,2)) as hsnoc,
	cast(sum(f.imptotalbruto) as decimal(18,2)) as impbruto, cast(sum(impretenciones) as decimal(18,2)) as impret, 
	cast(sum(f.impsac) as decimal(18,2)) as impsac, 
	cast(sum(f.impvacaciones) as decimal(18,2)) as impvac, 
	cast(sum(f.impsacvacaciones) as decimal(18,2)) as impsacv, 
	cast(sum(f.imptotalneto) as decimal(18,2)) as impneto, cast(sum(f.impcontribucionpatronal) as decimal(18,2)) as impcontr, 
	cast(sum(f.imptotalneto+f.impcontribucionpatronal) as decimal(18,2)) as imptotal
FROM dbo.recursosdxds a
LEFT JOIN dbo.items b on a.iditem = b.iditem
LEFT JOIN dbo.subitems c on a.idsubitem = c.idsubitem
LEFT JOIN dbo.subrubros d ON b.idsubrubro = d.idsubrubro
LEFT JOIN dbo.rubros e ON d.idrubro = e.idrubro
LEFT JOIN dbo.realdxds f ON a.idrecursodxd = f.idrecursodxd
LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
LEFT JOIN dbo.crews q ON a.idcrew = q.idcrew
LEFT JOIN dbo.personas r ON q.idpersona = r.idpersona
LEFT JOIN dbo.tarifadxds s ON a.idproyecto = s.idproyecto and a.iditem = s.iditem
LEFT JOIN dbo.sica t ON s.idsica = t.idsica
WHERE p.idproyecto = {id} and f.activo = 1
GROUP BY p.idproyecto, p.orden, p.proyecto, e.idrubro, e.rubro, d.idsubrubro, d.subrubro, b.iditem, b.item, c.idsubitem, c.subitem, trim(t.cargo)+' '+trim(t.asignacion), r.nombre, q.cuil, f.horasbase, f.fecha
) u                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return shoottodate.Select(a => new Shoot2dateViewModel
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
                cargo = a.cargo,
                nombre = a.nombre,
                cuil = a.cuil,
                fecha = a.fecha,
                hsbase = a.hsbase,
                horas = a.horas,
                hsext = a.hsext,
                hseng = a.hseng,
                hsnoc = a.hsnoc,
                impbruto = a.impbruto,
                impret = a.impret,
                impsac = a.impsac,
                impvac = a.impvac,
                impsacv = a.impsacv,
                impneto = a.impneto,
                impcontr = a.impcontr,
                imptotal = a.imptotal
            });

        }

        // GET: api/Realdxds/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var realdxd = await _context.Realdxds
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.proyecto)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.item)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.subitem)
                .Include(p => p.recursodxd)
                .ThenInclude(p => p.crew)
                .ThenInclude(p => p.persona)
                .SingleOrDefaultAsync(a => a.idrealdxd == id);

            if (realdxd == null)
            {
                return NotFound();
            }

            return Ok(new RealdxdViewModel
            {
                idrealdxd = realdxd.idrealdxd,
                idrecursodxd = realdxd.idrecursodxd,
                idproyecto = realdxd.recursodxd.proyecto.idproyecto,
                proyecto = realdxd.recursodxd.proyecto.proyecto,
                proyectoorden = realdxd.recursodxd.proyecto.orden,
                iditem = realdxd.recursodxd.item.iditem,
                itemorden = realdxd.recursodxd.item.orden,
                itemes = realdxd.recursodxd.item.itemes,
                itemen = realdxd.recursodxd.item.itemen,
                idsubitem = realdxd.recursodxd.subitem.idsubitem,
                subitemorden = realdxd.recursodxd.subitem.idsubitem.HasValue ? realdxd.recursodxd.subitem.orden : "",
                subitemes = realdxd.recursodxd.subitem.idsubitem.HasValue ? realdxd.recursodxd.subitem.subitemes : "",
                subitemen = realdxd.recursodxd.subitem.idsubitem.HasValue ? realdxd.recursodxd.subitem.subitemen : "",
                idcrew = realdxd.recursodxd.crew.idcrew,
                nombre = realdxd.recursodxd.crew.persona.nombre,
                cuil = realdxd.recursodxd.crew.cuil,
                horasbase = realdxd.horasbase,
                dtdesde = realdxd.dtdesde,
                dthasta = realdxd.dthasta,
                controlsica = realdxd.controlsica,
                horasnormal = realdxd.horasnormal,
                horasextra = realdxd.horasextra,
                horasnocturna = realdxd.horasnocturna,
                horasenganche = realdxd.horasenganche,
                bolobruto = realdxd.bolobruto,
                boloneto = realdxd.boloneto,
                valhoraextra = realdxd.valhoraextra,
                impextra = realdxd.impextra,
                impadicional = realdxd.impadicional,
                septimodia = realdxd.septimodia,
                imptotalbruto = realdxd.imptotalbruto,
                impsac = realdxd.impsac,
                impvacaciones = realdxd.impvacaciones,
                impretenciones = realdxd.impretenciones,
                impsacvacaciones = realdxd.impsacvacaciones,
                imptotalneto = realdxd.imptotalneto,
                impcontribucionpatronal = realdxd.impcontribucionpatronal,
                iduseralta = realdxd.iduseralta,
                fecalta = realdxd.fecalta,
                iduserumod = realdxd.iduserumod,
                fecumod = realdxd.fecumod,
                activo = realdxd.activo
            });
        }

        // PUT: api/Realdxds/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] RealdxdUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idrealdxd <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var realdxd = await _context.Realdxds.FirstOrDefaultAsync(a => a.idrealdxd == model.idrealdxd);

            if (realdxd == null)
            {
                return NotFound();
            }
            realdxd.idrealdxd = model.idrealdxd;
            realdxd.idrecursodxd = model.idrecursodxd;
            realdxd.horasbase = model.horasbase;
            realdxd.fecha = model.dtdesde;
            realdxd.dtdesde = model.dtdesde;
            realdxd.dthasta = model.dthasta;
            realdxd.controlsica = model.controlsica;
            realdxd.horasnormal = model.horasnormal;
            realdxd.horasextra = model.horasextra;
            realdxd.horasnocturna = model.horasnocturna;
            realdxd.horasenganche = model.horasenganche;
            realdxd.bolobruto = model.bolobruto;
            realdxd.boloneto = model.boloneto;
            realdxd.valhoraextra = model.valhoraextra;
            realdxd.impextra = model.impextra;
            realdxd.impadicional = model.impadicional;
            realdxd.septimodia = model.septimodia;
            realdxd.imptotalbruto = model.imptotalbruto;
            realdxd.impsac = model.impsac;
            realdxd.impvacaciones = model.impvacaciones;
            realdxd.impretenciones = model.impretenciones;
            realdxd.impsacvacaciones = model.impsacvacaciones;
            realdxd.imptotalneto = model.imptotalneto;
            realdxd.impcontribucionpatronal = model.impcontribucionpatronal;
            realdxd.iduseralta = model.iduseralta;
            realdxd.fecalta = model.fecalta;
            realdxd.iduserumod = model.iduserumod;
            realdxd.fecumod = fechaHora;
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

        // POST: api/Realdxds/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] RealdxdCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Realdxd realdxd = new Realdxd
            {
                idrecursodxd = model.idrecursodxd,
                horasbase = model.horasbase,
                fecha = model.dtdesde,
                dtdesde = model.dtdesde,
                dthasta = model.dthasta,
                controlsica = model.controlsica,
                horasnormal = model.horasnormal,
                horasextra = model.horasextra,
                horasnocturna = model.horasnocturna,
                horasenganche = model.horasenganche,
                bolobruto = model.bolobruto,
                boloneto = model.boloneto,
                valhoraextra = model.valhoraextra,
                impextra = model.impextra,
                impadicional = model.impadicional,
                septimodia = model.septimodia,
                imptotalbruto = model.imptotalbruto,
                impsac = model.impsac,
                impvacaciones = model.impvacaciones,
                impretenciones = model.impretenciones,
                impsacvacaciones = model.impsacvacaciones,
                imptotalneto = model.imptotalneto,
                impcontribucionpatronal = model.impcontribucionpatronal,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Realdxds.Add(realdxd);
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


        // PUT: api/Realdxds/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var realdxd = await _context.Realdxds.FirstOrDefaultAsync(a => a.idrealdxd == id);

            if (realdxd == null)
            {
                return NotFound();
            }

            realdxd.activo = false;

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

        // PUT: api/Realdxds/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var realdxd = await _context.Realdxds.FirstOrDefaultAsync(a => a.idrealdxd == id);

            if (realdxd == null)
            {
                return NotFound();
            }

            realdxd.activo = true;

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


        private bool RealdxdExists(int id)
        {
            return _context.Realdxds.Any(e => e.idrealdxd == id);
        }
    }
}
