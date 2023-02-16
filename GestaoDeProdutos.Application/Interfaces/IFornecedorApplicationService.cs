using GestaoDeProdutos.Application.DTO.FornecedorDTO;
using GestaoDeProdutos.Application.DTO.ProdutoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Interfaces
{
    public interface IFornecedorApplicationService : IDisposable
    {
        /// <summary>
        /// Cadastro de fornecedor
        /// </summary>
        /// <param name="dto">Modelo de dados para cadastro</param>
        void CriarFornecedor(CriarFornecedorDTO dto);

        /// <summary>
        /// Edição de fornecedor
        /// </summary>
        /// <param name="dto">Modelo de dados para edição</param>
        void AlterarFornecedor(AlterarFornecedorDTO dto);

        /// <summary>
        /// Exclusão de fornecedor
        /// </summary>
        /// <param name="dto">Modelo de dados para exclusão</param>
        void ExcluirFornecedor(int codigo);

        /// <summary>
        /// Consulta de fornecedores
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        List<ConsultarFornecedorDTO> ConsultarTodosFornecedores();

        /// <summary>
        /// Consulta de fornecedor
        /// </summary>
        /// <returns>Modelo de dados da consulta</returns>
        ConsultarFornecedorDTO ConsultarFornecedor(int codigo);
    }
}
