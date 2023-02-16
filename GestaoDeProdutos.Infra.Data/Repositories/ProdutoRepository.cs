using GestaoDeProdutos.Application.DTO.ProdutoDTO;
using GestaoDeProdutos.Domain.Core;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces.Repositories;
using GestaoDeProdutos.Infra.Data.Contexts;
using GestaoDeProdutos.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto, int>, IProdutoRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public ProdutoRepository(SqlServerContext sqlServerContext)
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public List<Produto> GetByDataFabricacao(DateTime dataFabricacao)
        {
            return _sqlServerContext
                .Produtos
                .Where(p => p.DataFabricacao.Equals(dataFabricacao))
                .ToList();
        }

        public List<Produto> GetByDataValidacao(DateTime dataValidacao)
        {
            return _sqlServerContext
                .Produtos
                .Where(p => p.DataValidacao.Equals(dataValidacao))
                .ToList();
        }

        public List<Produto> GetByDescricao(string descricao)
        {
            return _sqlServerContext
                .Produtos
                .Where(p => p.Descricao.ToUpper().StartsWith(descricao.ToUpper()))
                .ToList();
        }

        public List<Produto> GetBySituacao(string situacao)
        {
            List<Produto> result = new List<Produto>();

            if(situacao.Equals("Inativo") || situacao.Equals("2"))
            {
                 result = _sqlServerContext
                .Produtos
                .Where(p => p.Situacao.Equals(Status.Inativo))
                .ToList();
            }
            
            if (situacao.Equals("Ativo") || situacao.Equals("1"))
            {
                 result = _sqlServerContext
                .Produtos
                .Where(p => p.Situacao.Equals(Status.Ativo))
                .ToList();
            }

            return result;
        }
    }
}