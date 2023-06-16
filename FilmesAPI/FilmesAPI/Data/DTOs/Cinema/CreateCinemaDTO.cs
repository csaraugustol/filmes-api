using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Cinema;

public class CreateCinemaDTO
{
    [Required(ErrorMessage = "Cinema: O nome é obrigatório.")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
}
