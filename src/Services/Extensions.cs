using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Photon.Data;
using Photon.Exceptions;
using Photon.Models;
using Photon.src.Models;
using Photon.src.Services;
using Serilog;
using System.Reflection;
using Photon.Interfaces;

namespace Photon.Services;

public static class Extensions
{
  static IConfiguration Config { get; } = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .Build();

  public static void SetupAuthentication(this IServiceCollection services)
  {
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = Config["Jwt:Issuer"],
          ValidAudience = Config["Jwt:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(Config["Jwt:Key"])
          )
        };
      });
  }

  public static void SerilogConfiguration(this IHostBuilder host)
  {
    host.UseSerilog((context, loggerConfig) =>
    {
      loggerConfig.WriteTo.Console();
    });
  }
  
  public static void RegisterServices(this IServiceCollection services)
  {
    services.AddExceptionHandler<ExceptionHandler>();

    services.AddCors();

    services.AddControllers()
      .AddJsonOptions(options =>
      {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
      });

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
      options.MapType<DateOnly>(() => new OpenApiSchema
      {
        Type = "string",
        Format = "date"
      });
      options.MapType<int>(() => new OpenApiSchema
      {
        Default = new OpenApiInteger(1)
      });
    });

    // mini-profiler
    // services.AddMiniProfiler();
    
    services.AddNpgsql<PhotonContext>("Host=localhost; Database=photon");
    services.AddScoped<FacilityService>();
    services.AddScoped<UserService>();
    services.AddScoped<RoleService>();
    services.AddScoped<AuthService>();
    services.AddScoped<PermissionService>();
    services.AddScoped<EquipmentService>();
    services.AddScoped<SupplierService>();
    services.AddScoped<ContactService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ItemService>();
    services.AddScoped<MaterialService>();
    services.AddScoped<TheContainerService>();
    services.AddScoped<ReportService>();
    services.AddScoped<InboundPurchaseOrderService>();
    services.AddScoped<InboundPurchaseOrderStatusService>();
    services.AddScoped<OutboundPurchaseOrderService>();
    services.AddScoped<OutboundPurchaseOrderStatusService>();
  }
}
