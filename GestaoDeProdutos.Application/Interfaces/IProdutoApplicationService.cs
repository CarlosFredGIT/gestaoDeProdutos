using GestaoDeProdutos.Application.DTO.ProdutoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Interfaces
{
    public interface IProdutoApplicationService : IDisposable
    {
        /// <summary>
        /// Cadastro de produto
        /// </summary>
        /// <param name="dto">Modelo de dados para cadastro</param>
        void CriarProduto(CriarProdutoDTO dto);
        
        /// <summary>
        /// Edição de produto
        /// </summary>
        /// <param name="dto">Modelo de dados para edição</param>
        void AlterarProduto(AlterarProdutoDTO dto);

        /// <summary>
        /// Exclusão de produto
        /// </summary>
        /// <param name="dto">Modelo de dados para exclusão</param>
        void ExcluirProduto(int codigo);

        /// <summary>
        /// Consulta de produtos
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        List<ConsultarProdutoDTO> ConsultarTodosProdutos();

        /// <summary>
        /// Consulta de produto
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        ConsultarProdutoDTO ConsultarProduto(int codigo);

        /// <summary>
        /// Consulta de produtos por descrição
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        List<ConsultarProdutoDTO> ConsultarProdutosPorDescricao(string descricao);

        /// <summary>
        /// Consulta de produtos por situação
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        List<ConsultarProdutoDTO> ConsultarProdutosPorSituacao(string situacao);

        /// <summary>
        /// Consulta de produtos por data de fabricação
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        List<ConsultarProdutoDTO> ConsultarProdutosPorDataFabricacao(DateTime dataFabricacao);

        /// <summary>
        /// Consulta de produtos por data de validação
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        List<ConsultarProdutoDTO> ConsultarProdutosPorDataValidacao(DateTime dataValidacao);
    }
}
