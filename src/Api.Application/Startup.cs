using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // var signingConfigurations = new SigningConfigurations();
            // services.AddSingleton(signingConfigurations);


            // services.AddAuthentication(authOptions =>
            //             {
            //                 authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //                 authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //             }).AddJwtBearer(bearerOptions =>
            //             {
            //                 var paramsValidation = bearerOptions.TokenValidationParameters;
            //                 paramsValidation.IssuerSigningKey = signingConfigurations.Key;
            //                 paramsValidation.ValidAudience = Environment.GetEnvironmentVariable("Audience");
            //                 paramsValidation.ValidIssuer = Environment.GetEnvironmentVariable("Issuer");

            //     // Valida a assinatura de um token recebido
            //     paramsValidation.ValidateIssuerSigningKey = true;

            //     // Verifica se um token recebido ainda é válido
            //     paramsValidation.ValidateLifetime = true;

            //     // Tempo de tolerância para a expiração de um token (utilizado
            //     // caso haja problemas de sincronismo de horário entre diferentes
            //     // computadores envolvidos no processo de comunicação)
            //     paramsValidation.ClockSkew = TimeSpan.Zero;
            //             });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            // services.AddAuthorization(auth =>
            // {
            //     auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //         .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            //         .RequireAuthenticatedUser().Build());
            // });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para Comissão de Nomeações",
                    Description = "API para Comissão de Nomeações",
                    // TermsOfService = new Uri("http://www.mfrinfo.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mauro Meneses Xavier",
                        Email = "mauro.mmx@gmail.com",
                        // Url = new Uri("http://www.mfrinfo.com.br")
                    },
                    // License = new OpenApiLicense
                    // {
                    //     Name = "Termo de Licença de Uso",
                    //     Url = new Uri("http://www.mfrinfo.com.br")
                    // }
                });

                // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     Description = "Entre com o Token JWT",
                //     Name = "Authorization",
                //     In = ParameterLocation.Header,
                //     Type = SecuritySchemeType.ApiKey
                // });

                // c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                //     {
                //         new OpenApiSecurityScheme {
                //             Reference = new OpenApiReference {
                //                 Id = "Bearer",
                //                 Type = ReferenceType.SecurityScheme
                //             }
                //         }, new List<string>()
                //     }
                // });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API para Comissão de Nomeações");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
