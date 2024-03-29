using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        public SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration { get; }

        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var baseUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email, user.Senha);

                var acessos = string.Join(",",  baseUser.Role.RolePermissions.Select(p => p.Permission.Slug).ToArray());
                var permissions = baseUser.Role.RolePermissions.Select(p => p.Permission.Slug).ToArray();

                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {

                    var claims = new List<Claim>();
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Email));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, baseUser.Id.ToString()));

                    claims.Add(new Claim(JwtRegisteredClaimNames.NameId, baseUser.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Sid, baseUser.Id.ToString()));
                    claims.Add(new Claim("UserID", baseUser.Id.ToString()));
                    claims.Add(new Claim("Name", baseUser.Name));

                    foreach(var permission in permissions) {
                        claims.Add(new Claim("Permissions", permission));
                    }

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Claims");


                    ClaimsIdentity identity1 = new ClaimsIdentity(
                        new GenericIdentity(user.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, baseUser.Id.ToString()),

                            // new Claim("Policy", acessos),

                            new Claim(JwtRegisteredClaimNames.NameId, baseUser.Id.ToString()),
                            new Claim(ClaimTypes.Sid, baseUser.Id.ToString()),
                            new Claim("UserID", baseUser.Id.ToString()),
                            new Claim("Name", baseUser.Name),

                        }

                    );
                    // foreach(var permission in permissions) {
                    //     identity.Claims.Append(new Claim("", permission));
                    // }

                    // identity. = baseUser.Id.ToString();

                    DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, baseUser);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        public async Task<object> VerifyToken(string token)
        {
            // var stream ="[encoded jwt]";  
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            Guid id = new Guid();
            foreach (Claim ci in tokenS.Claims)
            {
                if (ci.Type == "nameid")
                    id = Guid.Parse(ci.Value);
            }
            var user = await _repository.FindById(id);

            return new
            {
                validToken = true,
                email = user.Email,
                name = user.Name,
                role = user.Role.Name,
                permissions = user.Role.RolePermissions.Select(p => p.Permission.Slug).ToArray(),
                id = user.Id,
            };
        }
        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                email = user.Email,
                name = user.Name,
                role = user.Role.Name,
                permissions = user.Role.RolePermissions.Select(p => p.Permission.Slug).ToArray(),
                id = user.Id,
                message = "Usuário Logado com sucesso"
            };
        }


    }
}
