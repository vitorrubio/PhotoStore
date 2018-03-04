namespace PhotoStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusPedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produto", "Foto_Id", "dbo.Foto");
            DropIndex("dbo.Produto", new[] { "Foto_Id" });
            AddColumn("dbo.Pedido", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Pedido", "ValidoAte", c => c.DateTime());
            DropColumn("dbo.Produto", "Foto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Foto_Id", c => c.Int());
            DropColumn("dbo.Pedido", "ValidoAte");
            DropColumn("dbo.Pedido", "Status");
            CreateIndex("dbo.Produto", "Foto_Id");
            AddForeignKey("dbo.Produto", "Foto_Id", "dbo.Foto", "Id");
        }
    }
}
