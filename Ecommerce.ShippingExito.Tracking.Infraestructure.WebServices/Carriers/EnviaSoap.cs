using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Interfaces;
using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Carriers
{
    public class EnviaSoap :  ICarrierServiceWeb
    {
        private ISoapServices _iSoapServices;
        private List<Shipment> _shippments;
        private Seguimiento_detalladoIn _body;

        public EnviaSoap(ISoapServices iSoapServices, List<Shipment> shippments) 
        {
            _iSoapServices = iSoapServices;
            _shippments = shippments;
        }

        public bool CreateEntityResource()
        {
            _body = new Seguimiento_detalladoIn();

            _body.codigo_remision = "73810138339";
            _body.nit = "890900608";
            _body.div = "18";
            _body.referencia = "953203182899";
            _body.imagen = 0;
            _body.anexo = 0;
            _body.apikey = "bd24d4ee-634a-11e7-907b-a6006ad3dba0";
            _body.clave = "2fh63EK12h7?77e";

            return true;
        }

        public async Task<IEnumerable<Shipment>> GetShippingStatus()
        {
            try
            {
                var endpointUrl = "http://200.69.100.66/enviawsleec/service1.asmx";
                var binding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
                EndpointAddress address = new EndpointAddress(endpointUrl);
                RpcServerSoapManagerPortClient client1 = new RpcServerSoapManagerPortClient(binding, address);

                foreach (Shipment shipment in _shippments)
                {
                    _body.codigo_remision = shipment.Tracking;
                    _body.nit = "890900608";
                    _body.div = "18";
                    _body.referencia = shipment.Order;
                    _body.imagen = 0;
                    _body.anexo = 0;
                    _body.apikey = "bd24d4ee-634a-11e7-907b-a6006ad3dba0";
                    _body.clave = "2fh63EK12h7?77e";

                    var response = await client1.Seguimiento_detalladoAsync(_body);

                    Seguimiento_detalle[] states = response.Seguimiento_detalladoResult.estados;
                    if (states != null && states.Length > 0)
                    {
                        foreach (Seguimiento_detalle state in states)
                        {

                        }
                    }

                    var json = JsonConvert.SerializeObject(response);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            List<Shipment> listRestul = new List<Shipment>();            

            return listRestul;

        }

        public void XmlEnvia(List<Shipment> shipments)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("file.xml");

            foreach (var item in shipments)
            {

                XmlElement foo = doc.CreateElement("foo");
                XmlElement bar = doc.CreateElement("bar");
                bar.InnerText = "whatever";
                foo.AppendChild(bar);
                doc.DocumentElement.AppendChild(foo);
                doc.Save("file.xml");

            }           

        }

    }
}
