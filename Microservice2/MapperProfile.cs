using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Model;
using Microservice2.Model.Dto;

namespace Microservice2
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DebitCardDto, DebitCard>();
             

         
      
        }
    }
}
