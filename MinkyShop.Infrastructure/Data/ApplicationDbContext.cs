using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using MinkyShop.Data.Configurations;
using MinkyShop.Data.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using MinkyShop.Infrastructure.Common.Extensions;

namespace MinkyShop.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChucVuConfiguration());
            modelBuilder.ApplyConfiguration(new CuaHangConfiguration());
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonChiTietConfiguration());
            modelBuilder.ApplyConfiguration(new GioHangChiTietConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new NsxConfiguration());
            modelBuilder.ApplyConfiguration(new MauSacConfiguration());
            modelBuilder.ApplyConfiguration(new DongSpConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietSpConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new GioHangChiTietConfiguration());
            modelBuilder.SeedData();
        }

        public DbSet<ChucVu> ChucVu { get; set; }

        public DbSet<CuaHang> CuaHang { get; set; }

        public DbSet<NhanVien> NhanVien { get; set; }

        public DbSet<KhachHang> KhachHang { get; set; }

        public DbSet<HoaDon> HoaDon { get; set; }

        public DbSet<GioHang> GioHang { get; set; }

        public DbSet<SanPham> SanPham { get; set; }

        public DbSet<Nsx> Nsx { get; set; }

        public DbSet<MauSac> MauSac { get; set; }

        public DbSet<DongSp> DongSp { get; set; }

        public DbSet<ChiTietSp> ChiTietSp { get; set; }

        public DbSet<HoaDonChiTiet> HoaDonChiTiet { get; set; }

        public DbSet<GioHangChiTiet> GioHangChiTiet { get; set; }
    }
}
