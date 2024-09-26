using Filmes.Domain.Entities;
using FluentValidation;

namespace Filmes.Domain.Validations;

public class CinemaValidation : AbstractValidator<Cinema>
{
    public CinemaValidation()
    {
        RuleFor(c => c.IdCinema)
            .NotEmpty();

        RuleFor(c => c.Nome)
            .NotEmpty()
            .Length(6, 150)
            .WithMessage("Nome de cinema inválido");
    }
}
