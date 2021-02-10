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

            CreateMap<RoleModel, RoleEntity>()
               .ReverseMap();

            CreateMap<PermissionModel, PermissionEntity>()
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
