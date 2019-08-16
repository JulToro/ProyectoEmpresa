using Ecommerce.ShippingExito.Tracking.Domain.Repositories;
using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Services;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Interfaces;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Clients;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Services
{
    public class ShipmentStatusService : IWebIShipmentStatusServices
    {
        public async Task<IEnumerable<Shipment>> ProcessStatusServicesWeb(Carrier carrier, List<Shipment> shippments, List<ShipmentState> listShipmentState)
        {

            try
            {
                IServiceWebFactory iServiceWebFactory = new TypesServicesWeb();
                ServicesClient serviceWeb = new ServicesClient(iServiceWebFactory, carrier, shippments, listShipmentState);

                return await serviceWeb.ProcessShippment();
            }
            catch (Exception ex) {
                return null;
            }

            
        }
    }
}
