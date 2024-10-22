using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Commands.Endereco;

public class CriarEnderecoCommand
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? Logradouro { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int? Numero {  get; set; }
}