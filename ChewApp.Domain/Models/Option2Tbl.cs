namespace ChewApp.Domain.Models {

    using System.ComponentModel.DataAnnotations;

    public partial class Option2Tbl {
        public long ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }
    }
}
