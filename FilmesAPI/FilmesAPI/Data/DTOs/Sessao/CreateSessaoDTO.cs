using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Sessao;

public class CreateSessaoDTO
{
    [Required(ErrorMessage = "Sessão: Id do filme é obrigatório.")]
    public int FilmeId { get; set; }
    public int CinemaId { get; set; }
}
