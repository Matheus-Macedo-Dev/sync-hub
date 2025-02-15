using Hangfire;
using SyncHub.Jobs.Jobs;

namespace SyncHub.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RecurringJob.AddOrUpdate<DeckOfCardsJob>(job => job.FetchAndStoreDeckAsync(), Cron.Hourly);
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
