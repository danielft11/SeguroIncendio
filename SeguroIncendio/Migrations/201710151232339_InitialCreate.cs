namespace SeguroIncendio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaImovel",
                c => new
                    {
                        CategoriaImovelId = c.Int(nullable: false, identity: true),
                        CategoriaDesc = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaImovelId);
            
            CreateTable(
                "dbo.TipoImovel",
                c => new
                    {
                        TipoImovelId = c.Int(nullable: false, identity: true),
                        TipoImovelDesc = c.String(),
                        TipoImovelTaxa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoriaImovelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoImovelId)
                .ForeignKey("dbo.CategoriaImovel", t => t.CategoriaImovelId, cascadeDelete: true)
                .Index(t => t.CategoriaImovelId);
            
            CreateTable(
                "dbo.Orcamento",
                c => new
                    {
                        OrcamentoId = c.Int(nullable: false, identity: true),
                        Inquilino = c.String(),
                        TipoInquilino = c.Int(nullable: false),
                        CpfCnpjInquilino = c.String(),
                        Proprietario = c.String(),
                        TipoProprietario = c.Int(nullable: false),
                        CpfCnpjProprietario = c.String(),
                        CEP = c.String(),
                        Endereco = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        ValorAluguel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImportCobertIncendio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PremioCobertIncendio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImportCobertPerda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PremioCobertPerda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdentificacaoCategoria = c.Int(nullable: false),
                        TipoImovelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrcamentoId)
                .ForeignKey("dbo.TipoImovel", t => t.TipoImovelId, cascadeDelete: true)
                .Index(t => t.TipoImovelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orcamento", "TipoImovelId", "dbo.TipoImovel");
            DropForeignKey("dbo.TipoImovel", "CategoriaImovelId", "dbo.CategoriaImovel");
            DropIndex("dbo.Orcamento", new[] { "TipoImovelId" });
            DropIndex("dbo.TipoImovel", new[] { "CategoriaImovelId" });
            DropTable("dbo.Orcamento");
            DropTable("dbo.TipoImovel");
            DropTable("dbo.CategoriaImovel");
        }
    }
}
