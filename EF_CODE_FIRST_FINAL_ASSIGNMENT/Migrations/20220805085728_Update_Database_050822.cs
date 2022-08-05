using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Migrations
{
    public partial class Update_Database_050822 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_DongSP_IdDongSp",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_MauSac_IdMauSac",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_Nsx_IdNsx",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_SanPham_IdSp",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_ChucVu_IdCv",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_CuaHang_IdCh",
                table: "NhanVien");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCv",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCh",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNv",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKh",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNv",
                table: "GioHang",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKh",
                table: "GioHang",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongTon",
                table: "ChiTietSP",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSp",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNsx",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdMauSac",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdDongSp",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_DongSP_IdDongSp",
                table: "ChiTietSP",
                column: "IdDongSp",
                principalTable: "DongSP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_MauSac_IdMauSac",
                table: "ChiTietSP",
                column: "IdMauSac",
                principalTable: "MauSac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_Nsx_IdNsx",
                table: "ChiTietSP",
                column: "IdNsx",
                principalTable: "Nsx",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_SanPham_IdSp",
                table: "ChiTietSP",
                column: "IdSp",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_ChucVu_IdCv",
                table: "NhanVien",
                column: "IdCv",
                principalTable: "ChucVu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_CuaHang_IdCh",
                table: "NhanVien",
                column: "IdCh",
                principalTable: "CuaHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_DongSP_IdDongSp",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_MauSac_IdMauSac",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_Nsx_IdNsx",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_SanPham_IdSp",
                table: "ChiTietSP");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_ChucVu_IdCv",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_CuaHang_IdCh",
                table: "NhanVien");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCv",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCh",
                table: "NhanVien",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNv",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKh",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNv",
                table: "GioHang",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKh",
                table: "GioHang",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoLuongTon",
                table: "ChiTietSP",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSp",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNsx",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdMauSac",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdDongSp",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_DongSP_IdDongSp",
                table: "ChiTietSP",
                column: "IdDongSp",
                principalTable: "DongSP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_MauSac_IdMauSac",
                table: "ChiTietSP",
                column: "IdMauSac",
                principalTable: "MauSac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_Nsx_IdNsx",
                table: "ChiTietSP",
                column: "IdNsx",
                principalTable: "Nsx",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_SanPham_IdSp",
                table: "ChiTietSP",
                column: "IdSp",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_ChucVu_IdCv",
                table: "NhanVien",
                column: "IdCv",
                principalTable: "ChucVu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_CuaHang_IdCh",
                table: "NhanVien",
                column: "IdCh",
                principalTable: "CuaHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
