using Api.Domain.Interfaces.Services.Associate;
using Api.Domain.Interfaces.Services.Elected;
using Api.Domain.Interfaces.Services.Election;
using Api.Domain.Interfaces.Services.Member;
using Api.Domain.Interfaces.Services.Office;
using Api.Domain.Interfaces.Services.Permission;
using Api.Domain.Interfaces.Services.Role;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IRoleService, RoleService>();
            serviceCollection.AddTransient<IPermissionService, PermissionService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IMemberService, MemberService>();
            serviceCollection.AddTransient<IAssociateService, AssociateService>();
            serviceCollection.AddTransient<IElectedService, ElectedService>();
            serviceCollection.AddTransient<IOfficeService, OfficeService>();
            serviceCollection.AddTransient<IElectionService, ElectionService>();
        }
    }
}
