using FluentValidation;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .Length(3, 500)
                .WithMessage("Descrição é obrigatório.");

            RuleFor(p => p.DataFabricacao)
                .NotEmpty()
                .WithMessage("Data de Fabricação é obrigatório.");

            RuleFor(p => p.DataValidacao)
                .NotEmpty()
                .WithMessage("Data de Validação é obrigatório.");

            RuleFor(p => p.Situacao)
                .NotEmpty()
                .WithMessage("Situação é obrigatório.");
        }
    }
}
