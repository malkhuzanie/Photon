using Microsoft.EntityFrameworkCore;

namespace wms.Models;

public class Role 
{
  public long Id { get; set; }
  public required string Name { get; set; }
}
