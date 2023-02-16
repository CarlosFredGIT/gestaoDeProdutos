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
    public class DtoToProduto : Profile
    {
        public DtoToProduto()
        {
            CreateMap<CriarProdutoDTO, Produto>();
            CreateMap<AlterarProdutoDTO, Produto>();
            CreateMap<ConsultarProdutoDTO, Produto>();
        }
    }
}
