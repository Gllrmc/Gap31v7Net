using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping.Daybyday;
using Sistema.Datos.Mapping.Fondos;
using Sistema.Datos.Mapping.Garantias;
using Sistema.Datos.Mapping.Gastos;
using Sistema.Datos.Mapping.Jerarquia;
using Sistema.Datos.Mapping.Limbos;
using Sistema.Datos.Mapping.Maestros;
using Sistema.Datos.Mapping.Motion;
using Sistema.Datos.Mapping.Pagos;
using Sistema.Datos.Mapping.Post;
using Sistema.Datos.Mapping.Proyectos;
using Sistema.Datos.Mapping.Usuarios;
using Sistema.Entidades.Daybyday;
using Sistema.Entidades.Fondos;
using Sistema.Entidades.Garantias;
using Sistema.Entidades.Gastos;
using Sistema.Entidades.Jerarquia;
using Sistema.Entidades.Limbos;
using Sistema.Entidades.Maestros;
using Sistema.Entidades.Motion;
using Sistema.Entidades.Pagos;
using Sistema.Entidades.Post;
using Sistema.Entidades.Proyectos;
using Sistema.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Subrubro> Subrubros { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Subitem> Subitems { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Usuarioproyecto> Usuarioproyectos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Territorio> Territorios { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Origen> Origenes { get; set; }
        public DbSet<Tipoprod> Tipoprods { get; set; }
        public DbSet<Tipoproy> Tipoproys { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Pitch> Pitchs { get; set; }
        public DbSet<Posicion> Posiciones { get; set; }
        public DbSet<Garantia> Garantias { get; set; }
        public DbSet<Productora> Productoras { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Flujocaja> Flujocajas { get; set; }
        public DbSet<Pedidofondo> Pedidosfondo { get; set; }
        public DbSet<Distribucionfondo> Distribucionfondos { get; set; }
        public DbSet<Rendicionfondo> Rendicionfondos { get; set; }
        public DbSet<Ordenpago> Ordenpagos { get; set; }
        public DbSet<Sqlordenpago> Sqlordenpagos { get; set; }
        public DbSet<Sqlpedidosfondo> Sqlpedidofondo { get; set; }
        public DbSet<Alternativapago> Alternativapagos { get; set; }
        public DbSet<Recursodxd> Recursodxds { get; set; }
        public DbSet<Realdxd> Realdxds { get; set; }
        public DbSet<Tarifadxd> Tarifadxds { get; set; }
        public DbSet<Sica> Sicas { get; set; }
        public DbSet<Proveedorpost> Proveedorposts { get; set; }
        public DbSet<Proveedormotion> Proveedormotions { get; set; }
        public DbSet<Realpost> Realposts { get; set; }
        public DbSet<Realmotion> Realmotions { get; set; }
        public DbSet<Gapconfig> Gapconfigs { get; set; }
        public DbSet<Proyectodate> Proyectodates { get; set; }
        public DbSet<Shoot2date> Shoot2dates { get; set; }
        public DbSet<Op2date> Op2dates { get; set; }
        public DbSet<Rendicion2date> Rendicion2dates { get; set; }
        public DbSet<Motion2date> Motion2dates { get; set; }
        public DbSet<Post2date> Post2dates { get; set; }
        public DbSet<Garantia2date> Garantia2dates { get; set; }
        public DbSet<Limbo> Limbos { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }
        public DbSet<Over> Overs { get; set; }
        public DbSet<Factu> Factus { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Forpago> Forpagos { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RubroMap());
            modelBuilder.ApplyConfiguration(new SubrubroMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            modelBuilder.ApplyConfiguration(new SubitemMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioproyectoMap());
            modelBuilder.ApplyConfiguration(new PersonaMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProveedorMap());
            modelBuilder.ApplyConfiguration(new CrewMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new ProvinciaMap());
            modelBuilder.ApplyConfiguration(new TerritorioMap());
            modelBuilder.ApplyConfiguration(new AgenciaMap());
            modelBuilder.ApplyConfiguration(new BancoMap());
            modelBuilder.ApplyConfiguration(new OrigenMap());
            modelBuilder.ApplyConfiguration(new TipoprodMap());
            modelBuilder.ApplyConfiguration(new TipoproyMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new ResultadoMap());
            modelBuilder.ApplyConfiguration(new PitchMap());
            modelBuilder.ApplyConfiguration(new PosicionMap());
            modelBuilder.ApplyConfiguration(new GarantiaMap());
            modelBuilder.ApplyConfiguration(new ProductoraMap());
            modelBuilder.ApplyConfiguration(new ProyectoMap());
            modelBuilder.ApplyConfiguration(new PresupuestoMap());
            modelBuilder.ApplyConfiguration(new FlujocajaMap());
            modelBuilder.ApplyConfiguration(new PedidofondoMap());
            modelBuilder.ApplyConfiguration(new DistribucionfondoMap());
            modelBuilder.ApplyConfiguration(new RendicionfondoMap());
            modelBuilder.ApplyConfiguration(new OrdenpagoMap());
            modelBuilder.ApplyConfiguration(new SqlordenpagoMap());
            modelBuilder.ApplyConfiguration(new SqlpedidofondoMap());
            modelBuilder.ApplyConfiguration(new AlternativapagoMap());
            modelBuilder.ApplyConfiguration(new RecursodxdMap());
            modelBuilder.ApplyConfiguration(new RealdxdMap());
            modelBuilder.ApplyConfiguration(new TarifadxdMap());
            modelBuilder.ApplyConfiguration(new SicaMap());
            modelBuilder.ApplyConfiguration(new ProveedorpostMap());
            modelBuilder.ApplyConfiguration(new ProveedormotionMap());
            modelBuilder.ApplyConfiguration(new RealpostMap());
            modelBuilder.ApplyConfiguration(new RealmotionMap());
            modelBuilder.ApplyConfiguration(new GapconfigMap());
            modelBuilder.ApplyConfiguration(new ProyectodateMap());
            modelBuilder.ApplyConfiguration(new Shoot2dateMap());
            modelBuilder.ApplyConfiguration(new Op2dateMap());
            modelBuilder.ApplyConfiguration(new Rendicion2dateMap());
            modelBuilder.ApplyConfiguration(new Motion2dateMap());
            modelBuilder.ApplyConfiguration(new Post2dateMap());
            modelBuilder.ApplyConfiguration(new Garantia2dateMap());
            modelBuilder.ApplyConfiguration(new LimboMap());
            modelBuilder.ApplyConfiguration(new ConceptoMap());
            modelBuilder.ApplyConfiguration(new OverMap());
            modelBuilder.ApplyConfiguration(new FactuMap());
            modelBuilder.ApplyConfiguration(new GastoMap());
            modelBuilder.ApplyConfiguration(new ForpagoMap());
        }

    }
}
