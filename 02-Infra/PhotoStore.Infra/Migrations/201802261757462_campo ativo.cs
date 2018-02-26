namespace PhotoStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoativo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foto", "Evento_Id", "dbo.Evento");
            AddColumn("dbo.ArquivoFoto", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Foto", "Vitrine", c => c.Boolean(nullable: false));
            AddColumn("dbo.Foto", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Foto", "Evento_Id", c => c.Int());
            AddColumn("dbo.Evento", "Vitrine", c => c.Boolean(nullable: false));
            AddColumn("dbo.Evento", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Evento", "Capa_Id", c => c.Int());
            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.TipoProduto", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.ItemDoPedido", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pedido", "Ativo", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Foto", "Evento_Id");
            CreateIndex("dbo.Evento", "Capa_Id");
            AddForeignKey("dbo.Evento", "Capa_Id", "dbo.Foto", "Id");
            AddForeignKey("dbo.Foto", "Evento_Id", "dbo.Evento", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foto", "Evento_Id", "dbo.Evento");
            DropForeignKey("dbo.Evento", "Capa_Id", "dbo.Foto");
            DropIndex("dbo.Evento", new[] { "Capa_Id" });
            DropIndex("dbo.Foto", new[] { "Evento_Id" });
            DropColumn("dbo.Pedido", "Ativo");
            DropColumn("dbo.ItemDoPedido", "Ativo");
            DropColumn("dbo.TipoProduto", "Ativo");
            DropColumn("dbo.Produto", "Ativo");
            DropColumn("dbo.Evento", "Capa_Id");
            DropColumn("dbo.Evento", "Ativo");
            DropColumn("dbo.Evento", "Vitrine");
            DropColumn("dbo.Foto", "Evento_Id");
            DropColumn("dbo.Foto", "Ativo");
            DropColumn("dbo.Foto", "Vitrine");
            DropColumn("dbo.ArquivoFoto", "Ativo");
            AddForeignKey("dbo.Foto", "Evento_Id", "dbo.Evento", "Id");
        }
    }
}
