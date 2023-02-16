using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Infra.Data.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        //Metodo que adiciona cada classe de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new FornecedorMap());

            modelBuilder.Entity<Produto>()
                .Property(p => p.Codigo)
                .ValueGeneratedOnAdd();
        }

        //Propriedade que fornece os metodos que serão utilizados no repositorio.
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
