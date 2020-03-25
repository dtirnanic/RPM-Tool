using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RPM_Tool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

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
            var msgs = new Dictionary<int, string>()
            {
                { 2, "this is a friendly reminder to pay your rent by the 5th" },
                { 6, "your rent is now late and a $25 fee has been applies to this months balance" },
                { 8, "an eviction notice has been placed on your front door due to rent not being paid" }
            };

            //if rent is not paid by the 2nd 
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var units = dbContext.Units;
                var today = DateTime.Today;
                if (today.Day == 2 || today.Day == 6 || today.Day == 8 )
                {
                    foreach (var unit in units)
                    {
                        if (unit.RentPaid == false)
                        {
                            var tenant = dbContext.Tenants.Where(t => t.UnitId == unit.Id).FirstOrDefault();
                            var to = new PhoneNumber($"+1{tenant.PhoneNumber}");
                            var message = MessageResource.Create(
                                to,
                                from: new PhoneNumber(@"+15109747715"),  //twilio number
                                body: $"{tenant.FirstName} {tenant.LastName} {msgs[today.Day]}");

                        }
                    }
                }
            }
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
    //--Resources for NotificationServices--
    // Backround tasks with hosted services
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio
    // Inject ApplicationDbContext into IHostedService
    //https://stackoverflow.com/questions/48368634/how-should-i-inject-a-dbcontext-instance-into-an-ihostedservice
}
