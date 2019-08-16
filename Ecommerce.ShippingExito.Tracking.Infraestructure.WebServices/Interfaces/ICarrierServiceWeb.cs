using Ecommerce.ShippingExito.Tracking.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Interfaces
{
    public interface ICarrierServiceWeb
    {
        bool CreateEntityResource();

        Task<IEnumerable<Shipment>> GetShippingStatus();

    }
}
