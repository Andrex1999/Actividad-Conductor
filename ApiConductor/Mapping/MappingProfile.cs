using ApiConductor.DTO;
using ApiConductor.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConductor.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<MatriculaDTO,Matricula >();

        }
    }
}
