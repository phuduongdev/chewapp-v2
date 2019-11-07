namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KeeChewPlaceOrderTbl")]
    public partial class KeeChewPlaceOrderTbl
    {
        public long ID { get; set; }

        public long? KeeChewID { get; set; }

        public long? SoonChewID { get; set; }

        [StringLength(500)]
        public string KeeChewName { get; set; }

        [StringLength(500)]
        public string SoonChewName { get; set; }

        [StringLength(500)]
        public string OrderLocation { get; set; }

        [StringLength(500)]
        public string DeliveryLocation { get; set; }

        public long? PaymentMethodID { get; set; }

        [StringLength(500)]
        public string Charge_Object_ID { get; set; }

        [StringLength(500)]
        public string TotalPrice { get; set; }

        [StringLength(500)]
        public string Delivery { get; set; }

        [StringLength(500)]
        public string Delivery_New { get; set; }

        [StringLength(500)]
        public string PlatformFee { get; set; }

        [StringLength(500)]
        public string PromotionCode { get; set; }

        [StringLength(500)]
        public string KCPayment { get; set; }

        [StringLength(500)]
        public string SCPayout { get; set; }

        [StringLength(500)]
        public string Incentive { get; set; }

        [StringLength(500)]
        public string ServicesFee { get; set; }

        public DateTime? DatePlaceOrder { get; set; }

        [StringLength(500)]
        public string LatitudeFrom { get; set; }

        [StringLength(500)]
        public string LongtitudeFrom { get; set; }

        [StringLength(500)]
        public string LatitudeTo { get; set; }

        [StringLength(500)]
        public string LongtitudeTo { get; set; }

        public DateTime? TimeCreateOrder { get; set; }

        public DateTime? DatePriceAccepted { get; set; }

        public DateTime? DateAcceptedKC { get; set; }

        public DateTime? SCOnDateTime { get; set; }

        public DateTime? SCCancelKCDateTime { get; set; }

        [StringLength(255)]
        public string BuildingName { get; set; }

        [StringLength(255)]
        public string CardNumber { get; set; }

        [StringLength(500)]
        public string CreditCard { get; set; }

        public int? Status { get; set; }

        [StringLength(500)]
        public string Display_Status { get; set; }
    }
}
