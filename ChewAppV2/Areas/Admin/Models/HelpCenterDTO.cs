using ChewApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChewAppV2.Areas.Admin.Models
{
    public class HelpCenterDTO
    {
        public long ID { get; set; }

        public UserTbl ReportByID { get; set; }

        public UserTbl ReportOnID { get; set; }

        public KeeChewPlaceOrderTbl ConnectionID { get; set; }

        public DateTime? ReportedDate { get; set; }

        public string ReportedIssue { get; set; }

        public int? Status { get; set; }

        public string ContentText { get; set; }
    }
}