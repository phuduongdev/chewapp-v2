namespace ChewApp.Domain.Models {

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PaymentMethodTbl")]
    public partial class PaymentMethodTbl {
        public long ID { get; set; }

        public long? UserID { get; set; }

        [StringLength(100)]
        public string CardNumber { get; set; }

        [StringLength(500)]
        public string CreditCard { get; set; }

        [StringLength(255)]
        public string NameCreditCard { get; set; }

        [StringLength(255)]
        public string Expiry { get; set; }

        public string Description { get; set; }

        public long? KeeChewPlaceOrderTbl_ID { get; set; }

        [StringLength(255)]
        public string Card_Stripe_ID { get; set; }

        public int? Status { get; set; }
    }
}
