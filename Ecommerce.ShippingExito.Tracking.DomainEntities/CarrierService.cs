using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.DomainEntities
{
    [Table("carrier_service")]
    public class CarrierService
    {
        [Key]
        [Column("id")]
        public int ServiceId { get; set; }
        [Column("carrier_code")]
        public string CarrierCode { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("last_update")]
        public DateTime LastUpdate { get; set; }
        [Column("type")]
        public int? Type { get; set; }
        [Column("min_length")]
        public float MinLength { get; set; }
        [Column("max_length")]
        public float MaxLength { get; set; }
        [Column("min_width")]
        public float MinWidth { get; set; }
        [Column("max_width")]
        public float MaxWidth { get; set; }
        [Column("min_height")]
        public float MinHeight { get; set; }
        [Column("max_height")]
        public float MaxHeight { get; set; }
        [Column("min_weight")]
        public float MinWeight { get; set; }
        [Column("max_weight")]
        public float MaxWeight { get; set; }
        [Column("min_declared")]
        public float MinDeclared { get; set; }
        [Column("max_declared")]
        public float MaxDeclared { get; set; }
        [Column("pick_start")]
        public TimeSpan? PickStart { get; set; }
        [Column("pick_limit")]
        public TimeSpan? PickLimit { get; set; }
        [Column("pick_limit_day")]
        public TimeSpan? PickLimitDay { get; set; }
        [Column("carrier_id")]
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
        public ICollection<Shipment> Shipments{ get; set; }

    }
}
