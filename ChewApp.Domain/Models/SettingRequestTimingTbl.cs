namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SettingRequestTimingTbl")]
    public partial class SettingRequestTimingTbl
    {
        public int ID { get; set; }

        public DateTime? EffectDate { get; set; }

        public double? Seconds { get; set; }
    }
}
