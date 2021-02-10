using Api.Domain.Dtos.Associate;
using Api.Domain.Dtos.Elected;
using Api.Domain.Dtos.Election;
using Api.Domain.Dtos.Member;
using Api.Domain.Dtos.Office;
using Api.Domain.Dtos.Permission;
using Api.Domain.Dtos.Role;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User
            CreateMap<UserDto, UserEntity>()
               .ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>()
               .ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>()
               .ReverseMap();
            #endregion

            #region Role
            CreateMap<RoleDto, RoleEntity>()
               .ReverseMap();
            #endregion

            #region Permission
            CreateMap<PermissionDto, PermissionEntity>()
               .ReverseMap();
            #endregion

            #region Member
            CreateMap<MemberDto, MemberEntity>()
               .ReverseMap();
            CreateMap<MemberDtoCreateResult, MemberEntity>()
               .ReverseMap();
            CreateMap<MemberDtoUpdateResult, MemberEntity>()
               .ReverseMap();
            #endregion

            CreateMap<AssociateDto, AssociateEntity>()
               .ReverseMap();

            CreateMap<ElectedDto, ElectedEntity>()
               .ReverseMap();

            #region Office
            CreateMap<OfficeDto, OfficeEntity>()
               .ReverseMap();
            CreateMap<OfficeDtoCreateResult, OfficeEntity>()
               .ReverseMap();
            CreateMap<OfficeDtoUpdateResult, OfficeEntity>()
               .ReverseMap();
            #endregion

            #region Election
            CreateMap<ElectionDto, ElectionEntity>()
               .ReverseMap();
            CreateMap<ElectionDtoCreateResult, ElectionEntity>()
               .ReverseMap();
            CreateMap<ElectionDtoUpdateResult, ElectionEntity>()
               .ReverseMap();
            #endregion

        }
    }
}
