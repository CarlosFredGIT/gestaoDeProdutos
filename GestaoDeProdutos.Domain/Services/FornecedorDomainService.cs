using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces.Repositories;
using GestaoDeProdutos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeFornecedors.Domain.Services
{
    public class FornecedorDomainService : IFornecedorDomainService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorDomainService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public void CriarFornecedor(Fornecedor fornecedor)
        {
            _fornecedorRepository.Create(fornecedor);
        }

        public void AlterarFornecedor(Fornecedor fornecedor)
        {
            _fornecedorRepository.Update(fornecedor);
        }

        public void ExcluirFornecedor(int codigo)
        {
            var fornecedor = _fornecedorRepository.GetByCodigo(codigo);
            _fornecedorRepository.Delete(fornecedor);
        }

        public List<Fornecedor> ConsultarTodosFornecedores()
        {
            return _fornecedorRepository.GetAll();
        }

        public Fornecedor ConsultarFornecedor(int codigo)
        {
            return _fornecedorRepository.GetByCodigo(codigo);
        }

        public void Dispose()
        {
            _fornecedorRepository.Dispose();
        }
    }
}
