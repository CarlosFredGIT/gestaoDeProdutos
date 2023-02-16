using FluentValidation;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(p => p.Descricao)
                    .NotEmpty()
                    .Length(3, 500)
                    .WithMessage("Descrição é obrigatório.");

            RuleFor(p => p.Cnpj)
                    .NotEmpty()
                    .WithMessage("Cnpj é obrigatório.");
        }
    }
}
