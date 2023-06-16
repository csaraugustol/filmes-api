using FilmesAPI.Data.DTOs.Endereco;
using FilmesAPI.Data.DTOs.Sessao;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Cinema;

public class ReadCinemaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDTO Endereco { get; set; }
    public virtual ICollection<ReadSessaoDTO> Sessoes { get; set; }
}
