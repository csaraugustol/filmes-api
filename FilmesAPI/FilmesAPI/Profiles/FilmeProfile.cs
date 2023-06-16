using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data.DTOs.Filme;

namespace FilmesAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDTO, Filme>();
        CreateMap<UpdateCinemaDTO, Filme>();
        CreateMap<Filme, UpdateCinemaDTO>();
        CreateMap<Filme, ReadFilmeDTO>();
    }
}
