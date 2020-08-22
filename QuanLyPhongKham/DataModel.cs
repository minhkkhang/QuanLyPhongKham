namespace QuanLyPhongKham
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Benh> Benhs { get; set; }
        public virtual DbSet<BenhNhan> BenhNhans { get; set; }
        public virtual DbSet<LuotKham> LuotKhams { get; set; }
        public virtual DbSet<LuotThuoc> LuotThuocs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Thuoc> Thuocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benh>()
                .HasMany(e => e.LuotKhams)
                .WithOptional(e => e.Benh1)
                .HasForeignKey(e => e.Benh);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<BenhNhan>()
                .HasMany(e => e.LuotKhams)
                .WithOptional(e => e.BenhNhan1)
                .HasForeignKey(e => e.BenhNhan);

            modelBuilder.Entity<LuotKham>()
                .Property(e => e.BenhNhan)
                .IsUnicode(false);

            modelBuilder.Entity<LuotKham>()
                .Property(e => e.NgayKham)
                .IsUnicode(false);

            modelBuilder.Entity<LuotKham>()
                .HasMany(e => e.LuotThuocs)
                .WithOptional(e => e.LuotKham1)
                .HasForeignKey(e => e.LuotKham);

            modelBuilder.Entity<Thuoc>()
                .HasMany(e => e.LuotThuocs)
                .WithOptional(e => e.Thuoc1)
                .HasForeignKey(e => e.Thuoc);
        }
    }
}
