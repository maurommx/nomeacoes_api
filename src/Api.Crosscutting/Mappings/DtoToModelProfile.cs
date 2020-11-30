using Api.Domain.Dtos.Associate;
using Api.Domain.Dtos.Elected;
using Api.Domain.Dtos.Election;
using Api.Domain.Dtos.Member;
using Api.Domain.Dtos.Office;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDto>()
                .ReverseMap();
            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();
            #endregion

            #region Member
            CreateMap<MemberModel, MemberDto>()
                .ReverseMap();
            CreateMap<MemberModel, MemberDtoCreate>()
                .ReverseMap();
            CreateMap<MemberModel, MemberDtoUpdate>()
                .ReverseMap();
            #endregion

            #region Elected
            CreateMap<ElectedModel, ElectedDto>()
                .ReverseMap();
            #endregion

            #region Associate
            CreateMap<AssociateModel, AssociateDto>()
                .ReverseMap();
            #endregion

            #region Office
            CreateMap<OfficeModel, OfficeDto>()
                .ReverseMap();
            CreateMap<OfficeModel, OfficeDtoCreate>()
                .ReverseMap();
            CreateMap<OfficeModel, OfficeDtoUpdate>()
                .ReverseMap();
            #endregion

            #region Election
            CreateMap<ElectionModel, ElectionDto>()
                .ReverseMap();
            CreateMap<ElectionModel, ElectionDtoCreate>()
                .ReverseMap();
            CreateMap<ElectionModel, ElectionDtoUpdate>()
                .ReverseMap();
            #endregion


        }

    }
}
