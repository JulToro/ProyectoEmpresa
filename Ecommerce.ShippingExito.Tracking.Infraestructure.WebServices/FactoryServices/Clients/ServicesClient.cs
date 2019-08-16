using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Carriers;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Interfaces;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.ShippingExito.Tracking.Infraestructure.Common.Enumerators.Enumerators;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Clients
{
    public class ServicesClient
    {
        private IRestServices _iRestServices;
        private ISoapServices _iSoapServices;
        ICarrierServiceWeb _iCarrierServiceWeb;

        public ServicesClient(IServiceWebFactory iServiceWebFactory, Carrier carrier, List<Shipment> shipments, List<ShipmentState> listShipmentState)
        {
            _iRestServices = iServiceWebFactory.GetRestService();
            _iSoapServices = iServiceWebFactory.GetSoapService();
            SetCarrier(carrier, shipments, listShipmentState);
        }

        /// <summary>
        /// Metodo encargado de iniciar el proceso de verificacion de estados de los envios
        /// </summary>
        /// <returns>Retorna una lista actualizada con los estados de los envíos</returns>
        public async Task<IEnumerable<Shipment>> ProcessShippment()
        {
            List<Shipment> shipments = new List<Shipment>();
            try
            {
                bool resp = _iCarrierServiceWeb.CreateEntityResource();
                if (resp)
                {
                    var statusShipments = await _iCarrierServiceWeb.GetShippingStatus();
                    shipments = statusShipments.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return shipments;
        }

        /// <summary>
        /// Metodo encargado de crear las instanacias de los clientes que se van a consumir
        /// dentro de sus parametros ingresa la información del transportista y la lista de pedidos
        /// </summary>
        /// <param name="carrier"></param>
        /// <param name="shippments"></param>
        private void SetCarrier(Carrier carrier, List<Shipment> shippments, List<ShipmentState> listShipmentState)
        {
            if (carrier.Name.ToString().ToUpper() == "COORDINADORA")
            {
                _iCarrierServiceWeb = new CoordinadoraSoap(_iSoapServices, shippments, listShipmentState);
                return;
            }
            if (carrier.Name.ToString().ToUpper() == "ENVIA")
            {
                _iCarrierServiceWeb = new EnviaSoap(_iSoapServices, shippments);
                return;
            }
            if (carrier.Name.ToString() == "pruebaRest")
            {
                _iCarrierServiceWeb = new PruebaRest();
            }
        }

    }
}
