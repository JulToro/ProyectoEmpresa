using Ecommerce.ShippingExito.Tracking.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Domain.Repositories
{
    public interface IWebIShipmentStatusServices
    {
        Task<IEnumerable<Shipment>> ProcessStatusServicesWeb(Carrier carrier, List<Shipment> shippments, List<ShipmentState> listShipmentState);
    }
}
