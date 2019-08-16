using Ecommerce.ShippingExito.Tracking.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Domain.Services
{
    public interface ICarrierServices
    {
        IEnumerable<Carrier> GetCarriers();        
    }
}
