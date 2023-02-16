using AutoMapper;
using FluentValidation;
using GestaoDeProdutos.Application.DTO.FornecedorDTO;
using GestaoDeProdutos.Application.DTO.ProdutoDTO;
using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces.Services;
using GestaoDeProdutos.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorDomainService _fornecedorDomainService;
        private readonly IMapper _mapper;

        public FornecedorApplicationService(IFornecedorDomainService fornecedorDomainService, IMapper mapper)
        {
            _fornecedorDomainService = fornecedorDomainService;
            _mapper = mapper;
        }

        public void CriarFornecedor(CriarFornecedorDTO dto)
        {
            //Gerando um fornecedor a partir do automapper
            var fornecedor = _mapper.Map<Fornecedor>(dto);

            //Executando a validação do fornecedor
            var validate = fornecedor.Validate;

            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _fornecedorDomainService.CriarFornecedor(fornecedor);
        }

        public void AlterarFornecedor(AlterarFornecedorDTO dto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(dto);
            _fornecedorDomainService.AlterarFornecedor(fornecedor);
        }

        public void ExcluirFornecedor(int codigo)
        {
            _fornecedorDomainService.ExcluirFornecedor(codigo);
        }

        public List<ConsultarFornecedorDTO> ConsultarTodosFornecedores()
        {
            var fornecedores = _fornecedorDomainService
                .ConsultarTodosFornecedores()
                .Skip(0)
                .Take(20); 

            return _mapper.Map<List<ConsultarFornecedorDTO>>(fornecedores);
        }

        public ConsultarFornecedorDTO ConsultarFornecedor(int codigo)
        {
            var fornecedor = _fornecedorDomainService
                .ConsultarFornecedor(codigo);

            return _mapper.Map<ConsultarFornecedorDTO>(fornecedor);
        }

        public void Dispose()
        {
            _fornecedorDomainService.Dispose();
        }   
    }
}
