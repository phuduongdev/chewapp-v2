namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KeeChewSoonChewHistoryTbl")]
    public partial class KeeChewSoonChewHistoryTbl
    {
        public long ID { get; set; }

        public DateTime? DatePlaceOrder { get; set; }

        public long? SoonChewID { get; set; }

        [StringLength(500)]
        public string SoonChewName { get; set; }

        [StringLength(500)]
        public string StreetName { get; set; }

        [StringLength(500)]
        public string PostalCode { get; set; }

        [StringLength(500)]
        public string Latitude { get; set; }

        [StringLength(500)]
        public string Longtitude { get; set; }

        public long? KeeChewPlaceOrderTbl_ID { get; set; }

        public int? Status { get; set; }

        public long? KeeChewID { get; set; }

        [StringLength(500)]
        public string KeeChewName { get; set; }

        [StringLength(500)]
        public string Destination { get; set; }

        [StringLength(500)]
        public string OrderQTY { get; set; }

        [StringLength(500)]
        public string DeliveryFee { get; set; }
        public long? FootID { get; set; }
    }
}
