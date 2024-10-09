namespace MinkyShop.Infrastructure.Common.Extensions
{
    public static class MinkyShopData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DongSp>().HasData(
                new DongSp()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    Ten = "Iphone"
                }
            );
            modelBuilder.Entity<MauSac>().HasData(
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a2"),
                    Ten = "Đỏ"
                },
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a8"),
                    Ten = "Vàng"
                },
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a9"),
                    Ten = "Tím"
                },
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a5"),
                    Ten = "Trắng"
                },
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a6"),
                    Ten = "Đen"
                }
            );
            modelBuilder.Entity<Nsx>().HasData(
                new Nsx()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    Ten = "Apple"
                }
            );
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Ten = "Iphone 13 Promax"
                }
            );
            modelBuilder.Entity<ChiTietSp>().HasData(
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a2"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a8"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/230529/TimerThumb/iphone-13-pro-max-(18).jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a9"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/251703/oppo-a95-4g-bac-2-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a9"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/253402/realme-c21-y-blue-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a5"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a6"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                }
            );
        }
    }
}
