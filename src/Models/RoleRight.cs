using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace wms.Models;

public class RoleRight 
{
  public long Id { get; set; }
  public long RoleId { get; set; }
  public long PermissionId { get; set; }
  public required Role Role { get; set; }
  public required Permission Permission { get; set; }
}
