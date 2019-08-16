using Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Services
{
    public class TypesServicesWeb : IServiceWebFactory
    {
        public IRestServices GetRestService()
        {
            return new RestService();
        }

        ISoapServices IServiceWebFactory.GetSoapService()
        {
            return new SoapService();
        }
    }
}
