using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Limbos;
using Sistema.Web.Models.Limbos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class LimbosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public LimbosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Limbos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<LimboViewModel>> Listar()
        {
            var Limbo = await _context.Limbos
                .Include(p => p.lep)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.pitchs)
                .Include(p => p.ldirector)
                .Include(p => p.lcodirector)
                .Include(p => p.tipoprods)
                .Include(p => p.tipoproys)
                .Include(p => p.estados)
                .Include(p => p.posiciones)
                .Include(p => p.productoras)
                .Include(p => p.clientes)
                .Where(p => p.idresultado == null)
                .ToListAsync();

            return Limbo.Select(r => new LimboViewModel
            {
                idlimbo = r.idlimbo,
                orden = r.orden,
                proyecto = r.proyecto,
                idep = r.idep,
                ep = r.lep.nombre,
                idcliente = r.idcliente,
                cliente = r.clientes.razonsocial,
                idorigen = r.idorigen,
                origen = r.origenes.origen,
                territorio = r.origenes.territorio.territorio,
                idagencia = r.idagencia,
                agencia = r.agencias.agencia,
                idpitch = r.idpitch,
                pitch = r.pitchs.pitch,
                iddirector = r.iddirector,
                director = r.ldirector.nombre,
                idcodirector = r.idcodirector,
                codirector = r.idcodirector.HasValue ? r.lcodirector.nombre : "",
                idproductora = r.idproductora,
                productora = r.productoras.productora,
                idtipoprod = r.idtipoprod,
                tipoprod = r.tipoprods.tipoprod,
                impcosto = r.impcosto,
                porcontingencia = r.porcontingencia,
                porgastosfijo = r.porgastosfijo,
                porganancia = r.porganancia,
                porfeedireccion = r.porfeedireccion,
                porotrosgastos = r.porotrosgastos,
                porcostofinanciero = r.porcostofinanciero,
                porimpuestoycomision = r.porimpuestoycomision,
                impventa = r.impventa,
                impcontribucion = r.impcontribucion,
                porcontribucion = r.porcontribucion,
                idtipoproy = r.idtipoproy,
                tipoproy = r.tipoproys.tipoproy,
                idestado = r.idestado,
                estado = r.estados.estado,
                fecingreso = r.fecingreso,
                fecadjudicacion = r.fecadjudicacion,
                fecpitch = r.fecpitch,
                fecrodaje = r.fecrodaje,
                fecentrega = r.fecentrega,
                aprobacion = r.aprobacion,
                fecaprobacion = r.fecaprobacion,
                idresultado = r.idresultado,
                resultado = r.idresultado.HasValue ? r.resultados.resultado : "",
                comentario = r.comentario,
                visitaforanea = r.visitaforanea,
                postinhouse = r.postinhouse,
                idposiciones = r.idposiciones,
                posiciones = r.posiciones.posicion,
                editinhouse = r.editinhouse,
                ars1usd = r.ars1usd,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Limbos/Listarusuario/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<LimboViewModel>> Listarusuario([FromRoute] int id)
        {
            var Limbo = await _context.Limbos
                .Include(p => p.lep)
                .ThenInclude(p => p.usuario)
                .Where(p => p.lep.usuario.idusuario == id && p.lep.usuario.idpersona == p.lep.idpersona)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.pitchs)
                .Include(p => p.ldirector)
                .Include(p => p.lcodirector)
                .Include(p => p.tipoprods)
                .Include(p => p.tipoproys)
                .Include(p => p.estados)
                .Include(p => p.posiciones)
                .Include(p => p.productoras)
                .Include(p => p.clientes)
                .Where(p => p.idresultado == null)
                .ToListAsync();

            return Limbo.Select(r => new LimboViewModel
            {
                idlimbo = r.idlimbo,
                orden = r.orden,
                proyecto = r.proyecto,
                idep = r.idep,
                ep = r.lep.nombre,
                idcliente = r.idcliente,
                cliente = r.clientes.razonsocial,
                idorigen = r.idorigen,
                origen = r.origenes.origen,
                territorio = r.origenes.territorio.territorio,
                idagencia = r.idagencia,
                agencia = r.agencias.agencia,
                idpitch = r.idpitch,
                pitch = r.pitchs.pitch,
                iddirector = r.iddirector,
                director = r.ldirector.nombre,
                idcodirector = r.idcodirector,
                codirector = r.idcodirector.HasValue ? r.lcodirector.nombre : "",
                idproductora = r.idproductora,
                productora = r.productoras.productora,
                idtipoprod = r.idtipoprod,
                tipoprod = r.tipoprods.tipoprod,
                impcosto = r.impcosto,
                porcontingencia = r.porcontingencia,
                porgastosfijo = r.porgastosfijo,
                porganancia = r.porganancia,
                porfeedireccion = r.porfeedireccion,
                porotrosgastos = r.porotrosgastos,
                porcostofinanciero = r.porcostofinanciero,
                porimpuestoycomision = r.porimpuestoycomision,
                impventa = r.impventa,
                impcontribucion = r.impcontribucion,
                porcontribucion = r.porcontribucion,
                idtipoproy = r.idtipoproy,
                tipoproy = r.tipoproys.tipoproy,
                idestado = r.idestado,
                estado = r.estados.estado,
                fecingreso = r.fecingreso,
                fecadjudicacion = r.fecadjudicacion,
                fecpitch = r.fecpitch,
                fecrodaje = r.fecrodaje,
                fecentrega = r.fecentrega,
                aprobacion = r.aprobacion,
                fecaprobacion = r.fecaprobacion,
                idresultado = r.idresultado,
                resultado = r.idresultado.HasValue ? r.resultados.resultado : "",
                comentario = r.comentario,
                visitaforanea = r.visitaforanea,
                postinhouse = r.postinhouse,
                idposiciones = r.idposiciones,
                posiciones = r.posiciones.posicion,
                editinhouse = r.editinhouse,
                ars1usd = r.ars1usd,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Limbos/ListarAprobados
        [HttpGet("[action]")]
        public async Task<IEnumerable<LimboViewModel>> ListarAprobados()
        {
            var Limbo = await _context.Limbos
                .Include(p => p.lep)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.pitchs)
                .Include(p => p.ldirector)
                .Include(p => p.lcodirector)
                .Include(p => p.tipoprods)
                .Include(p => p.tipoproys)
                .Include(p => p.estados)
                .Include(p => p.posiciones)
                .Include(p => p.productoras)
                .Include(p => p.clientes)
                .Include(p => p.resultados)
                .Where(p => p.resultados.esaprobacion == true)
                .OrderByDescending(p => p.fecaprobacion)
                .Take(20)
                .ToListAsync();

            return Limbo.Select(r => new LimboViewModel
            {
                idlimbo = r.idlimbo,
                orden = r.orden,
                proyecto = r.proyecto,
                idep = r.idep,
                ep = r.lep.nombre,
                idcliente = r.idcliente,
                cliente = r.clientes.razonsocial,
                idorigen = r.idorigen,
                origen = r.origenes.origen,
                territorio = r.origenes.territorio.territorio,
                idagencia = r.idagencia,
                agencia = r.agencias.agencia,
                idpitch = r.idpitch,
                pitch = r.pitchs.pitch,
                iddirector = r.iddirector,
                director = r.ldirector.nombre,
                idcodirector = r.idcodirector,
                codirector = r.idcodirector.HasValue ? r.lcodirector.nombre : "",
                idproductora = r.idproductora,
                productora = r.productoras.productora,
                idtipoprod = r.idtipoprod,
                tipoprod = r.tipoprods.tipoprod,
                impcosto = r.impcosto,
                porcontingencia = r.porcontingencia,
                porgastosfijo = r.porgastosfijo,
                porganancia = r.porganancia,
                porfeedireccion = r.porfeedireccion,
                porotrosgastos = r.porotrosgastos,
                porcostofinanciero = r.porcostofinanciero,
                porimpuestoycomision = r.porimpuestoycomision,
                impventa = r.impventa,
                impcontribucion = r.impcontribucion,
                porcontribucion = r.porcontribucion,
                idtipoproy = r.idtipoproy,
                tipoproy = r.tipoproys.tipoproy,
                idestado = r.idestado,
                estado = r.estados.estado,
                fecingreso = r.fecingreso,
                fecadjudicacion = r.fecadjudicacion,
                fecpitch = r.fecpitch,
                fecrodaje = r.fecrodaje,
                fecentrega = r.fecentrega,
                aprobacion = r.aprobacion,
                fecaprobacion = r.fecaprobacion,
                idresultado = r.idresultado,
                resultado = r.idresultado.HasValue ? r.resultados.resultado : "",
                comentario = r.comentario,
                visitaforanea = r.visitaforanea,
                postinhouse = r.postinhouse,
                idposiciones = r.idposiciones,
                posiciones = r.posiciones.posicion,
                editinhouse = r.editinhouse,
                ars1usd = r.ars1usd,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Limbos/ListarAprobadosusuario/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<LimboViewModel>> ListarAprobadosusuario([FromRoute] int id)
        {
            var Limbo = await _context.Limbos
                .Include(p => p.lep)
                .ThenInclude(p => p.usuario)
                .Where(p => p.lep.usuario.idusuario == id && p.lep.usuario.idpersona == p.lep.idpersona)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.pitchs)
                .Include(p => p.ldirector)
                .Include(p => p.lcodirector)
                .Include(p => p.tipoprods)
                .Include(p => p.tipoproys)
                .Include(p => p.estados)
                .Include(p => p.posiciones)
                .Include(p => p.productoras)
                .Include(p => p.clientes)
                .Include(p => p.resultados)
                .Where(p => p.resultados.esaprobacion == true)
                .OrderByDescending(p => p.fecaprobacion)
                .Take(20)
                .ToListAsync();

            return Limbo.Select(r => new LimboViewModel
            {
                idlimbo = r.idlimbo,
                orden = r.orden,
                proyecto = r.proyecto,
                idep = r.idep,
                ep = r.lep.nombre,
                idcliente = r.idcliente,
                cliente = r.clientes.razonsocial,
                idorigen = r.idorigen,
                origen = r.origenes.origen,
                territorio = r.origenes.territorio.territorio,
                idagencia = r.idagencia,
                agencia = r.agencias.agencia,
                idpitch = r.idpitch,
                pitch = r.pitchs.pitch,
                iddirector = r.iddirector,
                director = r.ldirector.nombre,
                idcodirector = r.idcodirector,
                codirector = r.idcodirector.HasValue ? r.lcodirector.nombre : "",
                idproductora = r.idproductora,
                productora = r.productoras.productora,
                idtipoprod = r.idtipoprod,
                tipoprod = r.tipoprods.tipoprod,
                impcosto = r.impcosto,
                porcontingencia = r.porcontingencia,
                porgastosfijo = r.porgastosfijo,
                porganancia = r.porganancia,
                porfeedireccion = r.porfeedireccion,
                porotrosgastos = r.porotrosgastos,
                porcostofinanciero = r.porcostofinanciero,
                porimpuestoycomision = r.porimpuestoycomision,
                impventa = r.impventa,
                impcontribucion = r.impcontribucion,
                porcontribucion = r.porcontribucion,
                idtipoproy = r.idtipoproy,
                tipoproy = r.tipoproys.tipoproy,
                idestado = r.idestado,
                estado = r.estados.estado,
                fecingreso = r.fecingreso,
                fecadjudicacion = r.fecadjudicacion,
                fecpitch = r.fecpitch,
                fecrodaje = r.fecrodaje,
                fecentrega = r.fecentrega,
                aprobacion = r.aprobacion,
                fecaprobacion = r.fecaprobacion,
                idresultado = r.idresultado,
                resultado = r.idresultado.HasValue ? r.resultados.resultado : "",
                comentario = r.comentario,
                visitaforanea = r.visitaforanea,
                postinhouse = r.postinhouse,
                idposiciones = r.idposiciones,
                posiciones = r.posiciones.posicion,
                editinhouse = r.editinhouse,
                ars1usd = r.ars1usd,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Limbos/ListarHistorico
        [HttpGet("[action]")]
        public async Task<IEnumerable<LimboViewModel>> ListarHistorico()
        {
            var Limbo = await _context.Limbos
                .Include(p => p.lep)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.pitchs)
                .Include(p => p.ldirector)
                .Include(p => p.lcodirector)
                .Include(p => p.tipoprods)
                .Include(p => p.tipoproys)
                .Include(p => p.estados)
                .Include(p => p.posiciones)
                .Include(p => p.productoras)
                .Include(p => p.clientes)
                .Include(p => p.resultados)
                .Where(p => p.idresultado != null)
                .ToListAsync();

            return Limbo.Select(r => new LimboViewModel
            {
                idlimbo = r.idlimbo,
                orden = r.orden,
                proyecto = r.proyecto,
                idep = r.idep,
                ep = r.lep.nombre,
                idcliente = r.idcliente,
                cliente = r.clientes.razonsocial,
                idorigen = r.idorigen,
                origen = r.origenes.origen,
                territorio = r.origenes.territorio.territorio,
                idagencia = r.idagencia,
                agencia = r.agencias.agencia,
                idpitch = r.idpitch,
                pitch = r.pitchs.pitch,
                iddirector = r.iddirector,
                director = r.ldirector.nombre,
                idcodirector = r.idcodirector,
                codirector = r.idcodirector.HasValue ? r.lcodirector.nombre : "",
                idproductora = r.idproductora,
                productora = r.productoras.productora,
                idtipoprod = r.idtipoprod,
                tipoprod = r.tipoprods.tipoprod,
                impcosto = r.impcosto,
                porcontingencia = r.porcontingencia,
                porgastosfijo = r.porgastosfijo,
                porganancia = r.porganancia,
                porfeedireccion = r.porfeedireccion,
                porotrosgastos = r.porotrosgastos,
                porcostofinanciero = r.porcostofinanciero,
                porimpuestoycomision = r.porimpuestoycomision,
                impventa = r.impventa,
                impcontribucion = r.impcontribucion,
                porcontribucion = r.porcontribucion,
                idtipoproy = r.idtipoproy,
                tipoproy = r.tipoproys.tipoproy,
                idestado = r.idestado,
                estado = r.estados.estado,
                fecingreso = r.fecingreso,
                fecadjudicacion = r.fecadjudicacion,
                fecpitch = r.fecpitch,
                fecrodaje = r.fecrodaje,
                fecentrega = r.fecentrega,
                aprobacion = r.aprobacion,
                fecaprobacion = r.fecaprobacion,
                idresultado = r.idresultado,
                resultado = r.idresultado.HasValue ? r.resultados.resultado : "",
                comentario = r.comentario,
                visitaforanea = r.visitaforanea,
                postinhouse = r.postinhouse,
                idposiciones = r.idposiciones,
                posiciones = r.posiciones.posicion,
                editinhouse = r.editinhouse,
                ars1usd = r.ars1usd,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Limbos/ListarHistoricousuario/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<LimboViewModel>> ListarHistoricousuario([FromRoute] int id)
        {
            var Limbo = await _context.Limbos
                .Include(p => p.lep)
                .ThenInclude(p => p.usuario)
                .Where(p => p.lep.usuario.idusuario == id && p.lep.usuario.idpersona == p.lep.idpersona)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.pitchs)
                .Include(p => p.ldirector)
                .Include(p => p.lcodirector)
                .Include(p => p.tipoprods)
                .Include(p => p.tipoproys)
                .Include(p => p.estados)
                .Include(p => p.posiciones)
                .Include(p => p.productoras)
                .Include(p => p.clientes)
                .Include(p => p.resultados)
                .Where(p => p.idresultado != null)
                .ToListAsync();

            return Limbo.Select(r => new LimboViewModel
            {
                idlimbo = r.idlimbo,
                orden = r.orden,
                proyecto = r.proyecto,
                idep = r.idep,
                ep = r.lep.nombre,
                idcliente = r.idcliente,
                cliente = r.clientes.razonsocial,
                idorigen = r.idorigen,
                origen = r.origenes.origen,
                territorio = r.origenes.territorio.territorio,
                idagencia = r.idagencia,
                agencia = r.agencias.agencia,
                idpitch = r.idpitch,
                pitch = r.pitchs.pitch,
                iddirector = r.iddirector,
                director = r.ldirector.nombre,
                idcodirector = r.idcodirector,
                codirector = r.idcodirector.HasValue ? r.lcodirector.nombre : "",
                idproductora = r.idproductora,
                productora = r.productoras.productora,
                idtipoprod = r.idtipoprod,
                tipoprod = r.tipoprods.tipoprod,
                impcosto = r.impcosto,
                porcontingencia = r.porcontingencia,
                porgastosfijo = r.porgastosfijo,
                porganancia = r.porganancia,
                porfeedireccion = r.porfeedireccion,
                porotrosgastos = r.porotrosgastos,
                porcostofinanciero = r.porcostofinanciero,
                porimpuestoycomision = r.porimpuestoycomision,
                impventa = r.impventa,
                impcontribucion = r.impcontribucion,
                porcontribucion = r.porcontribucion,
                idtipoproy = r.idtipoproy,
                tipoproy = r.tipoproys.tipoproy,
                idestado = r.idestado,
                estado = r.estados.estado,
                fecingreso = r.fecingreso,
                fecadjudicacion = r.fecadjudicacion,
                fecpitch = r.fecpitch,
                fecrodaje = r.fecrodaje,
                fecentrega = r.fecentrega,
                aprobacion = r.aprobacion,
                fecaprobacion = r.fecaprobacion,
                idresultado = r.idresultado,
                resultado = r.idresultado.HasValue ? r.resultados.resultado : "",
                comentario = r.comentario,
                visitaforanea = r.visitaforanea,
                postinhouse = r.postinhouse,
                idposiciones = r.idposiciones,
                posiciones = r.posiciones.posicion,
                editinhouse = r.editinhouse,
                ars1usd = r.ars1usd,
                iduseralta = r.iduseralta,
                fecalta = r.fecalta,
                iduserumod = r.iduserumod,
                fecumod = r.fecumod,
                activo = r.activo
            });
        }

        // GET: api/Limbos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<LimboSelectModel>> Select()
        {
            var limbo = await _context.Limbos
                .Where(r => r.activo == true)
                .OrderBy(r => r.orden)
                .ToListAsync();

            return limbo.Select(r => new LimboSelectModel
            {
                idlimbo = r.idlimbo,
                orden = r.orden,
                proyecto = r.proyecto
            });
        }

        // GET: api/Limbos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var limbo = await _context.Limbos
                .Include(p => p.lep)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.pitchs)
                .Include(p => p.ldirector)
                .Include(p => p.lcodirector)
                .Include(p => p.tipoprods)
                .Include(p => p.tipoproys)
                .Include(p => p.estados)
                .Include(p => p.productoras)
                .Include(p => p.clientes)
                .OrderBy(p => p.idlimbo)
                .Take(100)
                .SingleOrDefaultAsync(a => a.idlimbo == id);

            if (limbo == null)
            {
                return NotFound();
            }

            return Ok(new LimboViewModel
            {
                idlimbo = limbo.idlimbo,
                orden = limbo.orden,
                proyecto = limbo.proyecto,
                idcliente = limbo.idcliente,
                cliente = limbo.clientes.razonsocial,
                idep = limbo.idep,
                ep = limbo.lep.nombre,
                idorigen = limbo.idorigen,
                origen = limbo.origenes.origen,
                territorio = limbo.origenes.territorio.territorio,
                idagencia = limbo.idagencia,
                agencia = limbo.agencias.agencia,
                idpitch = limbo.idpitch,
                pitch = limbo.pitchs.pitch,
                iddirector = limbo.iddirector,
                director = limbo.ldirector.nombre,
                idcodirector = limbo.idcodirector,
                codirector = limbo.lcodirector.nombre,
                idproductora = limbo.idproductora,
                productora = limbo.productoras.productora,
                idtipoprod = limbo.idtipoprod,
                tipoprod = limbo.tipoprods.tipoprod,
                impcosto = limbo.impcosto,
                porcontingencia = limbo.porcontingencia,
                porgastosfijo = limbo.porgastosfijo,
                porganancia = limbo.porganancia,
                porfeedireccion = limbo.porfeedireccion,
                porotrosgastos = limbo.porotrosgastos,
                porcostofinanciero = limbo.porcostofinanciero,
                porimpuestoycomision = limbo.porimpuestoycomision,
                impventa = limbo.impventa,
                impcontribucion = limbo.impcontribucion,
                porcontribucion = limbo.porcontribucion,
                idtipoproy = limbo.idtipoproy,
                tipoproy = limbo.tipoproys.tipoproy,
                idestado = limbo.idestado,
                estado = limbo.estados.estado,
                fecingreso = limbo.fecingreso,
                fecadjudicacion = limbo.fecadjudicacion,
                fecpitch = limbo.fecpitch,
                fecrodaje = limbo.fecrodaje,
                fecentrega = limbo.fecentrega,
                aprobacion = limbo.aprobacion,
                fecaprobacion = limbo.fecaprobacion,
                idresultado = limbo.idresultado,
                resultado = limbo.resultados.resultado,
                comentario = limbo.comentario,
                visitaforanea = limbo.visitaforanea,
                postinhouse = limbo.postinhouse,
                idposiciones = limbo.idposiciones,
                posiciones = limbo.posiciones.posicion,
                editinhouse = limbo.editinhouse,
                ars1usd = limbo.ars1usd,
                iduseralta = limbo.iduseralta,
                fecalta = limbo.fecalta,
                iduserumod = limbo.iduserumod,
                fecumod = limbo.fecumod,
                activo = limbo.activo
            });
        }

        // PUT: api/Limbos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] LimboUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idlimbo <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var limbo = await _context.Limbos.FirstOrDefaultAsync(c => c.idlimbo == model.idlimbo);

            if (limbo == null)
            {
                return NotFound();
            }

            limbo.orden = model.orden;
            limbo.proyecto = model.proyecto;
            limbo.idcliente = model.idcliente;
            limbo.idep = model.idep;
            limbo.idorigen = model.idorigen;
            limbo.idagencia = model.idagencia;
            limbo.idpitch = model.idpitch;
            limbo.iddirector = model.iddirector;
            limbo.idcodirector = model.idcodirector;
            limbo.idproductora = model.idproductora;
            limbo.idtipoprod = model.idtipoprod;
            limbo.impcosto = model.impcosto;
            limbo.porcontingencia = model.porcontingencia;
            limbo.porgastosfijo = model.porgastosfijo;
            limbo.porganancia = model.porganancia;
            limbo.porfeedireccion = model.porfeedireccion;
            limbo.porotrosgastos = model.porotrosgastos;
            limbo.porcostofinanciero = model.porcostofinanciero;
            limbo.porimpuestoycomision = model.porimpuestoycomision;
            limbo.impventa = model.impcosto * (1 + model.porcontingencia / 100 ) * (1 + model.porgastosfijo / 100 + model.porganancia / 100) * (1 + model.porfeedireccion / 100 ) * (1 + model.porotrosgastos / 100) * (1 + model.porcostofinanciero / 100 ) * (1 + model.porimpuestoycomision / 100);
            limbo.impcontribucion = model.impcosto * (1 + model.porcontingencia / 100 ) * (1 + model.porgastosfijo / 100 + model.porganancia / 100 ) * (1 + model.porfeedireccion / 100) * (1 + model.porotrosgastos / 100) * (1 + model.porcostofinanciero / 100) * (1 + model.porimpuestoycomision / 100) * (model.porganancia / 100 + model.porgastosfijo / 100) * (1 + model.porcontingencia / 100) * model.impcosto / (model.impcosto * (1 + model.porcontingencia / 100) * (1 + model.porgastosfijo / 100 + model.porganancia / 100) * (1 + model.porfeedireccion / 100) * (1 + model.porotrosgastos / 100) * (1 + model.porcostofinanciero / 100) * (1 + model.porimpuestoycomision / 100));
            limbo.porcontribucion = model.impcosto != 0 ? (model.porganancia / 100 + model.porgastosfijo / 100) * (1 + model.porcontingencia / 100 ) * model.impcosto / (model.impcosto * (1 + model.porcontingencia / 100) * (1 + model.porgastosfijo / 100 + model.porganancia / 100) * (1 + model.porfeedireccion / 100 ) * (1 + model.porotrosgastos / 100) * (1 + model.porcostofinanciero / 100) * (1 + model.porimpuestoycomision / 100)) * 100 : 0;
            limbo.idtipoproy = model.idtipoproy;
            limbo.idestado = model.idestado;
            limbo.fecingreso = model.fecingreso;
            limbo.fecadjudicacion = model.fecadjudicacion;
            limbo.fecpitch = model.fecpitch;
            limbo.fecrodaje = model.fecrodaje;
            limbo.fecentrega = model.fecentrega;
            limbo.aprobacion = model.aprobacion;
            limbo.fecaprobacion = model.fecaprobacion;
            limbo.idresultado = model.idresultado;
            limbo.comentario = model.comentario;
            limbo.visitaforanea = model.visitaforanea;
            limbo.postinhouse = model.postinhouse;
            limbo.idposiciones = model.idposiciones;
            limbo.editinhouse = model.editinhouse;
            limbo.ars1usd = model.ars1usd;
            limbo.iduserumod = model.iduserumod;
            limbo.fecumod = fechaHora;

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

        // POST: api/Limbos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] LimboCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fechaHora = DateTime.Now;
            var initorden = Convert.ToInt32(_context.Gapconfigs
                .Where(p => p.parametro == "LIMBOLASTNUMBER")
                .Select(p => p.valor)
                .FirstOrDefault());
            var numorden = _context.Limbos.Max(x => (int?)x.orden) ?? 0;

            numorden = initorden > numorden ? initorden : numorden;
            Limbo limbo = new Limbo
            {
                orden = numorden + 1,
                proyecto = model.proyecto,
                idcliente = model.idcliente,
                idep = model.idep,
                idorigen = model.idorigen,
                idagencia = model.idagencia,
                idpitch = model.idpitch,
                iddirector = model.iddirector,
                idcodirector = model.idcodirector,
                idproductora = model.idproductora,
                idtipoprod = model.idtipoprod,
                impcosto = model.impcosto,
                porcontingencia = model.porcontingencia,
                porgastosfijo = model.porgastosfijo,
                porganancia = model.porganancia,
                porfeedireccion = model.porfeedireccion,
                porotrosgastos = model.porotrosgastos,
                porcostofinanciero = model.porcostofinanciero,
                porimpuestoycomision = model.porimpuestoycomision,
                impventa = model.impcosto * (1 + model.porcontingencia / 100) * (1 + model.porgastosfijo / 100 + model.porganancia / 100) * (1 + model.porfeedireccion / 100) * (1 + model.porotrosgastos / 100) * (1 + model.porcostofinanciero / 100) * (1 + model.porimpuestoycomision / 100),
                impcontribucion = model.impcosto * (1 + model.porcontingencia / 100) * (1 + model.porgastosfijo / 100 + model.porganancia / 100) * (1 + model.porfeedireccion / 100) * (1 + model.porotrosgastos / 100) * (1 + model.porcostofinanciero / 100) * (1 + model.porimpuestoycomision / 100) * (model.porganancia / 100 + model.porgastosfijo / 100) * (1 + model.porcontingencia / 100) * model.impcosto / (model.impcosto * (1 + model.porcontingencia / 100) * (1 + model.porgastosfijo / 100 + model.porganancia / 100) * (1 + model.porfeedireccion / 100) * (1 + model.porotrosgastos / 100) * (1 + model.porcostofinanciero / 100) * (1 + model.porimpuestoycomision / 100)),
                porcontribucion = model.impcosto != 0 ? (model.porganancia / 100 + model.porgastosfijo / 100) * (1 + model.porcontingencia / 100) * model.impcosto / (model.impcosto * (1 + model.porcontingencia / 100) * (1 + model.porgastosfijo / 100 + model.porganancia / 100) * (1 + model.porfeedireccion / 100) * (1 + model.porotrosgastos / 100) * (1 + model.porcostofinanciero / 100) * (1 + model.porimpuestoycomision / 100)) * 100 : 0,
                idtipoproy = model.idtipoproy,
                idestado = model.idestado,
                fecingreso = model.fecingreso,
                fecadjudicacion = model.fecadjudicacion,
                fecpitch = model.fecpitch,
                fecrodaje = model.fecrodaje,
                fecentrega = model.fecentrega,
                aprobacion = model.aprobacion,
                fecaprobacion = model.fecaprobacion,
                idresultado = model.idresultado,
                comentario = model.comentario,
                visitaforanea = model.visitaforanea,
                postinhouse = model.postinhouse,
                idposiciones = model.idposiciones,
                editinhouse = model.editinhouse,
                ars1usd = model.ars1usd,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Limbos.Add(limbo);
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

        // DELETE: api/Limbos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var limbo = await _context.Limbos.FindAsync(id);
            if (limbo == null)
            {
                return NotFound();
            }

            _context.Limbos.Remove(limbo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(limbo);
        }

        // PUT: api/Limbos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var limbo = await _context.Limbos.FirstOrDefaultAsync(c => c.idlimbo == id);

            if (limbo == null)
            {
                return NotFound();
            }

            limbo.activo = false;

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

        // PUT: api/Limbos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var limbo = await _context.Limbos.FirstOrDefaultAsync(c => c.idlimbo == id);

            if (limbo == null)
            {
                return NotFound();
            }

            limbo.activo = true;

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

        private bool LimboExists(int id)
        {
            return _context.Limbos.Any(e => e.idlimbo == id);
        }
    }
}
