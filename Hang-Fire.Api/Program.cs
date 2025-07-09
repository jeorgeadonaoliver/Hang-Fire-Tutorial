using Hang_Fire.Api.Controllers;
using Hang_Fire.Api.Middleware;
using Hang_Fire.Application;
using Hang_Fire.Application.Interfaces;
using Hang_Fire.Http;
using Hang_Fire.Http.Cat;
using Hang_Fire.Persistence;
using Hang_Fire.Service;
using Hangfire;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build())
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfireServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpClientService();


builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard("/hangfire", new DashboardOptions { 
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
