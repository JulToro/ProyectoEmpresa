using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.ShippingExito.Tracking.Domain.Repositories;
using Ecommerce.ShippingExito.Tracking.DomainEntities;

namespace Ecommerce.ShippingExito.Tracking.Domain.Services
{
    public class TrackingDomainService : ITrackingDomainService
    {
        private readonly IShipmentService _iShipmentService;
        private readonly ICarrierServices _iCarrierService;

        public TrackingDomainService(IShipmentService shipmentService, ICarrierServices carrierService)
        {
            _iShipmentService = shipmentService;
            _iCarrierService = carrierService;
        }

        /// <summary>
        /// Realiza el proceso de tracking
        /// </summary>
        /// <returns></returns>
        public async Task<bool> TrackingProcess()
        {
            try
            {
                List<Carrier> carriers = _iCarrierService.GetCarriers().ToList();
                if(carriers != null)
                {
                    foreach (Carrier carrier in carriers)
                    {
                        List<Shipment> shipments = _iShipmentService.GetShipments(carrier.CarrierId).ToList();

                        if (shipments != null && shipments.Count > 0)
                        {
                            List<ShipmentState> listShipmentState = _iShipmentService.GetShippingStates().ToList();

                            var updatedShipments = await _iShipmentService.ProcessShippments(carrier, shipments, listShipmentState);

                            if(updatedShipments != null)
                            {
                                _iShipmentService.SaveStatusShippments(updatedShipments.ToList());
                            }

                        }
                       
                        //return _iShipmentService.SaveStatusShippments(listShippments.ToList());
                        //ListShippment.ToList();
                        var x = "";
                        
                    }
                }   
            }
            catch (Exception ex)
            {
                //throw ex;
            }

            return true;
        }
    }
}
