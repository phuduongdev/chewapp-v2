namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FoodTbl")]
    public partial class FoodTbl
    {
        public long ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        public string Option1 { get; set; }

        public string Option2 { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public long? Option1Tbl_ID { get; set; }

        public long? Option2Tbl_ID { get; set; }

        public long? KeeChewPlaceOrderTbl_ID { get; set; }

        public long? FoodCategoryTbl_ID { get; set; }

        [StringLength(255)]
        public string FoodCategoryTbl_Name { get; set; }

        public int? FoodIndex { get; set; }

        public int? Status { get; set; }

        public int? Type { get; set; }

        public long? UserID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Payment { get; set; }

        public DateTime? ValidDate { get; set; }

        [StringLength(500)]
        public string From { get; set; }

        [StringLength(500)]
        public string To { get; set; }

        [StringLength(500)]
        public string LatitudeFrom { get; set; }

        [StringLength(500)]
        public string LongtitudeFrom { get; set; }

        [StringLength(500)]
        public string LatitudeTo { get; set; }

        [StringLength(500)]
        public string LongtitudeTo { get; set; }
       

    }
}
