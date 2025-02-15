using Microsoft.EntityFrameworkCore;
using SyncHub.Application.Applications;
using SyncHub.Application.Applications.Interfaces;
using SyncHub.Application.Services;
using SyncHub.Application.Services.Interfaces;
using SyncHub.Domain.Repositories;
using SyncHub.Infrastructure.Data;
using SyncHub.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Repository Dependency Injection
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddTransient<ICardRepository, CardRepository>();

//Application Dependency Injection
builder.Services.AddScoped<ICardApplication, CardApplication>();

//Service Dependency Injection
builder.Services.AddScoped<ICardService, CardService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
