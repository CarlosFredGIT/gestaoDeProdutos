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
    public class FornecedorRepositoryTest
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorRepositoryTest(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        [Fact]
        public void TestCreate()
        {
            #region Realizando cadastro do fornecedor

            var fornecedor = CreateFornecedor();

            #endregion

            #region Verificando se o fornecedor foi cadastrado

            var fornecedorByCodigo = _fornecedorRepository.GetByCodigo(fornecedor.Codigo);

            fornecedorByCodigo.Should().NotBeNull(); //Codigo não pode ser null
            fornecedorByCodigo.Descricao.Should().Be(fornecedor.Descricao); //Comparando com a descrição gravada
            fornecedorByCodigo.Cnpj.Should().Be(fornecedor.Cnpj); //Comparando com o Cnpj gravada

            #endregion
        }


        [Fact]
        public void TestUpdate()
        {
            #region Realizando cadastro do fornecedor

            var fornecedor = CreateFornecedor();

            #endregion

            #region Atualizando os dados do fornecedor

            var faker = new Faker("pt_BR");

            fornecedor.Descricao = $"Alteração da descrição para teste."; //Comparando com a descrição gravada
            fornecedor.Cnpj = $"987654321-11"; //Comparando com o cnpj gravada

            _fornecedorRepository.Update(fornecedor);

            #endregion

            #region Verificando se o fornecedor foi cadastrado

            var fornecedorByCodigo = _fornecedorRepository.GetByCodigo(fornecedor.Codigo);

            fornecedorByCodigo.Should().NotBeNull(); //Codigo não pode ser null
            fornecedorByCodigo.Descricao.Should().Be(fornecedor.Descricao); //Comparando com a descrição gravada
            fornecedorByCodigo.Cnpj.Should().Be(fornecedor.Cnpj); //Comparando com o cnpj gravada

            #endregion
        }


        [Fact]
        public void TestDelete()
        {
            #region Realizando cadastro do fornecedor

            var fornecedor = CreateFornecedor();

            #endregion

            #region Deletando o fornecedor

            _fornecedorRepository.Delete(fornecedor);

            #endregion

            #region Verificando se o fornecedor não foi encontrado

            var fornecedorByCodigo = _fornecedorRepository.GetByCodigo(fornecedor.Codigo);

            fornecedorByCodigo.Should().BeNull(); //Codigo não pode existir

            #endregion
        }


        [Fact]
        public void TestGetAll()
        {
            #region Realizando cadastro do fornecedor

            var fornecedor = CreateFornecedor();

            #endregion

            #region Consultando todos os fornecedors do banco de dados

            var lista = _fornecedorRepository.GetAll();

            #endregion

            #region Verificando se o fornecedor foi retornado na cosulta

            lista.FirstOrDefault(p => p.Codigo.Equals(fornecedor.Codigo)).Should().NotBeNull();

            #endregion
        }


        [Fact]
        public void TestGetByCodigo()
        {
            #region Realizando cadastro do fornecedor

            var fornecedor = CreateFornecedor();

            #endregion

            #region Consulta o fornecedor pelo codigo

            var fornecedorByCodigo = _fornecedorRepository.GetByCodigo(fornecedor.Codigo);

            #endregion

            #region Verificando se o fornecedor foi retornado na cosulta

            fornecedorByCodigo.Should().NotBeNull();
            fornecedorByCodigo.Descricao.Should().Be(fornecedor.Descricao); //Comparando com a descrição gravada
            fornecedorByCodigo.Cnpj.Should().Be(fornecedor.Cnpj); //Comparando com o cnpj gravada

            #endregion
        }

        //Metodo auxiliar para criação do fornecedor
        private Fornecedor CreateFornecedor()
        {
            var faker = new Faker("pt_BR");

            var fornecedor = new Fornecedor
            {
                Descricao = $"Criação da descrição para teste.",
                Cnpj = $"123456789-88"
            };

            _fornecedorRepository.Create(fornecedor);

            return fornecedor;
        }
    }
}
