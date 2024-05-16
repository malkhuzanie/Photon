using System.Text.Json;
using Photon.Data;
namespace Photon.Services;

public static class Extensions
{
  public static void RegisterServices(this IServiceCollection services)
  {
    services.AddControllers().AddJsonOptions(options =>
    {
      options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    });
    
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    
    // mini-profiler
    // services.AddMiniProfiler();
    
    services.AddNpgsql<PhotonContext>("Host=localhost; Database=wms_temp");
    services.AddScoped<UserService>();
    services.AddScoped<RoleService>();
  }
}