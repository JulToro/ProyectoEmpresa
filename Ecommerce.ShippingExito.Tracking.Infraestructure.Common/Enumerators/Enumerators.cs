using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.Common.Enumerators
{
    public static class Enumerators
    {
        public enum ShippingStates
        {
            WaitPickup = 1,
            CastIn = 5
        }

        public enum EnumCarriers
        {
            Envia,
            Coordinadora
        }
    }
}
