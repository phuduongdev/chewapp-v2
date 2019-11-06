namespace ChewApp.Domain.Models {

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SettingDistanceTbl")]
    public partial class SettingDistanceTbl {
        public int ID { get; set; }

        public DateTime? EffectDate { get; set; }

        [StringLength(500)]
        public string OrderDistance { get; set; }
    }
}
