using Ecommerce.ShippingExito.Tracking.Domain.Repositories;
using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Ecommerce.ShippingExito.Tracking.Infraestructure.Common.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Domain.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IDbShipping _iDbShipping;
        private readonly IWebIShipmentStatusServices _iWebShippingServices;

        public ShipmentService(IDbShipping iDbShipping, IWebIShipmentStatusServices iWebShippingServices)
        {
            _iWebShippingServices = iWebShippingServices;
            _iDbShipping = iDbShipping;
        }

        /// <summary>
        /// Obtiene los envios por transportadora
        /// </summary>
        /// <param name="carrierId">Identificador de la transportadora</param>
        /// <returns></returns>
        public IEnumerable<Shipment> GetShipments(int carrierId)
        {

            //var prueba = _iDbShipping.ShipmentEvent.GetAll();
            var prueba = _iDbShipping.ShipmentEvent.Get(null, null, "Shipment");

            //var prueba3 = _iDbShipping.CarrierService.Get(null, null, "Shipment");

            //var prueba2 = _iDbShipping.Shipment.Get(null, null, "ShipmentEvent");



            return _iDbShipping.Shipment.Get(x => x.Tracking != null
                                            && x.StateId != null
                                            && x.StateId >= (int)Enumerators.ShippingStates.WaitPickup
                                            && x.StateId <= (int)Enumerators.ShippingStates.CastIn
                                            && x.CreateAt > DateTime.Now.AddMonths(-1)
                                            && x.CarrierService.Carrier.CarrierId == carrierId
                                            , null, "CarrierService");
        }

        public IEnumerable<ShipmentState> GetShippingStates()
        {
            return _iDbShipping.ShipmentState.Get(x => x.Active, null, "");
        }

        public async Task<IEnumerable<Shipment>> ProcessShippments(Carrier carrier, List<Shipment> shippments, List<ShipmentState> listShipmentState)
        {
            return await _iWebShippingServices.ProcessStatusServicesWeb(carrier, shippments, listShipmentState);
        }

        public bool SaveStatusShippments(List<Shipment> shipments)
        {
            try
            {
                //Actualizar estados en bd
                foreach (Shipment shipment in shipments)
                {
                    _iDbShipping.Shipment.Update(shipment);
                }

                //_iDbShipping.Shipment.UpdateRange(shipments);
            }
            catch (Exception ex)
            {

                throw;
            }


            return true;
        }
    }
}
