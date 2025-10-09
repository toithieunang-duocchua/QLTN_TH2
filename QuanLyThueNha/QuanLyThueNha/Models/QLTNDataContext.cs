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
