using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Endereco;

public class ReadEnderecoDTO
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
}
