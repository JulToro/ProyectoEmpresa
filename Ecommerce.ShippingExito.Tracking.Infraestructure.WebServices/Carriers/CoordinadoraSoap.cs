
using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.EntitiesDto;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Interfaces;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Interfaces;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Carriers
{
    public class CoordinadoraSoap : ICarrierServiceWeb
    {
        ISoapServices _soapServices;
        string _endpointUrl = string.Empty;
        List<Shipment> _shipmentCoordinadora;
        private List<StatusShippimentDTO> _listSeguimiento = new List<StatusShippimentDTO>();
        List<ShipmentState> _listShipmentState;

        public CoordinadoraSoap(ISoapServices soapServices, List<Shipment> shippments, List<ShipmentState> listShipmentState)
        {
            _soapServices = soapServices;
            _shipmentCoordinadora = shippments;
            _listShipmentState = listShipmentState;
        }

        public bool CreateEntityResource()
        {

            foreach (Shipment shippment in _shipmentCoordinadora)
            {
                AuthCoordinadoraDTO authCoordinadoraDTO = JsonConvert.DeserializeObject<AuthCoordinadoraDTO>(shippment.CarrierService.Carrier.Auth);
                
                Seguimiento_detalladoIn trackingBody = new Seguimiento_detalladoIn
                {
                    codigo_remision = shippment.Tracking,
                    nit = authCoordinadoraDTO.nit,
                    div = authCoordinadoraDTO.division,
                    referencia = shippment.Order,
                    imagen = 0,
                    anexo = 0,
                    apikey = authCoordinadoraDTO.tracking.key,
                    clave = authCoordinadoraDTO.tracking.password
                };

                StatusShippimentDTO statusShippimentDTO = new StatusShippimentDTO
                {
                    Shipment = shippment,
                    Seguimiento_detalladoIn = trackingBody
                };

                _listSeguimiento.Add(statusShippimentDTO);

                if (string.IsNullOrEmpty(_endpointUrl))
                {
                    _endpointUrl = shippment.CarrierService.Carrier.Tracking_endpoint;
                    _endpointUrl = _endpointUrl.Replace("?wsdl", "");
                }
               
            }

            return true;
        }

        /// <summary>
        /// Obtiene el listado de envios con los estados actualizados.
        /// </summary>
        /// <returns>Retorna la lista de estados actualizados</returns>
        public async Task<IEnumerable<Shipment>> GetShippingStatus()
        {
            List<Shipment> shipmentResult = new List<Shipment>();

            try
            {
                var binding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
                EndpointAddress address = new EndpointAddress(_endpointUrl);
                RpcServerSoapManagerPortClient client = new RpcServerSoapManagerPortClient(binding, address);

                foreach (StatusShippimentDTO data in _listSeguimiento)
                {
                    Seguimiento_detalladoResponse detailedTrackingResponse = await client.Seguimiento_detalladoAsync(data.Seguimiento_detalladoIn);
                    if(detailedTrackingResponse != null)
                    {
                        if (detailedTrackingResponse.Seguimiento_detalladoResult.estados != null)
                        {
                            List<Seguimiento_detalle> states = detailedTrackingResponse.Seguimiento_detalladoResult.estados.ToList();
                            List<ShipmentEvent> shipmentEvents = new List<ShipmentEvent>();
                            foreach (Seguimiento_detalle state in states)
                            {
                                int statusCode = Convert.ToInt32(state.codigo);

                                if (statusCode >= 2 && !string.IsNullOrEmpty(state.fecha) && !string.IsNullOrEmpty(state.hora))
                                {
                                    string date = state.fecha + " " + state.hora;
                                    DateTime fullDate = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", null);
                                    shipmentEvents.Add(new ShipmentEvent() { Name = state.descripcion, EventDate = fullDate, ShipmentId = data.Shipment.ShipmentId });
                                }
                            }

                            data.Shipment.StateId = states.Max(q => Convert.ToInt32(q.codigo));
                            data.Shipment.ShipmentEvents = shipmentEvents;
                            shipmentResult.Add(data.Shipment);
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return shipmentResult;
        }

    }
}
