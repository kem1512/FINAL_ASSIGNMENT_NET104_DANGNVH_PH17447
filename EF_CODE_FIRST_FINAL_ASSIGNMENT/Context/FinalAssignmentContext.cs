using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Configurations;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Context
{
    public class FinalAssignmentContext : DbContext
    {
        public FinalAssignmentContext(DbContextOptions<FinalAssignmentContext> options) : base(options)
        {

        }

        public FinalAssignmentContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=MinkyStore;Persist Security Info=True;User ID=dangnvhph17447;Password=badao1234");
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
