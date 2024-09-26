using FluentValidation.Results;

namespace Filmes.Domain.Core;

public interface IEntity
{
    ValidationResult Validate { get; }
}
