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
    //public class DateTimeReminderJobs : IHostedService, IDisposable
    //{
    //    IConfiguration _configuration;
    //    ILogger<DateTimeReminderJobs> _logger;
    //    private Timer _timer;
    //    string path = @"C:\temp\log.txt";
    //    public DateTimeReminderJobs(IConfiguration config, ILogger<DateTimeReminderJobs> logger)
    //    {
    //        _configuration = config;
    //        _logger = logger;
    //    }
    //    private void HourlyReminder(object state)
    //    {
    //        //string path = @"C:\temp\log.txt";
    //        try
    //        {
    //            IO.File.AppendAllText(path, string.Format("HourlyReminder executes on {0}", DateTime.Now.ToString() + Environment.NewLine));
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogInformation(Environment.NewLine + DateTime.Now.ToString() + " / " + ex.Message);
    //        }

    //    }


    //    public Task StartAsync(CancellationToken cancellationToken)
    //    {
    //        _timer = new Timer(HourlyReminder, null, 0, int.Parse(_configuration.GetSection("JobOccuranceInMinutes").Value));
    //        return Task.CompletedTask;
    //    }

    //    public Task StopAsync(CancellationToken cancellationToken)
    //    {
    //        IO.File.AppendAllText(path, string.Format("HourlyReminder stopped at {0}", DateTime.Now.ToString()));
    //        _timer.Change(Timeout.Infinite, 0);
    //        return Task.CompletedTask;
    //    }

    //    public void Dispose()
    //    {
    //        _timer?.Dispose();
    //    }
    //}
    public class DateTimeReminderJobs : BackgroundService//IHostedService, IDisposable
    {
        IConfiguration _configuration;
        ILogger<DateTimeReminderJobs> _logger;
        //private Timer _timer;
        string path = @"C:\temp\log.txt";
        public DateTimeReminderJobs(IConfiguration config, ILogger<DateTimeReminderJobs> logger)
        {
            _configuration = config;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //string str =_configuration["JobOccuranceInMinutes"];
                HourlyReminder();
                await Task.Delay(int.Parse(_configuration.GetSection("JobOccuranceInMinutes").Value), stoppingToken);
            }
        }
        private void HourlyReminder()
        {
            //string path = @"C:\temp\log.txt";
            try
            {
                IO.File.AppendAllText(path, string.Format("HourlyReminder executes on {0}", DateTime.Now.ToString() + Environment.NewLine));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(Environment.NewLine + DateTime.Now.ToString() + " / " + ex.Message);
            }

        }
        private void HourlyReminder(object state)
        {
            //string path = @"C:\temp\log.txt";
            try
            {
                IO.File.AppendAllText(path, string.Format("HourlyReminder executes on {0}", DateTime.Now.ToString() + Environment.NewLine));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(Environment.NewLine + DateTime.Now.ToString() + " / " + ex.Message);
            }

        }


        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    _timer = new Timer(HourlyReminder, null, 0, int.Parse(_configuration.GetSection("JobOccuranceInMinutes").Value));
        //    return Task.CompletedTask;
        //}

        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    IO.File.AppendAllText(path, string.Format("HourlyReminder stopped at {0}", DateTime.Now.ToString()));
        //    _timer.Change(Timeout.Infinite, 0);
        //    return Task.CompletedTask;
        //}

        //public void Dispose()
        //{
        //    _timer?.Dispose();
        //}

    }
}
