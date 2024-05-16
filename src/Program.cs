using Photon.Data;
using Photon.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseMiniProfiler();

app.CreateDbIfNotExists();
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
