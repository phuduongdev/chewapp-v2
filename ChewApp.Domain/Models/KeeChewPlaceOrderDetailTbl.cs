namespace ChewApp.Domain.Models {

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KeeChewPlaceOrderDetailTbl")]
    public partial class KeeChewPlaceOrderDetailTbl {
        public long ID { get; set; }

        public long? FoodID { get; set; }

        [StringLength(50)]
        public string PriceFood { get; set; }

        [StringLength(50)]
        public string Quantity { get; set; }

        public string Option1 { get; set; }

        public string WhatWouldYouLike { get; set; }

        public long? KeeChewPlaceOrderTbl_ID { get; set; }
    }
}
