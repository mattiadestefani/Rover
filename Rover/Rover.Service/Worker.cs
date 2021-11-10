using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rover.Engine;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rover.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configurazione;
        private readonly Navigatore _navigator;

        public Worker(ILogger<Worker> logger,IConfiguration configuration, Navigatore navigator)
        {
            _logger = logger;
            _configurazione = configuration;
            _navigator = navigator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _navigator.SetPianeta();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _navigator.StartRoverAction();
                await Task.Delay(TimeSpan.FromSeconds(Convert.ToDouble(_configurazione["jobTime"])), stoppingToken);
            }
        }
    }
}
