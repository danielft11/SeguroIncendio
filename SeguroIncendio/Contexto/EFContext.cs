using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeguroIncendio.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SeguroIncendio.Migrations;

namespace SeguroIncendio.Contexto
{
    public class EFContext : DbContext
    {
        public EFContext() : base("SeguroIncendio1_CS")
        {
            //Construtor antes de habilitar o Migrations.
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFContext>());

            //Construtor ao habilitar o Migrations.
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        //Serve para remover pluralização das tabelas criadas no banco de dados. Ver página 118 do livro.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Aumentar precisão de um campo de uma tabela: https://social.msdn.microsoft.com/Forums/pt-BR/977a00a8-abf9-44d2-b469-009b74b1519b/especificar-como-annotation-uma-escala-decimal-como-um-atributo?forum=mvcpt
            //No caso está sendo aumentada a precisão de casas decimais do campo "TipoImovelTaxa".
            modelBuilder.Entity<TipoImovel>().Property(TiposImovel => TiposImovel.TipoImovelTaxa).HasPrecision(18, 9);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<CategoriaImovel> CategoriasImovel { get; set; }
        public DbSet<TipoImovel> TiposImovel { get; set; }
    }
}