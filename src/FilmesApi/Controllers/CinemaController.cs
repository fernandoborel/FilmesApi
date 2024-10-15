using Filmes.Application.Commands.Cinema;
using Filmes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CinemaController : ControllerBase
{
    
    private readonly ICinemaAppService _cinemaAppService;

    public CinemaController(ICinemaAppService cinemaAppService)
        => _cinemaAppService = cinemaAppService;


    [HttpGet]
    [Route("BuscarTodos")]
    public IActionResult GetAll()
    {
        var cinemas = _cinemaAppService.BuscarCinemas();
        if (cinemas != null && cinemas.Any())
            return StatusCode(200, new { message = "Cinema(s) encontrado(s)", quantidade = cinemas.Count(), cinemas });

        return BadRequest(new { message = "Nenhum cinema encontrado" });
    }

    [HttpPost]
    [Route("CriarCinema")]
    public IActionResult Post(CriarCinemaCommand command) 
    {
        try
        {
            _cinemaAppService.CriarCinema(command);
            return StatusCode(201, new { message = "Cinema criado com sucesso", cinema = command });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao criar cinema", error = ex.Message });
        }
    }
}
