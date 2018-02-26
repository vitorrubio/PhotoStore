namespace PhotoStore.Infra.Migrations
{
    using PhotoStore.Infra.DbContext;
    using PhotoStore.Infra.Services;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = false;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            Console.WriteLine("Inicialização");
            IdentityAdminInitializer initializer = new IdentityAdminInitializer();

            //funcionou
            Task.Run(()=>initializer.Initialize());

            if(!context.TiposProdutos.Any(x => x.Nome == "Foto"))
            {
                context.TiposProdutos.Add(new Core.Model.TipoProduto
                {
                    Nome = "Foto",
                    PrecoSugerido = 14.90M,
                    Descricao = "A foto digital escolhida em alta resolução"
                });

                context.SaveChanges();             
            }



			if (!context.Produtos.Any(x => x.Nome == "Foto em alta resolução"))
			{
				var tipo = context.TiposProdutos.Where(x => x.Nome == "Foto").FirstOrDefault();
				context.Produtos.Add(new Core.Model.Produto
				{
					Nome = "Foto em alta resolução",
					Preco = 14.90M,
					Descricao = "A foto digital escolhida em alta resolução",
					Tipo = tipo
				});

				context.SaveChanges();
			}


			Console.WriteLine("Fim");

        }
    }
}
