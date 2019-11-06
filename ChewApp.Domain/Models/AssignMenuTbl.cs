namespace ChewApp.Domain.Models {

    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AssignMenuTbl")]
    public partial class AssignMenuTbl {
        public long ID { get; set; }

        public int? AdministratorTbl_ID { get; set; }

        public int? Accounts { get; set; }

        public int? SoonChewHistory { get; set; }

        public int? KeeChewHistory { get; set; }

        public int? Orders { get; set; }

        public int? WithdrawRequests { get; set; }

        public int? PromoCodes { get; set; }

        public int? ReportsStatistics { get; set; }

        public int? Announcement { get; set; }

        public int? ActivateSuspendApp { get; set; }

        public int? GlobalSettings { get; set; }

        public int? ManageAdministrators { get; set; }

        public int? Option1 { get; set; }

        public int? Option2 { get; set; }

        public int? FoodCategory { get; set; }

        public int? FoodManagement { get; set; }

        public int? Bank { get; set; }

        public int? Wallet { get; set; }

        public int? ReferralSetting { get; set; }

        public int? ReferralList { get; set; }
    }
}
