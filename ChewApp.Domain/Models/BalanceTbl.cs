namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BalanceTbl")]
    public partial class BalanceTbl
    {
        public int ID { get; set; }

        public int? SoonChewID { get; set; }

        public int? KeeChewID { get; set; }

        [StringLength(255)]
        public string KeeChewName { get; set; }

        public DateTime? DateBalance { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public double? Amount { get; set; }

        public double? Balance { get; set; }

        public int? Status { get; set; }
    }
}
