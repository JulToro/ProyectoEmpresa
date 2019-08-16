using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasks = System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Ecommerce.ShippingExito.Tracking.Infrastructure.Data.Context;

namespace Ecommerce.ShippingExito.Tracking.Task.Background
{
    public class BackgroundService : IHostedService
    {
        public IServiceProvider Services { get; }
        public BackgroundService(IServiceProvider services)
        {
            Services = services;
        }
        

        public Tasks.Task StartAsync(CancellationToken stoppingToken)
        {
            RunTask();
            return  Tasks.Task.CompletedTask;
        }
        

        public  Tasks.Task StopAsync(CancellationToken cancellationToken)
        {
            return Tasks.Task.CompletedTask;
        }

        public void Dispose()
        {
            //_stoppingCts.Cancel();
        }

        private void RunTask()
        {

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedProcessingService>();

                    
                scopedProcessingService.RunTask();
            }
        }
    }
}
