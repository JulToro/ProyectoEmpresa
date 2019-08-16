using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.DomainEntities
{
    [Table("shipment_state")]
    public class ShipmentState
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("step")]
        public int? Step { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("last_update")]
        public DateTime? LastUpdate { get; set; }
    }
}
