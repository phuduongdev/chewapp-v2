namespace ChewApp.Domain.Models {

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PromotionTbl")]
    public partial class PromotionTbl {
        public long ID { get; set; }

        public DateTime? DateCreate { get; set; }

        [StringLength(500)]
        public string Code { get; set; }

        [StringLength(500)]
        public string Amount { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTill { get; set; }

        [StringLength(500)]
        public string Usage { get; set; }

        [StringLength(500)]
        public string MaxLimit { get; set; }

        public int? Times { get; set; }
    }
}
