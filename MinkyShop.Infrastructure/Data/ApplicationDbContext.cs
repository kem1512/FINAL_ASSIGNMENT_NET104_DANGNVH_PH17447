using MinkyShop.Infrastructure.Common.Extensions;
using System.Reflection;

namespace MinkyShop.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedData();
        }

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
