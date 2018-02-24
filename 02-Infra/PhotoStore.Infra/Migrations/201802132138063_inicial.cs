namespace PhotoStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArquivoFoto",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Bytes = c.Binary(),
                        UsuarioInclusao = c.String(),
                        MomentoInclusao = c.DateTime(),
                        UsuarioEdicao = c.String(),
                        MomentoEdicao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foto", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Foto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeArquivo = c.String(),
                        MD5 = c.String(),
                        Nome = c.String(),
                        Numero = c.String(),
                        UsuarioInclusao = c.String(),
                        MomentoInclusao = c.DateTime(),
                        UsuarioEdicao = c.String(),
                        MomentoEdicao = c.DateTime(),
                        Evento_Id = c.Int(),
                        Fotografo_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evento", t => t.Evento_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Fotografo_Id)
                .Index(t => t.Evento_Id)
                .Index(t => t.Fotografo_Id);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Descricao = c.String(maxLength: 2000),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(),
                        UsuarioInclusao = c.String(),
                        MomentoInclusao = c.DateTime(),
                        UsuarioEdicao = c.String(),
                        MomentoEdicao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CPF = c.String(maxLength: 11),
                        Nome = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CPF, unique: true, name: "ix_ApplicationUser_CPF")
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioInclusao = c.String(),
                        MomentoInclusao = c.DateTime(),
                        UsuarioEdicao = c.String(),
                        MomentoEdicao = c.DateTime(),
                        Foto_Id = c.Int(),
                        Tipo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foto", t => t.Foto_Id)
                .ForeignKey("dbo.TipoProduto", t => t.Tipo_Id)
                .Index(t => t.Foto_Id)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.TipoProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        Descricao = c.String(nullable: false, maxLength: 2000),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UsuarioInclusao = c.String(),
                        MomentoInclusao = c.DateTime(),
                        UsuarioEdicao = c.String(),
                        MomentoEdicao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true);
            
            CreateTable(
                "dbo.ItemDoPedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UsuarioInclusao = c.String(),
                        MomentoInclusao = c.DateTime(),
                        UsuarioEdicao = c.String(),
                        MomentoEdicao = c.DateTime(),
                        Pedido_Id = c.Int(),
                        Produto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .Index(t => t.Pedido_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        DataPedido = c.DateTime(nullable: false),
                        UsuarioInclusao = c.String(),
                        MomentoInclusao = c.DateTime(),
                        UsuarioEdicao = c.String(),
                        MomentoEdicao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ItemDoPedido", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.ItemDoPedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.ArquivoFoto", "Id", "dbo.Foto");
            DropForeignKey("dbo.Produto", "Tipo_Id", "dbo.TipoProduto");
            DropForeignKey("dbo.Produto", "Foto_Id", "dbo.Foto");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Foto", "Fotografo_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Foto", "Evento_Id", "dbo.Evento");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ItemDoPedido", new[] { "Produto_Id" });
            DropIndex("dbo.ItemDoPedido", new[] { "Pedido_Id" });
            DropIndex("dbo.TipoProduto", new[] { "Nome" });
            DropIndex("dbo.Produto", new[] { "Tipo_Id" });
            DropIndex("dbo.Produto", new[] { "Foto_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", "ix_ApplicationUser_CPF");
            DropIndex("dbo.Evento", new[] { "Nome" });
            DropIndex("dbo.Foto", new[] { "Fotografo_Id" });
            DropIndex("dbo.Foto", new[] { "Evento_Id" });
            DropIndex("dbo.ArquivoFoto", new[] { "Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pedido");
            DropTable("dbo.ItemDoPedido");
            DropTable("dbo.TipoProduto");
            DropTable("dbo.Produto");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Evento");
            DropTable("dbo.Foto");
            DropTable("dbo.ArquivoFoto");
        }
    }
}
