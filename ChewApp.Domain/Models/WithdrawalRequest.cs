namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WithdrawalRequest")]
    public partial class WithdrawalRequest
    {
        public long ID { get; set; }

        public DateTime? DateOfRequest { get; set; }

        public long? User_ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Mobile { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Amount { get; set; }

        [StringLength(500)]
        public string Bank { get; set; }

        [StringLength(500)]
        public string AccountName { get; set; }

        [StringLength(500)]
        public string AccountNumber { get; set; }

        [StringLength(500)]
        public string PayNowNumber { get; set; }

        public long? Status { get; set; }

        public DateTime? StatusChangeDateTime { get; set; }
    }
}
