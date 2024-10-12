using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinkyShop.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuocGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nsx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nsx", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayShip = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<int>(type: "int", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "DongSp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNsx = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DongSp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DongSp_Nsx_IdNsx",
                        column: x => x.IdNsx,
                        principalTable: "Nsx",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDongSp = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_DongSp_IdDongSp",
                        column: x => x.IdDongSp,
                        principalTable: "DongSp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSp = table.Column<int>(type: "int", nullable: false),
                    IdMauSac = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSp_MauSac_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSac",
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
                    IdHoaDon = table.Column<int>(type: "int", nullable: false),
                    IdChiTietSp = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                table: "MauSac",
                columns: new[] { "Id", "Ten" },
                values: new object[,]
                {
                    { 1, "Đỏ" },
                    { 2, "Vàng" },
                    { 3, "Tím" },
                    { 4, "Trắng" },
                    { 5, "Đen" }
                });

            migrationBuilder.InsertData(
                table: "Nsx",
                columns: new[] { "Id", "Ten" },
                values: new object[] { 1, "Apple" });

            migrationBuilder.InsertData(
                table: "DongSp",
                columns: new[] { "Id", "IdNsx", "Ten" },
                values: new object[] { 1, 1, "Iphone" });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "Id", "IdDongSp", "Ten" },
                values: new object[] { 1, 1, "Iphone 13 Promax" });

            migrationBuilder.InsertData(
                table: "ChiTietSp",
                columns: new[] { "Id", "Anh", "GiaBan", "GiaNhap", "IdMauSac", "IdSp", "MoTa", "SoLuongTon" },
                values: new object[,]
                {
                    { 1, "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg", 100000m, 800000m, 1, 1, "", 50 },
                    { 2, "https://cdn.tgdd.vn/Products/Images/42/230529/TimerThumb/iphone-13-pro-max-(18).jpg", 500000m, 100000m, 2, 1, "", 50 },
                    { 3, "https://cdn.tgdd.vn/Products/Images/42/251703/oppo-a95-4g-bac-2-600x600.jpg", 400000m, 200000m, 3, 1, "", 50 },
                    { 4, "https://cdn.tgdd.vn/Products/Images/42/253402/realme-c21-y-blue-600x600.jpg", 250000m, 950000m, 4, 1, "", 50 },
                    { 5, "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg", 900000m, 100000m, 5, 1, "", 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdMauSac",
                table: "ChiTietSp",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSp_IdSp",
                table: "ChiTietSp",
                column: "IdSp");

            migrationBuilder.CreateIndex(
                name: "IX_DongSp_IdNsx",
                table: "DongSp",
                column: "IdNsx");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdKh",
                table: "HoaDon",
                column: "IdKh");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IdChiTietSp",
                table: "HoaDonChiTiet",
                column: "IdChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdDongSp",
                table: "SanPham",
                column: "IdDongSp");
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
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "DongSp");

            migrationBuilder.DropTable(
                name: "Nsx");
        }
    }
}
