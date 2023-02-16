using AutoMapper;
using GestaoDeProdutos.Application.DTO.FornecedorDTO;
using GestaoDeProdutos.Application.DTO.ProdutoDTO;
using GestaoDeProdutos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProdutos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _fornecedorApplicationService;

        public FornecedorController(IFornecedorApplicationService fornecedorApplicationService)
        {
            _fornecedorApplicationService = fornecedorApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CriarFornecedorDTO dto)
        {
            try
            {
                _fornecedorApplicationService.CriarFornecedor(dto);
                return StatusCode(200, new { message = "fornecedor cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Update(AlterarFornecedorDTO dto)
        {
            try
            {
                _fornecedorApplicationService.AlterarFornecedor(dto);
                return StatusCode(200, new { message = "fornecedor alterado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            try
            {
                _fornecedorApplicationService.ExcluirFornecedor(codigo);
                return StatusCode(201, new { message = "fornecedor excluido com sucesso." });
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
                return Ok(_fornecedorApplicationService.ConsultarTodosFornecedores());
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
                return Ok(_fornecedorApplicationService.ConsultarFornecedor(codigo));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
