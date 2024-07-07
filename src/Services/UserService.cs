using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;
using Photon.DTOs;
using Photon.Mapping;
using Photon.Encryption;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;

namespace Photon.Services;

public class UserService(PhotonContext context) : IEntityService<User, UserDto>
{
  public async Task<int?> UsernameExists(string username)
  {
    return (await context.Users.Where(u => u.Username == username)
        .FirstOrDefaultAsync())
      ?.Id;
  }

  public async Task<bool> CheckPassword(int id, string password)
  {
    return await Hasher.VerifyPassword(
      (await context.Users.SingleAsync(u => u.Id == id)).PasswordHash,
      password);
  }
  
  public async Task<IEnumerable<User>> GetAll()
  {
    return await context.Users.Include(u => u.Facility)
      .Include(u => u.Equipment)
      .Include(u => u.Roles)
      .ThenInclude(r => r.Permissions)
      .AsNoTracking()
      .ToListAsync();
  }

  public async Task<User?> GetById(int id)
  {
    return await context.Users.Include(u => u.Facility)
      .Include(u => u.Equipment)
      .Include(u => u.Roles)
      .ThenInclude(r => r.Permissions)
      .AsNoTracking()
      .SingleOrDefaultAsync(u => u.Id == id);
  }

  public async Task<User> Create(UserDto _user)
  {
    var user = await _user.ToUser(context);
    if (await UsernameExists(user.Username) != null)
    {
      throw new IllegalArgumentException("username already exists");
    }

    context.Add(user);
    await context.SaveChangesAsync();
    return user;
  }

  public async Task<bool> Delete(int id)
  {
    if (await context.Users.FindAsync(id) is not { } user)
    {
      return false;
    }

    context.Users.Remove(user);
    await context.SaveChangesAsync();
    return true;
  }

  public async Task Update(int id, UserDto _user)
  {
    var user = await context.Users.Include(u => u.Facility)
      .Include(u => u.Equipment)
      .Include(u => u.Roles)
      .ThenInclude(r => r.Permissions)
      .SingleOrDefaultAsync(u => u.Id == id);

    if (user == null)
    {
      throw new NotFoundException("user is not found in the database");
    }
    
    user.UpdateFrom(
      await _user.ToUser(context),
      (usr) => { usr.Password = _user.Password; }
    );
    await context.SaveChangesAsync();
  }
}
