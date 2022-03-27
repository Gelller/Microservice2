using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Model;
using Microservice2.Model.Dto;
using Microservice2.Domain.Managers.Implementation;

namespace Microservice2
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DebitCardDto, DebitCard>();
            CreateMap<UserDto, User>()
              .ForMember(x => x.PasswordHash, x => x.MapFrom(x => UsersManager.GetPasswordHash(x.Password)));

            CreateMap<BookDto, Book>()
                 .ForMember(x => x.Id, x => x.MapFrom(x => Guid.NewGuid()));
        }
    }
}
