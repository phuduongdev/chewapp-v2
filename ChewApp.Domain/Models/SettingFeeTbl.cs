namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SettingFeeTbl")]
    public partial class SettingFeeTbl
    {
        public long ID { get; set; }

        public DateTime? EffectDate { get; set; }

        [StringLength(500)]
        public string Fee { get; set; }
    }
}
