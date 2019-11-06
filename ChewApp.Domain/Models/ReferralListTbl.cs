namespace ChewApp.Domain.Models {

    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ReferralListTbl")]
    public partial class ReferralListTbl {
        public int ID { get; set; }

        public DateTime? DateReferred { get; set; }

        public int? Referrer { get; set; }

        public int? ReferrerAmount { get; set; }

        public int? Referred { get; set; }

        public int? ReferredAmount { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime? DateCompleted1stSCOrder { get; set; }

        public int? Status { get; set; }

        public int? ReferralSetting_Id { get; set; }
    }
}
