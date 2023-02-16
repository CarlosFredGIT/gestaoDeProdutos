using FluentValidation.Results;
using GestaoDeProdutos.Domain.Core;
using GestaoDeProdutos.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Entities
{
    public class Produto : IEntity<int>
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public Status Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidacao { get; set; }

        public ValidationResult Validate => new ProdutoValidation().Validate(this);

        #region Relacionamento

        public List<Fornecedor> Fornecedores { get; set; }
        

        #endregion
    }

    public enum Status
    {
        Ativo = 1,
        Inativo = 2
    }
}

