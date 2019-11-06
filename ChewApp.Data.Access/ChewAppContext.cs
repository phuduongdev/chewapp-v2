using ChewApp.Domain.Models;
using System.Data.Entity;

namespace ChewApp.Data.Access {

    public class ChewAppContext : DbContext {

        public ChewAppContext()
            : base("ChewAppContext") {
            // New code:
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AdministratorsTbl> AdministratorsTbls { get; set; }
        public DbSet<AnnouncementTbl> AnnouncementTbls { get; set; }
        public DbSet<AssignMenuTbl> AssignMenuTbls { get; set; }
        public DbSet<BalanceTbl> BalanceTbls { get; set; }
        public DbSet<BankDetailsTbl> BankDetailsTbls { get; set; }
        public DbSet<BankTbl> BankTbls { get; set; }
        public DbSet<FoodCategoryTbl> FoodCategoryTbls { get; set; }
        public DbSet<FoodTbl> FoodTbls { get; set; }
        public DbSet<KeeChewPlaceOrderDetailTbl> KeeChewPlaceOrderDetailTbls { get; set; }
        public DbSet<KeeChewPlaceOrderTbl> KeeChewPlaceOrderTbls { get; set; }
        public DbSet<KeeChewSoonChewHistoryTbl> KeeChewSoonChewHistoryTbls { get; set; }
        public DbSet<Option1Tbl> Option1Tbl { get; set; }
        public DbSet<Option2Tbl> Option2Tbl { get; set; }
        public DbSet<PaymentMethodTbl> PaymentMethodTbls { get; set; }
        public DbSet<PlatformFeeTbl> PlatformFeeTbls { get; set; }
        public DbSet<PromotionTbl> PromotionTbls { get; set; }
        public DbSet<RatingTbl> RatingTbls { get; set; }
        public DbSet<ReferralListTbl> ReferralListTbls { get; set; }
        public DbSet<ReferralSettingTbl> ReferralSettingTbls { get; set; }
        public DbSet<SettingDistanceTbl> SettingDistanceTbls { get; set; }
        public DbSet<SettingFeeTbl> SettingFeeTbls { get; set; }
        public DbSet<SettingRequestTimingTbl> SettingRequestTimingTbls { get; set; }
        public DbSet<UserTbl> UserTbls { get; set; }
        public DbSet<WithdrawalRequest> WithdrawalRequests { get; set; }
        public DbSet<ChatTbl> ChatTbls { get; set; }
        public DbSet<TransactionTbl> TransactionTbls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<BankTbl>()
                .Property(e => e.Bank_Name)
                .IsUnicode(false);

            modelBuilder.Entity<BankTbl>()
                .Property(e => e.Bank_Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTbl>()
                .Property(e => e.Price)
                .IsUnicode(false);

            modelBuilder.Entity<FoodTbl>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentMethodTbl>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<RatingTbl>()
                .Property(e => e.Star)
                .IsUnicode(false);

            modelBuilder.Entity<RatingTbl>()
                .Property(e => e.UserRateID)
                .IsUnicode(false);

            modelBuilder.Entity<RatingTbl>()
                .Property(e => e.UserBeRateID)
                .IsUnicode(false);

            modelBuilder.Entity<UserTbl>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<UserTbl>()
                .Property(e => e.Devices_OS)
                .IsUnicode(false);
        }
    }
}