using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Mappings;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Context
{
    //REGRA 1) Herdar DbContext
    public class DataContext : DbContext
    {
        //REGRA 2) Sobrescrevendo o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar as classes de mapeamento
            modelBuilder.ApplyConfiguration(new DependenteMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
        }

        //REGRA 3) Declarar uma propriedade DbSet para cada entidade
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
