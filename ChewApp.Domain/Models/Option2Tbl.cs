namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Option2Tbl
    {
        public long ID { get; set; }

        [StringLength(500)]
        public string Name { get; set; }
    }
}
