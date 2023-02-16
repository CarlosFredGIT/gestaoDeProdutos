using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Core
{
    public class DomainException : Exception
    {
        public DomainException(string errorMessage)
            : base(errorMessage) 
        {

        }

        //Metodo para testar uma condição de erro e disparar uma exceçao
        public static void When(bool hasError, string errorMessage)
        {
            if (hasError) 
                throw new DomainException(errorMessage);
        }
    }
}
