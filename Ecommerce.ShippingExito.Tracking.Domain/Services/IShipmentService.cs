using Ecommerce.ShippingExito.Tracking.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Domain.Services
{
    public interface IShipmentService
    {
        IEnumerable<ShipmentState> GetShippingStates();

        IEnumerable<Shipment> GetShipments(int carrierId);

        Task<IEnumerable<Shipment>> ProcessShippments(Carrier carrier, List<Shipment> shippments, List<ShipmentState> listShipmentState);

        bool SaveStatusShippments(List<Shipment> shipments);
    }
}
                                                                            