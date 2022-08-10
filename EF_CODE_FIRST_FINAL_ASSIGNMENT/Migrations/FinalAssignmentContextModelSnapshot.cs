﻿// <auto-generated />
using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Migrations
{
    [DbContext(typeof(FinalAssignmentContext))]
    partial class FinalAssignmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.ChiTietSp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GiaBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(20,0)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("GiaNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(20,0)")
                        .HasDefaultValue(0m);

                    b.Property<Guid?>("IdDongSp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdMauSac")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdNsx")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdSp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NamBh")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDongSp");

                    b.HasIndex("IdMauSac");

                    b.HasIndex("IdNsx");

                    b.HasIndex("IdSp");

                    b.ToTable("ChiTietSP");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.ChucVu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Ma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Ten")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.CuaHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ma")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("QuocGia")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ten")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ThanhPho")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CuaHang");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.DongSp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Ma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Ten")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("DongSP");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.GioHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdKh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdNv")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KhachHangId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("NhanVienId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiNhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TinhTrang")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KhachHangId");

                    b.HasIndex("NhanVienId");

                    b.ToTable("GioHang");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.GioHangChiTiet", b =>
                {
                    b.Property<Guid>("IdGioHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdChiTietSp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DonGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(20,0)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("DonGiaKhiGiam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(20,0)")
                        .HasDefaultValue(0m);

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("IdGioHang", "IdChiTietSp");

                    b.HasIndex("IdChiTietSp");

                    b.ToTable("GioHangChiTiet");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.HoaDon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("IdKh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdNv")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime>("NgayNhan")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("NgayShip")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("DATE");

                    b.Property<string>("Sdt")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("TenNguoiNhan")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TinhTrang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("IdKh");

                    b.HasIndex("IdNv");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.HoaDonChiTiet", b =>
                {
                    b.Property<Guid>("IdHoaDon")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdChiTietSp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DonGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(20,0)")
                        .HasDefaultValue(0m);

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("IdHoaDon", "IdChiTietSp");

                    b.HasIndex("IdChiTietSp");

                    b.ToTable("HoaDonChiTiet");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.KhachHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ho")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Ma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("DATE");

                    b.Property<string>("QuocGia")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sdt")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Ten")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TenDem")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ThanhPho")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.MauSac", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Ma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Ten")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("MauSac");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.NhanVien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GioiTinh")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Ho")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid?>("IdCh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdCv")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdGuiBc")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("DATE");

                    b.Property<string>("Sdt")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Ten")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TenDem")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TrangThai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("IdCh");

                    b.HasIndex("IdCv");

                    b.HasIndex("IdGuiBc");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.Nsx", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Ma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Ten")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Nsx");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Ma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Ten")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.ChiTietSp", b =>
                {
                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.DongSp", "DongSp")
                        .WithMany("ChiTietSps")
                        .HasForeignKey("IdDongSp");

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.MauSac", "MauSac")
                        .WithMany("ChiTietSps")
                        .HasForeignKey("IdMauSac");

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.Nsx", "Nsx")
                        .WithMany("ChiTietSps")
                        .HasForeignKey("IdNsx");

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.SanPham", "SanPham")
                        .WithMany("ChiTietSps")
                        .HasForeignKey("IdSp");

                    b.Navigation("DongSp");

                    b.Navigation("MauSac");

                    b.Navigation("Nsx");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.GioHang", b =>
                {
                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.KhachHang", "KhachHang")
                        .WithMany("GioHangs")
                        .HasForeignKey("KhachHangId");

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.NhanVien", "NhanVien")
                        .WithMany("GioHangs")
                        .HasForeignKey("NhanVienId");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.GioHangChiTiet", b =>
                {
                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.ChiTietSp", "ChiTietSp")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdChiTietSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.GioHang", "GioHang")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdGioHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChiTietSp");

                    b.Navigation("GioHang");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.HoaDon", b =>
                {
                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.KhachHang", "KhachHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdKh");

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.NhanVien", "NhanVien")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdNv");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.HoaDonChiTiet", b =>
                {
                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.ChiTietSp", "ChiTietSp")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdChiTietSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.HoaDon", "HoaDon")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdHoaDon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChiTietSp");

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.NhanVien", b =>
                {
                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.CuaHang", "CuaHang")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdCh");

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.ChucVu", "ChucVu")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdCv");

                    b.HasOne("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.NhanVien", "Nhan_Vien")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdGuiBc");

                    b.Navigation("ChucVu");

                    b.Navigation("CuaHang");

                    b.Navigation("Nhan_Vien");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.ChiTietSp", b =>
                {
                    b.Navigation("GioHangChiTiets");

                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.ChucVu", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.CuaHang", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.DongSp", b =>
                {
                    b.Navigation("ChiTietSps");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.GioHang", b =>
                {
                    b.Navigation("GioHangChiTiets");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.KhachHang", b =>
                {
                    b.Navigation("GioHangs");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.MauSac", b =>
                {
                    b.Navigation("ChiTietSps");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.NhanVien", b =>
                {
                    b.Navigation("GioHangs");

                    b.Navigation("HoaDons");

                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.Nsx", b =>
                {
                    b.Navigation("ChiTietSps");
                });

            modelBuilder.Entity("EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass.SanPham", b =>
                {
                    b.Navigation("ChiTietSps");
                });
#pragma warning restore 612, 618
        }
    }
}
