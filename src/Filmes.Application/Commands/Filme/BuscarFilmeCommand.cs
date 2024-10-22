using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Commands.Filme;

public class BuscarFilmeCommand
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string? Titulo { get; set; }
}