using AutoMapper;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(DTO => DTO.HorarioInicio, opts => opts
                 .MapFrom(dto => dto.HorarioEnceramentoSessao.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}
