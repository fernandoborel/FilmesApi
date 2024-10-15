using Filmes.Domain.Core;
using Filmes.Domain.Validations;
using FluentValidation.Results;

namespace Filmes.Domain.Entities;

public class Cinema : IEntity
{
    public int IdCinema { get; set; }
    public string? Nome { get; set; }
    public int? IdEndereco { get; set; }
    public int? IdShopping { get; set; }

    public virtual Endereco? IdEnderecoNavigation { get; set; }
    public virtual Shopping? IdShoppingNavigation { get; set; }
    
    public ValidationResult Validate => new CinemaValidation().Validate(this);
}