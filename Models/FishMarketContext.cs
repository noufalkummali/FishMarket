using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FishMarketing.Models
{
    public partial class FishMarketContext : DbContext
    {
        //public FishMarketContext()
        //{
        //}

        public FishMarketContext(DbContextOptions<FishMarketContext> options): base(options)
        {
        }

        public virtual DbSet<BoxMark> BoxMarks { get; set; }
        public virtual DbSet<CashFlow> CashFlows { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<FinancialYear> FinancialYears { get; set; }
        public virtual DbSet<FlowMaster> FlowMasters { get; set; }
        public virtual DbSet<Ledger> Ledgers { get; set; }
        public virtual DbSet<LedgerGroup> LedgerGroups { get; set; }
        public virtual DbSet<LoginTable> LoginTables { get; set; }
        public virtual DbSet<MarketAndPurchasePlace> MarketAndPurchasePlaces { get; set; }
        public virtual DbSet<MarketBoxFlow> MarketBoxFlows { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<OpeningBalance> OpeningBalances { get; set; }
        public virtual DbSet<PurchaseBoxFlow> PurchaseBoxFlows { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<UserPrivilege> UserPrivileges { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FishMarket;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoxMark>(entity =>
            {
                entity.ToTable("BoxMark");

                entity.Property(e => e.BoxMarkName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(250);
            });

            modelBuilder.Entity<CashFlow>(entity =>
            {
                entity.ToTable("CashFlow");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.Clogin).HasColumnName("CLogin");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Mlogin).HasColumnName("MLogin");

                entity.Property(e => e.RecievedBy).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Vehicle).HasMaxLength(50);

                entity.Property(e => e.VoucherType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CloginNavigation)
                    .WithMany(p => p.CashFlowCloginNavigations)
                    .HasForeignKey(d => d.Clogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cashflow_LoginTable");

                entity.HasOne(d => d.CrLedger)
                    .WithMany(p => p.CashFlowCrLedgers)
                    .HasForeignKey(d => d.CrLedgerId)
                    .HasConstraintName("FK_Cashflow_CrLedger");

                entity.HasOne(d => d.DrLedger)
                    .WithMany(p => p.CashFlowDrLedgers)
                    .HasForeignKey(d => d.DrLedgerId)
                    .HasConstraintName("FK_Cashflow_DrLedger");

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.CashFlows)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CashFlow_FinancialYear");

                entity.HasOne(d => d.FlowMaster)
                    .WithMany(p => p.CashFlows)
                    .HasForeignKey(d => d.FlowMasterId)
                    .HasConstraintName("FK_CashFlow_FlowMaster");

                entity.HasOne(d => d.MloginNavigation)
                    .WithMany(p => p.CashFlowMloginNavigations)
                    .HasForeignKey(d => d.Mlogin)
                    .HasConstraintName("FK_Cashflow_LoginTable1");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RegNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<FinancialYear>(entity =>
            {
                entity.ToTable("FinancialYear");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartingDate)
                    .HasColumnType("date")
                    .HasColumnName("startingDate");
            });

            modelBuilder.Entity<FlowMaster>(entity =>
            {
                entity.ToTable("FlowMaster");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.CloginId).HasColumnName("CLoginId");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.MloginId).HasColumnName("MLoginId");

                entity.Property(e => e.PurchaseAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Clogin)
                    .WithMany(p => p.FlowMasterClogins)
                    .HasForeignKey(d => d.CloginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FlowMaster_LoginTable");

                entity.HasOne(d => d.Mlogin)
                    .WithMany(p => p.FlowMasterMlogins)
                    .HasForeignKey(d => d.MloginId)
                    .HasConstraintName("FK_FlowMaster_LoginTable1");

                entity.HasOne(d => d.PurchasePlace)
                    .WithMany(p => p.FlowMasters)
                    .HasForeignKey(d => d.PurchasePlaceId)
                    .HasConstraintName("FK_FlowMaster_MarketAndPurchasePlace");
            });

            modelBuilder.Entity<Ledger>(entity =>
            {
                entity.HasKey(e => e.LedgerId);

                entity.ToTable("Ledger");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.LedgerGroup)
                    .WithMany(p => p.Ledgers)
                    .HasForeignKey(d => d.LedgerGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ledger_LedgerGroups");

                entity.HasOne(d => d.MarketOrPurchae)
                    .WithMany(p => p.Ledgers)
                    .HasForeignKey(d => d.MarketOrPurchaeId)
                    .HasConstraintName("FK_Ledger_MarketAndPurchasePlace");
            });

            modelBuilder.Entity<LedgerGroup>(entity =>
            {
                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.DrOrCr)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LoginTable>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("LoginTable");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.LoginType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MarketAndPurchasePlace>(entity =>
            {
                entity.HasKey(e => e.MarketPurchasePlaceId)
                    .HasName("PK_Market");

                entity.ToTable("MarketAndPurchasePlace");

                entity.Property(e => e.MarketPurchasePlaceId).HasColumnName("Market_PurchasePlaceId");

                entity.Property(e => e.Advance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Deposit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Mlogin).HasColumnName("MLogin");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Place).HasMaxLength(100);

                entity.Property(e => e.ProfCommission).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MarketBoxFlow>(entity =>
            {
                entity.ToTable("MarketBoxFlow");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.DriverMobile).HasMaxLength(50);

                entity.Property(e => e.DriverName).HasMaxLength(50);

                entity.Property(e => e.HelperMobile).HasMaxLength(50);

                entity.Property(e => e.HelperName).HasMaxLength(50);

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.VehicleNo).HasMaxLength(50);

                entity.HasOne(d => d.BoxMark)
                    .WithMany(p => p.MarketBoxFlows)
                    .HasForeignKey(d => d.BoxMarkId)
                    .HasConstraintName("FK_MarketBoxFlow_BoxMark");

                entity.HasOne(d => d.FlowMaster)
                    .WithMany(p => p.MarketBoxFlows)
                    .HasForeignKey(d => d.FlowMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketBoxFlow_FlowMaster");

                entity.HasOne(d => d.Market)
                    .WithMany(p => p.MarketBoxFlows)
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketBoxFlow_MarketAndPurchasePlace");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ControllerName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(150);

                //entity.Property(e => e.Type)
                //    .IsRequired()
                //    .HasMaxLength(2);

            });

            modelBuilder.Entity<OpeningBalance>(entity =>
            {
                entity.ToTable("OpeningBalance");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.CloginId).HasColumnName("CLoginId");

                entity.Property(e => e.CrOrDr)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.MloginId).HasColumnName("MLoginId");

                entity.Property(e => e.OpeningBalance1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("OpeningBalance");

                entity.HasOne(d => d.Clogin)
                    .WithMany(p => p.OpeningBalanceClogins)
                    .HasForeignKey(d => d.CloginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpeningBalance_LoginTable");

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.OpeningBalances)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpeningBalance_FinancialYear");

                entity.HasOne(d => d.Ledger)
                    .WithMany(p => p.OpeningBalances)
                    .HasForeignKey(d => d.LedgerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpeningBalance_Ledger");

                entity.HasOne(d => d.Mlogin)
                    .WithMany(p => p.OpeningBalanceMlogins)
                    .HasForeignKey(d => d.MloginId)
                    .HasConstraintName("FK_OpeningBalance_LoginTable1");
            });

            modelBuilder.Entity<PurchaseBoxFlow>(entity =>
            {
                entity.ToTable("PurchaseBoxFlow");

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.DriverMobile).HasMaxLength(50);

                entity.Property(e => e.DriverName).HasMaxLength(50);

                entity.Property(e => e.HelperMobile).HasMaxLength(50);

                entity.Property(e => e.HelperName).HasMaxLength(50);

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.VehicleNumber).HasMaxLength(50);

                entity.HasOne(d => d.BoxMark)
                    .WithMany(p => p.PurchaseBoxFlows)
                    .HasForeignKey(d => d.BoxMarkId)
                    .HasConstraintName("FK_PurchaseBoxFlow_BoxMark");

                entity.HasOne(d => d.FlowMaster)
                    .WithMany(p => p.PurchaseBoxFlows)
                    .HasForeignKey(d => d.FlowMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseBoxFlow_FlowMaster");

                entity.HasOne(d => d.PurchasePlace)
                    .WithMany(p => p.PurchaseBoxFlows)
                    .HasForeignKey(d => d.PurchasePlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseBoxFlow_MarketAndPurchasePlace");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.SettingsId);

                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPrivilege>(entity =>
            {
                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.MloginId).HasColumnName("MLoginId");

                entity.HasOne(d => d.Clogin)
                    .WithMany(p => p.UserPrivilegeClogins)
                    .HasForeignKey(d => d.CloginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPrivileges_LoginTable1");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.UserPrivilegeLogins)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPrivileges_LoginTable");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.UserPrivileges)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPrivileges_Menus");

                entity.HasOne(d => d.Mlogin)
                    .WithMany(p => p.UserPrivilegeMlogins)
                    .HasForeignKey(d => d.MloginId)
                    .HasConstraintName("FK_UserPrivileges_LoginTable2");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Cdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CDate");

                entity.Property(e => e.Clogin).HasColumnName("CLogin");

                entity.Property(e => e.InsuranceExpDate).HasColumnType("date");

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Mlogin).HasColumnName("MLogin");

                entity.Property(e => e.OwnerName).HasMaxLength(150);

                entity.Property(e => e.PolutionExpDate).HasColumnType("date");

                entity.Property(e => e.RcexpDate)
                    .HasColumnType("date")
                    .HasColumnName("RCExpDate");

                entity.Property(e => e.Rcnumber)
                    .HasMaxLength(50)
                    .HasColumnName("RCNumber");

                entity.Property(e => e.VehicleNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
