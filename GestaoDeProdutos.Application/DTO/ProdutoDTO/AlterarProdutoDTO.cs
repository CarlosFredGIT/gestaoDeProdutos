using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.DTO.ProdutoDTO
{
    public class AlterarProdutoDTO
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public Status Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidacao { get; set; }
    }
}
