using Filmes.Application.Commands.Usuario;
using Filmes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioAppService _usuarioAppService;

    public LoginController(IUsuarioAppService usuarioAppService)
       => _usuarioAppService = usuarioAppService;

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Post(CriarUsuarioCommand command)
    {
        try
        {
            _usuarioAppService.CriarUsuario(command);
            return StatusCode(201, new { message = "Usuário criado com sucesso", usuario = command });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = "Erro ao criar usuário", error = e.Message });
        }
    }
}
