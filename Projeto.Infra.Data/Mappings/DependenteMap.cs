using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class DependenteMap : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            //chave primária
            builder.HasKey(d => new { d.IdDependente });

            //campos
            builder.Property(d => d.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.DataNascimento)
                .HasColumnType("date")
                .IsRequired();

            //chave estrangeira
            builder.HasOne(d => d.Funcionario)
                .WithMany(f => f.Dependentes)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
