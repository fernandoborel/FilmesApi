namespace Filmes.Domain.Entities;

public class Sessao
{
    public int? IdFilme { get; set; }
    public int? IdCinema { get; set; }

    public virtual Cinema? IdCinemaNavigation { get; set; }
    public virtual Filme? IdFilmeNavigation { get; set; }
}
