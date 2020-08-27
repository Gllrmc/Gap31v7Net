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
    public class RendicionfondosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public RendicionfondosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Rendicionfondos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RendicionfondoViewModel>> Listar()
        {
            var rendicionfondo = await _context.Rendicionfondos
                .Include(p => p.distribucionfondo)
                .ThenInclude(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Include(p => p.distribucionfondo)
                .ThenInclude(p => p.usuario)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Where(p => p.distribucionfondo.activo == true && p.distribucionfondo.pedidofondo.activo == true && p.distribucionfondo.pedidofondo.proyecto.activo == true)
                .OrderBy(p => p.idrendicionfondo)
                .AsNoTracking()
                .ToListAsync();

            return rendicionfondo.Select(a => new RendicionfondoViewModel
            {
                idrendicionfondo = a.idrendicionfondo,
                idproyecto = a.distribucionfondo.pedidofondo.proyecto.idproyecto,
                proyecto = a.distribucionfondo.pedidofondo.proyecto.proyecto,
                idpedidofondo = a.distribucionfondo.pedidofondo.idpedidofondo,
                iddistribucionfondo = a.iddistribucionfondo,
                fecdistribucion = a.distribucionfondo.fecdistribucion,
                responsable = a.distribucionfondo.usuario.userid,
                importedistribucion = a.distribucionfondo.importe,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                itemen = a.item.itemen,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitem.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitem.subitemes : "",
                subitemen = a.idsubitem.HasValue ? a.subitem.subitemen : "",
                idproveedor = a.idproveedor,
                proveedor = a.idproveedor.HasValue ? a.proveedor.razonsocial : "",
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                feccomprobante = a.feccomprobante,
                indiceinterno = a.indiceinterno,
                impsiniva = a.impsiniva,
                imptotal = a.imptotal,
                notas = a.notas,
                pdfcomprobante = a.pdfcomprobante,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Rendicionfondos/ListarActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<RendicionfondoViewModel>> ListarActivos()
        {
            var rendicionfondo = await _context.Rendicionfondos
                .Include(p => p.distribucionfondo)
                .ThenInclude(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Include(p => p.distribucionfondo)
                .ThenInclude(p => p.usuario)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Where(p => p.activo == true && p.distribucionfondo.activo == true && p.distribucionfondo.pedidofondo.activo == true 
                    && p.distribucionfondo.pedidofondo.proyecto.activo == true && p.distribucionfondo.rendido == false)
                .OrderBy(p => p.idrendicionfondo)
                .AsNoTracking()
                .ToListAsync();

            return rendicionfondo.Select(a => new RendicionfondoViewModel
            {
                idrendicionfondo = a.idrendicionfondo,
                idproyecto = a.distribucionfondo.pedidofondo.proyecto.idproyecto,
                proyecto = a.distribucionfondo.pedidofondo.proyecto.proyecto,
                idpedidofondo = a.distribucionfondo.pedidofondo.idpedidofondo,
                iddistribucionfondo = a.iddistribucionfondo,
                fecdistribucion = a.distribucionfondo.fecdistribucion,
                responsable = a.distribucionfondo.usuario.userid,
                importedistribucion = a.distribucionfondo.importe,
                iditem = a.iditem,
                idsubitem = a.idsubitem,
                idproveedor = a.idproveedor,
                proveedor = a.idproveedor.HasValue ? a.proveedor.razonsocial : "",
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                feccomprobante = a.feccomprobante,
                indiceinterno = a.indiceinterno,
                impsiniva = a.impsiniva,
                imptotal = a.imptotal,
                notas = a.notas,
                pdfcomprobante = a.pdfcomprobante,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Rendicionfondos/ListarDistribucionfondo/2
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<RendicionfondoViewModel>> ListarDistribucionfondo([FromRoute] int id)
        {
            var rendicionfondo = await _context.Rendicionfondos
                .Include(p => p.distribucionfondo)
                .ThenInclude(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Include(p => p.distribucionfondo)
                .ThenInclude(p => p.usuario)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Where(p => p.distribucionfondo.iddistribucionfondo == id && p.distribucionfondo.rendido == false)
                .OrderBy(p => p.idrendicionfondo)
                .AsNoTracking()
                .ToListAsync();

            return rendicionfondo.Select(a => new RendicionfondoViewModel
            {
                idrendicionfondo = a.idrendicionfondo,
                idproyecto = a.distribucionfondo.pedidofondo.proyecto.idproyecto,
                proyecto = a.distribucionfondo.pedidofondo.proyecto.proyecto,
                idpedidofondo = a.distribucionfondo.pedidofondo.idpedidofondo,
                iddistribucionfondo = a.iddistribucionfondo,
                fecdistribucion = a.distribucionfondo.fecdistribucion,
                responsable = a.distribucionfondo.usuario.userid,
                importedistribucion = a.distribucionfondo.importe,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                itemen = a.item.itemen,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitem.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitem.subitemes : "",
                subitemen = a.idsubitem.HasValue ? a.subitem.subitemen : "",
                idproveedor = a.idproveedor,
                proveedor = a.idproveedor.HasValue ? a.proveedor.razonsocial : "",
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                feccomprobante = a.feccomprobante,
                indiceinterno = a.indiceinterno,
                impsiniva = a.impsiniva,
                imptotal = a.imptotal,
                notas = a.notas,
                pdfcomprobante = a.pdfcomprobante,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Rendicionfondos/Controlrendicion2date/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Rendicion2dateViewModel>> Controlrendicion2date([FromRoute] int id)
        {
            var rendiciontodate = await _context.Rendicion2dates
                .FromSqlRaw($@"
SELECT cast(ROW_NUMBER() OVER(order by idproyecto) as int) AS id, *
FROM (
SELECT p.idproyecto, p.orden as proy, p.proyecto as proyecto, a.numpedido, r.nombre, 'Pedido' as origen, t.rubro, s.idsubrubro, s.subrubro, '' AS item, '' AS subitem, cast(sum(a.importe) as decimal(18,2)) as importe
FROM dbo.pedidosfondo a
LEFT JOIN dbo.proyectos p ON a.idproyecto = p.idproyecto
LEFT JOIN dbo.personas r ON a.idresponsable = r.idpersona
LEFT JOIN dbo.subrubros s ON a.idsubrubro = s.idsubrubro
LEFT JOIN dbo.rubros t ON s.idrubro = t.idrubro
WHERE p.idproyecto = {id} and a.activo = 1
GROUP BY p.idproyecto, p.orden, proyecto, numpedido, nombre, rubro, s.idsubrubro, subrubro
UNION
SELECT p.idproyecto, p.orden as proy, p.proyecto as proyecto, g.numpedido, r.nombre, 'Rendicion' as origen, v.rubro, u.idsubrubro, u.subrubro, s.item, t.subitem, cast(sum(a.imptotal*-1) as decimal(18,2)) as importe
FROM dbo.rendicionfondos a
LEFT JOIN dbo.distribucionfondos f ON a.iddistribucionfondo = f.iddistribucionfondo
LEFT JOIN dbo.pedidosfondo g ON g.idpedidofondo = f.idpedidofondo
LEFT JOIN dbo.proyectos p ON g.idproyecto = p.idproyecto
LEFT JOIN dbo.personas r ON g.idresponsable = r.idpersona
LEFT JOIN dbo.items s ON a.iditem = s.iditem
Left Join dbo.subitems t ON a.idsubitem = t.idsubitem
Left Join dbo.subrubros u ON s.idsubrubro = u.idsubrubro
Left Join dbo.rubros v ON u.idrubro = v.idrubro
WHERE p.idproyecto = {id} and a.activo = 1
GROUP BY p.idproyecto, p.orden, proyecto, numpedido, nombre, rubro, u.idsubrubro, subrubro, item, subitem
) u                
                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return rendiciontodate.Select(a => new Rendicion2dateViewModel
            {
                idproyecto = a.idproyecto,
                proy = a.proy,
                proyecto = a.proyecto,
                numpedido = a.numpedido,
                nombre = a.nombre,
                origen = a.origen,
                rubro = a.rubro,
                idsubrubro = a.idsubrubro,
                subrubro = a.subrubro,
                item = a.item,
                subitem = a.subitem,
                importe = a.importe
            });
        }

        // GET: api/Rendicionfondos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var rendicionfondo = await _context.Rendicionfondos
                .Include(p => p.distribucionfondo)
                .ThenInclude(p => p.pedidofondo)
                .ThenInclude(p => p.proyecto)
                .Include(p => p.distribucionfondo)
                .ThenInclude(p => p.usuario)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Where(p => p.activo == true && p.distribucionfondo.activo == true && p.distribucionfondo.pedidofondo.activo == true && p.distribucionfondo.pedidofondo.proyecto.activo == true)
                .OrderBy(p => p.idrendicionfondo)
                .SingleOrDefaultAsync(a => a.idrendicionfondo == id);

            if (rendicionfondo == null)
            {
                return NotFound();
            }

            return Ok(new RendicionfondoViewModel
            {
                idrendicionfondo = rendicionfondo.idrendicionfondo,
                idproyecto = rendicionfondo.distribucionfondo.pedidofondo.proyecto.idproyecto,
                proyecto = rendicionfondo.distribucionfondo.pedidofondo.proyecto.proyecto,
                iddistribucionfondo = rendicionfondo.iddistribucionfondo,
                responsable = rendicionfondo.distribucionfondo.usuario.userid,
                fecdistribucion = rendicionfondo.distribucionfondo.fecdistribucion,
                importedistribucion = rendicionfondo.distribucionfondo.importe,
                iditem = rendicionfondo.iditem,
                idsubitem = rendicionfondo.idsubitem,
                idproveedor = rendicionfondo.idproveedor,
                proveedor = rendicionfondo.idproveedor.HasValue ? rendicionfondo.proveedor.razonsocial : "",
                tipocomprobante = rendicionfondo.tipocomprobante,
                numcomprobante = rendicionfondo.numcomprobante,
                feccomprobante = rendicionfondo.feccomprobante,
                indiceinterno = rendicionfondo.indiceinterno,
                impsiniva = rendicionfondo.impsiniva,
                imptotal = rendicionfondo.imptotal,
                notas = rendicionfondo.notas,
                pdfcomprobante = rendicionfondo.pdfcomprobante,
                iduseralta = rendicionfondo.iduseralta,
                fecalta = rendicionfondo.fecalta,
                iduserumod = rendicionfondo.iduserumod,
                fecumod = rendicionfondo.fecumod,
                activo = rendicionfondo.activo
            });
        }

        // PUT: api/Rendicionfondos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] RendicionfondoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idrendicionfondo <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var rendicionfondo = await _context.Rendicionfondos.FirstOrDefaultAsync(a => a.idrendicionfondo == model.idrendicionfondo);

            if (rendicionfondo == null)
            {
                return NotFound();
            }
            rendicionfondo.idrendicionfondo = model.idrendicionfondo;
            rendicionfondo.iddistribucionfondo = model.iddistribucionfondo;
            rendicionfondo.iditem = model.iditem;
            rendicionfondo.idsubitem = model.idsubitem;
            rendicionfondo.idproveedor = model.idproveedor;
            rendicionfondo.tipocomprobante = model.tipocomprobante;
            rendicionfondo.numcomprobante = model.numcomprobante;
            rendicionfondo.feccomprobante = model.feccomprobante;
            rendicionfondo.indiceinterno = model.indiceinterno;
            rendicionfondo.impsiniva = model.impsiniva;
            rendicionfondo.imptotal = model.imptotal;
            rendicionfondo.notas = model.notas;
            rendicionfondo.pdfcomprobante = model.pdfcomprobante;
            rendicionfondo.iduseralta = model.iduseralta;
            rendicionfondo.fecalta = model.fecalta;
            rendicionfondo.iduserumod = model.iduserumod;
            rendicionfondo.fecumod = fechaHora;
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

        // POST: api/Rendicionfondos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] RendicionfondoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Rendicionfondo rendicionfondo = new Rendicionfondo
            {
                iddistribucionfondo = model.iddistribucionfondo,
                iditem = model.iditem,
                idsubitem = model.idsubitem,
                idproveedor = model.idproveedor,
                tipocomprobante = model.tipocomprobante,
                numcomprobante = model.numcomprobante,
                feccomprobante = model.feccomprobante,
                indiceinterno = model.indiceinterno,
                impsiniva = model.impsiniva,
                imptotal = model.imptotal,
                notas = model.notas,
                pdfcomprobante = model.pdfcomprobante,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Rendicionfondos.Add(rendicionfondo);
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


        // PUT: api/Rendicionfondos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var rendicionfondo = await _context.Rendicionfondos.FirstOrDefaultAsync(a => a.idrendicionfondo == id);

            if (rendicionfondo == null)
            {
                return NotFound();
            }

            rendicionfondo.activo = false;

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

        // PUT: api/Rendicionfondos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var rendicionfondo = await _context.Rendicionfondos.FirstOrDefaultAsync(a => a.idrendicionfondo == id);

            if (rendicionfondo == null)
            {
                return NotFound();
            }

            rendicionfondo.activo = true;

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
        private bool RendicionfondoExists(int id)
        {
            return _context.Rendicionfondos.Any(e => e.idrendicionfondo == id);
        }
    }
}
