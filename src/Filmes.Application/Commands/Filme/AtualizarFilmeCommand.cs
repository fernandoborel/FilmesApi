using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Commands.Filme;

public class AtualizarFilmeCommand
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int IdFilme { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string? Titulo { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string? Genero { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Duracao { get; set; }
}