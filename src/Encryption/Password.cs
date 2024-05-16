using Microsoft.AspNetCore.Identity;

namespace Photon.Encryption;

public static class Hasher 
{
  public static async Task<string> Hash(string password)
  {
    return await Task.Run(() => new PasswordHasher<IdentityUser>().HashPassword(
      new IdentityUser { }, password
    ));
  }

  public static async Task<bool> VerifyPassword(string hashed, string password)
  {
    var res = await Task.Run(() =>
      new PasswordHasher<IdentityUser>().VerifyHashedPassword(new IdentityUser { }, hashed,
        password)
    );
    return (res == PasswordVerificationResult.Success ? true : false);
  }
}
