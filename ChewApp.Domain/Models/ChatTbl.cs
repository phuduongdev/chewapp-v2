namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChatTbl")]
    public partial class ChatTbl
    {
        public long ID { get; set; }

        public long? UserSendID { get; set; }

        public long? UserReceiveID { get; set; }

        public string Msg { get; set; }

        [StringLength(255)]
        public string ImageLink { get; set; }

        public DateTime? DateSend { get; set; }
    }
}
