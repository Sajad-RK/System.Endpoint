using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ScheduledJobs.Jobs
{
    public class ClearFileJob : BackgroundService
    {
        IConfiguration configuration;
        ILogger<ClearFileJob> logger;
        string path = @"C:\temp\log.txt";
        public ClearFileJob(IConfiguration _configuration, ILogger<ClearFileJob> _logger)
        {
            logger = _logger;
            configuration = _configuration;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ClearFile();
                await Task.Delay(int.Parse(configuration.GetSection("ClearFileJobTimePeriod").Value), stoppingToken);
            }
        }

        private void ClearFile()
        {
            System.IO.File.WriteAllText(path, string.Empty);
        }

    }
}
