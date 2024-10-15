namespace Filmes.Domain.Entities;

public class Endereco
{
    public Endereco()
    {
        Cinemas = new HashSet<Cinema>();
    }

    public int IdEndereco { get; set; }
    public string? Logradouro { get; set; }
    public int? Numero { get; set; }

    public virtual ICollection<Cinema> Cinemas { get; set; }
}