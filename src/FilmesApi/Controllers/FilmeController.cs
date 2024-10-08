using Filmes.Application.Commands.Filme;
using Filmes.Application.Interfaces;
using Filmes.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeAppService _filmeAppService;

        public FilmeController(IFilmeAppService filmeAppService)
        {
            _filmeAppService = filmeAppService;
        }

        [HttpGet]
        [Route("BuscarFilmePeloNome")]
        public IActionResult Get(Filme filme)
        {
            _filmeAppService.BuscarFilmePeloNome(filme);
            return StatusCode(200, filme);
        }

        [HttpGet]
        [Route("BuscarTodos")]
        public IActionResult GetAll()
        {
            var filmes = _filmeAppService.BuscarFilmes();
            if (filmes != null && filmes.Any())
                return StatusCode(200, new { message = "Filme(s) encontrado(s)", quantidade = filmes.Count(), filmes });

            return BadRequest(new { message = "Nenhum filme encontrado" });
        }

        [HttpPost]
        [Route("CriarFilme")]
        public IActionResult Post(CriarFilmeCommand command)
        {
            try
            {
                _filmeAppService.CriarFilme(command);
                return StatusCode(201, new { message = "Filme cadastrado com sucesso", filme = command });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao cadastrar Filme", error = ex.Message });
            }
        }
    }
}
