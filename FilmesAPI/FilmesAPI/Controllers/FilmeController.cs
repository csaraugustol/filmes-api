using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
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

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO createFilmeDTO)
    {
        Filme filme = _mapper.Map<Filme>(createFilmeDTO);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Filme), new { id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> Filmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult Filme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null) return NotFound();
        return Ok(filme);
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
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

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

}