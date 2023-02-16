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
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            #region Mapeamento
            
            builder.ToTable("Fornecedor");

            builder.HasKey(f => f.Codigo);

            builder.Property(f => f.Codigo)
               .HasColumnName("Codigo")
               .UseIdentityColumn();

            builder.Property(f => f.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500);

            builder.Property(f => f.Cnpj)
                .HasColumnName("Cnpj")
                .HasMaxLength(15);
            
            #endregion

        }
    }
}
