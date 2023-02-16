using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces.Repositories;
using GestaoDeProdutos.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Infra.Data.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor, int>, IFornecedorRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public FornecedorRepository(SqlServerContext sqlServerContext)
            :base(sqlServerContext) 
        {
            _sqlServerContext = sqlServerContext;
        }    
    }
}
