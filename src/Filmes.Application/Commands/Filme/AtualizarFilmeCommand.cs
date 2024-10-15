namespace Filmes.Application.Commands.Filme;

public class AtualizarFilmeCommand
{
    public int IdFilme { get; set; }
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public int Duracao { get; set; }
}