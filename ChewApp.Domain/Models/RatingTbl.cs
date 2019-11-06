namespace ChewApp.Domain.Models {

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RatingTbl")]
    public partial class RatingTbl {
        public long ID { get; set; }

        [StringLength(45)]
        public string Star { get; set; }

        public string Feedback { get; set; }

        [StringLength(45)]
        public string UserRateID { get; set; }

        [StringLength(45)]
        public string UserBeRateID { get; set; }

        public long? OrderID { get; set; }

        public int? UserType { get; set; }
    }
}
