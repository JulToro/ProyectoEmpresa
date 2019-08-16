using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.FactoryServices.Interfaces
{
    public interface ISoapServices
    {
        bool CreateConnection();
        bool SendXML();

    }
}
