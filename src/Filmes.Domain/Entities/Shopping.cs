namespace Filmes.Domain.Entities;

public class Shopping
{
    public Shopping()
    {
        Cinemas = new HashSet<Cinema>();
    }

    public int IdShopping { get; set; }
    public string Nome { get; set; } = null!;

    public virtual ICollection<Cinema> Cinemas { get; set; }
}
