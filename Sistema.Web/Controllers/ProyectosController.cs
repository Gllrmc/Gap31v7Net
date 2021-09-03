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
using Sistema.Web.Models.Garantias;
using Sistema.Web.Models.Proyectos;

namespace Sistema.Web.Controllers
{
    [Authorize(Roles = "Administrador,JefeAdministracion,AsistAdministracion,ExecutiveProducer,AsistProduccion,LineProducer,ChiefProducer,AsistGeneral")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ProyectosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Proyectos/Listarusuario/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProyectoViewModel>> Listarusuario([FromRoute] int id)
        {
            var proyecto = await _context.Usuarioproyectos
                .Where(p => p.idusuario == id)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include (p => p.proyecto)
                .ThenInclude(p => p.productoras)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.empresas)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.agencias)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.cliente)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.director)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.codirector)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.ep)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.lp)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.cp)
                .Where(p => p.proyecto.cierreadmin == false)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();


            return proyecto.Select(a => new ProyectoViewModel
            {
                idproyecto = a.idproyecto,
                idraiz = a.proyecto.idraiz,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idtipoprod = a.proyecto.tipoprod.idtipoprod,
                tipoprod = a.proyecto.tipoprod.tipoprod,
                idempresa = a.proyecto.idempresa,
                empresa = a.proyecto.idempresa.HasValue ? a.proyecto.empresas.empresa : "",
                idorigen = a.proyecto.idorigen,
                origen = a.proyecto.origenes.origen,
                idterritorio = a.proyecto.origenes.idterritorio,
                territorio = a.proyecto.origenes.territorio.territorio,
                idagencia = a.proyecto.idagencia,
                agencia = a.proyecto.idagencia.HasValue ? a.proyecto.agencias.agencia : "",
                idproductora = a.proyecto.idproductora,
                productora = a.proyecto.idproductora.HasValue ? a.proyecto.productoras.productora : "",
                idcliente = a.proyecto.idcliente,
                cliente = a.proyecto.cliente.razonsocial,
                iddirector = a.proyecto.iddirector,
                director = a.proyecto.director.nombre,
                idcodirector = a.proyecto.idcodirector,
                codirector = a.proyecto.idcodirector.HasValue ? a.proyecto.codirector.nombre : "",
                idep = a.proyecto.idep,
                ep = a.proyecto.ep.nombre,
                idlp = a.proyecto.idlp,
                lp = a.proyecto.idlp.HasValue ? a.proyecto.lp.nombre : "",
                idcp = a.proyecto.idcp,
                cp = a.proyecto.idcp.HasValue ? a.proyecto.cp.nombre : "",
                ars1usd = a.proyecto.ars1usd,
                fecadjudicacion = a.proyecto.fecadjudicacion,
                fecdesdxd = a.proyecto.fecdesdxd,
                fechasdxd = a.proyecto.fechasdxd,
                fecdescf = a.proyecto.fecdescf,
                fechascf = a.proyecto.fechascf,
                fecrodaje = a.proyecto.fecrodaje,
                fecoffline = a.proyecto.fecoffline,
                feconline = a.proyecto.feconline,
                cierreprod = a.proyecto.cierreprod,
                feccierreprod = a.proyecto.feccierreprod,
                cierreadmin = a.proyecto.cierreadmin,
                feccierreadmin = a.proyecto.feccierreadmin,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Proyectos/Listaractivosusuario/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProyectoViewModel>> Listaractivosusuario([FromRoute] int id)
        {
            var proyecto = await _context.Usuarioproyectos
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.productoras)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.empresas)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.agencias)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.cliente)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.director)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.codirector)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.ep)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.lp)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.cp)
                .Where(p => p.proyecto.cierreadmin == false && p.proyecto.activo == true && p.activo == true && p.idusuario == id)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();


            return proyecto.Select(a => new ProyectoViewModel
            {
                idproyecto = a.idproyecto,
                idraiz = a.proyecto.idraiz,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idtipoprod = a.proyecto.tipoprod.idtipoprod,
                tipoprod = a.proyecto.tipoprod.tipoprod,
                idempresa = a.proyecto.idempresa,
                empresa = a.proyecto.idempresa.HasValue ? a.proyecto.empresas.empresa : "",
                idorigen = a.proyecto.idorigen,
                origen = a.proyecto.origenes.origen,
                idterritorio = a.proyecto.origenes.idterritorio,
                territorio = a.proyecto.origenes.territorio.territorio,
                idagencia = a.proyecto.idagencia,
                agencia = a.proyecto.idagencia.HasValue ? a.proyecto.agencias.agencia : "",
                idproductora = a.proyecto.idproductora,
                productora = a.proyecto.idproductora.HasValue ? a.proyecto.productoras.productora : "",
                idcliente = a.proyecto.idcliente,
                cliente = a.proyecto.idcliente.HasValue ? a.proyecto.cliente.razonsocial : "",
                iddirector = a.proyecto.iddirector,
                director = a.proyecto.director.nombre,
                idcodirector = a.proyecto.idcodirector,
                codirector = a.proyecto.idcodirector.HasValue ? a.proyecto.codirector.nombre : "",
                idep = a.proyecto.idep,
                ep = a.proyecto.ep.nombre,
                idlp = a.proyecto.idlp,
                lp = a.proyecto.idlp.HasValue ? a.proyecto.lp.nombre : "",
                idcp = a.proyecto.idcp,
                cp = a.proyecto.idcp.HasValue ? a.proyecto.cp.nombre : "",
                ars1usd = a.proyecto.ars1usd,
                fecadjudicacion = a.proyecto.fecadjudicacion,
                fecdesdxd = a.proyecto.fecdesdxd,
                fechasdxd = a.proyecto.fechasdxd,
                fecdescf = a.proyecto.fecdescf,
                fechascf = a.proyecto.fechascf,
                fecrodaje = a.proyecto.fecrodaje,
                fecoffline = a.proyecto.fecoffline,
                feconline = a.proyecto.feconline,
                cierreprod = a.proyecto.cierreprod,
                feccierreprod = a.proyecto.feccierreprod,
                cierreadmin = a.proyecto.cierreadmin,
                feccierreadmin = a.proyecto.feccierreadmin,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Proyectos/Listaractivosusuariovivo/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProyectoViewModel>> Listaractivosusuariovivo([FromRoute] int id)
        {
            var proyecto = await _context.Usuarioproyectos
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.productoras)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.empresas)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.agencias)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.cliente)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.director)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.codirector)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.ep)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.lp)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.cp)
                .Where(p => p.activo == true && p.vivo == true && p.proyecto.cierreadmin == false && p.proyecto.activo == true && p.idusuario == id )
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();


            return proyecto.Select(a => new ProyectoViewModel
            {
                idproyecto = a.idproyecto,
                idraiz = a.proyecto.idraiz,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idtipoprod = a.proyecto.tipoprod.idtipoprod,
                tipoprod = a.proyecto.tipoprod.tipoprod,
                idempresa = a.proyecto.idempresa,
                empresa = a.proyecto.idempresa.HasValue ? a.proyecto.empresas.empresa : "",
                idorigen = a.proyecto.idorigen,
                origen = a.proyecto.origenes.origen,
                idterritorio = a.proyecto.origenes.idterritorio,
                territorio = a.proyecto.origenes.territorio.territorio,
                idagencia = a.proyecto.idagencia,
                agencia = a.proyecto.idagencia.HasValue ? a.proyecto.agencias.agencia : "",
                idproductora = a.proyecto.idproductora,
                productora = a.proyecto.idproductora.HasValue ? a.proyecto.productoras.productora : "",
                idcliente = a.proyecto.idcliente,
                cliente = a.proyecto.idcliente.HasValue ? a.proyecto.cliente.razonsocial : "",
                iddirector = a.proyecto.iddirector,
                director = a.proyecto.director.nombre,
                idcodirector = a.proyecto.idcodirector,
                codirector = a.proyecto.idcodirector.HasValue ? a.proyecto.codirector.nombre : "",
                idep = a.proyecto.idep,
                ep = a.proyecto.ep.nombre,
                idlp = a.proyecto.idlp,
                lp = a.proyecto.idlp.HasValue ? a.proyecto.lp.nombre : "",
                idcp = a.proyecto.idcp,
                cp = a.proyecto.idcp.HasValue ? a.proyecto.cp.nombre : "",
                ars1usd = a.proyecto.ars1usd,
                fecadjudicacion = a.proyecto.fecadjudicacion,
                fecdesdxd = a.proyecto.fecdesdxd,
                fechasdxd = a.proyecto.fechasdxd,
                fecdescf = a.proyecto.fecdescf,
                fechascf = a.proyecto.fechascf,
                fecrodaje = a.proyecto.fecrodaje,
                fecoffline = a.proyecto.fecoffline,
                feconline = a.proyecto.feconline,
                cierreprod = a.proyecto.cierreprod,
                feccierreprod = a.proyecto.feccierreprod,
                cierreadmin = a.proyecto.cierreadmin,
                feccierreadmin = a.proyecto.feccierreadmin,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }

        // GET: api/Proyectos/Listaractivosusuariopost/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProyectoViewModel>> Listaractivosusuariopost([FromRoute] int id)
        {
            var proyecto = await _context.Usuarioproyectos
                .Include(p => p.proyecto)
                .ThenInclude(p => p.tipoprod)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.productoras)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.empresas)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.agencias)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.cliente)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.director)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.codirector)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.ep)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.lp)
                .Include(p => p.proyecto)
                .ThenInclude(p => p.cp)
                .Where(p => p.post == true && p.proyecto.cierreadmin == false && p.proyecto.activo == true && p.activo == true && p.idusuario == id)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();


            return proyecto.Select(a => new ProyectoViewModel
            {
                idproyecto = a.idproyecto,
                idraiz = a.proyecto.idraiz,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto,
                idtipoprod = a.proyecto.tipoprod.idtipoprod,
                tipoprod = a.proyecto.tipoprod.tipoprod,
                idempresa = a.proyecto.idempresa,
                empresa = a.proyecto.idempresa.HasValue ? a.proyecto.empresas.empresa : "",
                idorigen = a.proyecto.idorigen,
                origen = a.proyecto.origenes.origen,
                idterritorio = a.proyecto.origenes.idterritorio,
                territorio = a.proyecto.origenes.territorio.territorio,
                idagencia = a.proyecto.idagencia,
                agencia = a.proyecto.idagencia.HasValue ? a.proyecto.agencias.agencia : "",
                idproductora = a.proyecto.idproductora,
                productora = a.proyecto.idproductora.HasValue ? a.proyecto.productoras.productora : "",
                idcliente = a.proyecto.idcliente,
                cliente = a.proyecto.idcliente.HasValue ? a.proyecto.cliente.razonsocial : "",
                iddirector = a.proyecto.iddirector,
                director = a.proyecto.director.nombre,
                idcodirector = a.proyecto.idcodirector,
                codirector = a.proyecto.idcodirector.HasValue ? a.proyecto.codirector.nombre : "",
                idep = a.proyecto.idep,
                ep = a.proyecto.ep.nombre,
                idlp = a.proyecto.idlp,
                lp = a.proyecto.idlp.HasValue ? a.proyecto.lp.nombre : "",
                idcp = a.proyecto.idcp,
                cp = a.proyecto.idcp.HasValue ? a.proyecto.cp.nombre : "",
                ars1usd = a.proyecto.ars1usd,
                fecadjudicacion = a.proyecto.fecadjudicacion,
                fecdesdxd = a.proyecto.fecdesdxd,
                fechasdxd = a.proyecto.fechasdxd,
                fecdescf = a.proyecto.fecdescf,
                fechascf = a.proyecto.fechascf,
                fecrodaje = a.proyecto.fecrodaje,
                fecoffline = a.proyecto.fecoffline,
                feconline = a.proyecto.feconline,
                cierreprod = a.proyecto.cierreprod,
                feccierreprod = a.proyecto.feccierreprod,
                cierreadmin = a.proyecto.cierreadmin,
                feccierreadmin = a.proyecto.feccierreadmin,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });
        }


        // GET: api/Proyectos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProyectoViewModel>> Listar()
        {
            var proyecto = await _context.Proyectos
                .Include(p => p.tipoprod)
                .Include(p => p.productoras)
                .Include(p => p.empresas)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.cliente)
                .Include(p => p.director)
                .Include(p => p.codirector)
                .Include(p => p.ep)
                .Include(p => p.lp)
                .Include(p => p.cp)
                .Where(p => p.cierreadmin == false)
                //.Include(p => p.padre)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();

            return proyecto.Select(a => new ProyectoViewModel
            {
                idproyecto = a.idproyecto,
                idraiz = a.idraiz,
                orden = a.orden,
                proyecto = a.proyecto,
                idtipoprod = a.tipoprod.idtipoprod,
                tipoprod = a.tipoprod.tipoprod,
                idempresa = a.idempresa,
                empresa = a.idempresa.HasValue ? a.empresas.empresa : "",
                idorigen = a.idorigen,
                origen = a.origenes.origen,
                idterritorio = a.origenes.idterritorio,
                territorio = a.origenes.territorio.territorio,
                idagencia = a.idagencia,
                agencia = a.idagencia.HasValue ? a.agencias.agencia : "",
                idproductora = a.idproductora,
                productora = a.idproductora.HasValue ? a.productoras.productora : "",
                idcliente = a.idcliente,
                cliente = a.idcliente.HasValue ? a.cliente.razonsocial : "",
                iddirector = a.iddirector,
                director = a.director.nombre,
                idcodirector = a.idcodirector,
                codirector = a.idcodirector.HasValue ? a.codirector.nombre : "",
                idep = a.idep,
                ep = a.ep.nombre,
                idlp = a.idlp,
                lp = a.idlp.HasValue ? a.lp.nombre:"",
                idcp = a.idcp,
                cp = a.idcp.HasValue ? a.cp.nombre:"",
                ars1usd = a.ars1usd,
                fecadjudicacion = a.fecadjudicacion,
                fecdesdxd = a.fecdesdxd,
                fechasdxd = a.fechasdxd,
                fecdescf = a.fecdescf,
                fechascf = a.fechascf,
                fecrodaje = a.fecrodaje,
                fecoffline = a.fecoffline,
                feconline = a.feconline,
                cierreprod = a.cierreprod,
                feccierreprod = a.feccierreprod,
                cierreadmin = a.cierreadmin,
                feccierreadmin = a.feccierreadmin,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Proyectos/ListarHistorico
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProyectoViewModel>> ListarHistorico()
        {
            var proyecto = await _context.Proyectos
                .Include(p => p.tipoprod)
                .Include(p => p.productoras)
                .Include(p => p.empresas)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.cliente)
                .Include(p => p.director)
                .Include(p => p.codirector)
                .Include(p => p.ep)
                .Include(p => p.lp)
                .Include(p => p.cp)
                .Where(p => p.cierreadmin == true)
                //.Include(p => p.padre)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();

            return proyecto.Select(a => new ProyectoViewModel
            {
                idproyecto = a.idproyecto,
                idraiz = a.idraiz,
                orden = a.orden,
                proyecto = a.proyecto,
                idtipoprod = a.tipoprod.idtipoprod,
                tipoprod = a.tipoprod.tipoprod,
                idempresa = a.idempresa,
                empresa = a.idempresa.HasValue ? a.empresas.empresa : "",
                idorigen = a.idorigen,
                origen = a.origenes.origen,
                idterritorio = a.origenes.idterritorio,
                territorio = a.origenes.territorio.territorio,
                idagencia = a.idagencia,
                agencia = a.agencias.agencia,
                idproductora = a.idproductora,
                productora = a.productoras.productora,
                idcliente = a.idcliente,
                cliente = a.cliente.razonsocial,
                iddirector = a.iddirector,
                director = a.director.nombre,
                idcodirector = a.idcodirector,
                codirector = a.idcodirector.HasValue ? a.codirector.nombre : "",
                idep = a.idep,
                ep = a.ep.nombre,
                idlp = a.idlp,
                lp = a.idlp.HasValue ? a.lp.nombre : "",
                idcp = a.idcp,
                cp = a.idcp.HasValue ? a.cp.nombre : "",
                ars1usd = a.ars1usd,
                fecadjudicacion = a.fecadjudicacion,
                fecdesdxd = a.fecdesdxd,
                fechasdxd = a.fechasdxd,
                fecdescf = a.fecdescf,
                fechascf = a.fechascf,
                fecrodaje = a.fecrodaje,
                fecoffline = a.fecoffline,
                feconline = a.feconline,
                cierreprod = a.cierreprod,
                feccierreprod = a.feccierreprod,
                cierreadmin = a.cierreadmin,
                feccierreadmin = a.feccierreadmin,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }


        // GET: api/Proyectos/ListarActivos
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProyectoViewModel>> ListarActivos()
        {
            var proyecto = await _context.Proyectos
                .Include(p => p.tipoprod)
                .Include(p => p.productoras)
                .Include(p => p.empresas)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.cliente)
                .Include(p => p.director)
                .Include(p => p.codirector)
                .Include(p => p.ep)
                .Include(p => p.lp)
                .Include(p => p.cp)
                .Where(p => p.activo == true && p.cierreadmin == false)
                //.Include(p => p.padre)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();

            return proyecto.Select(a => new ProyectoViewModel
            {
                idproyecto = a.idproyecto,
                idraiz = a.idraiz,
                orden = a.orden,
                proyecto = a.proyecto,
                idtipoprod = a.tipoprod.idtipoprod,
                tipoprod = a.tipoprod.tipoprod,
                idempresa = a.idempresa,
                empresa = a.idempresa.HasValue ? a.empresas.empresa : "",
                idorigen = a.idorigen,
                origen = a.origenes.origen,
                idterritorio = a.origenes.idterritorio,
                territorio = a.origenes.territorio.territorio,
                idagencia = a.idagencia,
                agencia = a.idagencia.HasValue ? a.agencias.agencia : "",
                idproductora = a.idproductora,
                productora = a.idproductora.HasValue ? a.productoras.productora : "",
                idcliente = a.idcliente,
                cliente = a.idcliente.HasValue ? a.cliente.razonsocial : "",
                iddirector = a.iddirector,
                director = a.director.nombre,
                idcodirector = a.idcodirector,
                codirector = a.idcodirector.HasValue ? a.codirector.nombre : "",
                idep = a.idep,
                ep = a.ep.nombre,
                idlp = a.idlp,
                lp = a.idlp.HasValue ? a.lp.nombre : "",
                idcp = a.idcp,
                cp = a.idcp.HasValue ? a.cp.nombre : "",
                ars1usd = a.ars1usd,
                fecadjudicacion = a.fecadjudicacion,
                fecdesdxd = a.fecdesdxd,
                fechasdxd = a.fechasdxd,
                fecdescf = a.fecdescf,
                fechascf = a.fechascf,
                fecrodaje = a.fecrodaje,
                fecoffline = a.fecoffline,
                feconline = a.feconline,
                cierreprod = a.cierreprod,
                feccierreprod = a.feccierreprod,
                cierreadmin = a.cierreadmin,
                feccierreadmin = a.feccierreadmin,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Proyectos/ListarFiltro/Text
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<ProyectoViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var proyecto = await _context.Proyectos
                .Where(p => p.proyecto.Contains(texto))
                .Include(p => p.tipoprod)
                .Include(p => p.productoras)
                .Include(p => p.empresas)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.cliente)
                .Include(p => p.director)
                .Include(p => p.codirector)
                .Include(p => p.ep)
                .Include(p => p.lp)
                .Include(p => p.cp)
                .Where(p => p.activo == true && p.cierreadmin == false)
                //.Include(p => p.padre)
                .OrderBy(p => p.idproyecto)
                .AsNoTracking()
                .ToListAsync();

            return proyecto.Select(a => new ProyectoViewModel
            {
                idproyecto = a.idproyecto,
                idraiz = a.idraiz,
                orden = a.orden,
                proyecto = a.proyecto,
                idtipoprod = a.tipoprod.idtipoprod,
                tipoprod = a.tipoprod.tipoprod,
                idempresa = a.idempresa,
                empresa = a.idempresa.HasValue ? a.empresas.empresa : "",
                idorigen = a.idorigen,
                origen = a.origenes.origen,
                idterritorio = a.origenes.idterritorio,
                territorio = a.origenes.territorio.territorio,
                idagencia = a.idagencia,
                agencia = a.idagencia.HasValue ? a.agencias.agencia : "",
                idproductora = a.idproductora,
                productora = a.idproductora.HasValue ? a.productoras.productora : "",
                idcliente = a.idcliente,
                cliente = a.idcliente.HasValue ? a.cliente.razonsocial : "",
                iddirector = a.iddirector,
                director = a.director.nombre,
                idcodirector = a.idcodirector,
                codirector = a.idcodirector.HasValue ? a.codirector.nombre : "",
                idep = a.idep,
                ep = a.ep.nombre,
                idlp = a.idlp,
                lp = a.idlp.HasValue ? a.lp.nombre : "",
                idcp = a.idcp,
                cp = a.idcp.HasValue ? a.cp.nombre : "",
                ars1usd = a.ars1usd,
                fecadjudicacion = a.fecadjudicacion,
                fecdesdxd = a.fecdesdxd,
                fechasdxd = a.fechasdxd,
                fecdescf = a.fecdescf,
                fechascf = a.fechascf,
                fecrodaje = a.fecrodaje,
                fecoffline = a.fecoffline,
                feconline = a.feconline,
                cierreprod = a.cierreprod,
                feccierreprod = a.feccierreprod,
                cierreadmin = a.cierreadmin,
                feccierreadmin = a.feccierreadmin,
                iduseralta = a.iduseralta,
                fecalta = a.fecalta,
                iduserumod = a.iduserumod,
                fecumod = a.fecumod,
                activo = a.activo
            });

        }

        // GET: api/Proyectos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProyectoSelectModel>> Select()

        {
            var proyecto = await _context.Proyectos
                .Where(a => a.activo == true && a.cierreadmin == false)
                .OrderBy(a => a.orden)
                .ToListAsync();

            return proyecto.Select(a => new ProyectoSelectModel
            {
                idproyecto = a.idproyecto,
                orden = a.orden,
                proyecto = a.proyecto
            });

        }

        // GET: api/Proyectos/SelectDeUsuario/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProyectoSelectModel>> SelectDeUsuario([FromRoute] int id)

        {
            var proyecto = await _context.Usuarioproyectos
                .Where(p => p.idusuario == id)
                .Include(p => p.proyecto)
                .Where(a => a.proyecto.activo == true && a.proyecto.cierreadmin == false)
                .OrderBy(a => a.proyecto.orden)
                .ToListAsync();

            return proyecto.Select(a => new ProyectoSelectModel
            {
                idproyecto = a.proyecto.idproyecto,
                orden = a.proyecto.orden,
                proyecto = a.proyecto.proyecto
            });

        }

        // GET: api/Proyectos/SelectProyectosDeCliente/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProyectoSelectModel>> SelectProyectosDeCliente([FromRoute] int id)

        {
            var proyecto = await _context.Proyectos
                .Where(a => a.idcliente == id)
                .OrderBy(a => a.orden)
                .ToListAsync();

            return proyecto.Select(a => new ProyectoSelectModel
            {
                idproyecto = a.idproyecto,
                orden = a.orden,
                proyecto = a.proyecto
            });
        }


        // GET: api/Proyectos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var proyecto = await _context.Proyectos
                .Include(p => p.tipoprod)
                .Include(p => p.productoras)
                .Include(p => p.empresas)
                .Include(p => p.origenes)
                .ThenInclude(p => p.territorio)
                .Include(p => p.agencias)
                .Include(p => p.cliente)
                .Include(p => p.director)
                .Include(p => p.codirector)
                .Include(p => p.ep)
                .Include(p => p.lp)
                .Include(p => p.cp)
                .Where(p => p.activo == true && p.cierreadmin == false)
                //.Include(p => p.padre)
                .OrderBy(p => p.idproyecto)
                .SingleOrDefaultAsync(a => a.idproyecto == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return Ok(new ProyectoViewModel
            {
                idproyecto = proyecto.idproyecto,
                orden = proyecto.orden,
                idraiz = proyecto.idraiz,
                proyecto = proyecto.proyecto,
                idtipoprod = proyecto.tipoprod.idtipoprod,
                tipoprod = proyecto.tipoprod.tipoprod,
                idempresa = proyecto.idempresa,
                empresa = proyecto.idempresa.HasValue ? proyecto.empresas.empresa : "",
                idterritorio = proyecto.origenes.idterritorio,
                territorio = proyecto.origenes.territorio.territorio,
                idagencia = proyecto.idagencia,
                agencia = proyecto.idagencia.HasValue ? proyecto.agencias.agencia : "",
                idproductora = proyecto.idproductora,
                productora = proyecto.idproductora.HasValue ? proyecto.productoras.productora : "",
                idcliente = proyecto.idcliente,
                cliente = proyecto.idcliente.HasValue ? proyecto.cliente.razonsocial : "",
                iddirector = proyecto.iddirector,
                director = proyecto.director.nombre,
                idcodirector = proyecto.idcodirector,
                codirector = proyecto.idcodirector.HasValue ? proyecto.codirector.nombre : "",
                idep = proyecto.idep,
                ep = proyecto.ep.nombre,
                idlp = proyecto.idlp,
                lp = proyecto.idlp.HasValue ? proyecto.lp.nombre : "",
                idcp = proyecto.idcp,
                cp = proyecto.idcp.HasValue ? proyecto.cp.nombre : "",
                ars1usd = proyecto.ars1usd,
                fecadjudicacion = proyecto.fecadjudicacion,
                fecdesdxd = proyecto.fecdesdxd,
                fechasdxd = proyecto.fechasdxd,
                fecdescf = proyecto.fecdescf,
                fechascf = proyecto.fechascf,
                fecrodaje = proyecto.fecrodaje,
                fecoffline = proyecto.fecoffline,
                feconline = proyecto.feconline,
                cierreprod = proyecto.cierreprod,
                feccierreprod = proyecto.feccierreprod,
                cierreadmin = proyecto.cierreadmin,
                feccierreadmin = proyecto.feccierreadmin,
                iduseralta = proyecto.iduseralta,
                fecalta = proyecto.fecalta,
                iduserumod = proyecto.iduserumod,
                fecumod = proyecto.fecumod,
                activo = proyecto.activo
            });
        }

        // PUT: api/Proyectos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProyectoUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idproyecto <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(a => a.idproyecto == model.idproyecto);

            if (proyecto == null)
            {
                return NotFound();
            }
            proyecto.idproyecto = model.idproyecto;
            proyecto.orden = model.orden;
            proyecto.idraiz = model.idraiz;
            proyecto.proyecto = model.proyecto;
            proyecto.idtipoprod = model.idtipoprod;
            proyecto.idempresa = model.idempresa;
            proyecto.idorigen = model.idorigen;
            proyecto.idagencia = model.idagencia;
            proyecto.idproductora = model.idproductora;
            proyecto.idcliente = model.idcliente;
            proyecto.iddirector = model.iddirector;
            proyecto.idcodirector = model.idcodirector;
            proyecto.idep = model.idep;
            proyecto.idlp = model.idlp;
            proyecto.idcp = model.idcp;
            proyecto.ars1usd = model.ars1usd;
            proyecto.fecadjudicacion = model.fecadjudicacion;
            proyecto.fecdesdxd = model.fecdesdxd;
            proyecto.fechasdxd = model.fechasdxd;
            proyecto.fecdescf = model.fecdescf;
            proyecto.fechascf = model.fechascf;
            proyecto.fecrodaje = model.fecrodaje;
            proyecto.fecoffline = model.fecoffline;
            proyecto.feconline = model.feconline;
            proyecto.cierreprod = model.cierreprod;
            proyecto.feccierreprod = model.feccierreprod;
            proyecto.cierreadmin = model.cierreadmin;
            proyecto.feccierreadmin = model.feccierreadmin;
            proyecto.iduserumod = model.iduserumod;
            proyecto.fecumod = fechaHora;
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

        // POST: api/Proyectos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ProyectoCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fechaHora = DateTime.Now;
            Proyecto proyecto = new Proyecto
            {
                idraiz = model.idraiz,
                orden = model.orden,
                proyecto = model.proyecto,
                idtipoprod = model.idtipoprod,
                idempresa = model.idempresa,
                idorigen = model.idorigen,
                idagencia = model.idagencia,
                idproductora = model.idproductora,
                idcliente = model.idcliente,
                iddirector = model.iddirector,
                idcodirector = model.idcodirector,
                idep = model.idep,
                idlp = model.idlp,
                idcp = model.idcp,
                ars1usd = model.ars1usd,
                fecadjudicacion = model.fecadjudicacion,
                fecdesdxd = model.fecdesdxd,
                fechasdxd = model.fechasdxd,
                fecdescf = model.fecdescf,
                fechascf = model.fechascf,
                fecrodaje = model.fecrodaje,
                fecoffline = model.fecoffline,
                feconline = model.feconline,
                cierreprod = false,
                cierreadmin = false,
                iduseralta = model.iduseralta,
                fecalta = fechaHora,
                iduserumod = model.iduseralta,
                fecumod = fechaHora,
                activo = true
            };

            _context.Proyectos.Add(proyecto);
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

        // PUT: api/Proyectos/Cierreprod/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Cierreprod([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(a => a.idproyecto == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            proyecto.cierreprod = true;
            proyecto.feccierreprod = fechaHora;

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

        // PUT: api/Proyectos/Cierreadmin/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Cierreadmin([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var fechaHora = DateTime.Now;
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(a => a.idproyecto == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            if (proyecto.cierreprod == false)
            {
                return BadRequest();
            }

            proyecto.cierreadmin = true;
            proyecto.feccierreadmin = fechaHora;

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

        // PUT: api/Proyectos/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(a => a.idproyecto == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            proyecto.activo = false;

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

        // PUT: api/Proyectos/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(a => a.idproyecto == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            proyecto.activo = true;

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

        private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.idproyecto == id);
        }
    }
}
