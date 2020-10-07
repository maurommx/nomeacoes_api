using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>()
               .ReverseMap();

            CreateMap<MemberModel, MemberEntity>()
               .ReverseMap();

            CreateMap<AssociateModel, AssociateEntity>()
               .ReverseMap();

            CreateMap<ElectedModel, ElectedEntity>()
               .ReverseMap();

            CreateMap<OfficeModel, OfficeEntity>()
               .ReverseMap();

            CreateMap<ElectionModel, ElectionEntity>()
               .ReverseMap();

        }
    }
}
