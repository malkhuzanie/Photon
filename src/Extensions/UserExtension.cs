using Photon.Models;

namespace Photon.Extensions;

public static class UserExtension
{
  public static void UpdateFrom(this User user, User newUser, Action<User>? modify = null)
  {
    user.Username = newUser.Username;
    user.FirstName = newUser.FirstName;
    user.LastName = newUser.LastName;
    user.Email = newUser.Email;
    user.Image = newUser.Image;
    user.HourlyWage = newUser.HourlyWage;
    user.HireDate = newUser.HireDate;
    user.Facility = newUser.Facility;
    user.Equipment = newUser.Equipment;
    user.Roles = newUser.Roles;

    modify?.Invoke(user);
  }
}