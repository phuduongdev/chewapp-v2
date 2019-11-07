namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReferralSettingTbl")]
    public partial class ReferralSettingTbl
    {
        public int ID { get; set; }

        public DateTime? EffectiveFrom { get; set; }

        public int? Referrer { get; set; }

        public int? ReferredAmount { get; set; }

        public int? ExpiryDays { get; set; }

        public string InviteMessage { get; set; }

        public int? Status { get; set; }
    }
}
