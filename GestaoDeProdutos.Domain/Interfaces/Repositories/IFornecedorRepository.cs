using GestaoDeProdutos.Domain.Core;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces.Repositories
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor, int>
    {
    }
}
