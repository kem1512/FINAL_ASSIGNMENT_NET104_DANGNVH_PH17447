namespace MinkyShop.Data
{
    public static class MinkyShopData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = "1", Name = "Administrator" });


            modelBuilder.Entity<NguoiDung>().HasData(new NguoiDung()
            {
                Id = "1",
                UserName = "admin@minky.shop",
                Email = "admin@minky.shop",
                NormalizedUserName = "ADMIN@MINKY.SHOP",
                NormalizedEmail = "ADMIN@MINKY.SHOP",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<NguoiDung>().HashPassword(null, "Padaoks_1512"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>() { RoleId = "1", UserId = "1" });

            modelBuilder.Entity<MauSac>().HasData(
                new MauSac { Id = 1, Ten = "Đỏ" },
                new MauSac { Id = 2, Ten = "Vàng" },
                new MauSac { Id = 3, Ten = "Tím" },
                new MauSac { Id = 4, Ten = "Trắng" },
                new MauSac { Id = 5, Ten = "Đen" }
            );

            modelBuilder.Entity<Nsx>().HasData(
                new Nsx
                {
                    Id = 1,
                    Ten = "Apple",
                }
            );

            modelBuilder.Entity<DongSp>().HasData(
                new List<DongSp>
                {
                    new DongSp
                    {
                        Id = 1,
                        IdNsx = 1,
                        Ten = "Iphone",
                    }
                }
            );

            modelBuilder.Entity<SanPham>().HasData(
                new List<SanPham>
                {
                    new SanPham
                    {
                        Id = 1,
                        IdDongSp = 1,
                        Ten = "Iphone 13 Promax",
                    }
                }
            );

            modelBuilder.Entity<ChiTietSp>().HasData(
                new List<ChiTietSp>
                {
                    new ChiTietSp
                    {
                        Id = 1,
                        IdSp = 1,
                        IdMauSac = 1,
                        Anh = "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg",
                        MoTa = "",
                        SoLuongTon = 50,
                        GiaBan = 100000,
                        GiaNhap = 800000,
                    },
                    new ChiTietSp
                    {
                        Id = 2,
                        IdSp = 1,
                        IdMauSac = 2,
                        Anh = "https://cdn.tgdd.vn/Products/Images/42/230529/TimerThumb/iphone-13-pro-max-(18).jpg",
                        MoTa = "",
                        SoLuongTon = 50,
                        GiaBan = 500000,
                        GiaNhap = 100000,
                    },
                    new ChiTietSp
                    {
                        Id = 3,
                        IdSp = 1,
                        IdMauSac = 3,
                        Anh = "https://cdn.tgdd.vn/Products/Images/42/251703/oppo-a95-4g-bac-2-600x600.jpg",
                        MoTa = "",
                        SoLuongTon = 50,
                        GiaBan = 400000,
                        GiaNhap = 200000,
                    },
                    new ChiTietSp
                    {
                        Id = 4,
                        IdSp = 1,
                        IdMauSac = 4,
                        Anh = "https://cdn.tgdd.vn/Products/Images/42/253402/realme-c21-y-blue-600x600.jpg",
                        MoTa = "",
                        SoLuongTon = 50,
                        GiaBan = 250000,
                        GiaNhap = 950000,
                    },
                    new ChiTietSp
                    {
                        Id = 5,
                        IdSp = 1,
                        IdMauSac = 5,
                        Anh = "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg",
                        MoTa = "",
                        SoLuongTon = 50,
                        GiaBan = 900000,
                        GiaNhap = 100000,
                    }
                }
            );
        }
    }
}
