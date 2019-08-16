using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.ShippingExito.Tracking.DomainEntities
{
    [Table("shipment")]
    public class Shipment
    {
        [Key]
        [Column("id")]
        public int ShipmentId { get; set; }
        [Column("created_at")]
        public DateTime CreateAt { get; set; }
        [Column("last_update")]
        public DateTime? LastUpdate { get; set; }
        [Column("order")]
        public string Order { get; set; }
        [Column("time_limit")]
        public DateTime? TimeLimit { get; set; }
        [Column("pickup")]
        public DateTime? Pickup { get; set; }
        [Column("tracking")]
        public string Tracking { get; set; }
        [Column("address_to")]
        public string AddressTo { get; set; }
        [Column("address_from")]
        public string AddresFrom { get; set; }
        [Column("packages")]
        public string Packages { get; set; }
        [Column("price")]
        public int? Price { get; set; }
        [Column("tax")]
        public float? Tax { get; set; }
        [Column("charge")]
        public float? Charge { get; set; }
        [Column("cost_center")]
        public string CostCenter { get; set; }
        [Column("file_tracking")]
        public string FileTracking { get; set; }
        [Column("file_label")]
        public string FileLabel { get; set; }
        [Column("extra")]
        public string Extra { get; set; }
        [Column("booking_id")]
        public int? BookingId { get; set; }
        [Column("state_id")]
        public int? StateId { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("business_id")]
        public int? BussinessId { get; set; }
        [Column("file_tracking_download")]
        public bool? FileTrackingDonwload { get; set; }
        [Column("file_label_download")]
        public bool? FileLabelDownload { get; set; }
        [Column("service_id")]
        public int? ServiceId { get; set; }
        public CarrierService CarrierService { get; set; }

        public ICollection<ShipmentEvent> ShipmentEvents { get; set; }
     
    }
}
