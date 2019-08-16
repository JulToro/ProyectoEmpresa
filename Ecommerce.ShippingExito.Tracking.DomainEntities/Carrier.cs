using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.DomainEntities
{
    [Table("carrier")]
    public class Carrier
    {
        [Key]
        [Column("id")]
        public int CarrierId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("picture")]
        public string Picture { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("discount_type")]
        public int Discount_type { get; set; }
        [Column("created_at")]
        public DateTime Created_at { get; set; }
        [Column("last_update")]
        public DateTime Last_update { get; set; }
        [Column("discount")]
        public float Discount { get; set; }
        [Column("commission")]
        public float Commission { get; set; }
        [Column("endpoint")]
        public string Endpoint { get; set; }
        [Column("tracking_endpoint")]
        public string Tracking_endpoint { get; set; }
        [Column("cancel_endpoint")]
        public string Cancel_endpoint { get; set; }
        [Column("pickup_endpoint")]
        public string Pickup_endpoint { get; set; }
        [Column("auth")]
        public string Auth { get; set; }
        [Column("type_endpoint")]
        public bool Type_endpoint { get; set; }
        [Column("conversion")]
        public float Conversion { get; set; }
        [Column("min_tracking")]
        public long Min_tracking { get; set; }
        [Column("max_tracking")]
        public long Max_tracking { get; set; }

        public ICollection<CarrierService> CarrierServices { get; set; }
    }
}
