using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.ShippingExito.Tracking.Domain.Services;
using Ecommerce.ShippingExito.Tracking.DomainEntities;

namespace Ecommerce.ShippingExito.Tracking.Application.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly ITrackingDomainService _iTrackingDomainService;

        public TrackingService(ITrackingDomainService iTrackingDomainService)
        {
            _iTrackingDomainService = iTrackingDomainService;
        }

        public async Task<bool> TrackingProcess()
        {
            return await _iTrackingDomainService.TrackingProcess();
        }
    }
}
