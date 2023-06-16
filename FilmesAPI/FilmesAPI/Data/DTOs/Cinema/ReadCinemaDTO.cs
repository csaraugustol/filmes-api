using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Cinema;

public class ReadCinemaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
