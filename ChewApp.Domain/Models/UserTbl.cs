namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserTbl")]
    public partial class UserTbl
    {
        public long ID { get; set; }

        [StringLength(500)]
        public string FullName { get; set; }

        public int? Gender { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [StringLength(500)]
        public string UserName { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        public double? StarTotalSC { get; set; }

        public double? StarTotalKC { get; set; }

        public int? KeeChew { get; set; }

        public int? SoonChew { get; set; }

        public int? UserType { get; set; }

        public int? UserRole { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(100)]
        public string ResetPasswordCode { get; set; }

        [StringLength(50)]
        public string DigitCode { get; set; }

        public DateTime? RegisteredOn { get; set; }

        [StringLength(500)]
        public string ReferralCode { get; set; }

        [StringLength(500)]
        public string ReferredBy { get; set; }

        public string TokenDevices { get; set; }

        public long? KeeChewPlaceOrderTbl_ID { get; set; }

        public long? HistorySoonChew_ID { get; set; }

        public long? HistoryKeeChew_ID { get; set; }

        [StringLength(500)]
        public string Latitude { get; set; }

        [StringLength(500)]
        public string Longitude { get; set; }

        public DateTime? TimeOTP { get; set; }

        public DateTime? TimeOpenApp { get; set; }

        public int? VerifyCode { get; set; }

        public int? StatusEmail { get; set; }

        public int? StatusOnline { get; set; }

        public int? Status { get; set; }

        [StringLength(255)]
        public string Customer_Stripe_ID { get; set; }

        [StringLength(10)]
        public string Devices_OS { get; set; }

        [StringLength(500)]
        public string IDGoogle { get; set; }

        [StringLength(500)]
        public string IDFacebook { get; set; }
    }
}
