using HotelReservationApi.DTOs.Users;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelReservationApi.Services
{
    public static class TokenGenerator
    {
        public static string GenerateToken(UserDTO userDTO) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokeDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userDTO.Id.ToString()),
                    new Claim("Role", userDTO.Role),
                    new Claim(ClaimTypes.Name, userDTO.UserName)
                }),
                Expires = DateTime.Now.AddHours(1),
                Issuer = "HotelReservationSystem",
                Audience = "HotelReservationSystem-Users",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("qPBB70yxYUSy5ievCLDNEItuIR69qBDhCcC7/8eFhhU=")), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokeDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
