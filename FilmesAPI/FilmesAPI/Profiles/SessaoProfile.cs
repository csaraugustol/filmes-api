using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data.DTOs.Sessao;

namespace FilmesAPI.Profiles;

public class SessaoProfile: Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDTO, Sessao>();
        CreateMap<Sessao, ReadSessaoDTO>();
    }
}
