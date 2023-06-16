﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs.Endereco;

public class CreateEnderecoDTO
{
    [Required(ErrorMessage = "Endereço: O logradouro é obrigatório")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "Endereço: O Número é obrigatório")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "Endereço: O Complemento é obrigatório")]
    public string Complemento { get; set; }

    [Required(ErrorMessage = "Endereço: O Bairro é obrigatório")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "Endereço: O Cidade é obrigatório")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "Endereço: O Estado é obrigatório")]
    public string Estado { get; set; }
}
