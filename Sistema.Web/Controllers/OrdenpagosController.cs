using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Pagos;
using Sistema.Web.Models.Pagos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenpagosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public OrdenpagosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Ordenpagos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<OrdenpagoViewModel>> Listar()
        {
            var ordenpago = await _context.Ordenpagos
                .Include(p => p.proyecto)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Include(p => p.alternativapago)
                .Where(p => p.proyecto.activo == true)
                .OrderBy(p => p.idordenpago)
                .AsNoTracking()
                .ToListAsync();

            return ordenpago.Select(a => new OrdenpagoViewModel
            {
                idordenpago = a.idordenpago,
                idproyecto = a.idproyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitem.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitem.subitemes : "",
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                idalternativapago = a.idalternativapago,
                alternativapago = a.alternativapago.beneficiario,
                feccomprobante = a.feccomprobante,
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                impsiniva = a.impsiniva,
                imptotal = a.imptotal,
                fecpago = a.fecpago,
                pdfcomprobantefac = a.pdfcomprobantefac,
                pagado = a.pagado,
                fecpagado = a.fecpagado,
                pdfcomprobantepago = a.pdfcomprobantepago,
                pdfcertificado1 = a.pdfcertificado1,
                pdfcertificado2 = a.pdfcertificado2,
                pdfcertificado3 = a.pdfcertificado3,
                pdfcertificado4 = a.pdfcertificado4,
                notas = a.notas,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Ordenpagos/ListarPendientes
        [HttpGet("[action]")]
        public async Task<IEnumerable<OrdenpagoViewModel>> ListarPendientes()
        {
            var ordenpago = await _context.Ordenpagos
                .Include(p => p.proyecto)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Include(p => p.alternativapago)
                .Where(p => p.proyecto.activo == true && p.pagado == false)
                .OrderBy(p => p.fecpago)
                .AsNoTracking()
                .ToListAsync();

            return ordenpago.Select(a => new OrdenpagoViewModel
            {
                idordenpago = a.idordenpago,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitem.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitem.subitemes : "",
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                idalternativapago = a.idalternativapago,
                alternativapago = a.alternativapago.beneficiario,
                feccomprobante = a.feccomprobante,
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                impsiniva = a.impsiniva,
                imptotal = a.imptotal,
                fecpago = a.fecpago,
                pdfcomprobantefac = a.pdfcomprobantefac,
                pagado = a.pagado,
                fecpagado = a.fecpagado,
                pdfcomprobantepago = a.pdfcomprobantepago,
                pdfcertificado1 = a.pdfcertificado1,
                pdfcertificado2 = a.pdfcertificado2,
                pdfcertificado3 = a.pdfcertificado3,
                pdfcertificado4 = a.pdfcertificado4,
                notas = a.notas,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Ordenpagos/ListarPendientesUsuario/7
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<OrdenpagoViewModel>> ListarPendientesUsuario([FromRoute] int id)
        {
            var ordenpago = await _context.Sqlordenpagos
                .FromSqlRaw($@"
                    SELECT c.idordenpago, b.idproyecto, b.orden AS proyectoorden, b.proyecto, c.iditem, d.orden AS itemorden, d.itemes, 
                            e.idsubitem, e.orden AS subitemorden, e.subitemes, f.idproveedor, f.razonsocial, g.idalternativapago, g.beneficiario AS alternativapago,
                            c.feccomprobante, c.tipocomprobante, c.numcomprobante, c.impsiniva, c.imptotal, c.fecpago, c.pdfcomprobantefac,
                            c.pagado, c.fecpagado, c.pdfcomprobantepago, c.pdfcertificado1, c.pdfcertificado2, c.pdfcertificado3, c.pdfcertificado4, 
                            c.notas, c.iduseralta, c.fecalta, c.iduserumod, c.fecumod, c.activo
                    FROM dbo.usuarioproyectos a
	                    LEFT JOIN dbo.proyectos b ON a.idproyecto = b.idproyecto
	                    LEFT JOIN dbo.ordenpagos c ON a.idproyecto = c.idproyecto
	                    LEFT JOIN dbo.items d ON c.iditem = d.iditem
	                    LEFT JOIN dbo.subitems e ON c.idsubitem = e.idsubitem
	                    LEFT JOIN dbo.proveedores f ON c.idproveedor = f.idproveedor
	                    LEFT JOIN dbo.alternativapagos g ON c.idalternativapago = g.idalternativapago
                    WHERE c.activo = 1 and c.pagado = 0 and idusuario = {id}
                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return ordenpago.Select(a => new OrdenpagoViewModel
            {
                idordenpago = a.idordenpago,
                idproyecto = a.idproyecto,
                proyectoorden = a.proyectoorden,
                proyecto = a.proyecto,
                iditem = a.iditem,
                itemorden = a.itemorden,
                itemes = a.itemes,
                idsubitem = a.idsubitem,
                subitemorden = a.subitemorden,
                subitemes = a.subitemes,
                idproveedor = a.idproveedor,
                proveedor = a.razonsocial,
                idalternativapago = a.idalternativapago,
                alternativapago = a.alternativapago,
                feccomprobante = a.feccomprobante,
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                impsiniva = a.impsiniva,
                imptotal = a.imptotal,
                fecpago = a.fecpago,
                pdfcomprobantefac = a.pdfcomprobantefac,
                pagado = a.pagado,
                fecpagado = a.fecpagado,
                pdfcomprobantepago = a.pdfcomprobantepago,
                pdfcertificado1 = a.pdfcertificado1,
                pdfcertificado2 = a.pdfcertificado2,
                pdfcertificado3 = a.pdfcertificado3,
                pdfcertificado4 = a.pdfcertificado4,
                notas = a.notas,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Ordenpagos/ListarActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<OrdenpagoViewModel>> ListarActivos()
        {
            var ordenpago = await _context.Ordenpagos
                .Include(p => p.proyecto)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Include(p => p.alternativapago)
                .Where(p => p.proyecto.activo == true && p.activo == true)
                .OrderBy(p => p.idordenpago)
                .AsNoTracking()
                .ToListAsync();

            return ordenpago.Select(a => new OrdenpagoViewModel
            {
                idordenpago = a.idordenpago,
                idproyecto = a.idproyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitem.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitem.subitemes : "",
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                idalternativapago = a.idalternativapago,
                alternativapago = a.alternativapago.beneficiario,
                feccomprobante = a.feccomprobante,
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                impsiniva = a.impsiniva,
                imptotal = a.imptotal,
                fecpago = a.fecpago,
                pdfcomprobantefac = a.pdfcomprobantefac,
                pagado = a.pagado,
                fecpagado = a.fecpagado,
                pdfcomprobantepago = a.pdfcomprobantepago,
                pdfcertificado1 = a.pdfcertificado1,
                pdfcertificado2 = a.pdfcertificado2,
                pdfcertificado3 = a.pdfcertificado3,
                pdfcertificado4 = a.pdfcertificado4,
                notas = a.notas,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Ordenpagos/BuscarImagenes
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<OrdenpagoImageModel>> BuscarImagenes([FromRoute] int id)
        {
            var ordenpago = await _context.Ordenpagos
                .Where(p => p.idordenpago == id)
                .ToListAsync();

            return ordenpago.Select(a => new OrdenpagoImageModel
            {
                idordenpago = a.idordenpago,
                pdfcomprobantefac = a.pdfcomprobantefac,
                pdfcomprobantepago = a.pdfcomprobantepago,
                pdfcertificado1 = a.pdfcertificado1,
                pdfcertificado2 = a.pdfcertificado2,
                pdfcertificado3 = a.pdfcertificado3,
                pdfcertificado4 = a.pdfcertificado4,
            });
        }


        // GET: api/Ordenpagos/ListarProyecto/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<OrdenpagoViewModel>> ListarProyecto([FromRoute] int id)
        {
            var ordenpago = await _context.Ordenpagos
                .Include(p => p.proyecto)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Include(p => p.alternativapago)
                .Where(p => p.idproyecto == id)
                .OrderBy(p => p.idordenpago)
                .AsNoTracking()
                .ToListAsync();

            return ordenpago.Select(a => new OrdenpagoViewModel
            {
                idordenpago = a.idordenpago,
                idproyecto = a.idproyecto,
                iditem = a.iditem,
                itemorden = a.item.orden,
                itemes = a.item.itemes,
                idsubitem = a.idsubitem,
                subitemorden = a.idsubitem.HasValue ? a.subitem.orden : "",
                subitemes = a.idsubitem.HasValue ? a.subitem.subitemes : "",
                idproveedor = a.idproveedor,
                proveedor = a.proveedor.razonsocial,
                idalternativapago = a.idalternativapago,
                alternativapago = a.alternativapago.beneficiario,
                feccomprobante = a.feccomprobante,
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                impsiniva = a.impsiniva,
                imptotal = a.imptotal,
                fecpago = a.fecpago,
                pdfcomprobantefac = a.pdfcomprobantefac,
                pagado = a.pagado,
                fecpagado = a.fecpagado,
                pdfcomprobantepago = a.pdfcomprobantepago,
                pdfcertificado1 = a.pdfcertificado1,
                pdfcertificado2 = a.pdfcertificado2,
                pdfcertificado3 = a.pdfcertificado3,
                pdfcertificado4 = a.pdfcertificado4,
                notas = a.notas,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Ordenpagos/Controlop2date/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Op2dateViewModel>> Controlop2date([FromRoute] int id)
        {
            var opdate = await _context.Op2dates
                .FromSqlRaw($@"
SELECT cast(ROW_NUMBER() OVER(order by idproyecto) as int) AS id, *
FROM (
SELECT a.idproyecto AS idproyecto
      ,b.orden AS proy
	  ,b.proyecto AS proyecto
	  ,f.idrubro
	  ,f.rubro
	  ,e.idsubrubro
	  ,e.subrubro
	  ,c.iditem
      ,c.item
	  ,d.idsubitem
      ,d.subitem
      ,g.razonsocial AS proveedor
      ,h.beneficiario
	  ,isnull(h.cbu,'') AS cbu
      ,a.feccomprobante
      ,a.tipocomprobante
      ,a.numcomprobante
      ,cast(a.impsiniva AS decimal(18,2)) AS impneto
      ,cast(a.imptotal AS decimal(18,2)) AS imptotal
      ,a.fecpago
      ,a.pagado
      ,isnull(a.fecpagado,'') AS fecpagado
      ,a.notas
  FROM dbo.ordenpagos a
	LEFT JOIN dbo.proyectos b ON a.idproyecto = b.idproyecto
	LEFT JOIN dbo.items c on a.iditem = c.iditem
	LEFT JOIN dbo.subitems d on a.idsubitem = d.idsubitem
	LEFT JOIN dbo.subrubros e ON e.idsubrubro = c.idsubrubro
	LEFT JOIN dbo.rubros f ON f.idrubro = e.idrubro
	LEFT JOIN dbo.proveedores g ON a.idproveedor = g.idproveedor
	LEFT JOIN dbo.alternativapagos h ON a.idalternativapago = h.idalternativapago
WHERE a.activo = 1 and b.idproyecto = {id}
) u                ")
                .IgnoreQueryFilters()
                .AsNoTracking()
                .ToListAsync();

            return opdate.Select(a => new Op2dateViewModel
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
                beneficiario = a.beneficiario,
                cbu = a.cbu,
                feccomprobante = a.feccomprobante,
                tipocomprobante = a.tipocomprobante,
                numcomprobante = a.numcomprobante,
                impneto = a.impneto,
                imptotal = a.imptotal,
                fecpago = a.fecpago,
                pagado = a.pagado,
                fecpagado = a.fecpagado,
                notas = a.notas
            });

        }

        // GET: api/Ordenpagos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var ordenpago = await _context.Ordenpagos
               .Include(p => p.proyecto)
                .Include(p => p.item)
                .Include(p => p.subitem)
                .Include(p => p.proveedor)
                .Include(p => p.alternativapago)
                .Where(p => p.proyecto.activo == true)
                .OrderBy(p => p.idordenpago)
                .SingleOrDefaultAsync(a => a.idordenpago == id);

            if (ordenpago == null)
            {
                return NotFound();
            }

            return Ok(new OrdenpagoViewModel
            {
                idordenpago = ordenpago.idordenpago,
                idproyecto = ordenpago.idproyecto,
                iditem = ordenpago.iditem,
                idsubitem = ordenpago.idsubitem,
                idproveedor = ordenpago.idproveedor,
                idalternativapago = ordenpago.idalternativapago,
                feccomprobante = ordenpago.feccomprobante,
                tipocomprobante = ordenpago.tipocomprobante,
                numcomprobante = ordenpago.numcomprobante,
                impsiniva = ordenpago.impsiniva,
                imptotal = ordenpago.imptotal,
                fecpago = ordenpago.fecpago,
                pdfcomprobantefac = ordenpago.pdfcomprobantefac,
                pagado = ordenpago.pagado,
                fecpagado = ordenpago.fecpagado,
                pdfcomprobantepago = ordenpago.pdfcomprobantepago,
                pdfcertificado1 = ordenpago.pdfcertificado1,
                pdfcertificado2 = ordenpago.pdfcertificado2,
                pdfcertificado3 = ordenpago.pdfcertificado3,
                pdfcertificado4 = ordenpago.pdfcertificado4,
                notas = ordenpago.notas,
                iduseralta = ordenpago.iduseralta,
                fecalta = ordenpago.fecalta,
                iduserumod = ordenpago.iduserumod,
                fecumod = ordenpago.fecumod,
                activo = ordenpago.activo
            });
        }

        // PUT: api/Ordenpagos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] OrdenpagoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idordenpago <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var ordenpago = await _context.Ordenpagos.FirstOrDefaultAsync(a => a.idordenpago == model.idordenpago);

            if (ordenpago == null)
            {
                return NotFound();
            }
            ordenpago.idordenpago = model.idordenpago;
            ordenpago.idproyecto = model.idproyecto;
            ordenpago.iditem = model.iditem;
            ordenpago.idsubitem = model.idsubitem;
            ordenpago.idproveedor = model.idproveedor;
            ordenpago.idalternativapago = model.idalternativapago;
            ordenpago.feccomprobante = model.feccomprobante;
            ordenpago.tipocomprobante = model.tipocomprobante;
            ordenpago.numcomprobante = model.numcomprobante;
            ordenpago.impsiniva = model.impsiniva;
            ordenpago.imptotal = model.imptotal;
            ordenpago.fecpago = model.fecpago;
            ordenpago.pdfcomprobantefac = model.pdfcomprobantefac;
            ordenpago.pdfcomprobantepago = model.pdfcomprobantepago;
            ordenpago.pdfcertificado1 = model.pdfcertificado1;
            ordenpago.pdfcertificado2 = model.pdfcertificado2;
            ordenpago.pdfcertificado3 = model.pdfcertificado3;
            ordenpago.pdfcertificado4 = model.pdfcertificado4;
            ordenpago.pagado = model.pagado;
            ordenpago.fecpagado = model.fecpagado;
            ordenpago.notas = model.notas;
            ordenpago.iduseralta = model.iduseralta;
            ordenpago.fecalta = model.fecalta;
            ordenpago.iduserumod = model.iduserumod;
            ordenpago.fecumod = fechaHora;
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

        // POST: api/Ordenpagos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] OrdenpagoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Ordenpago ordenpago = new Ordenpago
            {
                idproyecto = model.idproyecto,
                iditem = model.iditem,
                idsubitem = model.idsubitem,
                idproveedor = model.idproveedor,
                idalternativapago = model.idalternativapago,
                feccomprobante = model.feccomprobante,
                tipocomprobante = model.tipocomprobante,
                numcomprobante = model.numcomprobante,
                impsiniva = model.impsiniva,
                imptotal = model.imptotal,
                fecpago = model.fecpago,
                pdfcomprobantefac = model.pdfcomprobantefac,
                pdfcomprobantepago = model.pdfcomprobantepago,
                pdfcertificado1 = model.pdfcertificado1,
                pdfcertificado2 = model.pdfcertificado2,
                pdfcertificado3 = model.pdfcertificado3,
                pdfcertificado4 = model.pdfcertificado4,
                pagado = model.pagado,
                fecpagado = model.fecpagado,
                notas = model.notas,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Ordenpagos.Add(ordenpago);
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


        // PUT: api/Ordenpagos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var ordenpago = await _context.Ordenpagos.FirstOrDefaultAsync(a => a.idordenpago == id);

            if (ordenpago == null)
            {
                return NotFound();
            }

            ordenpago.activo = false;

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

        // PUT: api/Ordenpagos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var ordenpago = await _context.Ordenpagos.FirstOrDefaultAsync(a => a.idordenpago == id);

            if (ordenpago == null)
            {
                return NotFound();
            }

            ordenpago.activo = true;

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

        private bool OrdenpagoExists(int id)
        {
            return _context.Ordenpagos.Any(e => e.idordenpago == id);
        }
    }
}
