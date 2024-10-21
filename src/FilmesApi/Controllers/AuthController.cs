using Filmes.Application.Commands.Usuario;
using Filmes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioAppService _usuarioAppService;

    public AuthController(IUsuarioAppService usuarioAppService)
       => _usuarioAppService = usuarioAppService;

    [HttpPost]
    [Route("autenticar")]
    public IActionResult Post(AutenticarUsuarioCommand command)
    {
        try
        {
            var usuario = _usuarioAppService.AutenticarUsuario(command);

            var response = new AutenticarUsuarioResponse
            {
                Message = "Usuário autenticado com sucesso!",
                Model = new AuthorizationModel
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    AccessToken = usuario.AccessToken,
                }
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}