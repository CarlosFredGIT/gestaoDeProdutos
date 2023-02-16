using GestaoDeProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            #region Mapeamento

            builder.ToTable("Produto");

            builder.HasKey(p => p.Codigo);

            builder.Property(p => p.Codigo)
               .HasColumnName("Codigo")
               .UseIdentityColumn();

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500);

            builder.Property(p => p.Situacao)
                .HasColumnName("Situacao");

            builder.Property(p => p.DataFabricacao)
                .HasColumnName("DataFabricacao")
                .HasColumnType("date");

            builder.Property(p => p.DataValidacao)
                .HasColumnName("DataValidacao")
                .HasColumnType("date");

            #endregion
        }
    }
}
