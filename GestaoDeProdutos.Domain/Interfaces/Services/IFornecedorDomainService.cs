using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces.Services
{
    public interface IFornecedorDomainService : IDisposable
    {
        void CriarFornecedor(Fornecedor fornecedor);
        void AlterarFornecedor(Fornecedor fornecedor);
        void ExcluirFornecedor(int codigo);

        List<Fornecedor> ConsultarTodosFornecedores();
        Fornecedor ConsultarFornecedor(int codigo);
    }
}
