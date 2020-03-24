using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RPM_Tool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RPM_Tool.Services
{
    public class NotificationService : IHostedService, IDisposable
    {
        //private int executionCount = 0;
        private readonly ILogger<NotificationService> _logger;
        private Timer _timer;
        private readonly IServiceScopeFactory scopeFactory;

        public NotificationService(ILogger<NotificationService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            this.scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("NotificationService running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //if rent is not paid by the 2nd 

        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("NotificationService is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
    //--Resources for hosted services--
    // Backround tasks with hosted services
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio
    // Inject ApplicationDbContext into IHostedService
    //https://stackoverflow.com/questions/48368634/how-should-i-inject-a-dbcontext-instance-into-an-ihostedservice
}
