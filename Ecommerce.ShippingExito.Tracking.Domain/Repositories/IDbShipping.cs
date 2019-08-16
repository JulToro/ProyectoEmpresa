using Ecommerce.ShippingExito.Tracking.Domain.UnitOfWork;
using Ecommerce.ShippingExito.Tracking.DomainEntities;
using System;

namespace Ecommerce.ShippingExito.Tracking.Domain.Repositories
{
    public interface IDbShipping:  IUnitOfWork, IDisposable
    {
       
        /// <summary>
        /// Información de transportadoras.
        /// </summary>
        IRepository<Carrier> Carrier { get; }

        IRepository<Shipment> Shipment { get; }

        IRepository<ShipmentEvent> ShipmentEvent { get; }

        IRepository<CarrierService> CarrierService { get; }

        /// <summary>
        /// Información de estados de envíos
        /// </summary>
        IRepository<ShipmentState> ShipmentState { get; }

    }
}
