using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Photon.DTOs.Request;

namespace Photon.Services;

public class AuthService(UserService service, IConfiguration config)
{
  public async Task<string> GenerateToken(UserLoginDto login)
  {
    var claims = new List<Claim> { new(ClaimTypes.NameIdentifier, login.Username) };

    (await service.GetRoles(login.Username)).ToList()
      .ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role.Name)));
      
    return await Task.Run(() =>
    {
      var token = new JwtSecurityToken(
        config["Jwt:Issuer"],
        config["Jwt:Audience"],
        claims,
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
