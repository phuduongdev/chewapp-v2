namespace ChewApp.Data.Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministratorsTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FullName = c.String(maxLength: 500),
                        Email = c.String(maxLength: 500),
                        UserName = c.String(maxLength: 500),
                        Password = c.String(),
                        Avatar = c.String(),
                        Status = c.Int(),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AnnouncementTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(),
                        Title = c.String(maxLength: 500),
                        Description = c.String(),
                        Image = c.String(),
                        Position = c.Int(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AssignMenuTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AdministratorTbl_ID = c.Int(),
                        Accounts = c.Int(),
                        SoonChewHistory = c.Int(),
                        KeeChewHistory = c.Int(),
                        Orders = c.Int(),
                        WithdrawRequests = c.Int(),
                        PromoCodes = c.Int(),
                        ReportsStatistics = c.Int(),
                        Announcement = c.Int(),
                        ActivateSuspendApp = c.Int(),
                        GlobalSettings = c.Int(),
                        ManageAdministrators = c.Int(),
                        Option1 = c.Int(),
                        Option2 = c.Int(),
                        FoodCategory = c.Int(),
                        FoodManagement = c.Int(),
                        Bank = c.Int(),
                        Wallet = c.Int(),
                        ReferralSetting = c.Int(),
                        ReferralList = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BalanceTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoonChewID = c.Int(),
                        KeeChewID = c.Int(),
                        KeeChewName = c.String(maxLength: 255),
                        DateBalance = c.DateTime(),
                        Description = c.String(maxLength: 255),
                        Amount = c.Double(),
                        Balance = c.Double(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BankDetailsTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        BankName = c.String(maxLength: 255),
                        AccountName = c.String(maxLength: 255),
                        AccountNumber = c.String(maxLength: 255),
                        PayNowNumber = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BankTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Bank_Name = c.String(maxLength: 50, unicode: false),
                        Bank_Abbreviation = c.String(maxLength: 10, unicode: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ChatTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserSendID = c.Long(),
                        UserReceiveID = c.Long(),
                        Msg = c.String(),
                        ImageLink = c.String(maxLength: 255),
                        DateSend = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FoodCategoryTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 500),
                        CategoryImage = c.String(maxLength: 500),
                        CategoryIndex = c.Int(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FoodTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        Price = c.String(maxLength: 50, unicode: false),
                        Option1 = c.String(),
                        Option2 = c.String(),
                        Image = c.String(maxLength: 500, unicode: false),
                        Option1Tbl_ID = c.Long(),
                        Option2Tbl_ID = c.Long(),
                        KeeChewPlaceOrderTbl_ID = c.Long(),
                        FoodCategoryTbl_ID = c.Long(),
                        FoodCategoryTbl_Name = c.String(maxLength: 255),
                        FoodIndex = c.Int(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KeeChewPlaceOrderDetailTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FoodID = c.Long(),
                        PriceFood = c.String(maxLength: 50),
                        Quantity = c.String(maxLength: 50),
                        Option1 = c.String(),
                        WhatWouldYouLike = c.String(),
                        KeeChewPlaceOrderTbl_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KeeChewPlaceOrderTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        KeeChewID = c.Long(),
                        SoonChewID = c.Long(),
                        KeeChewName = c.String(maxLength: 500),
                        SoonChewName = c.String(maxLength: 500),
                        OrderLocation = c.String(maxLength: 500),
                        DeliveryLocation = c.String(maxLength: 500),
                        PaymentMethodID = c.Long(),
                        Charge_Object_ID = c.String(maxLength: 500),
                        TotalPrice = c.String(maxLength: 500),
                        Delivery = c.String(maxLength: 500),
                        Delivery_New = c.String(maxLength: 500),
                        PlatformFee = c.String(maxLength: 500),
                        PromotionCode = c.String(maxLength: 500),
                        KCPayment = c.String(maxLength: 500),
                        SCPayout = c.String(maxLength: 500),
                        Incentive = c.String(maxLength: 500),
                        ServicesFee = c.String(maxLength: 500),
                        DatePlaceOrder = c.DateTime(),
                        LatitudeFrom = c.String(maxLength: 500),
                        LongtitudeFrom = c.String(maxLength: 500),
                        LatitudeTo = c.String(maxLength: 500),
                        LongtitudeTo = c.String(maxLength: 500),
                        TimeCreateOrder = c.DateTime(),
                        DatePriceAccepted = c.DateTime(),
                        DateAcceptedKC = c.DateTime(),
                        SCOnDateTime = c.DateTime(),
                        SCCancelKCDateTime = c.DateTime(),
                        BuildingName = c.String(maxLength: 255),
                        CardNumber = c.String(maxLength: 255),
                        CreditCard = c.String(maxLength: 500),
                        Status = c.Int(),
                        Display_Status = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KeeChewSoonChewHistoryTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DatePlaceOrder = c.DateTime(),
                        SoonChewID = c.Long(),
                        SoonChewName = c.String(maxLength: 500),
                        StreetName = c.String(maxLength: 500),
                        PostalCode = c.String(maxLength: 500),
                        Latitude = c.String(maxLength: 500),
                        Longtitude = c.String(maxLength: 500),
                        KeeChewPlaceOrderTbl_ID = c.Long(),
                        Status = c.Int(),
                        KeeChewID = c.Long(),
                        KeeChewName = c.String(maxLength: 500),
                        Destination = c.String(maxLength: 500),
                        OrderQTY = c.String(maxLength: 500),
                        DeliveryFee = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Option1Tbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Option2Tbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PaymentMethodTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(),
                        CardNumber = c.String(maxLength: 100, unicode: false),
                        CreditCard = c.String(maxLength: 500),
                        NameCreditCard = c.String(maxLength: 255),
                        Expiry = c.String(maxLength: 255),
                        Description = c.String(),
                        KeeChewPlaceOrderTbl_ID = c.Long(),
                        Card_Stripe_ID = c.String(maxLength: 255),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PlatformFeeTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EffectDate = c.DateTime(),
                        PlatformFee = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PromotionTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DateCreate = c.DateTime(),
                        Code = c.String(maxLength: 500),
                        Amount = c.String(maxLength: 500),
                        ValidFrom = c.DateTime(),
                        ValidTill = c.DateTime(),
                        Usage = c.String(maxLength: 500),
                        MaxLimit = c.String(maxLength: 500),
                        Times = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RatingTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Star = c.String(maxLength: 45, unicode: false),
                        Feedback = c.String(),
                        UserRateID = c.String(maxLength: 45, unicode: false),
                        UserBeRateID = c.String(maxLength: 45, unicode: false),
                        OrderID = c.Long(),
                        UserType = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReferralListTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateReferred = c.DateTime(),
                        Referrer = c.Int(),
                        ReferrerAmount = c.Int(),
                        Referred = c.Int(),
                        ReferredAmount = c.Int(),
                        ExpiryDate = c.DateTime(),
                        DateCompleted1stSCOrder = c.DateTime(),
                        Status = c.Int(),
                        ReferralSetting_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReferralSettingTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EffectiveFrom = c.DateTime(),
                        Referrer = c.Int(),
                        ReferredAmount = c.Int(),
                        ExpiryDays = c.Int(),
                        InviteMessage = c.String(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SettingDistanceTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EffectDate = c.DateTime(),
                        OrderDistance = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SettingFeeTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        EffectDate = c.DateTime(),
                        Fee = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SettingRequestTimingTbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EffectDate = c.DateTime(),
                        Seconds = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransactionTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserSendID = c.Long(),
                        UserReceiveID = c.Long(),
                        PaymentMethod = c.Long(),
                        TotalMoney = c.String(maxLength: 50),
                        DateSend = c.DateTime(),
                        Status = c.Int(),
                        DateReceived = c.DateTime(),
                        DateWithDraw = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserTbl",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FullName = c.String(maxLength: 500),
                        Gender = c.Int(),
                        Email = c.String(maxLength: 500),
                        Phone = c.String(maxLength: 500),
                        Address = c.String(),
                        UserName = c.String(maxLength: 500),
                        Password = c.String(maxLength: 500),
                        StarTotalSC = c.Double(),
                        StarTotalKC = c.Double(),
                        KeeChew = c.Int(),
                        SoonChew = c.Int(),
                        UserType = c.Int(),
                        UserRole = c.Int(),
                        Image = c.String(maxLength: 500, unicode: false),
                        ResetPasswordCode = c.String(maxLength: 100),
                        DigitCode = c.String(maxLength: 50),
                        RegisteredOn = c.DateTime(),
                        ReferralCode = c.String(maxLength: 500),
                        ReferredBy = c.String(maxLength: 500),
                        TokenDevices = c.String(),
                        KeeChewPlaceOrderTbl_ID = c.Long(),
                        HistorySoonChew_ID = c.Long(),
                        HistoryKeeChew_ID = c.Long(),
                        Latitude = c.String(maxLength: 500),
                        Longitude = c.String(maxLength: 500),
                        TimeOTP = c.DateTime(),
                        TimeOpenApp = c.DateTime(),
                        VerifyCode = c.Int(),
                        StatusEmail = c.Int(),
                        StatusOnline = c.Int(),
                        Status = c.Int(),
                        Customer_Stripe_ID = c.String(maxLength: 255),
                        Devices_OS = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WithdrawalRequest",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DateOfRequest = c.DateTime(),
                        User_ID = c.Long(),
                        Name = c.String(maxLength: 500),
                        Mobile = c.String(maxLength: 500),
                        Email = c.String(maxLength: 500),
                        Amount = c.String(maxLength: 500),
                        Bank = c.String(maxLength: 500),
                        AccountName = c.String(maxLength: 500),
                        AccountNumber = c.String(maxLength: 500),
                        PayNowNumber = c.String(maxLength: 500),
                        Status = c.Long(),
                        StatusChangeDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WithdrawalRequest");
            DropTable("dbo.UserTbl");
            DropTable("dbo.TransactionTbl");
            DropTable("dbo.SettingRequestTimingTbl");
            DropTable("dbo.SettingFeeTbl");
            DropTable("dbo.SettingDistanceTbl");
            DropTable("dbo.ReferralSettingTbl");
            DropTable("dbo.ReferralListTbl");
            DropTable("dbo.RatingTbl");
            DropTable("dbo.PromotionTbl");
            DropTable("dbo.PlatformFeeTbl");
            DropTable("dbo.PaymentMethodTbl");
            DropTable("dbo.Option2Tbl");
            DropTable("dbo.Option1Tbl");
            DropTable("dbo.KeeChewSoonChewHistoryTbl");
            DropTable("dbo.KeeChewPlaceOrderTbl");
            DropTable("dbo.KeeChewPlaceOrderDetailTbl");
            DropTable("dbo.FoodTbl");
            DropTable("dbo.FoodCategoryTbl");
            DropTable("dbo.ChatTbl");
            DropTable("dbo.BankTbl");
            DropTable("dbo.BankDetailsTbl");
            DropTable("dbo.BalanceTbl");
            DropTable("dbo.AssignMenuTbl");
            DropTable("dbo.AnnouncementTbl");
            DropTable("dbo.AdministratorsTbl");
        }
    }
}
