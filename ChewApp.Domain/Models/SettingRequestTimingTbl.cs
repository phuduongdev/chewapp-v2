namespace ChewApp.Domain.Models {

    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SettingRequestTimingTbl")]
    public partial class SettingRequestTimingTbl {
        public int ID { get; set; }

        public DateTime? EffectDate { get; set; }

        public double? Seconds { get; set; }
    }
}
