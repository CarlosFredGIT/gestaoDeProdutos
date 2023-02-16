using GestaoDeProdutos.Application.DTO.ProdutoDTO;
using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.Services;
using GestaoDeProdutos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProdutos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationService _produtoApplicationService;

        public ProdutoController(IProdutoApplicationService produtoApplicationService)
        {
            _produtoApplicationService = produtoApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CriarProdutoDTO dto)
        {
            try
            {
                if (dto.DataFabricacao < dto.DataValidacao)
                {
                    _produtoApplicationService.CriarProduto(dto);
                    return StatusCode(201, new { message = "produto cadastrado com sucesso." });
                }
                else
                    return StatusCode(400, new { message = $"produto não pode ser cadastrado. A data de fabricação - {dto.DataFabricacao} deve ser menor que a data de validação - {dto.DataValidacao}." });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Update(AlterarProdutoDTO dto)
        {
            try
            {
                if (dto.DataFabricacao < dto.DataValidacao)
                {
                    _produtoApplicationService.AlterarProduto(dto);
                    return StatusCode(200, new { message = "produto alterado com sucesso." });                            
                }
                else
                    return StatusCode(400, new { message = "produto não pode ser alterado. A data de fabricação deve ser menor que a data de validação." });
                
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_produtoApplicationService.ConsultarTodosProdutos());
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{codigo}")]
        public IActionResult GetByCodigo(int codigo)
        {
            try
            {
                return Ok(_produtoApplicationService.ConsultarProduto(codigo));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("Descricao")]
        public IActionResult GetByDescricao(string descricao)
        {
            try
            {
                return Ok(_produtoApplicationService.ConsultarProdutosPorDescricao(descricao));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("Situacao")]
        public IActionResult GetBySituacao(string situacao)
        {
            try
            {
                return Ok(_produtoApplicationService.ConsultarProdutosPorSituacao(situacao));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("DataValidacao")]
        public IActionResult GetByDataValidacao(DateTime dataValidacao)
        {
            try
            {
                return Ok(_produtoApplicationService.ConsultarProdutosPorDataValidacao(dataValidacao));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("DataFabricacao")]
        public IActionResult GetByDataFabricacao(DateTime dataFabricacao)
        {
            try
            {
                return Ok(_produtoApplicationService.ConsultarProdutosPorDataFabricacao(dataFabricacao));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
