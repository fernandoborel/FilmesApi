namespace Filmes.Domain.Entities;

public class Filme
{
    public int IdFilme { get; set; }
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public int Duracao { get; set; }
}