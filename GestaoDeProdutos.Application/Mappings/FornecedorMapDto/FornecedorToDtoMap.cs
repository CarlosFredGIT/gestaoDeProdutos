using AutoMapper;
using GestaoDeProdutos.Application.DTO.FornecedorDTO;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Mappings.FornecedorMapDto
{
    public class FornecedorToDtoMap : Profile
    {
        public FornecedorToDtoMap()
        {
            CreateMap<Fornecedor, CriarFornecedorDTO>();
            CreateMap<Fornecedor, AlterarFornecedorDTO>();
            CreateMap<Fornecedor, ConsultarFornecedorDTO>();
        }
    }
}
