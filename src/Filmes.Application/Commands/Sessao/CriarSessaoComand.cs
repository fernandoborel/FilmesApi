using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Commands.Sessao;

public class CriarSessaoComand
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int idFilme {  get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int idCinema { get; set; }
}