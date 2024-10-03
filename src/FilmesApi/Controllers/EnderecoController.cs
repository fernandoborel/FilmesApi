using Filmes.Application.Commands.Endereco;
using Filmes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoAppService _enderecoAppService;

    public EnderecoController(IEnderecoAppService enderecoAppService)
    {
        _enderecoAppService = enderecoAppService;
    }

    [HttpGet]
    [Route("BuscarTodos")]
    public IActionResult GetAll()
    {
        var enderecos = _enderecoAppService.BuscarEnderecos();
        if (enderecos != null && enderecos.Any())
            return StatusCode(200, new { message = "Endereço(s) encontrado(s)", quantidade = enderecos.Count(), enderecos });

        return BadRequest(new { message = "Nenhum endereço encontrado" });
    }

    [HttpPost]
    [Route("CriarEndereco")]
    public IActionResult Post(CriarEnderecoCommand command)
    {
        try
        {
            _enderecoAppService.CriarEndereco(command);
            return StatusCode(201, new { message = "Endereço cadastrado com sucesso", endereco = command });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao cadastrar endereço", error = ex.Message });
        }
    }
}
