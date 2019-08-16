using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.Utilities
{
    public static class Enumerators
    {
        public enum CoordinatoraServiceStatus
        {
             PRINTED = 0,
             WAIT_PICKUP = 1,
             ORIGIN_CITY = 2,
             TRANSPORT = 3,
             DESTINATION_CITY = 4,
             CAST_IN = 5,
             DELIVERED = 6,
             RETURNED = 7,
             ERRORS = 8,
             NOVELTIES = 9,
             CANCELED = 10
         }
    }
}
