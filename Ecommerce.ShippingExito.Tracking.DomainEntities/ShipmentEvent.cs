using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.DomainEntities
{
    [Table("shipment_event")]
    public class ShipmentEvent
    {
        [Key]
        [Column("id")]
        public int ShipmentEventId { get; set; }
        [Column("created_at")]
        public DateTime? CreateAt { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("event_date")]
        public DateTime? EventDate { get; set; }
        [Column("details")]
        public string Details { get; set; }
        [Column("shipment_id")]
        public int? ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
       
    }
}
