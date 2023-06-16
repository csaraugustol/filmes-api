using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Cinema;

public class UpdateCinemaDTO
{
    [Required(ErrorMessage = "Cinema: O nome é obrigatório.")]
    public string Nome { get; set; }
}
