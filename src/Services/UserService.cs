using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;
using Photon.DTOs;
using Photon.Mapping;
using Photon.Encryption;
using Photon.Exceptions;
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

  public async Task<User?> Find(int id)
  {
    return await context.Users.FindAsync(id);
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

    var u = (await _user.ToUser(context));
    
    user.Username = u.Username;
    user.FirstName = u.FirstName;
    user.LastName = u.LastName;
    user.Email = u.Email;
    user.Password = _user.Password;
    user.Image = u.Image;
    user.HourlyWage = u.HourlyWage;
    user.HireDate = u.HireDate;
    user.Facility = u.Facility;
    user.Equipment = u.Equipment;
    user.Roles = u.Roles;
    
    await context.SaveChangesAsync();
  }
}
