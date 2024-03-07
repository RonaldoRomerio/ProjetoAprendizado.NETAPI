using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.Authentication.JWTAuth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace curriculumManager.src.application.services
{
    public class TokenService
    {
        public static string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var keyByte = Encoding.ASCII.GetBytes(Configuration.secretKey);

            var crendentials = new SigningCredentials(
                new SymmetricSecurityKey(keyByte),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = generateClaims(user),
                SigningCredentials = crendentials,
                Expires = DateTime.UtcNow.AddHours(2)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
        private static ClaimsIdentity generateClaims(User user)
        {
            var claimsIndentity = new ClaimsIdentity();
            claimsIndentity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
            claimsIndentity.AddClaim(new Claim(ClaimTypes.Role, user.Roles.ToString()));
            return claimsIndentity;
        }
    }
}
