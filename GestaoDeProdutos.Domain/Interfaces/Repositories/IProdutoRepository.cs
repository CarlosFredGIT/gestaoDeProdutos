using GestaoDeProdutos.Domain.Core;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto, int>
    {
        List<Produto> GetByDescricao(string descricao);
        List<Produto> GetBySituacao(string situacao);
        List<Produto> GetByDataFabricacao(DateTime dataFabricacao);
        List<Produto> GetByDataValidacao(DateTime dataValidacao);
    }
}
