using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Commands.Cinema;

public class CriarCinemaCommand
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "O campo IdEndereco é obrigatório.")]
    public int? IdEndereco { get; set; }
    [Required(ErrorMessage = "O campo IdShopping é obrigatório.")]
    public int? IdShopping { get; set; }
}