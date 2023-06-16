﻿using AutoMapper;
using FilmesAPI.Data.DTOs.Cinema;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile: Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<UpdateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>();
        }
    }
}
