using Filmes.Application.Commands.Sessao;
using Filmes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessaoController : ControllerBase
{
    private readonly ISessaoAppService _sessaoAppService;

    public SessaoController(ISessaoAppService sessaoAppService)
        => _sessaoAppService = sessaoAppService;        

    [HttpGet]
    [Route("BuscarTodos")]
    public IActionResult GetAll()
    {
        var sessoes = _sessaoAppService.BuscarTodos();
        if (sessoes != null && sessoes.Any())
            return StatusCode(200, new { message = "Sessao(ões) encontrada(s)", quantidade = sessoes.Count(), sessoes });

        return BadRequest(new { message = "Nenhuma sessão encontrada" });
    }


    [HttpPost]
    [Route("CriarSessao")]
    public IActionResult Post(CriarSessaoComand command)
    {
        try
        {
            _sessaoAppService.CriarSessao(command);
            return StatusCode(201, new { message = "Sessão criada com sucesso", sessao = command });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao criar sessão", error = ex.Message });
        }
    }
}