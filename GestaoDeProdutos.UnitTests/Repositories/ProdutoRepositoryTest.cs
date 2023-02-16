using Bogus;
using FluentAssertions;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GestaoDeProdutos.UnitTests.Repositories
{
    public class ProdutoRepositoryTest
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoRepositoryTest(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [Fact]
        public void TestCreate()
        {
            #region Realizando cadastro do produto

            var produto = CreateProduto();

            #endregion

            #region Verificando se o produto foi cadastrado

            var produtoByCodigo = _produtoRepository.GetByCodigo(produto.Codigo);

            produtoByCodigo.Should().NotBeNull(); //Codigo não pode ser null
            produtoByCodigo.Descricao.Should().Be(produto.Descricao); //Comparando com a descrição gravada
            produtoByCodigo.Situacao.Should().Be(produto.Situacao); //Comparando com a situação gravada
            produtoByCodigo.DataFabricacao.Should().Be(produto.DataFabricacao); //Comparando com a data de fabricação gravada
            produtoByCodigo.DataValidacao.Should().Be(produto.DataValidacao); //Comparando com a data de validalção gravada

            #endregion
        }

        [Fact]
        public void TestUpdate()
        {
            #region Realizando cadastro do produto

            var produto = CreateProduto();

            #endregion

            #region Atualizando os dados do produto

            var faker = new Faker("pt_BR");

            produto.Descricao = $"Alteração da descrição para teste.";
            produto.Situacao = Status.Inativo;

            _produtoRepository.Update(produto);

            #endregion

            #region Verificando se o produto foi cadastrado

            var produtoByCodigo = _produtoRepository.GetByCodigo(produto.Codigo);

            produtoByCodigo.Should().NotBeNull(); //Codigo não pode ser null
            produtoByCodigo.Descricao.Should().Be(produto.Descricao); //Comparando com a descrição gravada
            produtoByCodigo.Situacao.Should().Be(produto.Situacao); //Comparando com a situação gravada
            produtoByCodigo.DataFabricacao.Should().Be(produto.DataFabricacao); //Comparando com a data de fabricação gravada
            produtoByCodigo.DataValidacao.Should().Be(produto.DataValidacao); //Comparando com a data de validalção gravada

            #endregion
        }

        [Fact]
        public void TestDelete()
        {
            #region Realizando cadastro do produto

            var produto = CreateProduto();

            produto.Situacao = Status.Inativo;

            #endregion

            #region Deletando o produto

            _produtoRepository.Delete(produto);

            #endregion

            #region Verificando se o produto não foi encontrado

            var produtoByCodigo = _produtoRepository.GetByCodigo(produto.Codigo);

            produtoByCodigo.Should().BeNull(); //Codigo não pode existir

            #endregion
        }

        [Fact]
        public void TestGetAll()
        {
            #region Realizando cadastro do produto

            var produto = CreateProduto();

            #endregion

            #region Consultando todos os produtos do banco de dados

            var lista = _produtoRepository.GetAll();

            #endregion

            #region Verificando se o produto foi retornado na cosulta

            lista.FirstOrDefault(p => p.Codigo.Equals(produto.Codigo)).Should().NotBeNull();

            #endregion
        }

        [Fact]
        public void TestGetByCodigo()
        {
            #region Realizando cadastro do produto

            var produto = CreateProduto();

            #endregion

            #region Consulta o produto pelo codigo

            var produtoByCodigo = _produtoRepository.GetByCodigo(produto.Codigo);

            #endregion

            #region Verificando se o produto foi retornado na cosulta

            produtoByCodigo.Should().NotBeNull();
            produtoByCodigo.Descricao.Should().Be(produto.Descricao); //Comparando com a descrição gravada
            produtoByCodigo.Situacao.Should().Be(produto.Situacao); //Comparando com a situação gravada
            produtoByCodigo.DataFabricacao.Should().Be(produto.DataFabricacao); //Comparando com a data de fabricação gravada
            produtoByCodigo.DataValidacao.Should().Be(produto.DataValidacao); //Comparando com a data de validalção gravada

            #endregion
        }

        //Metodo auxiliar para criação do produto
        private Produto CreateProduto()
        {
            var faker = new Faker("pt_BR");

            var produto = new Produto
            {
                Descricao = $"Criação da descrição para teste.",
                Situacao = Status.Ativo,
                DataFabricacao = DateTime.Now,
                DataValidacao = DateTime.Now
            };

            _produtoRepository.Create(produto);

            return produto;
        }
    }
}
