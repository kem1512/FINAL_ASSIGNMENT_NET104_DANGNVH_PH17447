using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinkyShop.Migrations
{
    /// <inheritdoc />
    public partial class Two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", null, "Administrator", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DiaChi", "Discriminator", "Email", "EmailConfirmed", "Ho", "LockoutEnabled", "LockoutEnd", "NgaySinh", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "QuocGia", "Sdt", "SecurityStamp", "Ten", "TenDem", "ThanhPho", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "f567f672-a91b-441e-a928-74299dca0f5a", null, "NguoiDung", "admin@minky.shop", true, null, false, null, null, "ADMIN@MINKY.SHOP", "ADMIN@MINKY.SHOP", "AQAAAAIAAYagAAAAEJHhBUN3Wva2xttpA0NvmN1wKEtAnjd/DtEHHddx5THXZbX4M5PoAWoM0j8mFB6s3Q==", null, false, null, null, "69a409a0-745f-479d-93a7-53a0de58b9f5", null, null, null, false, "admin@minky.shop" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
