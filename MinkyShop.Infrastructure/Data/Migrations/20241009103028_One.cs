using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinkyShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DongSp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DongSp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TenDem = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "DATE", nullable: true),
                    Sdt = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThanhPho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSac",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nsx",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nsx", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    NgayTao = table.Column<DateTime>(type: "DATE", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "DATE", nullable: false),
                    NgayShip = table.Column<DateTime>(type: "DATE", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "DATE", nullable: false),
                    TinhTrang = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sdt = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    TongTien = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKh = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_IdKh",
                        column: x => x.IdKh,
                        principalTable: "KhachHang",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(NEWID())"),
                    MoTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m),
                    GiaBan = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNsx = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDongSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_DongSp_IdDongSp",
                        column: x => x.IdDongSp,
                        principalTable: "DongSp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_MauSac_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_Nsx_IdNsx",
                        column: x => x.IdNsx,
                        principalTable: "Nsx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_SanPham_IdSp",
                        column: x => x.IdSp,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietSp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => new { x.IdHoaDon, x.IdChiTietSp });
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_ChiTietSp_IdChiTietSp",
                        column: x => x.IdChiTietSp,
                        principalTable: "ChiTietSp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DongSp",
                columns: new[] { "Id", "Ten" },
                values: new object[] { new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), "Iphone" });

            migrationBuilder.InsertData(
                table: "MauSac",
                columns: new[] { "Id", "Ten" },
                values: new object[,]
                {
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a2"), "Đỏ" },
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a5"), "Trắng" },
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a6"), "Đen" },
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a8"), "Vàng" },
                    { new Guid("b29ceea6-16a5-4171-9486-621650b569a9"), "Tím" }
                });

            migrationBuilder.InsertData(
                table: "Nsx",
                columns: new[] { "Id", "Ten" },
                values: new object[] { new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), "Apple" });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "Id", "Ten" },
                values: new object[] { new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "Iphone 13 Promax" });

            migrationBuilder.InsertData(
                table: "ChiTietSp",
                columns: new[] { "Id", "Anh", "GiaBan", "GiaNhap", "IdDongSp", "IdMauSac", "IdNsx", "IdSp", "MoTa", "SoLuongTon" },
                values: new object[,]
                {
                    { new Guid("21ea1339-27c9-4008-b49a-792da2ac24b6"), "https://cdn.tgdd.vn/Products/Images/42/253402/realme-c21-y-blue-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a9"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 50 },
                    { new Guid("266ebcec-a9ae-4c5e-9988-b37e522c3d64"), "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a5"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 50 },
                    { new Guid("4541a279-9813-4ce2-bdc2-d5cdca240d13"), "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a2"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 50 },
                    { new Guid("7273e040-d365-4be5-b65e-8da92667f5db"), "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a6"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 50 },
                    { new Guid("b259d5e3-64b1-4276-a7dc-c7953a019bd1"), "https://cdn.tgdd.vn/Products/Images/42/251703/oppo-a95-4g-bac-2-600x600.jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a9"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 50 },
                    { new Guid("d0397c42-9a13-44b0-9a69-34a278d0f3eb"), "https://cdn.tgdd.vn/Products/Images/42/230529/TimerThumb/iphone-13-pro-max-(18).jpg", 200000m, 900000m, new Guid("b29ceea6-16a5-4171-9486-621650b569a1"), new Guid("b29ceea6-16a5-4171-9486-621650b569a8"), new Guid("b29ceea6-16a5-4171-9486-621650b569a3"), new Guid("b29ceea6-16a5-4171-9486-621650b569a4"), "", 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdDongSp",
                table: "ChiTietSp",
                column: "IdDongSp");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdMauSac",
                table: "ChiTietSp",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdNsx",
                table: "ChiTietSp",
                column: "IdNsx");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdSp",
                table: "ChiTietSp",
                column: "IdSp");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdKh",
                table: "HoaDon",
                column: "IdKh");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IdChiTietSp",
                table: "HoaDonChiTiet",
                column: "IdChiTietSp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "ChiTietSp");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "DongSp");

            migrationBuilder.DropTable(
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "Nsx");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
