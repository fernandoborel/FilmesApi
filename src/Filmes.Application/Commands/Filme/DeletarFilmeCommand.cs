using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Commands.Filme;

public class DeletarFilmeCommand
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int IdFilme { get; set; }
}