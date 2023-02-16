using GestaoDeProdutos.Domain.Core;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces.Repositories;
using GestaoDeProdutos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoDomainService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void CriarProduto(Produto produto)
        {
            _produtoRepository.Create(produto);
        }

        public void AlterarProduto(Produto produto)
        {
            _produtoRepository.Update(produto);
        }

        public void ExcluirProduto(int codigo)
        {
            var produto = _produtoRepository.GetByCodigo(codigo);
            _produtoRepository.Delete(produto);
        }

        public List<Produto> ConsultarTodosProdutos()
        {
            return _produtoRepository.GetAll();                 
        }

        public Produto ConsultarProduto(int codigo)
        {
            return _produtoRepository.GetByCodigo(codigo);
        }

        public List<Produto> GetByDataFabricacao(DateTime dataFabricacao)
        {
            return _produtoRepository.GetByDataFabricacao(dataFabricacao);
        }

        public List<Produto> GetByDataValidacao(DateTime dataValidacao)
        {
            return _produtoRepository.GetByDataValidacao(dataValidacao);
        }

        public List<Produto> GetByDescricao(string descricao)
        {
            return _produtoRepository.GetByDescricao(descricao);
        }

        public List<Produto> GetBySituacao(string situacao)
        {
            return _produtoRepository.GetBySituacao(situacao);
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
