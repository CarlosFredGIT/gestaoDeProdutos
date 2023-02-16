using AutoMapper;
using FluentValidation;
using GestaoDeProdutos.Application.DTO.ProdutoDTO;
using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IProdutoDomainService _produtoDomainService;
        private readonly IMapper _mapper;

        public ProdutoApplicationService(IProdutoDomainService produtoDomainService, IMapper mapper)
        {
            _produtoDomainService = produtoDomainService;
            _mapper = mapper;
        }

        public void CriarProduto(CriarProdutoDTO dto)
        {
            var produto = _mapper.Map<Produto>(dto);

            //Executando a validação do produto
            var validate = produto.Validate;

            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _produtoDomainService.CriarProduto(produto);
        }

        public void AlterarProduto(AlterarProdutoDTO dto)
        {
            var produto = _mapper.Map<Produto>(dto);
            _produtoDomainService.AlterarProduto(produto);

            if(produto.Situacao.Equals(Status.Inativo) || produto.Situacao.Equals("2"))
                _produtoDomainService.ExcluirProduto(produto.Codigo);            
        }

        public void ExcluirProduto(int codigo)
        {
            _produtoDomainService.ExcluirProduto(codigo);
        }

        public List<ConsultarProdutoDTO> ConsultarTodosProdutos()
        {
            var produtos = _produtoDomainService
                .ConsultarTodosProdutos()
                .Skip(0)
                .Take(20);
            
            return _mapper.Map<List<ConsultarProdutoDTO>>(produtos);
        }

        public ConsultarProdutoDTO ConsultarProduto(int codigo)
        {
            var produto = _produtoDomainService
                .ConsultarProduto(codigo);

            return _mapper.Map<ConsultarProdutoDTO>(produto);
        }

        public List<ConsultarProdutoDTO> ConsultarProdutosPorDescricao(string descricao)
        {
            var produtos = _produtoDomainService
                .GetByDescricao(descricao)
                .Skip(0)
                .Take(20);

            return _mapper.Map<List<ConsultarProdutoDTO>>(produtos);
        }

        public List<ConsultarProdutoDTO> ConsultarProdutosPorSituacao(string situacao)
        {
            var produtos = _produtoDomainService
                .GetBySituacao(situacao)
                .Skip(0)
                .Take(20);

            return _mapper.Map<List<ConsultarProdutoDTO>>(produtos);
        }

        public List<ConsultarProdutoDTO> ConsultarProdutosPorDataFabricacao(DateTime dataFabricacao)
        {
            var produtos = _produtoDomainService
                .GetByDataFabricacao(dataFabricacao)
                .Skip(0)
                .Take(20);

            return _mapper.Map<List<ConsultarProdutoDTO>>(produtos);
        }

        public List<ConsultarProdutoDTO> ConsultarProdutosPorDataValidacao(DateTime dataValidacao)
        {
            var produtos = _produtoDomainService
                .GetByDataValidacao(dataValidacao)
                .Skip(0)
                .Take(20);

            return _mapper.Map<List<ConsultarProdutoDTO>>(produtos);
        }

        public void Dispose()
        {
            _produtoDomainService.Dispose();
        }
    }
}
