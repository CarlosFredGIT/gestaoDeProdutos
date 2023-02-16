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
    /// <summary>
    /// Mapeamento dos fluxos de entrada da aplicação
    /// </summary>
    public class DtoToFornecedorMap : Profile
    {
        public DtoToFornecedorMap()
        {
            CreateMap<CriarFornecedorDTO, Fornecedor>(); 
            CreateMap<AlterarFornecedorDTO, Fornecedor>();
            CreateMap<ConsultarFornecedorDTO, Fornecedor>();
        }
    }
}
