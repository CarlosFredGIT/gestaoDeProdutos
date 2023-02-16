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
    public class Fornecedor : IEntity<int>
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }

        public ValidationResult Validate => new FornecedorValidation().Validate(this);

        #region Relacionamento

        public List<Produto> Produtos { get; set; }

        #endregion
    }
}
