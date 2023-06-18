using AutoMapper;
using FilmesAPI.Data.Contextos;
using FilmesAPI.Data.DTOs.Filme;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("filme")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    ///// <summary>
    ///// Adiciona um filme ao banco de dados
    ///// </summary>
    ///// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    ///// <returns>IActionResult</returns>
    ///// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO createFilmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(createFilmeDTO);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Filme), new { id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> Filmes([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? nomeCinema = null)
    {
        if(nomeCinema == null)
        {
            return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.Skip(skip).Take(take));
        }

        return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.Skip(skip).Take(take).Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema))) ;
    }

    [HttpGet("{id}")]
    public IActionResult Filme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) return NotFound();

        var filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);

        return Ok(filmeDTO);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO updateFilmeDTO )
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) return NotFound();

        _mapper.Map(updateFilmeDTO, filme);
        _context.SaveChanges();

        return NoContent();
    }

    //[HttpPatch("{id}")]
    //public IActionResult AtualizarFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> jsonPatch)
    //{
    //    var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

    //    if (filme == null) return NotFound();

    //    var filmeAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);

    //    jsonPatch.ApplyTo(filmeAtualizar, ModelState);

    //    if (!TryValidateModel(filmeAtualizar)) return ValidationProblem(ModelState);

    //    _mapper.Map(jsonPatch, filme);
    //    _context.SaveChanges();

    //    return NoContent();
    //}

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id,
            JsonPatchDocument<UpdateFilmeDTO> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}