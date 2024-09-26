namespace Filmes.Domain.Entities;

public class Filme
{
    public int IdFilme { get; set; }
    public string Titulo { get; set; } = null!;
    public string Genero { get; set; } = null!;
    public int Duracao { get; set; }
}
