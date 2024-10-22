using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Commands.Usuario;

public class AutenticarUsuarioCommand
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Senha { get; set; }
}