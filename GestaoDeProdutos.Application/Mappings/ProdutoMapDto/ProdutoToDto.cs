using AutoMapper;
using GestaoDeProdutos.Application.DTO.ProdutoDTO;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Mappings.ProdutoMapDto
{
    public class ProdutoToDto : Profile
    {
        public ProdutoToDto()
        {
            CreateMap<Produto, CriarProdutoDTO>();
            CreateMap<Produto, AlterarProdutoDTO>();
            CreateMap<Produto, ConsultarProdutoDTO>()
                .ForMember(cpd => cpd.Situacao, options => options.MapFrom(p => p.Situacao.ToString()));
        }
    }
}
