using Ecommerce.ShippingExito.Tracking.Domain.Repositories;
using Ecommerce.ShippingExito.Tracking.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ShippingExito.Tracking.Domain.Services
{
    public class CarrierServices : ICarrierServices
    {
        private readonly IDbShipping _iDbShipping;
        

        public CarrierServices(IDbShipping iDbShipping)
        {
            _iDbShipping = iDbShipping;
            
        }

        /// <summary>
        /// Obtiene las transportadoras activas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Carrier> GetCarriers()
        {
            return _iDbShipping.Carrier.Get(x => x.Active, null, "");
        }


    }
}
