using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.Infraestructure.WebServices.EntitiesDto
{
    public class AuthCoordinadoraDTO
    {
        public int id { get; set; }
        public string nit { get; set; }
        public string user { get; set; }
        public int label { get; set; }
        public Pickup pickup { get; set; }
        public string division { get; set; }
        public string password { get; set; }
        public Tracking tracking { get; set; }
        public Notification notification { get; set; }
    }

    public class Pickup
    {
        public string key { get; set; }
        public string password { get; set; }
    }

    public class Tracking
    {
        public string key { get; set; }
        public string password { get; set; }
    }

    public class Notification
    {
        public string email { get; set; }
        public long phone { get; set; }
    }

}
