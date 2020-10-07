using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IMemberRepository, MemberImplementation>();
            serviceCollection.AddScoped<IAssociateRepository, AssociateImplementation>();
            serviceCollection.AddScoped<IElectedRepository, ElectedImplementation>();
            serviceCollection.AddScoped<IOfficeRepository, OfficeImplementation>();
            serviceCollection.AddScoped<IElectionRepository, ElectionImplementation>();


            serviceCollection.AddDbContext<MyContext>(
                options => options.UseNpgsql("Server=192.168.0.17;Port=5432;Database=nomeacoes;User Id=postgres;Password=P@ssword00;")
            );


            //if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
            //{
            //    serviceCollection.AddDbContext<MyContext>(
            //        options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
            //    );
            //}
            //else
            //{
            //    serviceCollection.AddDbContext<MyContext>(
            //        options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
            //    );
            //}
        }
    }
}
