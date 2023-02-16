using Bogus;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GestaoDeProdutos.UnitTests.Services
{
    public class ProdutoDomainServiceTest
    {
        private readonly IProdutoDomainService _produtoDomainService;

        public ProdutoDomainServiceTest(IProdutoDomainService produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }

        [Fact]
        public void TestCriarProduto()
        {
            try
            {
                var produto = CreateProduto();
                _produtoDomainService.CriarProduto(produto);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Fact]
        public void TestAlterarProduto()
        {
            try
            {
                #region Realizando cadastro do produto

                var produto = CreateProduto();

                #endregion

                #region Atualizando os dados do produto

                var faker = new Faker("pt_BR");

                produto.Descricao = $"Alteração da descrição para teste.";
                produto.Situacao = Status.Inativo;

                _produtoDomainService.AlterarProduto(produto);

                #endregion
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Fact]
        public void TestExcluirProduto()
        {
            #region Realizando cadastro do produto

            var produto = CreateProduto();

            produto.Situacao = Status.Inativo;

            #endregion

            #region Deletando o produto
  
            _produtoDomainService.ExcluirProduto(produto.Codigo);

            #endregion
        }

        //Metodo auxiliar para criação do produto
        private Produto CreateProduto()
        {
            var faker = new Faker("pt_BR");

            return new Produto
            {
                Descricao = $"Criação da descrição para teste.",
                Situacao = Status.Ativo,
                DataFabricacao = DateTime.Now,
                DataValidacao = DateTime.Now
            };
        }
    }
}
