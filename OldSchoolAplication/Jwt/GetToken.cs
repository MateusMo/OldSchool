using Microsoft.IdentityModel.Tokens;
using OldSchoolDomain.Domain;
using OldSchoolInfrastructure.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Jwt
{
    public class GetToken : IGetToken
    {
        private readonly IUserRepository _userRepo;
        private readonly string _secretKey;

        public GetToken(IUserRepository userRepo, string secretKey)
        {
            _userRepo = userRepo;
            _secretKey = secretKey; // Chave secreta para assinar o token JWT
        }

        public async Task<string> GenerateToken(UserDomain user)
        {

            // Criar o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Nickname), // Adicionando o nickname como claim
                    new Claim(ClaimTypes.Role, "User")     // Você pode adicionar mais claims, como o papel do usuário
                }),
                Expires = DateTime.UtcNow.AddHours(1), // O token expira em 1 hora
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // Retorna o token como string
        }
    }
}
