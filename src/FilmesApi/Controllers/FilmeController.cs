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
        public IActionResult Get([FromQuery] string titulo)
        {
            try
            {
                var command = new BuscarFilmeCommand { Titulo = titulo };
                _filmeAppService.BuscarFilmePeloNome(command);
                return StatusCode(200, new { message = $"Filme encontrado: ({command.Titulo})", filme = command });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Erro ao buscar Filme", error = e.Message });
            }
        }


        [HttpGet]
        [Route("BuscarFilmePeloId")]
        public IActionResult Get(int id)
        {
            var filme = _filmeAppService.BuscarFilmePeloId(id);
            if (filme != null)
                return StatusCode(200, new { message = $"Filme encontrado: ({filme.Titulo})", filme = id });

            return BadRequest(new { message = "Filme não encontrado" });
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


        [HttpPut]
        [Route("AtualizarFilme")]
        public IActionResult Put(AtualizarFilmeCommand command)
        {
            try
            {
                _filmeAppService.AtualizarFilme(command);
                return StatusCode(200, new { message = "Filme atualizado com sucesso", filme = command });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao atualizar Filme", error = ex.Message });
            }
        }


        [HttpDelete]
        [Route("DeletarFilme")]
        public IActionResult Delete(DeletarFilmeCommand command)
        {
            try
            {
                _filmeAppService.DeletarFilme(command);
                return StatusCode(200, new { message = "Filme deletado com sucesso", filme = command });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao deletar Filme", error = ex.Message });
            }
        }
    }
}
