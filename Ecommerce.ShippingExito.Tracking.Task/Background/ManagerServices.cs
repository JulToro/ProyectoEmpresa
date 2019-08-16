using Ecommerce.ShippingExito.Tracking.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tasks = System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Task.Background
{
    public class ManagerServices : IScopedProcessingService// , BackgroundService
    {
        private System.Threading.Timer _timer;
        private readonly ITrackingService _iTrackingService;

        public ManagerServices(ITrackingService iTrackingService)//    : base(serviceScopeFactory)
        {
            _iTrackingService = iTrackingService;
        }

        public async void RunTask()
        {

            var method = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName;

            string Message = $"Inicio Proceso";

            
            //// Generamos alarmas de acuerdo a los acumulados
            await _iTrackingService.TrackingProcess();

            Message = $"FinalizaProceso";
            Console.WriteLine($"{Message}");
        }

        public void Dispose()
        {
        }
    }
}
