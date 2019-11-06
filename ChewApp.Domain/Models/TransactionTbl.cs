namespace ChewApp.Domain.Models {

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionTbl")]
    public partial class TransactionTbl {
        public long ID { get; set; }

        public long? UserSendID { get; set; }

        public long? UserReceiveID { get; set; }

        public long? PaymentMethod { get; set; }

        [StringLength(50)]
        public string TotalMoney { get; set; }

        public DateTime? DateSend { get; set; }

        public int? Status { get; set; }

        public DateTime? DateReceived { get; set; }

        public DateTime? DateWithDraw { get; set; }
    }
}
