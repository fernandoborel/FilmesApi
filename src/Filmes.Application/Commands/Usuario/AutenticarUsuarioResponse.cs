namespace Filmes.Application.Commands.Usuario;

public class AutenticarUsuarioResponse
{
    public string Message { get; set; }
    public AuthorizationModel Model { get; set; }
}