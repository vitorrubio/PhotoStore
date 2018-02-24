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
            AutomaticMigrationsEnabled = false;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            Console.WriteLine("Inicialização");
            IdentityAdminInitializer initializer = new IdentityAdminInitializer();
            initializer.Initialize().Wait(10000);

            //funcionou
            //Task.Run(initializer.Initialize);
            //Task.Run(()=>initializer.Initialize());
            //Task.Run(async() => await initializer.Initialize());

            //não funcionou
            //var task = Task.Run(async () => await initializer.Initialize());
            //task.Wait();
            //var asyncFunctionResult = task.Status;


            if(!context.TiposProdutos.Any(x => x.Nome == "Foto em alta resolução"))
            {
                context.TiposProdutos.Add(new Core.Model.TipoProduto
                {
                    Nome = "Foto em alta resolução",
                    Preco = 14.90M,
                    Descricao = "A foto digital escolhida em alta resolução"
                });

                context.SaveChanges();             
            }


            Console.WriteLine("Fim");

        }
    }
}
