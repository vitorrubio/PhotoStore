namespace PhotoStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fotoeprodutounidosnoitem : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ItemDoPedido", new[] { "Pedido_Id" });
            DropIndex("dbo.ItemDoPedido", new[] { "Produto_Id" });
            CreateTable(
                "dbo.ApplicationUserEvento",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Evento_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Evento_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Evento", t => t.Evento_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Evento_Id);
            
            AddColumn("dbo.Produto", "Nome", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Produto", "Descricao", c => c.String(maxLength: 1000));
            AddColumn("dbo.Produto", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TipoProduto", "PrecoSugerido", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ItemDoPedido", "Foto_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ItemDoPedido", "Pedido_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ItemDoPedido", "Produto_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Produto", "Nome", unique: true);
            CreateIndex("dbo.ItemDoPedido", "Foto_Id");
            CreateIndex("dbo.ItemDoPedido", "Pedido_Id");
            CreateIndex("dbo.ItemDoPedido", "Produto_Id");
            AddForeignKey("dbo.ItemDoPedido", "Foto_Id", "dbo.Foto", "Id");
            DropColumn("dbo.TipoProduto", "Preco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TipoProduto", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.ItemDoPedido", "Foto_Id", "dbo.Foto");
            DropForeignKey("dbo.ApplicationUserEvento", "Evento_Id", "dbo.Evento");
            DropForeignKey("dbo.ApplicationUserEvento", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserEvento", new[] { "Evento_Id" });
            DropIndex("dbo.ApplicationUserEvento", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ItemDoPedido", new[] { "Produto_Id" });
            DropIndex("dbo.ItemDoPedido", new[] { "Pedido_Id" });
            DropIndex("dbo.ItemDoPedido", new[] { "Foto_Id" });
            DropIndex("dbo.Produto", new[] { "Nome" });
            AlterColumn("dbo.ItemDoPedido", "Produto_Id", c => c.Int());
            AlterColumn("dbo.ItemDoPedido", "Pedido_Id", c => c.Int());
            DropColumn("dbo.ItemDoPedido", "Foto_Id");
            DropColumn("dbo.TipoProduto", "PrecoSugerido");
            DropColumn("dbo.Produto", "Preco");
            DropColumn("dbo.Produto", "Descricao");
            DropColumn("dbo.Produto", "Nome");
            DropTable("dbo.ApplicationUserEvento");
            CreateIndex("dbo.ItemDoPedido", "Produto_Id");
            CreateIndex("dbo.ItemDoPedido", "Pedido_Id");
        }
    }
}
