using AutoMapper;
using Domain.Interfaces.QueryOptions;
using Api.Domain.Interfaces.QueryOptions;
using Api.Domain.QueryOptions;

namespace Api.Crosscutting.Mappings
{
    public class OthersMappings : Profile
    {
        public OthersMappings() {
        // CreateMap<, RoleDto>()
        //         .ReverseMap();
            CreateMap<IQueryOptionsInput, IQueryOptions>()
                .ReverseMap();
            CreateMap<QueryOptionsInput, QueryOptions>()
                .ReverseMap();
        }
    }
}