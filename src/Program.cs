using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Logging;
using Photon.Data;
using Photon.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.SetupAuthentication();
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.CreateDbIfNotExists();
app.UseHttpsRedirection();
app.UseExceptionHandler(_ => {});

// app.UseAuthentication();
// app.UseAuthorization();

// app.MapControllers().RequireAuthorization();
app.MapControllers();
app.Run();
