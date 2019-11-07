namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HelpCenterTbl")]
    public partial class HelpCenterTbl
    {
        public long ID { get; set; }

        public long? ReportByID { get; set; }

        public long? ReportOnID { get; set; }

        public long? ConnectionID { get; set; }

        public DateTime? ReportedDate { get; set; }

        public string ReportedIssue { get; set; }

        public int? Status { get; set; }

        public string ContentText { get; set; }
    }
}
