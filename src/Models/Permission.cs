using Microsoft.EntityFrameworkCore;

namespace wms.Models;

public class Permission 
{
  public long Id { get; set; }
  public required string Name { get; set; }
}
