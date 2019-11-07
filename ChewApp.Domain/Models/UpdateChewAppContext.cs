//namespace ChewApp.Domain.Models {
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class UpdateChewAppContext : DbContext {
//        public UpdateChewAppContext()
//            : base("name=UpdateChewAppContext") {
//        }

//        public virtual DbSet<AdministratorsTbl> AdministratorsTbls { get; set; }
//        public virtual DbSet<AnnouncementTbl> AnnouncementTbls { get; set; }
//        public virtual DbSet<AssignMenuTbl> AssignMenuTbls { get; set; }
//        public virtual DbSet<BalanceTbl> BalanceTbls { get; set; }
//        public virtual DbSet<BankDetailsTbl> BankDetailsTbls { get; set; }
//        public virtual DbSet<BankTbl> BankTbls { get; set; }
//        public virtual DbSet<FoodCategoryTbl> FoodCategoryTbls { get; set; }
//        public virtual DbSet<FoodTbl> FoodTbls { get; set; }
//        public virtual DbSet<KeeChewPlaceOrderDetailTbl> KeeChewPlaceOrderDetailTbls { get; set; }
//        public virtual DbSet<KeeChewPlaceOrderTbl> KeeChewPlaceOrderTbls { get; set; }
//        public virtual DbSet<KeeChewSoonChewHistoryTbl> KeeChewSoonChewHistoryTbls { get; set; }
//        public virtual DbSet<Option1Tbl> Option1Tbl { get; set; }
//        public virtual DbSet<Option2Tbl> Option2Tbl { get; set; }
//        public virtual DbSet<PaymentMethodTbl> PaymentMethodTbls { get; set; }
//        public virtual DbSet<PlatformFeeTbl> PlatformFeeTbls { get; set; }
//        public virtual DbSet<PromotionTbl> PromotionTbls { get; set; }
//        public virtual DbSet<RatingTbl> RatingTbls { get; set; }
//        public virtual DbSet<ReferralListTbl> ReferralListTbls { get; set; }
//        public virtual DbSet<ReferralSettingTbl> ReferralSettingTbls { get; set; }
//        public virtual DbSet<SettingDistanceTbl> SettingDistanceTbls { get; set; }
//        public virtual DbSet<SettingFeeTbl> SettingFeeTbls { get; set; }
//        public virtual DbSet<SettingRequestTimingTbl> SettingRequestTimingTbls { get; set; }
//        public virtual DbSet<UserTbl> UserTbls { get; set; }
//        public virtual DbSet<WithdrawalRequest> WithdrawalRequests { get; set; }
//        public virtual DbSet<BannerTbl> BannerTbls { get; set; }
//        public virtual DbSet<ChatTbl> ChatTbls { get; set; }
//        public virtual DbSet<HelpCenterTbl> HelpCenterTbls { get; set; }
//        public virtual DbSet<TransactionTbl> TransactionTbls { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
//            modelBuilder.Entity<BankTbl>()
//                .Property(e => e.Bank_Name)
//                .IsUnicode(false);

//            modelBuilder.Entity<BankTbl>()
//                .Property(e => e.Bank_Abbreviation)
//                .IsUnicode(false);

//            modelBuilder.Entity<FoodTbl>()
//                .Property(e => e.Price)
//                .IsUnicode(false);

//            modelBuilder.Entity<FoodTbl>()
//                .Property(e => e.Image)
//                .IsUnicode(false);

//            modelBuilder.Entity<PaymentMethodTbl>()
//                .Property(e => e.CardNumber)
//                .IsUnicode(false);

//            modelBuilder.Entity<RatingTbl>()
//                .Property(e => e.Star)
//                .IsUnicode(false);

//            modelBuilder.Entity<RatingTbl>()
//                .Property(e => e.UserRateID)
//                .IsUnicode(false);

//            modelBuilder.Entity<RatingTbl>()
//                .Property(e => e.UserBeRateID)
//                .IsUnicode(false);

//            modelBuilder.Entity<UserTbl>()
//                .Property(e => e.Image)
//                .IsUnicode(false);

//            modelBuilder.Entity<UserTbl>()
//                .Property(e => e.Devices_OS)
//                .IsUnicode(false);
//        }
//    }
//}
