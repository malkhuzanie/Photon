using Photon.Data;
using Photon.Services;
using Photon.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Host.SerilogConfiguration();
builder.Services.SetupAuthentication();
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.CreateDbIfNotExists();
app.UseHttpsRedirection();
app.UseExceptionHandler(_ => {});

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

// app.MapControllers().RequireAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notificationHub");

app.Run();
