using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;
using Photon.DTOs;
using Photon.Mapping;

namespace Photon.Services;

public class UserService(PhotonContext context)
{
  public async Task<bool> UsernameExists(string username)
  {
    return await context.Users
      .Where(u => u.Username == username)
      .FirstOrDefaultAsync() != null;
  }
  
  public async Task<IEnumerable<User>> GetAll()
  {
    return await context.Users
      .Include(u => u.Facility)
      .Include(u => u.Equipment)
      .Include(u => u.Roles)
      .ThenInclude(r => r.Permissions)
      .AsNoTracking()
      .ToListAsync();
  }

  public async Task<User?> GetById(int id)
  {
    return await context.Users
      .Include(u => u.Facility)
      .Include(u => u.Equipment)
      .Include(u => u.Roles)
      .ThenInclude(r => r.Permissions)
      .AsNoTracking()
      .SingleOrDefaultAsync(u => u.Id == id);
  }

  public async Task<MappingResult<User>> Create(UserDto _user)
  {
    var user = await _user.FromDto(context);
    if (user.Result != null)
    {
      if (await UsernameExists(user.Result.Username))
      {
        return new MappingResult<User>("username exists", null);
      }
      context.Add(user.Result);
      await context.SaveChangesAsync();
    }
    return user;
  }
}
