using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Projeto.Domain.Entities;

namespace Projeto.Infra.Data.Repositories
{
    public class FuncionarioRepository
        : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        //atributo
        private readonly DataContext dataContext;

        public FuncionarioRepository(DataContext dataContext)
            : base(dataContext) //construtor da superclasse
        {
            this.dataContext = dataContext;
        }
    }
}
