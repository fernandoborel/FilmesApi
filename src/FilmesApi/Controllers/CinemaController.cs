using Filmes.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CinemaController : ControllerBase
{
    private readonly ICinemaRepository _cinemaRepository;

    public CinemaController(ICinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }

    [HttpGet]
    [Route("BuscarCinemaPeloNome")]
    public IActionResult Get(string name)
    {
        var cinema = _cinemaRepository.GetByName(name);
        if (cinema != null)
            return Ok(new { message = "Cinema encontrado", cinema });

        return NotFound(new { message = "Cinema não encontrado" });
    }
}
