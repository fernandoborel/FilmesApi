using Filmes.Application.Commands.Cinema;
using Filmes.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CinemaController : ControllerBase
{
    private readonly ICinemaDomainService _cinemaDomainService;

    public CinemaController(ICinemaDomainService cinemaDomainService)
    {
        _cinemaDomainService = cinemaDomainService;
    }

    [HttpGet]
    [Route("BuscarTodos")]
    public IActionResult GetAll()
    {
        var cinemas = _cinemaDomainService.BuscarTodos();
        if (cinemas != null && cinemas.Any())
            return StatusCode(200, new { message = "Cinema(s) encontrado(s)", cinemas });

        return BadRequest(new { message = "Nenhum cinema encontrado" });
    }


    [HttpPost]
    [Route("CriarCinema")]
    public IActionResult Post(CriarCinemaCommand command) 
    {
        try
        {
            _cinemaDomainService.CriarCinema(command);
            return StatusCode(201, new { message = "Cinema criado com sucesso", cinema = command });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao criar cinema", error = ex.Message });
        }
    }
}
