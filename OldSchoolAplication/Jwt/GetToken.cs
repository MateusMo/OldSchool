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
        private readonly string _secretKey;
        private readonly string _issuer; 
        private readonly string _audience; 

        public GetToken( string secretKey,string issuer, string audience)
        {
            _secretKey = secretKey; 
            _issuer = issuer;
            _audience = audience;
        }

        public async Task<string> GenerateToken(UserDomain user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Nickname),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "User")     
                }),
                Expires = DateTime.UtcNow.AddHours(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _issuer, 
                Audience = _audience 
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); 
        }
    }
}
