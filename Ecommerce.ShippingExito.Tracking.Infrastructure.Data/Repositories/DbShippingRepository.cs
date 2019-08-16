using Ecommerce.ShippingExito.Tracking.Domain.Repositories;
using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Ecommerce.ShippingExito.Tracking.Infrastructure.Data.Context;
using Ecommerce.ShippingExito.Tracking.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.Infrastructure.Data.Repositories
{
    public class DbShippingRepository: UnitOfWork<DBContext>, IDbShipping   
    {
        public DbShippingRepository(DBContext dbContext) : base(dbContext)
        {

        }

        IRepository<Carrier> carriers;
        IRepository<Shipment> shipments;
        IRepository<ShipmentEvent> shipmentEvents;
        IRepository<CarrierService> carrierService;
        IRepository<ShipmentState> shipmentState;

        /// <summary>
        /// Carriers
        /// </summary>
        IRepository<Carrier> IDbShipping.Carrier => carriers ?? (carriers = new Repository<Carrier>(GetDatabase()));

        /// <summary>
        /// Shipments
        /// </summary>
        IRepository<Shipment> IDbShipping.Shipment => shipments ?? (shipments = new Repository<Shipment>(GetDatabase()));

        /// <summary>
        /// ShipmentEvent
        /// </summary>
        IRepository<ShipmentEvent> IDbShipping.ShipmentEvent => shipmentEvents ?? (shipmentEvents = new Repository<ShipmentEvent>(GetDatabase()));

        /// <summary>
        /// CarrierService
        /// </summary>
        IRepository<CarrierService> IDbShipping.CarrierService => carrierService ?? (carrierService = new Repository<CarrierService>(GetDatabase()));

        /// <summary>
        /// ShipmentState
        /// </summary>
        IRepository<ShipmentState> IDbShipping.ShipmentState => shipmentState ?? (shipmentState = new Repository<ShipmentState>(GetDatabase()));

    }
}
