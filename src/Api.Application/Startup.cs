using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Filters;
using Api.Application.Middleware;
using Api.Crosscutting.Mappings;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            if (_environment.IsEnvironment("Testing"))
            {
                Environment.SetEnvironmentVariable("DB_CONNECTION", "Server=localhost;Port=5432;Database=nomeacoes;User Id=postgres;Password=postgres;");
                Environment.SetEnvironmentVariable("DATABASE", "PGSQL");
                Environment.SetEnvironmentVariable("MIGRATION", "APLICAR");
                Environment.SetEnvironmentVariable("Audience", "ExemploAudience");
                Environment.SetEnvironmentVariable("Issuer", "ExemploIssue");
                Environment.SetEnvironmentVariable("Seconds", "28800");
            }

            // services.AddCors(c => 
            // {
                
            //     c.AllowAnyMethod()
            //     .AllowAnyHeader()
            //     .AllowCredentials()
            //     .AllowAnyOrigin()
                
            // });


            // services.AddCors(options =>
            //     options.AddDefaultPolicy(builder =>
            //     {
            //         builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
            //     })
            // );

            // services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddCors(options =>
                        {
                            options.AddPolicy(name: MyAllowSpecificOrigins, builder => builder
                                .WithOrigins(
                                    "http://localhost:9090",
                                    "http://127.0.0.1:5000",
                                    "http://127.0.0.1:8080",
                                    "http://127.0.0.1:5432",
                                    "http://127.0.0.1",
                                    "http://localhost:9090",
                                    "http://localhost:5000",
                                    "http://localhost:8080",
                                    "http://localhost5432",
                                    "http://localhost",
                                    "http://192.168.100.104:9090",
                                    "http://192.168.100.104:5000",
                                    "http://192.168.100.104:8080",
                                    "http://192.168.100.104:5432",
                                    "http://192.168.100.104"

                                )
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials()
                            // .AllowAnyOrigin()
                            );
                        });


            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new OthersMappings());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);


            services.AddAuthentication(authOptions =>
                        {
                            authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        }).AddJwtBearer(bearerOptions =>
                        {
                            var paramsValidation = bearerOptions.TokenValidationParameters;
                            paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                            paramsValidation.ValidAudience = Environment.GetEnvironmentVariable("Audience");
                            paramsValidation.ValidIssuer = Environment.GetEnvironmentVariable("Issuer");

                            // Valida a assinatura de um token recebido
                            paramsValidation.ValidateIssuerSigningKey = true;

                            // Verifica se um token recebido ainda é válido
                            paramsValidation.ValidateLifetime = true;

                            // Tempo de tolerância para a expiração de um token (utilizado
                            // caso haja problemas de sincronismo de horário entre diferentes
                            // computadores envolvidos no processo de comunicação)
                            paramsValidation.ClockSkew = TimeSpan.Zero;
                        });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
            

            // services.AddSwaggerGenNewtonsoftSupport(); 

            services.AddSwaggerGen(c =>
            {
                // c.DescribeAllEnumsAsStrings();

                // c.IgnoreObsoleteProperties();

                c.SchemaFilter<SwaggerSkipPropertyFilter>();
                
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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });



            // services.AddCors(options =>
            //     options.AddPolicy("AnotherPolicy", builder =>
            //     {
            //         builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //     })
            // );

            // services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseCors(MyAllowSpecificOrigins);
            // app.UseCorsMiddleware();

            // app.UseMvc();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API para Comissão de Nomeações");
                c.RoutePrefix = string.Empty;
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            // app.UseCors(option => option.AllowAnyOrigin());
            // app.UseCors();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/echo", context => context.Response.WriteAsync("echo"))
                .RequireCors(MyAllowSpecificOrigins);

                endpoints.MapControllers()
                    .RequireCors(MyAllowSpecificOrigins);

                endpoints.MapGet("/echo2", context => context.Response.WriteAsync("echo2"));


            });
        }
    }
}
