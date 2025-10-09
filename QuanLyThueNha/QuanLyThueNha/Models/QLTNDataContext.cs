using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace QuanLyThueNha.Models
{
    public class QLTNDataContext : DbContext
    {
        public DbSet<Cannha> Buildings { get; set; }
        public DbSet<Phong> Rooms { get; set; }
        public DbSet<loaiphong> RoomType { get; set; }
        public DbSet<nguoithue> Tenants { get; set; }

        //public DbSet<Contract> Contracts { get; set; }
        //public DbSet<ResidentDetail> ResidentDetails { get; set; }
        //public DbSet<VehicleInfo> VehicleInfos { get; set; }
        //public DbSet<Pet> Pets { get; set; }
        //public DbSet<FingerprintInfo> FingerprintInfos { get; set; }
        //public DbSet<ElectricMeter> ElectricMeters { get; set; }
        //public DbSet<WaterMeter> WaterMeters { get; set; }
        //public DbSet<Setting> Settings { get; set; }
        //public DbSet<FeeNotice> FeeNotices { get; set; }
        //public DbSet<FeeNoticeDetail> FeeNoticeDetails { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        //public DbSet<AdditionalCost> AdditionalCosts { get; set; }
        //public DbSet<UserAccount> UserAccounts { get; set; }
        //public DbSet<ActivityLog> ActivityLogs { get; set; }
        //public DbSet<SystemNotification> SystemNotifications { get; set; }
        //public DbSet<SystemSetting> SystemSettings { get; set; }
        //public DbSet<RentHistory> RentHistories { get; set; }
        //public DbSet<Attachment> Attachments { get; set; }
        //public DbSet<BackupFile> BackupFiles { get; set; }
        //public DbSet<Recipient> Recipients { get; set; }
        //public DbSet<NotificationHistory> NotificationHistories { get; set; }
        //public DbSet<NotificationTemplate> NotificationTemplates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Conn.Instance.Connect);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cannha>().ToTable("Cannha");
            modelBuilder.Entity<Phong>().ToTable("phong");
            modelBuilder.Entity <loaiphong>().ToTable("loaiphong");
            modelBuilder.Entity<nguoithue>().ToTable("nguoithue");

        }


    }
}
