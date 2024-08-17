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
using Microsoft.EntityFrameworkCore;
using Photon.Interfaces;
using Photon.Services.ReportServices;
using Photon.srs.Services;

namespace Photon.Services;

public static class Extensions
{
  private static IConfiguration Config { get; } = new ConfigurationBuilder()
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
            Encoding.UTF8.GetBytes(Config["Jwt:Key"]!)
          )
        };
        options.Events = new JwtBearerEvents
        {
          OnMessageReceived = context =>
          {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/notificationHub")))
            {
              context.Token = accessToken;
            }
            return Task.CompletedTask;
          }
        };
      });
  }

  public static void SerilogConfiguration(this IHostBuilder host)
  {
    host.UseSerilog((context, loggerConfig) => { loggerConfig.WriteTo.Console(); });
  }

  public static void RegisterServices(this IServiceCollection services)
  {
    services.AddExceptionHandler<ExceptionHandler>();

    services.AddCors(options =>
    {
      options.AddPolicy("AllowAll", builder =>
      {
        builder
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(_ => true)
          .AllowCredentials();
      });
    });

    services.AddSignalR();

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

    services.AddDbContextFactory<PhotonContext>(options =>
    {
      options.UseNpgsql(
          $"""
          User ID={Config["DbConfig:UserId"]};
          Host={Config["DbConfig:Host"]}; 
          Password={Config["DbConfig:Password"]}; 
          Database={Config["DbConfig:Database"]};
          Include Error Detail=true
          """)
      .UseLazyLoadingProxies()
      .UseSnakeCaseNamingConvention()
      .EnableSensitiveDataLogging();
    });
    
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
    services.AddScoped<ItemMasterService>();
    services.AddScoped<MaterialService>();
    services.AddScoped<ContainerService>();
    services.AddScoped<ReportService>();
    services.AddScoped<InboundPurchaseOrderService>();
    services.AddScoped<InboundPurchaseOrderStatusService>();
    services.AddScoped<OutboundPurchaseOrderService>();
    services.AddScoped<OutboundPurchaseOrderStatusService>();
    services.AddScoped<PickListService>();
    services.AddScoped<PickListItemService>();
    services.AddScoped<ItemPickupStatusService>();
    services.AddScoped<InboundPurchaseOrderReportService>();
    services.AddScoped<OutboundPurchaseOrderReportService>();
    services.AddScoped<PurchaseOrderService>();
  }
}