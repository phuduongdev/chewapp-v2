namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnnouncementTbl")]
    public partial class AnnouncementTbl
    {
        public int ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int? Position { get; set; }

        public int? Status { get; set; }
    }
}
