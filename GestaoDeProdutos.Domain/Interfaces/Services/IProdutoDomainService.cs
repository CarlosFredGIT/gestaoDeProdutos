using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces.Services
{
    //Interface para serviços de domínio de produto
    public interface IProdutoDomainService : IDisposable
    {
        void CriarProduto(Produto produto);
        void AlterarProduto(Produto produto);
        void ExcluirProduto(int codigo);

        List<Produto> ConsultarTodosProdutos();
        List<Produto> GetByDataFabricacao(DateTime dataFabricacao);
        List<Produto> GetByDataValidacao(DateTime dataValidacao);
        List<Produto> GetByDescricao(string descricao);
        List<Produto> GetBySituacao(string situacao);
        Produto ConsultarProduto(int codigo);
    }
}






