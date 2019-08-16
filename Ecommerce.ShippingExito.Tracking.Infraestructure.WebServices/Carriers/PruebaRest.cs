using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Carriers
{
    public class PruebaRest : ICarrierServiceWeb
    {
        public bool CreateEntityResource()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shipment>> GetShippingStatus()
        {
            throw new NotImplementedException();
        }
    }
}
