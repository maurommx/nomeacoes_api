using Api.Domain.Dtos.Associate;
using Api.Domain.Dtos.Elected;
using Api.Domain.Dtos.Election;
using Api.Domain.Dtos.Member;
using Api.Domain.Dtos.Office;
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

            CreateMap<OfficeDto, OfficeEntity>()
               .ReverseMap();

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