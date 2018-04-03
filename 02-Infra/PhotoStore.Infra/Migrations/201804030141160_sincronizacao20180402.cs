namespace PhotoStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sincronizacao20180402 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Produto", new[] { "Tipo_Id" });
            RenameColumn(table: "dbo.Produto", name: "Tipo_Id", newName: "IdTipoProduto");
            AlterColumn("dbo.Produto", "IdTipoProduto", c => c.Int(nullable: false));
            CreateIndex("dbo.Produto", "IdTipoProduto");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Produto", new[] { "IdTipoProduto" });
            AlterColumn("dbo.Produto", "IdTipoProduto", c => c.Int());
            RenameColumn(table: "dbo.Produto", name: "IdTipoProduto", newName: "Tipo_Id");
            CreateIndex("dbo.Produto", "Tipo_Id");
        }
    }
}
