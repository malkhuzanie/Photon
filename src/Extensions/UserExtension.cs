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
  
  public static bool IsEmployee(this User user)
  {
    return user.Roles.Any(
      r => r.Name.Equals("employee", StringComparison.CurrentCultureIgnoreCase)
    );
  }

  public static bool IsShippingEmployee(this User user)
  {
    return user.Roles.Any(
      r => r.Name.Equals("shipping", StringComparison.CurrentCultureIgnoreCase)
    );
  }
  
  public static bool IsReceivingEmployee(this User user)
  {
    return user.Roles.Any(
      r => r.Name.Equals("receiving", StringComparison.CurrentCultureIgnoreCase)
    );
  }
}
