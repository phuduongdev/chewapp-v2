using ChewApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChewApp.Service.DTOs
{
    public class HelpCenterDTO
    {
        public long ID { get; set; }

        public string ReportByName { get; set; }

        public string ReportOnName { get; set; }

        public string ConnectionName { get; set; }

        public DateTime? ReportedDate { get; set; }

        public string ReportedIssue { get; set; }

        public int? Status { get; set; }

        public string ContentText { get; set; }

     
    }
}
