using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Core
{
    public interface IEntity<Tkey>
    {
        public Tkey Codigo { get; set; }

        ValidationResult Validate { get; }
    }  
}
