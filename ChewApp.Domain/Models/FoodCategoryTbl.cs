namespace ChewApp.Domain.Models {

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FoodCategoryTbl")]
    public partial class FoodCategoryTbl {
        public long ID { get; set; }

        [StringLength(500)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string CategoryImage { get; set; }

        public int? CategoryIndex { get; set; }

        public int? Status { get; set; }
    }
}
