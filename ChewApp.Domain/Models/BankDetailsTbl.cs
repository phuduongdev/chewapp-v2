﻿namespace ChewApp.Domain.Models {

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BankDetailsTbl")]
    public partial class BankDetailsTbl {
        public int ID { get; set; }

        public int? UserID { get; set; }

        [StringLength(255)]
        public string BankName { get; set; }

        [StringLength(255)]
        public string AccountName { get; set; }

        [StringLength(255)]
        public string AccountNumber { get; set; }

        [StringLength(255)]
        public string PayNowNumber { get; set; }
    }
}
