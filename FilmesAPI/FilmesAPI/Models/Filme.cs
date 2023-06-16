using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    [Required]
    [Key]
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres.")]
    [Required(ErrorMessage = "O título é obrigatório.")]
    public string Titulo { get; set; }

    [MaxLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres.")]
    [Required(ErrorMessage = "O gênero é obrigatório.")]
    public string Genero { get; set; }

    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")]
    [Required(ErrorMessage = "A duração é obrigatória.")]
    public int Duracao { get; set; }
}
