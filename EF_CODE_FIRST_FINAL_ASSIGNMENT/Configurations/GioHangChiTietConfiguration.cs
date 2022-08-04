using System;
using System.Collections.Generic;
using System.Text;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_CODE_FIRST_FINAL_ASSIGNMENT.Configurations
{
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.ToTable("GioHangChiTiet");

            builder.HasKey(c => new { c.IdGioHang, c.IdChiTietSp });

            builder.Property(c => c.DonGia).HasColumnType("DECIMAL(20,0)").HasDefaultValue(0);

            builder.Property(c => c.DonGiaKhiGiam).HasColumnType("DECIMAL(20,0)").HasDefaultValue(0);

            builder.HasOne(c => c.GioHang).WithMany(c => c.GioHangChiTiets).HasForeignKey(c => c.IdGioHang);

            builder.HasOne(c => c.ChiTietSp).WithMany(c => c.GioHangChiTiets).HasForeignKey(c => c.IdChiTietSp);
        }
    }
}
