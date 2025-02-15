using Hangfire;
using Microsoft.EntityFrameworkCore;
using SyncHub.Domain.Repositories;
using SyncHub.Infrastructure.Data;
using SyncHub.Infrastructure.Data.Repositories;
using SyncHub.Jobs.Interfaces;
using SyncHub.Jobs.Jobs;
using SyncHub.Jobs.Services;
using SyncHub.WorkerService;

var builder = Host.CreateApplicationBuilder(args);
//register db
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(connectionString));

//Register repository
builder.Services.AddTransient<IDeckRepository, DeckRepository>();
builder.Services.AddTransient<ICardRepository, CardRepository>();


//Register services
builder.Services.AddHttpClient<IDeckOfCardsService, DeckOfCardsService>();

//Register job
builder.Services.AddScoped<DeckOfCardsJob>();

//add Hangfire
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connectionString);
});
builder.Services.AddHangfireServer();

//Add worker
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
