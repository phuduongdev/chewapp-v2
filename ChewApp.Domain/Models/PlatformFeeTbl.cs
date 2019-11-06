namespace ChewApp.Domain.Models {

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlatformFeeTbl")]
    public partial class PlatformFeeTbl {
        public int ID { get; set; }

        public DateTime? EffectDate { get; set; }

        [StringLength(255)]
        public string PlatformFee { get; set; }
    }
}
