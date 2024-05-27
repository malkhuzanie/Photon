using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Photon.DTOs;
namespace Photon.Services;

public class AuthService(UserService service, IConfiguration config)
{
  public async Task<string> GenerateToken(UserLoginDto login)
  {
    return await Task.Run(() =>
    {
      var token = new JwtSecurityToken(
        config["Jwt:Issuer"],
        config["Jwt:Audience"],
        null,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: new SigningCredentials(
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
          SecurityAlgorithms.HmacSha256
        )
      );
      return new JwtSecurityTokenHandler().WriteToken(token);
    });
  }
  
  public async Task<bool> Authenticate(UserLoginDto login)
  {
    var id = await service.UsernameExists(login.Username);
    if (id == null)
    {
      return false;
    }
    return await service.CheckPassword(id.Value, login.Password);
  }
}
