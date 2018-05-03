using PhotoStore.Core.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PhotoStore.CrossCutting;

namespace PhotoStore.Infra.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


		/// <summary>
		/// traz um context especial sem lazy load, proxys ou validations para , em conjunto com noTracking, melhorar a performance das consultas
		/// </summary>
		/// <returns></returns>
		public  ApplicationDbContext CreateDetachedContext()
		{
			ApplicationDbContext db = new ApplicationDbContext();
			db.Configuration.AutoDetectChangesEnabled = false;
			db.Configuration.LazyLoadingEnabled = false;
			db.Configuration.ProxyCreationEnabled = false;
			db.Configuration.ValidateOnSaveEnabled = false;
			return db;
		}


		public DbSet<ArquivoFoto> ArquivosFotos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<ItemDoPedido> ItensDosPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TiposProdutos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove a pluralização (nomes das tabelas no singular)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //remove o manytomany cascade (para apagar um membro, tem que apagar todas as dependencias e ele mesmo ser removido de todas as listas)
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //remove convenção onetomany (só apaga um item se apagar todos os dependentes)
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }



        public override int SaveChanges()
        {
            try
            {
                AddTimestamps();
                return base.SaveChanges();
            }
            catch (Exception err)
            {
                LogServices.LogarException(err);
                throw;
            }
        }


        public override async Task<int> SaveChangesAsync()
        {
            try
            {
                AddTimestamps();
                return await base.SaveChangesAsync();
            }
            catch (Exception err)
            {
                LogServices.LogarException(err);
                throw;
            }
        }



        private void AddTimestamps()
        {

            try
            {

                var entries = ChangeTracker.Entries().Where(x => x.Entity is Entidade && (x.State == EntityState.Added || x.State == EntityState.Modified));

                var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
                    ? HttpContext.Current.User.Identity.Name
                    : "Anonymous";

                foreach (var entry in entries)
                {
                    if (entry.State == EntityState.Added)
                    {
                        ((Entidade)entry.Entity).MomentoInclusao = DateTime.Now;
                        ((Entidade)entry.Entity).UsuarioInclusao = currentUsername;
                    }

                    ((Entidade)entry.Entity).MomentoEdicao = DateTime.Now;
                    ((Entidade)entry.Entity).UsuarioEdicao = currentUsername;
                }

            }
            catch (Exception auditEx)
            {
                LogServices.LogarException(auditEx);
            }

        }


    }
}
