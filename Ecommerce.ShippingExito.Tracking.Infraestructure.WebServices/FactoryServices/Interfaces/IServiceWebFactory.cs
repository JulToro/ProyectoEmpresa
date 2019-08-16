using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Interfaces
{
    public interface IServiceWebFactory
    {
        IRestServices GetRestService();
        ISoapServices  GetSoapService();
    }
}
